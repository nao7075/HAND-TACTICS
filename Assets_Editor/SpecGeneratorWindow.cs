using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SpecGenerator
{
    public class SpecGeneratorWindow : EditorWindow
    {
        private static readonly HashSet<string> MagicMethods = new HashSet<string>
        {
            "Awake", "Start", "Update", "FixedUpdate", "LateUpdate",
            "OnEnable", "OnDisable", "OnDestroy", "OnGUI",
            "OnCollisionEnter", "OnCollisionStay", "OnCollisionExit",
            "OnTriggerEnter", "OnTriggerStay", "OnTriggerExit",
            "OnValidate", "Reset"
        };

        [MenuItem("Tools/Generate Script Specification")]
        public static void ShowWindow()
        {
            GetWindow<SpecGeneratorWindow>("Spec Gen");
        }

        private void OnGUI()
        {
            GUILayout.Label("Script Specification Generator", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            GUILayout.Label("プロジェクト内のスクリプトを解析し、\n複数のHTMLファイル（目次と詳細）を出力します。", EditorStyles.wordWrappedLabel);
            EditorGUILayout.Space();

            if (GUILayout.Button("Generate HTML Report", GUILayout.Height(40)))
            {
                GenerateReport();
            }
        }

        private void GenerateReport()
        {
            var scripts = FindScripts();
            var fileSpecs = new List<FileSpec>();

            try
            {
                for (int i = 0; i < scripts.Count; i++)
                {
                    var monoScript = scripts[i];
                    EditorUtility.DisplayProgressBar("Analyzing Scripts", monoScript.name, (float)i / scripts.Count);
                    
                    var spec = AnalyzeFile(monoScript);
                    if (spec != null)
                    {
                        fileSpecs.Add(spec);
                    }
                }

                // ソート
                fileSpecs = fileSpecs.OrderBy(f => f.AssetPath).ToList();

                // 出力ディレクトリの準備
                string outputDir = Path.Combine(Application.dataPath, "..", "ScriptDocs");
                string filesDir = Path.Combine(outputDir, "files");

                if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
                if (!Directory.Exists(filesDir)) Directory.CreateDirectory(filesDir);

                // 1. CSSファイルの生成
                GenerateCSS(Path.Combine(outputDir, "styles.css"));

                // 2. トップページ(index.html)の生成
                GenerateIndexHtml(fileSpecs, Path.Combine(outputDir, "index.html"));

                // 3. 各詳細ページの生成
                foreach (var file in fileSpecs)
                {
                    GenerateFileDetailHtml(file, filesDir);
                }

                EditorUtility.ClearProgressBar();
                EditorUtility.RevealInFinder(Path.Combine(outputDir, "index.html"));
                Debug.Log($"<color=cyan><b>[SpecGenerator]</b></color> Report generated at: {outputDir}");
            }
            catch (Exception e)
            {
                EditorUtility.ClearProgressBar();
                Debug.LogError($"Generation Failed: {e.Message}\n{e.StackTrace}");
            }
        }

        // --- 解析ロジック (変更なし) ---
        private List<MonoScript> FindScripts()
        {
            var found = new List<MonoScript>();
            string[] guids = AssetDatabase.FindAssets("t:MonoScript");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.StartsWith("Packages") || path.Contains("/Editor/")) continue;
                var script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                if (script != null) found.Add(script);
            }
            return found;
        }

        private FileSpec AnalyzeFile(MonoScript script)
        {
            string sourceCode = script.text;
            if (string.IsNullOrEmpty(sourceCode)) return null;

            var fileSpec = new FileSpec
            {
                FileName = script.name + ".cs",
                AssetPath = AssetDatabase.GetAssetPath(script)
            };

            var lines = sourceCode.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            fileSpec.TotalLines = lines.Length;
            
            foreach (var line in lines)
            {
                string trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed)) fileSpec.EmptyLines++;
                else if (trimmed.StartsWith("//") || trimmed.StartsWith("/*") || trimmed.StartsWith("*")) fileSpec.CommentLines++;
                else fileSpec.CodeLines++;
            }

            Type type = script.GetClass();
            if (type != null)
            {
                var mainClassSpec = AnalyzeClass(type, sourceCode);
                if (mainClassSpec != null) fileSpec.Classes.Add(mainClassSpec);
            }
            return fileSpec;
        }

        private ClassSpec AnalyzeClass(Type type, string sourceCode)
        {
            var docComments = ParseDocComments(sourceCode);
            var spec = new ClassSpec
            {
                ClassName = type.Name,
                Namespace = type.Namespace ?? "(Global)",
                FullName = type.FullName ?? type.Name,
                Description = docComments.ContainsKey(type.Name) ? docComments[type.Name] : "",
                IsMonoBehaviour = type.IsSubclassOf(typeof(MonoBehaviour)),
                TypeCategory = type.IsInterface ? "Interface" : type.IsEnum ? "Enum" : type.IsValueType ? "Struct" : "Class"
            };

            // 継承情報
            var inheritanceList = new List<string>();
            if (type.BaseType != null && type.BaseType != typeof(object) && type.BaseType != typeof(ValueType) && type.BaseType != typeof(Enum))
            {
                inheritanceList.Add(type.BaseType.Name);
            }
            var interfaces = type.GetInterfaces();
            if (type.BaseType != null) interfaces = interfaces.Except(type.BaseType.GetInterfaces()).ToArray();
            var specificInterfaces = new List<Type>();
            foreach (var iface in interfaces)
            {
                if (!interfaces.Any(other => other != iface && iface.IsAssignableFrom(other))) specificInterfaces.Add(iface);
            }
            foreach (var i in specificInterfaces) inheritanceList.Add(i.Name);
            if (inheritanceList.Count > 0) spec.BaseClass = string.Join(", ", inheritanceList);

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static;

            // Fields
            foreach (var field in type.GetFields(flags))
            {
                if (field.Name.Contains("k__BackingField") || field.Name.StartsWith("<") || field.Name.Contains("$") || field.IsDefined(typeof(CompilerGeneratedAttribute), false)) continue;
                
                var tooltips = field.GetCustomAttributes<TooltipAttribute>().Select(t => t.tooltip);
                var headers = field.GetCustomAttributes<HeaderAttribute>().Select(h => h.header);
                var fSpec = new FieldSpec
                {
                    Name = field.Name, Type = field.FieldType.Name, Access = GetAccessModifier(field),
                    Description = docComments.ContainsKey(field.Name) ? docComments[field.Name] : "",
                    Tooltip = string.Join("\n", tooltips), Header = string.Join(" / ", headers), IsStatic = field.IsStatic
                };
                var rangeAttr = field.GetCustomAttributes<RangeAttribute>().FirstOrDefault();
                if (rangeAttr != null) fSpec.Constraint = $"Range({rangeAttr.min}, {rangeAttr.max})";
                var minAttr = field.GetCustomAttributes<MinAttribute>().FirstOrDefault();
                if (minAttr != null) fSpec.Constraint = $"Min({minAttr.min})";
                spec.Fields.Add(fSpec);
            }

            // Properties
            foreach (var prop in type.GetProperties(flags))
            {
                spec.Properties.Add(new PropertySpec {
                    Name = prop.Name, Type = prop.PropertyType.Name, Access = GetAccessModifier(prop),
                    Description = docComments.ContainsKey(prop.Name) ? docComments[prop.Name] : "",
                    IsStatic = (prop.GetMethod?.IsStatic ?? false) || (prop.SetMethod?.IsStatic ?? false),
                    CanRead = prop.CanRead, CanWrite = prop.CanWrite
                });
            }

            // Constructors
            if (!spec.IsMonoBehaviour)
            {
                foreach (var ctor in type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    var ctorDefRegex = new Regex($@"\b(public|protected|private|internal)\s+{Regex.Escape(type.Name)}\s*\(");
                    if (!ctorDefRegex.IsMatch(sourceCode)) continue;
                    spec.Methods.Add(new MethodSpec {
                        Name = type.Name, ReturnType = "", Access = ctor.IsPublic ? "public" : (ctor.IsFamily ? "protected" : "private"),
                        Description = "Constructor", IsConstructor = true, IsStatic = ctor.IsStatic,
                        Parameters = string.Join(", ", ctor.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"))
                    });
                }
            }

            // Methods
            foreach (var method in type.GetMethods(flags))
            {
                if (method.IsSpecialName || method.Name.StartsWith("<") || method.Name.Contains("$") || method.IsDefined(typeof(CompilerGeneratedAttribute), false)) continue;
                if (method.DeclaringType == typeof(object)) continue;
                if ((method.DeclaringType == typeof(MonoBehaviour) || method.DeclaringType == typeof(Behaviour) || method.DeclaringType == typeof(Component) || method.DeclaringType == typeof(UnityEngine.Object)) && !MagicMethods.Contains(method.Name)) continue;

                spec.Methods.Add(new MethodSpec {
                    Name = method.Name, ReturnType = method.ReturnType.Name, Access = GetAccessModifier(method),
                    Description = docComments.ContainsKey(method.Name) ? docComments[method.Name] : (MagicMethods.Contains(method.Name) ? "Unity Event Function" : ""),
                    IsMagic = MagicMethods.Contains(method.Name), IsStatic = method.IsStatic,
                    Parameters = string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"))
                });
            }
            return spec;
        }

        // --- HTML Generation Functions ---

        private void GenerateCSS(string path)
        {
            string css = @"
body { font-family: 'Meiryo', 'Segoe UI', sans-serif; background-color: #f8f9fa; color: #333; margin: 0; padding: 20px; font-size: 13px; }
.container { max-width: 1200px; margin: 0 auto; background: white; padding: 40px; box-shadow: 0 0 15px rgba(0,0,0,0.05); min-height: 100vh; border-radius: 5px; }
h1 { background: linear-gradient(to right, #0044cc, #6699ff); color: white; padding: 15px 20px; margin: -40px -40px 30px -40px; font-size: 22px; border-radius: 5px 5px 0 0; }
.nav-bar { background: #eef2f5; padding: 10px 20px; margin-bottom: 20px; border: 1px solid #ddd; border-radius: 4px; }
.nav-bar a { margin-right: 20px; font-weight: bold; color: #0044cc; text-decoration: none; }
.nav-bar a:hover { text-decoration: underline; }
h2 { border-left: 8px solid #0044cc; border-bottom: 1px solid #ccc; background: linear-gradient(to right, #eef, #fff); padding: 8px 15px; margin-top: 40px; color: #003366; font-size: 16px; }
h3 { background: #f0f4ff; color: #003399; padding: 8px 15px; border-left: 5px solid #4d79ff; margin-top: 30px; font-size: 15px; }
h4 { color: #555; border-bottom: 1px dotted #999; padding-bottom: 5px; margin-top: 25px; font-size: 14px; font-weight:bold; }
table { width: 100%; border-collapse: collapse; margin-bottom: 20px; border: 1px solid #c0c0c0; font-size: 12px; }
th { background: linear-gradient(to bottom, #f0f0f0, #dcdcdc); color: #333; font-weight: bold; padding: 10px; text-align: center; border: 1px solid #a0a0a0; white-space: nowrap; }
td { padding: 8px; border: 1px solid #c0c0c0; vertical-align: top; }
tr:nth-child(even) { background-color: #f8f9fc; }
tr:hover { background-color: #eef5ff; }
.folder-header { background: #dbeafe; color: #1e3a8a; padding: 10px; border-left: 5px solid #2563eb; margin-top: 30px; font-weight: bold; font-size: 14px; }
.header-row td { background-color: #e9ecef; font-weight: bold; color: #495057; padding: 12px 10px 5px 10px; border-bottom: 2px solid #ced4da; font-size:13px; }
a { color: #0056b3; text-decoration: none; } a:hover { text-decoration: underline; color: #d35400; }
.tag { display: inline-block; padding: 2px 6px; border-radius: 3px; font-size: 10px; color: white; margin-right: 5px; vertical-align: middle; }
.tag-cls { background: #2980b9; } .tag-int { background: #8e44ad; } .tag-enum { background: #d35400; } .tag-struct { background: #27ae60; } .tag-magic { background: #16a085; } .tag-static { background: #7f8c8d; } .tag-ctor { background: #e67e22; }
.acc { font-family: monospace; font-size: 10px; padding: 1px 4px; border-radius: 2px; border: 1px solid #ccc; margin-right: 5px; }
.acc-public { background: #e8f5e9; color: #2e7d32; border-color: #a5d6a7; } .acc-protected { background: #fff8e1; color: #f57f17; border-color: #ffe082; } .acc-private { background: #ffebee; color: #c62828; border-color: #ef9a9a; } .acc-internal { background: #e3f2fd; color: #1565c0; border-color: #90caf9; }
.desc-box { padding: 10px; background: #fffcf5; border: 1px solid #e0d8b0; color: #555; margin: 10px 0; border-radius: 3px; }
.tooltip-icon { color: #888; cursor: help; border-bottom: 1px dotted #888; }
.center { text-align: center; }
";
            File.WriteAllText(path, css, Encoding.UTF8);
        }

        private void GenerateIndexHtml(List<FileSpec> files, string path)
        {
            var sb = new StringBuilder();
            var filesByFolder = files.GroupBy(f => Path.GetDirectoryName(f.AssetPath).Replace("\\", "/")).OrderBy(g => g.Key).ToList();
            var allClasses = files.SelectMany(f => f.Classes.Select(c => new { Class = c, File = f })).OrderBy(x => x.Class.Namespace).ThenBy(x => x.Class.ClassName).ToList();

            sb.Append(@"<!DOCTYPE html><html><head><meta charset='UTF-8'><title>プロジェクト仕様書 - 目次</title><link rel='stylesheet' href='styles.css'></head><body><div class='container'>");
            sb.Append($"<h1>プロジェクト仕様書 (Index)</h1>");
            sb.Append($"<div class='nav-bar'><span>Jump to: </span><a href='#folder-summary'>フォルダ一覧</a> <a href='#file-list'>ファイル一覧</a> <a href='#class-list'>クラス索引</a></div>");
            sb.Append($"<div style='text-align:right; font-size:0.8em; margin-bottom:10px; color:#666;'>作成日: {DateTime.Now:yyyy/MM/dd HH:mm}</div>");

            // Folder Summary
            sb.Append("<h2 id='folder-summary'>フォルダ一覧 (概要)</h2><table><thead><tr><th>フォルダ</th><th>ファイル数</th><th>総行数</th><th>コード行数</th><th>クラス数</th></tr></thead><tbody>");
            foreach (var group in filesByFolder) {
                string folderId = "Folder_" + group.Key.Replace("/", "_").Replace(" ", "_").Replace(".", "_");
                sb.Append($"<tr><td style='text-align:left'><a href='#{folderId}'>{group.Key}</a></td><td class='center'>{group.Count()}</td><td class='center'>{group.Sum(f=>f.TotalLines)}</td><td class='center'>{group.Sum(f=>f.CodeLines)}</td><td class='center'>{group.Sum(f=>f.Classes.Count)}</td></tr>");
            }
            sb.Append("</tbody></table>");

            // File List
            sb.Append("<h2 id='file-list'>ファイル一覧</h2>");
            foreach (var group in filesByFolder) {
                string folderId = "Folder_" + group.Key.Replace("/", "_").Replace(" ", "_").Replace(".", "_");
                sb.Append($"<div id='{folderId}' class='folder-header'>Folder: {group.Key}</div>");
                sb.Append("<table><thead><tr><th>ファイル名</th><th>行数</th><th>コード</th><th>コメント</th><th>定義クラス</th></tr></thead><tbody>");
                foreach (var f in group) {
                    string linkUrl = $"files/{GetSafeFileName(f.FileName)}.html";
                    sb.Append($"<tr><td style='font-weight:bold;'><a href='{linkUrl}'>{f.FileName}</a></td><td class='center'>{f.TotalLines}</td><td class='center'>{f.CodeLines}</td><td class='center'>{f.CommentLines}</td><td>");
                    foreach(var c in f.Classes) {
                        string typeTag = c.TypeCategory == "Interface" ? "tag-int" : c.TypeCategory == "Enum" ? "tag-enum" : c.TypeCategory == "Struct" ? "tag-struct" : "tag-cls";
                        sb.Append($"<a href='{linkUrl}#{c.ClassName}' style='color:#555; text-decoration:none; margin-right:5px;'><span class='tag {typeTag}'>{c.TypeCategory[0]}</span>{c.ClassName}</a> ");
                    }
                    sb.Append("</td></tr>");
                }
                sb.Append("</tbody></table>");
            }

            // Class Index
            sb.Append("<h2 id='class-list'>クラス索引</h2><table><thead><tr><th>クラス名</th><th>ファイル</th><th>種類</th><th>名前空間</th><th>説明</th></tr></thead><tbody>");
            foreach (var item in allClasses) {
                string linkUrl = $"files/{GetSafeFileName(item.File.FileName)}.html#{item.Class.ClassName}";
                string fileLink = $"files/{GetSafeFileName(item.File.FileName)}.html";
                string typeTag = item.Class.TypeCategory == "Interface" ? "tag-int" : item.Class.TypeCategory == "Enum" ? "tag-enum" : item.Class.TypeCategory == "Struct" ? "tag-struct" : "tag-cls";
                sb.Append($"<tr><td><a href='{linkUrl}'>{item.Class.ClassName}</a></td><td><a href='{fileLink}' style='color:#555'>{item.File.FileName}</a></td><td class='center'><span class='tag {typeTag}'>{item.Class.TypeCategory}</span></td><td>{item.Class.Namespace}</td><td><span style='color:#666'>{System.Web.HttpUtility.HtmlEncode(item.Class.Description).Split('\n')[0]}</span></td></tr>");
            }
            sb.Append("</tbody></table>");
            sb.Append("</div></body></html>");

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private void GenerateFileDetailHtml(FileSpec file, string dir)
        {
            var sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE html><html><head><meta charset='UTF-8'><title>" + file.FileName + @" - 詳細</title><link rel='stylesheet' href='../styles.css'></head><body><div class='container'>");
            
            // Header
            sb.Append($"<div class='nav-bar'><a href='../index.html'>&lt; トップページへ戻る</a> | <span>File: {file.FileName}</span></div>");
            sb.Append($"<div style='background:#666; color:white; padding:10px 15px; border-radius:5px; margin-bottom:20px;'>File Path: <span style='opacity:0.8'>{file.AssetPath}</span></div>");

            if (file.Classes.Count == 0) sb.Append("<div style='padding:20px; border:1px solid #ccc; background:#fff;'>No classes detected.</div>");

            foreach (var c in file.Classes) {
                string typeTag = c.TypeCategory == "Interface" ? "tag-int" : c.TypeCategory == "Enum" ? "tag-enum" : c.TypeCategory == "Struct" ? "tag-struct" : "tag-cls";
                sb.Append($"<div id='{c.ClassName}' style='border:1px solid #ccc; border-top:none; padding:20px; background:white; margin-bottom:40px; border-radius:5px;'>");
                
                sb.Append($"<h3><span><span class='tag {typeTag}'>{c.TypeCategory}</span> {c.ClassName}");
                if (!string.IsNullOrEmpty(c.BaseClass)) sb.Append($" <span style='color:#7f8c8d; font-weight:normal; font-size:0.9em;'>: {c.BaseClass}</span>");
                sb.Append($"</span><span style='font-size:0.8em; font-weight:normal; color:#666;'>{c.Namespace}</span></h3>");
                
                if (!string.IsNullOrEmpty(c.Description)) sb.Append($"<div class='desc-box'>{System.Web.HttpUtility.HtmlEncode(c.Description).Replace("\n", "<br/>")}</div>");

                if (c.Fields.Count > 0) {
                    sb.Append("<h4>フィールド (Variables)</h4><table><thead><tr><th>アクセス</th><th>名前</th><th>型</th><th>説明</th><th>属性・制約</th></tr></thead><tbody>");
                    foreach (var field in c.Fields) {
                        if (!string.IsNullOrEmpty(field.Header)) sb.Append($"<tr class='header-row'><td colspan='5'>{System.Web.HttpUtility.HtmlEncode(field.Header)}</td></tr>");
                        sb.Append("<tr>");
                        sb.Append($"<td class='center'><span class='acc acc-{field.Access}'>{field.Access}</span></td>");
                        sb.Append($"<td>{(field.IsStatic ? "<span class='tag tag-static'>S</span>" : "")}<b>{field.Name}</b></td>");
                        sb.Append($"<td class='center'><code>{field.Type}</code></td>");
                        string desc = System.Web.HttpUtility.HtmlEncode(field.Description);
                        if (!string.IsNullOrEmpty(field.Tooltip)) desc += $"<br/><span class='tooltip-icon' title='Tooltip'>💡 {System.Web.HttpUtility.HtmlEncode(field.Tooltip)}</span>";
                        sb.Append($"<td>{desc}</td>");
                        string attrs = "";
                        if (!string.IsNullOrEmpty(field.Constraint)) attrs += $"<span style='color:#27ae60'>{field.Constraint}</span>";
                        sb.Append($"<td class='center'>{attrs}</td></tr>");
                    }
                    sb.Append("</tbody></table>");
                }

                if (c.Properties.Count > 0) {
                    sb.Append("<h4>プロパティ (Properties)</h4><table><thead><tr><th>アクセス</th><th>名前</th><th>型</th><th>説明</th></tr></thead><tbody>");
                    foreach (var p in c.Properties) {
                        sb.Append("<tr>");
                        sb.Append($"<td class='center'><span class='acc acc-{p.Access}'>{p.Access}</span></td>");
                        sb.Append($"<td>{(p.IsStatic ? "<span class='tag tag-static'>S</span>" : "")}<b>{p.Name}</b> <span style='font-size:0.8em; color:#888'>{{ {(p.CanRead?"get;":"")} {(p.CanWrite?"set;":"")} }}</span></td>");
                        sb.Append($"<td class='center'><code>{p.Type}</code></td>");
                        sb.Append($"<td>{System.Web.HttpUtility.HtmlEncode(p.Description)}</td></tr>");
                    }
                    sb.Append("</tbody></table>");
                }

                var constructors = c.Methods.Where(m => m.IsConstructor).ToList();
                if (constructors.Count > 0) {
                    sb.Append("<h4>コンストラクタ (Constructors)</h4><table><thead><tr><th>アクセス</th><th>名前</th><th>引数</th><th>説明</th></tr></thead><tbody>");
                    foreach (var m in constructors) {
                        sb.Append("<tr>");
                        sb.Append($"<td class='center'><span class='acc acc-{m.Access}'>{m.Access}</span></td>");
                        sb.Append($"<td>{(m.IsStatic ? "<span class='tag tag-static'>S</span>" : "")}<b>{m.Name}</b></td>");
                        sb.Append($"<td><small>{m.Parameters}</small></td>");
                        sb.Append($"<td>{System.Web.HttpUtility.HtmlEncode(m.Description)}</td></tr>");
                    }
                    sb.Append("</tbody></table>");
                }

                var methods = c.Methods.Where(m => !m.IsConstructor).ToList();
                if (methods.Count > 0) {
                    sb.Append("<h4>メソッド (Methods)</h4><table><thead><tr><th>アクセス</th><th>名前</th><th>引数</th><th>戻り値</th><th>説明</th></tr></thead><tbody>");
                    foreach (var m in methods) {
                        sb.Append("<tr>");
                        sb.Append($"<td class='center'><span class='acc acc-{m.Access}'>{m.Access}</span></td>");
                        sb.Append($"<td>");
                        if (m.IsMagic) sb.Append("<span class='tag tag-magic'>Event</span>");
                        if (m.IsStatic) sb.Append("<span class='tag tag-static'>S</span>");
                        sb.Append($"<b>{m.Name}</b></td>");
                        sb.Append($"<td><small>{m.Parameters}</small></td>");
                        sb.Append($"<td class='center'><code>{m.ReturnType}</code></td>");
                        sb.Append($"<td>{System.Web.HttpUtility.HtmlEncode(m.Description)}</td></tr>");
                    }
                    sb.Append("</tbody></table>");
                }
                sb.Append("</div>"); // End Class Div
            }
            sb.Append("</div></body></html>");

            string fileName = GetSafeFileName(file.FileName) + ".html";
            File.WriteAllText(Path.Combine(dir, fileName), sb.ToString(), Encoding.UTF8);
        }

        private string GetSafeFileName(string fileName)
        {
            // ファイル名に使えない文字を置換し、HTML拡張子と衝突しないように整形
            return fileName.Replace(".", "_").Replace(" ", "_");
        }

        // --- Helper Methods (Access Modifier, Comments) ---
        // (省略なしで記述。前回と同じロジックを使用)
        private string GetAccessModifier(FieldInfo info) {
            if (info.IsPublic) return "public"; if (info.IsPrivate) return "private";
            if (info.IsFamily) return "protected"; if (info.IsAssembly) return "internal";
            if (info.IsFamilyOrAssembly) return "protected internal"; return "private";
        }
        private string GetAccessModifier(MethodInfo info) {
            if (info.IsPublic) return "public"; if (info.IsPrivate) return "private";
            if (info.IsFamily) return "protected"; if (info.IsAssembly) return "internal";
            if (info.IsFamilyOrAssembly) return "protected internal"; return "private";
        }
        private string GetAccessModifier(PropertyInfo info) {
            var get = info.GetMethod; var set = info.SetMethod;
            if ((get != null && get.IsPublic) || (set != null && set.IsPublic)) return "public";
            if ((get != null && get.IsFamily) || (set != null && set.IsFamily)) return "protected";
            if ((get != null && get.IsAssembly) || (set != null && set.IsAssembly)) return "internal";
            return "private";
        }

        private Dictionary<string, string> ParseDocComments(string source)
        {
            var comments = new Dictionary<string, string>();
            var lines = source.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var simpleCommentRegex = new Regex(@"///\s*(.*)");
            var attributeRegex = new Regex(@"\[.*?\]");
            var summaryBlockRegex = new Regex(@"<summary>(.*?)</summary>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var typeDefRegex = new Regex(@"\b(class|struct|interface|enum)\b");
            StringBuilder xmlBuffer = new StringBuilder();

            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;
                if (line.StartsWith("///")) {
                    var match = simpleCommentRegex.Match(line);
                    if (match.Success) xmlBuffer.AppendLine(match.Groups[1].Value);
                    continue;
                }
                string codePart = line;
                if (codePart.StartsWith("[")) {
                    codePart = attributeRegex.Replace(codePart, ""); codePart = codePart.Trim();
                }
                if (string.IsNullOrEmpty(codePart)) continue;
                string trailingComment = "";
                int commentIndex = codePart.IndexOf("//");
                if (commentIndex >= 0) {
                    trailingComment = codePart.Substring(commentIndex + 2).Trim();
                    codePart = codePart.Substring(0, commentIndex).Trim();
                }
                if (string.IsNullOrWhiteSpace(codePart)) continue;

                var names = ExtractNamesFromDefinition(codePart);
                if (names.Count > 0) {
                    string rawBuffer = xmlBuffer.ToString();
                    string summary = "";
                    var summaryMatch = summaryBlockRegex.Match(rawBuffer);
                    if (summaryMatch.Success) {
                        string content = summaryMatch.Groups[1].Value;
                        summary = Regex.Replace(content, @"<[^>]+>", "").Trim();
                        var summaryLines = summary.Split(new[]{'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
                        for(int k=0; k<summaryLines.Length; k++) summaryLines[k] = summaryLines[k].Trim();
                        summary = string.Join("\n", summaryLines);
                    }
                    if (!string.IsNullOrEmpty(trailingComment)) {
                        if (!string.IsNullOrEmpty(summary)) summary += "\n";
                        summary += trailingComment;
                    }
                    if (!string.IsNullOrEmpty(summary)) {
                        foreach (var name in names) {
                            if (!comments.ContainsKey(name)) comments[name] = summary;
                            else if (!comments[name].Contains(summary)) comments[name] += "\n" + summary;
                        }
                    }
                    if (typeDefRegex.IsMatch(codePart) || codePart.Trim().EndsWith(";") || codePart.Trim().EndsWith("{") || codePart.Trim().EndsWith("}") || codePart.Contains("(")) {
                        xmlBuffer.Clear();
                    }
                }
            }
            return comments;
        }

        private List<string> ExtractNamesFromDefinition(string line) {
            var results = new List<string>();
            var typeKeywords = new[] { "class", "struct", "interface", "enum" };
            var typeTokens = line.Split(new[] { ' ', '\t', ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < typeTokens.Length; i++) {
                if (Array.IndexOf(typeKeywords, typeTokens[i]) >= 0) {
                    if (i + 1 < typeTokens.Length) {
                        string name = typeTokens[i + 1];
                        int bracketIndex = name.IndexOf('<');
                        if (bracketIndex > 0) name = name.Substring(0, bracketIndex);
                        results.Add(name); return results;
                    }
                }
            }
            int parenIndex = line.IndexOf('(');
            if (parenIndex > 0) {
                int eqIndex = line.IndexOf('=');
                bool isInitialization = eqIndex >= 0 && eqIndex < parenIndex;
                if (!isInitialization) {
                    string beforeParen = line.Substring(0, parenIndex).Trim();
                    string name = GetLastToken(beforeParen);
                    if (name != null) results.Add(name); return results;
                }
            }
            var parts = SplitByCommaWithBrackets(line);
            foreach (var part in parts) {
                string defPart = part;
                int eqIndex = part.IndexOf('=');
                if (eqIndex >= 0) defPart = part.Substring(0, eqIndex).Trim();
                string name = GetLastToken(defPart);
                if (name != null) results.Add(name);
            }
            return results;
        }

        private string GetLastToken(string text) {
            var tokens = text.Split(new[]{' ', '\t', ';', ':'}, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0) return null;
            var keywords = new HashSet<string> { "public", "private", "protected", "internal", "static", "readonly", "const", "volatile", "class", "struct", "enum", "interface", "void", "async", "override", "virtual", "abstract", "new", "return", "get", "set", "delegate", "event", "fixed", "stackalloc", "int", "float", "bool", "string", "double", "long", "short", "byte", "char", "object", "uint", "ulong", "ushort", "sbyte", "decimal", "dynamic", "var" };
            for (int i = tokens.Length - 1; i >= 0; i--) {
                string t = tokens[i];
                if (keywords.Contains(t)) continue;
                if (!char.IsLetter(t[0]) && t[0] != '_') continue; 
                if (t.Contains(".")) continue; 
                return t;
            }
            return null;
        }

        private List<string> SplitByCommaWithBrackets(string text) {
            var results = new List<string>();
            int depth = 0; int start = 0;
            for (int i = 0; i < text.Length; i++) {
                char c = text[i];
                if (c == '<' || c == '(' || c == '{' || c == '[') depth++;
                else if (c == '>' || c == ')' || c == '}' || c == ']') depth--;
                else if (c == ',' && depth == 0) { results.Add(text.Substring(start, i - start).Trim()); start = i + 1; }
                else if (c == ';' && depth == 0) break;
            }
            if (start < text.Length) { string lastPart = text.Substring(start).Trim(' ', ';'); if (!string.IsNullOrEmpty(lastPart)) results.Add(lastPart); }
            return results;
        }

        // --- Data Classes ---
        private class FileSpec {
            public string FileName; public string AssetPath;
            public int TotalLines; public int CodeLines; public int CommentLines; public int EmptyLines;
            public List<ClassSpec> Classes = new List<ClassSpec>();
        }
        private class ClassSpec {
            public string ClassName; public string Namespace; public string FullName; public string Description;
            public string TypeCategory; public bool IsMonoBehaviour;
            public string BaseClass;
            public List<FieldSpec> Fields = new List<FieldSpec>();
            public List<PropertySpec> Properties = new List<PropertySpec>();
            public List<MethodSpec> Methods = new List<MethodSpec>();
        }
        private class FieldSpec {
            public string Name; public string Type; public string Access; public string Description;
            public string Tooltip; public string Header; public string Constraint; public bool IsStatic;
        }
        private class PropertySpec {
            public string Name; public string Type; public string Access; public string Description;
            public bool IsStatic; public bool CanRead; public bool CanWrite;
        }
        private class MethodSpec {
            public string Name; public string ReturnType; public string Access; public string Description;
            public bool IsMagic; public bool IsStatic; public bool IsConstructor;
            public string Parameters;
        }
    }
}
namespace System.Web {
    public static class HttpUtility {
        public static string HtmlEncode(string s) {
            return System.Net.WebUtility.HtmlEncode(s);
        }
    }
}