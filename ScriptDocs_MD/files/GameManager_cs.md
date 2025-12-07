# File: GameManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/GameManager.cs`

<a id='GameManager'></a>
## Class GameManager
**Namespace:** `(Global)`<br>
**Signature:** `GameManager : MonoBehaviour`

> ゲーム全体を通して存在するシングルトンマネージャー。  
> カードの生成や、オンライン対戦フラグなどの全体情報を管理する。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | cardPrefab | `CardController` | カードプレハブ |  |
| `private` | cardDetailsPanelPrefab | `CardDetailPanel` | カード詳細パネルのプレハブ |  |
| `public` | PossessionCardsList | `List`1` | 所持カードリスト |  |
| `private` | cardKindNum | `Int32` | カードの種類の初期値、unityのインスペクターで設定した枚数になる |  |
| `public` | instance | `GameManager` | シングルトン化 |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | IsOnlineBattle <br><small>{ get; set; }</small> | `Boolean` | オンライン対戦中かどうかのフラグ |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | CreateCard | Int32 cardId, Transform trans | `CardController` | 指定したIDのカードを、指定した場所に生成するファクトリーメソッド<br>カードを作るメソッド（生成したいカードのID、生成したいカードの場所） |
| `public` | CreateCardDetailsPanel | CardController card | `Void` | 指定したカードの詳細パネルをUI上に生成して表示する |

---

