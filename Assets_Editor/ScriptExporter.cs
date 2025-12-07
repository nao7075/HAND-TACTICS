#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class ScriptExporter : EditorWindow
{
    [MenuItem("Tools/Export Scripts for NotebookLM")]
    public static void ExportScripts()
    {
        // 保存先のパスを指定
        string path = EditorUtility.SaveFilePanel("Save All Scripts", "", "AllScripts", "txt");
        if (string.IsNullOrEmpty(path)) return;

        StringBuilder sb = new StringBuilder();
        
        // Assetsフォルダ以下の全.csファイルを検索
        string[] guids = AssetDatabase.FindAssets("t:Script", new[] { "Assets" });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            
            // パッケージや外部アセットを除外したい場合はここでフィルタリング
            // 例: Pluginsフォルダを除外する場合
            // if (assetPath.Contains("/Plugins/")) continue;

            if (assetPath.EndsWith(".cs"))
            {
                sb.AppendLine("--------------------------------------------------");
                sb.AppendLine($"// Filename: {assetPath}"); // AIがファイルパスを認識できるように記述
                sb.AppendLine("--------------------------------------------------");
                
                string content = File.ReadAllText(assetPath);
                sb.AppendLine(content);
                sb.AppendLine("\n"); // ファイル間の区切り
            }
        }

        File.WriteAllText(path, sb.ToString());
        Debug.Log($"Export Complete: {path}");
        EditorUtility.RevealInFinder(path);
    }
}
#endif
