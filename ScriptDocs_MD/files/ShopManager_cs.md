# File: ShopManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/ShopManager.cs`

<a id='ShopManager'></a>
## Class ShopManager
**Namespace:** `(Global)`<br>
**Signature:** `ShopManager : MonoBehaviour`

> 不使用

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | selectPackButtonPrefab | `SelectPackButtonManager` | パック選択ボタンのプレハブ |  |
| `private` | selectPackButtonTrans | `Transform` | パック選択ボタンを生成する場所 |  |
| `private` | purchasePackPanel | `GameObject` | パック購入パネル |  |
| `public` | packList | `List`1` | パックのIDリスト |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | SetSelectPackButton |  | `Void` |  |
| `public` | CreateSelectPackButton | Int32 packId, Transform transform | `Void` |  |
| `public` | ShowPurchasePackPanel | Int32 packId | `Void` |  |
| `public` | BackHomeButtom |  | `Void` |  |

---

