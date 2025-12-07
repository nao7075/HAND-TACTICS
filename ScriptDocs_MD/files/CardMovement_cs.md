# File: CardMovement.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/CardMovement.cs`

<a id='CardMovement'></a>
## Class CardMovement
**Namespace:** `(Global)`<br>
**Signature:** `CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler`

> デッキ編集画面などにおける、カードの一般的な移動制御クラス。  
> ドラッグ＆ドロップによる移動や、クリック時の詳細表示を担当する。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | canMove | `Boolean` | カードが移動可能かを示すフラグ（所持数0のカード等はfalseになる） |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ExpandThisCard | Transform moveTarget | `IEnumerator` | パック開封時にカードが移動する処理(使わない) |
| `public` | OnBeginDrag | PointerEventData eventData | `Void` | ドラッグ開始処理 |
| `public` | OnDrag | PointerEventData eventData | `Void` | ドラッグした時に起こす処理 |
| `public` | OnEndDrag | PointerEventData eventData | `Void` | ドラッグ終了処理<br>カードを離したときに行う処理 |
| `public` | OnPointerClick | PointerEventData eventData | `Void` | カードクリック時の処理。詳細パネルを表示する。 |

---

