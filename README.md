# HAND TACTICS

## 本リポジトリについて
本リポジトリは、自作ゲーム「HAND TACTICS」のUnityプロジェクトから、**主要なソースコードと仕様書を抜粋したもの**です。
ポートフォリオとして、コーディングスタイルや設計、ドキュメント作成能力をご確認いただくために公開しています。
Unityプロジェクト全体を含んでいないため、このままでは実行できません。

## ゲーム概要
**「運」と「読み合い」が融合した、1v1じゃんけんカードバトル**
プレイヤーはデッキを構築し、毎ターンの「じゃんけん」とカードプレイを駆使して勝利を目指します。
実際のビルドは <a href="https://unityroom.com/games/handtactics" target="_blank" rel="noopener">Unityroom</a> で公開しています（ブラウザで新しいタブを開きたい場合は右クリックや中クリックでお願いします）。

## 確認いただきたいポイント

### 1. ゲームの主要スクリプト ([Assets_Scripts](Assets_Scripts))
ゲームの主要スクリプトです。

### 2. 仕様書ドキュメント ([Documents](Documents))

*   **[HAND_TACTICS.md](Documents/HAND_TACTICS.md)**: 詳細なゲームルール、画面遷移図、データ構造などをまとめた仕様書。
*   **[ScriptDocs](Documents/ScriptDocs)**: 主要スクリプトに関しては [Documents/ScriptDocs/folders/Assets_Scripts.md](Documents/ScriptDocs/folders/Assets_Scripts.md) を参照してください。各スクリプトの責務やフィールド、メソッドなどがまとめられています。


---

## フォルダ構成

### [Assets_Editor](Assets_Editor)
Unityエディタ上で動作するAIを使用して自作した拡張スクリプトとその説明書。

### [Assets_Scripts](Assets_Scripts)
ゲームシステムのC#スクリプトファイル群。
(Photon, DOTweenなどの外部アセットは除外しています)
詳細な各ファイルの説明は [Documents/ScriptDocs/Index.md](Documents/ScriptDocs/Index.md) から参照できます。

### [Assets_Sounds](Assets_Sounds)
プロジェクトで使用した音声ファイル。

### [CollectedImages](CollectedImages)
エディタ拡張ツールによって収集された、ゲーム画面やカードのキャプチャ画像。

### [Documents](Documents)
仕様書、設計資料、およびそれに関連する画像素材。

