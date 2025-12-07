#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageCollector : MonoBehaviour
{
    // ---------------------------------------------------------
    // 1. シーン内の画像を収集
    // ---------------------------------------------------------
    [MenuItem("Tools/Collect Images/From Active Scene")]
    public static void CollectImagesFromScene()
    {
        HashSet<string> assetPaths = new HashSet<string>();
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = scene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            FindImageAssetsInGameObject(obj, assetPaths);
        }

        ExportImages(assetPaths, $"CollectedImages_Scene_{scene.name}");
    }

    // ---------------------------------------------------------
    // 2. 選択したアセット（プレハブやCardEntity）から画像を収集
    // ---------------------------------------------------------
    [MenuItem("Assets/Collect Images from Selection", false, 20)]
    public static void CollectImagesFromSelection()
    {
        HashSet<string> assetPaths = new HashSet<string>();
        Object[] selectedObjects = Selection.objects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogWarning("アセットを選択してください。");
            return;
        }

        foreach (Object obj in selectedObjects)
        {
            if (obj is GameObject go)
            {
                // プレハブの場合：階層をたどって画像を探す
                FindImageAssetsInGameObject(go, assetPaths);
            }
            else if (obj is ScriptableObject so)
            {
                // CardEntityなどの場合：プロパティから画像を探す
                FindImageAssetsInScriptableObject(so, assetPaths);
            }
        }

        string folderName = "CollectedImages_Selection";
        // 1つだけ選択している場合はその名前にする
        if (selectedObjects.Length == 1)
        {
            folderName = $"CollectedImages_{selectedObjects[0].name}";
        }

        ExportImages(assetPaths, folderName);
    }


    // --- 内部ロジック ---

    // ゲームオブジェクト（プレハブ含む）から画像を探索
    static void FindImageAssetsInGameObject(GameObject obj, HashSet<string> paths)
    {
        // Image, SpriteRenderer, Buttonなど
        var img = obj.GetComponent<Image>();
        if (img != null) AddPath(img.sprite, paths);

        var sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null) AddPath(sr.sprite, paths);

        var rawImg = obj.GetComponent<RawImage>();
        if (rawImg != null) AddPath(rawImg.texture, paths);

        var btn = obj.GetComponent<Button>();
        if (btn != null && btn.transition == Selectable.Transition.SpriteSwap)
        {
            AddPath(btn.spriteState.highlightedSprite, paths);
            AddPath(btn.spriteState.pressedSprite, paths);
            AddPath(btn.spriteState.selectedSprite, paths);
            AddPath(btn.spriteState.disabledSprite, paths);
        }

        // 再帰的に子要素を探索
        foreach (Transform child in obj.transform)
        {
            FindImageAssetsInGameObject(child.gameObject, paths);
        }
    }

    // ScriptableObject (CardEntity) から画像を探索
    static void FindImageAssetsInScriptableObject(ScriptableObject so, HashSet<string> paths)
    {
        SerializedObject serializedObject = new SerializedObject(so);
        SerializedProperty iter = serializedObject.GetIterator();
        bool enterChildren = true;

        while (iter.NextVisible(enterChildren))
        {
            enterChildren = false; 

            if (iter.propertyType == SerializedPropertyType.ObjectReference)
            {
                if (iter.objectReferenceValue is Sprite sprite)
                {
                    AddPath(sprite, paths);
                }
                else if (iter.objectReferenceValue is Texture texture)
                {
                    AddPath(texture, paths);
                }
            }
        }
    }

    // パスリストに追加
    static void AddPath(Object asset, HashSet<string> paths)
    {
        if (asset == null) return;
        string path = AssetDatabase.GetAssetPath(asset);
        if (!string.IsNullOrEmpty(path) && path.StartsWith("Assets"))
        {
            paths.Add(path);
        }
    }

    // ファイルコピー実行
    static void ExportImages(HashSet<string> assetPaths, string folderName)
    {
        if (assetPaths.Count == 0)
        {
            Debug.LogWarning("収集する画像が見つかりませんでした。");
            return;
        }

        string exportPath = Path.Combine(Application.dataPath, "../" + folderName);

        if (!Directory.Exists(exportPath))
        {
            Directory.CreateDirectory(exportPath);
        }

        int count = 0;
        foreach (string path in assetPaths)
        {
            string sourceSystemPath = Path.Combine(Application.dataPath, path.Substring(7));
            string fileName = Path.GetFileName(path);
            string destSystemPath = Path.Combine(exportPath, fileName);

            if (File.Exists(sourceSystemPath))
            {
                if (!File.Exists(destSystemPath))
                {
                    File.Copy(sourceSystemPath, destSystemPath);
                    count++;
                }
            }
        }

        EditorUtility.RevealInFinder(exportPath);
        Debug.Log($"成功: {count} 枚の画像を '{folderName}' にコピーしました！");
    }
}
#endif