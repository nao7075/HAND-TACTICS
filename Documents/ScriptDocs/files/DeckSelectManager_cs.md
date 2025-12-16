# File: DeckSelectManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/DeckSelectManager.cs`

<a id='DeckSelectManager'></a>
## Class DeckSelectManager
**Namespace:** `(Global)`<br>
**Signature:** `DeckSelectManager : MonoBehaviour`

> 対戦前に使用するデッキを選択する画面の管理クラス。  
> デッキ枚数が規定（32枚）に満たない場合は選択できないように制御する。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | Deck1Button | `Button` | 対戦デッキ1ボタン |  |
| `private` | Deck2Button | `Button` | 対戦デッキ2ボタン |  |
| `private` | Deck3Button | `Button` | 対戦デッキ3ボタン |  |
| `private` | Deck1Error | `GameObject` | 枚数不足時のエラー表示 |  |
| `private` | Deck2Error | `GameObject` | 枚数不足時のエラー表示 |  |
| `private` | Deck3Error | `GameObject` | 枚数不足時のエラー表示 |  |
| `public` | deckList | `List`1` | 対戦デッキデータを格納するリスト |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | PushDeckSelectButton | Int32 deckListNum | `Void` | デッキ選択ボタン押下時の処理。<br>選択されたデッキをバトル用デッキとして設定する。 |
| `public` | BackHomeButtom |  | `Void` | ホーム画面に移動するボタン |
| `public` | BackButtom |  | `IEnumerator` | BackHomeButtomで実行する |
| `public` | DeckSelectButtom |  | `IEnumerator` | マッチング画面へ遷移 |
| `private` | ⚡ OnEnable |  | `Void` | 画面表示時にデッキ枚数をチェックし、不備があるデッキのボタンを無効化する |

---

