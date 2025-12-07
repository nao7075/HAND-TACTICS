# File: PlayerListCell.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists/PlayerListCell.cs`

<a id='PlayerListCell'></a>
## Class PlayerListCell
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `PlayerListCell : MonoBehaviour`

> Player list cell representing a given PhotonPlayer

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ListManager | `PlayerListView` |  |  |
| `public` | NumberText | `Text` |  |  |
| `public` | NameText | `Text` |  |  |
| `public` | ActiveFlag | `Image` |  |  |
| `public` | InactiveColor | `Color` |  |  |
| `public` | ActiveColor | `Color` |  |  |
| `public` | isLocalText | `Text` |  |  |
| `public` | isMasterFlag | `Image` |  |  |
| `public` | LayoutElement | `LayoutElement` |  |  |
| `private` | _player | `Player` |  |  |
| `public` | isInactiveCache | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | RefreshInfo | Hashtable changedProps | `Void` |  |
| `public` | AddToList | Player info, Boolean animate | `Void` |  |
| `public` | RemoveFromList |  | `Void` |  |
| `public` | OnClick |  | `Void` |  |
| `private` | UpdateInfo |  | `Void` |  |
| `private` | Add |  | `IEnumerator` |  |
| `private` | Remove |  | `IEnumerator` |  |

---

