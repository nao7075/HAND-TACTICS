# **SceneStructureDumper 使い方ガイド**

このツールはUnityエディタ上で動作し、シーン構造、プレハブ構造、使用画像、ScriptableObjectデータをテキストファイルとして出力（ダンプ）するためのユーティリティです。

## **導入方法**

1. SceneStructureDumper.cs をUnityプロジェクトの Assets フォルダ内の任意の場所に配置してください。  
   * エディタ拡張機能として動作するため、ゲーム実行時には影響しません（\#if UNITY\_EDITOR で制御されています）。

## **機能と使い方**

ツールを導入すると、Unityのメニューバーに Tools および Assets 項目が追加されます。

### **1\. シーン構造の解析 (Dump Scene Structure)**

現在開いているシーンの階層構造とコンポーネント情報を出力します。

* **簡易モード**  
  * **メニュー:** Tools \> Dump Scene Structure (Simple)  
  * **内容:** オブジェクト名、階層、コンポーネントの種類のみを出力します。概観を把握するのに適しています。  
  * **出力ファイル名:** SceneStructure\_{シーン名}\_Simple.txt  
* **詳細モード**  
  * **メニュー:** Tools \> Dump Scene Structure (Detailed)  
  * **内容:** 全てのコンポーネントのプロパティ値を詳細に出力します。  
  * **特徴:**  
    * **インスペクター表示の再現:** 変数名ではなく、インスペクター上の表示名（例: Anchored Position）で出力されます。  
    * **RectTransform対応:** Anchor Presets（Top Leftなど）や、ストレッチ設定に応じた Left/Right Pos X/Width の動的な表示切り替えに対応しています。  
  * **出力ファイル名:** SceneStructure\_{シーン名}\_Detailed.txt

### **2\. プレハブの解析 (Dump Prefab Structure)**

プロジェクトウィンドウ（Project View）で選択したプレハブの中身を解析します。

* **使い方:**  
  1. Projectウィンドウで解析したい「プレハブ」を選択します。  
  2. 右クリック、またはメニューバーから Assets \> Dump Prefab Structure (Detailed) を実行します。  
* **内容:** シーン解析の「詳細モード」と同じ形式で出力されます。  
* **出力ファイル名:** PrefabStructure\_{プレハブ名}.txt

### **3\. 使用画像のリスト抽出 (Dump Used Images)**

シーンやプレハブ内で使用されている画像（Sprite, Texture）の一覧を抽出します。  
重複を除外したリストと、使用画像の総数が出力されます。

* **シーン内の画像**  
  * **メニュー:** Tools \> Dump Used Images in Scene  
  * **対象:** 現在のシーンにある全オブジェクト（Image, SpriteRenderer, RawImage, Button Transitionなど）。  
  * **出力ファイル名:** UsedImages\_{シーン名}.txt  
* **プレハブ内の画像**  
  * **メニュー:** Assets \> Dump Used Images (Selected Prefab)  
  * **対象:** Projectウィンドウで選択中のプレハブ。  
  * **出力ファイル名:** UsedImages\_Prefab\_{プレハブ名}.txt

### **4\. CardEntityデータの解析 (Dump CardEntities)**

プロジェクト内の CardEntity（ScriptableObject）を検索してデータを一覧化します。  
※この機能を使用するには、プロジェクト内に CardEntity クラスが存在する必要があります。

* **フルダンプ**  
  * **メニュー:** Tools \> Dump All CardEntities (Full)  
  * **内容:** 全てのCardEntityのパラメータを出力します。  
  * **出力ファイル名:** CardEntities\_Full.txt  
* **差分ダンプ (Diff)**  
  * **メニュー:** Tools \> Dump CardEntities (Diff from default)  
  * **内容:** default という名前のCardEntityを基準とし、そこから値が変更されている箇所のみを出力します。データの入力ミスや変更点の確認に便利です。  
  * **出力ファイル名:** CardEntities\_Diff.txt

## **出力ファイルの保存場所**

すべての出力ファイルは Unityプロジェクトのルートフォルダ（Assetsフォルダの1つ上の階層） に保存されます。  
出力が完了すると、自動的にOSのファイルブラウザ（Finder/Explorer）が開き、保存場所が表示されます。

## **注意事項**

* コンポーネント解析について:  
  詳細モードでは、Unity標準のコンポーネント（RectTransform, CanvasRenderer, Imageなど）を含む すべてのコンポーネント が解析対象です。  
  簡易モードでは、出力を見やすくするため Transform, RectTransform, CanvasRenderer の詳細は省略されます。  
* CardEntityについて:  
  機能4はプロジェクト固有のクラス CardEntity に依存しています。別のプロジェクトで使用する場合は、コード内の該当箇所を削除または修正してください。