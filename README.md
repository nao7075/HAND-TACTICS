# HAND TACTICS

## 本リポジトリについて
本リポジトリは、自作ゲーム「HAND TACTICS」のUnityプロジェクトから、**主要なソースコードと仕様書を抜粋したもの**です。
ポートフォリオとして、コーディングスタイルや設計、ドキュメント作成能力をご確認いただくために公開しています。
Unityプロジェクト全体を含んでいないため、このままでは実行できません。

## ゲーム概要
**「運」と「読み合い」が融合した、1v1じゃんけんカードバトル**
プレイヤーはデッキを構築し、毎ターンの「じゃんけん」とカードプレイを駆使して勝利を目指します。
実際のビルドは [Unityroom](https://unityroom.com/games/handtactics) で公開しています。

## 確認いただきたいポイント

### 1. ゲームロジックと設計 ([Assets_Scripts](Assets_Scripts))
Photon(PUN2)を用いたオンライン対戦ゲームの主要ロジックです。
*   **BattleManager.cs**: ゲームの進行管理、ターン制御。
*   **CardController.cs / CardModel.cs**: カードの挙動とデータ管理。
  
  など

### 2. 仕様書ドキュメント ([Documents](Documents))

*   **[HAND_TACTICS.md](Documents/HAND_TACTICS.md)**: 詳細なゲームルール、画面遷移図、データ構造などをまとめた仕様書。
*   **[ScriptDocs](Documents/ScriptDocs/Index.md)**: クラス図やシーケンス図を含む技術ドキュメント。

### 3. 開発効率化ツール ([Assets_Editor](Assets_Editor))
プロジェクト情報を抜粋するためにAIを使用して自作したUnityエディタ拡張です。
*   **ImageCollector.cs**: ゲーム内の画像を自動収集するツール。
*   **SceneStructureDumper.cs**: シーン内のオブジェクト構造をテキスト出力し、構成把握を助けるツール。

---

## フォルダ構成

### [Assets_Scripts](Assets_Scripts)
ゲームシステムのC#スクリプトファイル群。
(Photon, DOTweenなどの外部アセットは除外しています)

### [Documents](Documents)
仕様書、設計資料、およびそれに関連する画像素材。

### [Assets_Editor](Assets_Editor)
Unityエディタ上で動作する自作の拡張スクリプト。

### [CollectedImages](CollectedImages)
エディタ拡張ツールによって収集された、ゲーム画面やカードのキャプチャ画像。