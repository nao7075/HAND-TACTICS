# File: CardDetailPanel.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/CardDetailPanel.cs`

<a id='CardDetailPanel'></a>
## Class CardDetailPanel
**Namespace:** `(Global)`<br>
**Signature:** `CardDetailPanel : MonoBehaviour`

> カードをクリックした際に表示される詳細画面（ポップアップ）を制御するクラス。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | cardNameText | `TextMeshProUGUI` | カード名 |  |
| `private` | cardAbilityText | `TextMeshProUGUI` | 能力テキスト |  |
| `private` | cardTrans | `Transform` | 拡大カードを表示する位置 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | SetCardDetailsPanel | CardController card | `Void` | 詳細パネルの内容を設定し、カードの拡大モデルを生成する |
| `public` | DestoyCardDetailPanel |  | `Void` | 詳細パネルを閉じる（破棄する） |

---

