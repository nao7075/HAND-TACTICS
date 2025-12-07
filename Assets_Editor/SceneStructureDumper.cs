#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Imageコンポーネント用

public class SceneStructureDumper : MonoBehaviour
{
    // ---------------------------------------------------------
    // 1. シーン解析
    // ---------------------------------------------------------
    [MenuItem("Tools/Dump Scene Structure (Simple)")]
    public static void DumpStructureSimple() => RunSceneDump(false);

    [MenuItem("Tools/Dump Scene Structure (Detailed)")]
    public static void DumpStructureDetailed() => RunSceneDump(true);

    // ---------------------------------------------------------
    // 2. プレハブ解析
    // ---------------------------------------------------------
    [MenuItem("Assets/Dump Prefab Structure (Detailed)", false, 20)]
    public static void DumpSelectedPrefab()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj == null) { Debug.LogError("プレハブを選択してください。"); return; }
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Prefab Name: {obj.name}");
        sb.AppendLine("========================================");
        DumpGameObject(obj, sb, "", true);
        SaveFile($"PrefabStructure_{obj.name}.txt", sb);
    }

    // ---------------------------------------------------------
    // 3. 画像リスト抽出 (NEW!)
    // ---------------------------------------------------------
    // シーン内の使用画像をダンプ
    [MenuItem("Tools/Dump Used Images in Scene")]
    public static void DumpUsedImagesInScene()
    {
        StringBuilder sb = new StringBuilder();
        Scene scene = SceneManager.GetActiveScene();
        sb.AppendLine($"Used Images in Scene: {scene.name}");
        sb.AppendLine("========================================");

        HashSet<string> usedImages = new HashSet<string>();
        GameObject[] rootObjects = scene.GetRootGameObjects();
        
        foreach (GameObject obj in rootObjects)
        {
            CollectImages(obj, usedImages);
        }

        WriteSortedImages(sb, usedImages);
        SaveFile($"UsedImages_{scene.name}.txt", sb);
    }

    // 選択したプレハブ内の使用画像をダンプ
    [MenuItem("Assets/Dump Used Images (Selected Prefab)", false, 21)]
    public static void DumpUsedImagesInPrefab()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj == null) { Debug.LogError("プレハブを選択してください。"); return; }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Used Images in Prefab: {obj.name}");
        sb.AppendLine("========================================");

        HashSet<string> usedImages = new HashSet<string>();
        CollectImages(obj, usedImages);

        WriteSortedImages(sb, usedImages);
        SaveFile($"UsedImages_Prefab_{obj.name}.txt", sb);
    }

    // ---------------------------------------------------------
    // 4. CardEntity解析
    // ---------------------------------------------------------
    [MenuItem("Tools/Dump All CardEntities (Full)")]
    public static void DumpAllCardEntities() => RunCardEntityDump(false);

    [MenuItem("Tools/Dump CardEntities (Diff from default)")]
    public static void DumpCardEntitiesDiff() => RunCardEntityDump(true);


    // --- 内部処理: 画像収集 ---
    static void CollectImages(GameObject obj, HashSet<string> imageSet)
    {
        // uGUIのImage
        var image = obj.GetComponent<Image>();
        if (image != null && image.sprite != null)
        {
            imageSet.Add(image.sprite.name);
        }

        // SpriteRenderer (2Dオブジェクト)
        var spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            imageSet.Add(spriteRenderer.sprite.name);
        }

        // RawImage
        var rawImage = obj.GetComponent<RawImage>();
        if (rawImage != null && rawImage.texture != null)
        {
             imageSet.Add(rawImage.texture.name);
        }

        // ボタンのTransitionに設定されている画像
        var button = obj.GetComponent<Button>();
        if (button != null && button.transition == Selectable.Transition.SpriteSwap)
        {
            if (button.spriteState.highlightedSprite != null) imageSet.Add(button.spriteState.highlightedSprite.name);
            if (button.spriteState.pressedSprite != null) imageSet.Add(button.spriteState.pressedSprite.name);
            if (button.spriteState.selectedSprite != null) imageSet.Add(button.spriteState.selectedSprite.name);
            if (button.spriteState.disabledSprite != null) imageSet.Add(button.spriteState.disabledSprite.name);
        }

        // 子要素を再帰探索
        foreach (Transform child in obj.transform)
        {
            CollectImages(child.gameObject, imageSet);
        }
    }

    static void WriteSortedImages(StringBuilder sb, HashSet<string> images)
    {
        List<string> sortedList = new List<string>(images);
        sortedList.Sort();

        if (sortedList.Count == 0)
        {
            sb.AppendLine("(No images used)");
        }
        else
        {
            foreach (string imgName in sortedList)
            {
                sb.AppendLine(imgName);
            }
        }
        sb.AppendLine("");
        sb.AppendLine($"Total: {sortedList.Count} images");
    }

    // --- 内部処理: 既存機能 ---
    // (CardEntity解析部分)
    static void RunCardEntityDump(bool diffMode)
    {
        StringBuilder sb = new StringBuilder();
        string modeTitle = diffMode ? "Diff Only (Based on 'default')" : "Full Dump";
        sb.AppendLine($"All CardEntities Dump [{modeTitle}]");
        sb.AppendLine("========================================");

        string[] guids = AssetDatabase.FindAssets("t:CardEntity");
        if (guids.Length == 0) { Debug.LogWarning("CardEntityが見つかりませんでした。"); return; }

        ScriptableObject defaultEntity = null;
        if (diffMode)
        {
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
                if (asset != null && asset.name.ToLower() == "default")
                {
                    defaultEntity = asset;
                    sb.AppendLine($"[Base Entity Found]: {asset.name} (Path: {path})");
                    sb.AppendLine("----------------------------------------");
                    break;
                }
            }
            if (defaultEntity == null) { Debug.LogError("'default' という名前のCardEntityが必要です。"); return; }
        }

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ScriptableObject asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            if (asset != null)
            {
                if (diffMode && asset == defaultEntity) continue;
                sb.AppendLine($"[Card] {asset.name}"); 
                SerializedObject so = new SerializedObject(asset);
                SerializedProperty iter = so.GetIterator();
                SerializedObject defaultSo = diffMode ? new SerializedObject(defaultEntity) : null;
                bool enterChildren = true;
                bool hasChanges = false;
                while (iter.NextVisible(enterChildren))
                {
                    enterChildren = false;
                    if (iter.name == "m_Script") continue;
                    string valueStr = GetValueString(iter);
                    if (diffMode)
                    {
                        SerializedProperty defaultProp = defaultSo.FindProperty(iter.name);
                        if (defaultProp != null)
                        {
                            string defaultValueStr = GetValueString(defaultProp);
                            if (valueStr != defaultValueStr) { sb.AppendLine($"  > {iter.name}: {valueStr}"); hasChanges = true; }
                        }
                        else { sb.AppendLine($"  > {iter.name}: {valueStr} (New)"); hasChanges = true; }
                    }
                    else { if (!string.IsNullOrEmpty(valueStr)) sb.AppendLine($"  > {iter.name}: {valueStr}"); }
                }
                if (diffMode && !hasChanges) sb.AppendLine("  (No changes from default)");
                sb.AppendLine("");
            }
        }
        SaveFile(diffMode ? "CardEntities_Diff.txt" : "CardEntities_Full.txt", sb);
    }

    // (シーン解析部分)
    static void RunSceneDump(bool isDetailed)
    {
        StringBuilder sb = new StringBuilder();
        Scene scene = SceneManager.GetActiveScene();
        string modeName = isDetailed ? "Detailed" : "Simple";
        sb.AppendLine($"Scene Name: {scene.name} ({modeName} Mode)");
        sb.AppendLine("========================================");
        GameObject[] rootObjects = scene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects) DumpGameObject(obj, sb, "", isDetailed);
        SaveFile($"SceneStructure_{scene.name}_{modeName}.txt", sb);
    }

    static void DumpGameObject(GameObject obj, StringBuilder sb, string indent, bool isDetailed)
    {
        sb.AppendLine($"{indent}[GameObject] {obj.name} (Active: {obj.activeSelf}, Tag: {obj.tag}, Layer: {LayerMask.LayerToName(obj.layer)})");
        Component[] components = obj.GetComponents<Component>();
        foreach (Component c in components)
        {
            if (c == null) continue;
            string compName = c.GetType().Name;
            if (c is AudioSource audio)
            {
                sb.AppendLine($"{indent}  - (Component) {compName}");
                sb.AppendLine($"{indent}    > [Sound Info]");
                sb.AppendLine($"{indent}      Clip: {(audio.clip != null ? audio.clip.name : "None")}");
                sb.AppendLine($"{indent}      Volume: {audio.volume}");
                continue; 
            }
            if (!isDetailed && (compName == "Transform" || compName == "RectTransform")) { sb.AppendLine($"{indent}  - (Component) {compName}"); continue; }
            sb.AppendLine($"{indent}  - (Component) {compName}");
            if (c is MonoBehaviour mono)
            {
                SerializedObject so = new SerializedObject(mono);
                SerializedProperty iter = so.GetIterator();
                bool enterChildren = true;
                while (iter.NextVisible(enterChildren))
                {
                    enterChildren = false;
                    string valueStr = GetValueString(iter);
                    if (isDetailed && !string.IsNullOrEmpty(valueStr)) sb.AppendLine($"{indent}    > {iter.name}: {valueStr}");
                    else if (!isDetailed && iter.propertyType == SerializedPropertyType.ObjectReference && iter.objectReferenceValue != null) sb.AppendLine($"{indent}    > {iter.name}: {iter.objectReferenceValue.name} ({iter.objectReferenceValue.GetType().Name})");
                }
            }
        }
        foreach (Transform child in obj.transform) DumpGameObject(child.gameObject, sb, indent + "  ", isDetailed);
    }

    static string GetValueString(SerializedProperty prop)
    {
        switch (prop.propertyType)
        {
            case SerializedPropertyType.ObjectReference: return prop.objectReferenceValue != null ? $"{prop.objectReferenceValue.name} ({prop.objectReferenceValue.GetType().Name})" : "null";
            case SerializedPropertyType.String: return $"\"{prop.stringValue}\"";
            case SerializedPropertyType.Integer: return prop.intValue.ToString();
            case SerializedPropertyType.Float: return prop.floatValue.ToString();
            case SerializedPropertyType.Boolean: return prop.boolValue.ToString();
            case SerializedPropertyType.Enum: return (prop.enumValueIndex >= 0 && prop.enumValueIndex < prop.enumDisplayNames.Length) ? prop.enumDisplayNames[prop.enumValueIndex] : prop.enumValueIndex.ToString();
            case SerializedPropertyType.Generic:
                if (prop.isArray)
                {
                    if (prop.arraySize == 0) return "[]";
                    StringBuilder arraySb = new StringBuilder();
                    arraySb.Append("[");
                    for (int i = 0; i < prop.arraySize; i++)
                    {
                        SerializedProperty element = prop.GetArrayElementAtIndex(i);
                        arraySb.Append(GetValueString(element));
                        if (i < prop.arraySize - 1) arraySb.Append(", ");
                    }
                    arraySb.Append("]");
                    return arraySb.ToString();
                }
                return "";
            default: return "";
        }
    }

    static void SaveFile(string fileName, StringBuilder sb)
    {
        string path = Path.Combine(Application.dataPath, "../" + fileName);
        File.WriteAllText(path, sb.ToString());
        EditorUtility.RevealInFinder(path);
        Debug.Log($"出力完了: {path}");
    }
}
#endif