# File: RegionListCell.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists/RegionListCell.cs`

<a id='RegionListCell'></a>
## Class RegionListCell
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `RegionListCell : MonoBehaviour`

> Region list cell.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ListManager | `RegionListView` |  |  |
| `public` | CodeText | `Text` |  |  |
| `public` | IpText | `Text` |  |  |
| `public` | PingText | `Text` |  |  |
| `public` | LayoutElement | `LayoutElement` |  |  |
| `private` | _index | `Int32` |  |  |
| `private` | info | `Region` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | RefreshInfo | Region info | `Void` |  |
| `public` | AddToList | Region info, Int32 index | `Void` |  |
| `public` | RemoveFromList |  | `Void` |  |
| `private` | AnimateAddition |  | `IEnumerator` |  |
| `private` | AnimateRemove |  | `IEnumerator` |  |

---

