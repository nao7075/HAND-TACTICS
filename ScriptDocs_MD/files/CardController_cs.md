# File: CardController.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/CardController.cs`

<a id='CardController'></a>
## Class CardController
**Namespace:** `(Global)`<br>
**Signature:** `CardController : MonoBehaviourPunCallbacks`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | view | `CardView` | カードの見た目の処理 |  |
| `public` | model | `CardModel` | カードのデータを処理<br>カードデータを生成 |  |
| `public` | movement | `CardMovement` | カードの動きを処理（ドラッグ等） |  |
| `public` | Battlemovement | `BattleCardMovement` | バトル中のカードの動きを処理 |  |
| `public` | PlayerNumberth | `Int32` | 1ゲーム内でのカード識別用の一意なID（プレイヤー側）<br>IDインクリメント |  |
| `public` | destroycards | `Boolean` | カード破壊時音声のためのフラグ |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | Init | Int32 cardId, Boolean playerCard | `Void` | カード生成時の初期化（一般用） |
| `public` | PlayerInit | Int32 cardId, Boolean playerCard | `Void` | プレイヤーカード生成時の初期化 |
| `public` | EnemyInit | Int32 cardId, Boolean playerCard, Int32 PNumberth | `Void` | 敵カード生成時の初期化（RPC用）,敵に自分のカードを生成したいRPCで呼び出す関数 |
| `public` | DestroyCard | CardController card | `IEnumerator` | カード破壊処理 |
| `public` | ScaleCard | Single scaleNum | `Void` | CardDetailPanelで使用、カードの大きさを変える |
| `public` | DropField |  | `Void` | カードがフィールドにドロップされた時の処理 |
| `public` | DropMulliganField |  | `Void` | カードがマリガンフィールドにドロップされた時の処理 |
| `public` | StartCardMotion |  | `IEnumerator` | 召喚時とスペル使用時の演出 |
| `public` | CostDown |  | `Void` | コスト計算<br>じゃんけん結果に基づいてコストダウン判定を行う |
| `public` | activateAbility |  | `IEnumerator` | カードの効果発動処理。<br>非常に多岐にわたる効果（ドロー、召喚、バフ、ダメージなど）をフラグに応じて処理する。 |

---

