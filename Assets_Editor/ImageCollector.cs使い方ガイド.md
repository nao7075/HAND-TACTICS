# **ImageCollector.csの使い方ガイド**

このツールは、シーン内や特定のプレハブ、ScriptableObjectで使用されている画像（Sprite/Texture）を特定し、指定のフォルダに一括コピーして収集します。

## **1\. 導入方法**

1. Unityプロジェクトの Assets/Editor フォルダの中に ImageCollector.cs を配置します。

## **2\. 使い方（パターンA：現在のシーンから収集）**

現在開いているシーンに配置されているオブジェクトが参照している画像をすべて収集します。

1. 画像を収集したいシーンを開きます。  
2. メニューバーから **Tools** \> **Collect Images** \> **From Active Scene** を選択します。  
3. プロジェクトフォルダの階層（Assetsの隣）に CollectedImages\_Scene\_\[シーン名\] というフォルダが作成され、画像がコピーされます。

## **3\. 使い方（パターンB：選択したアセットから収集）**

特定のプレハブや ScriptableObject（CardEntityなど）が使用している画像を収集します。

1. Projectウィンドウで、画像を抽出したいプレハブやScriptableObjectを選択します（複数選択可）。  
2. メニューバーから **Assets** \> **Collect Images from Selection** を選択します。  
   * または、右クリックメニューには表示されない場合があるため、上部メニューを使用してください。  
3. CollectedImages\_Selection（またはアセット名）というフォルダに画像がコピーされます。

## **4\. 収集対象**

以下のコンポーネントやプロパティに割り当てられている画像が対象です。

* Image, RawImage, SpriteRenderer  
* Button (Transition設定されているSpriteSwap画像など)  
* ScriptableObject内の Sprite/Texture 型のフィールド