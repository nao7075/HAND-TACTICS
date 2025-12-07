# File: RoomListCell.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_PunCockpit_Scripts_Lists.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists/RoomListCell.cs`

<a id='RoomListCell'></a>
## Class RoomListCell
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `RoomListCell : MonoBehaviour`

> Roomlist cell.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ListManager | `RoomListView` |  |  |
| `public` | RoomNameText | `Text` |  |  |
| `public` | PlayerCountText | `Text` |  |  |
| `public` | OpenText | `Text` |  |  |
| `public` | JoinButtonCanvasGroup | `CanvasGroup` |  |  |
| `public` | LayoutElement | `LayoutElement` |  |  |
| `public` | info | `RoomInfo` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | RefreshInfo | RoomInfo info | `Void` |  |
| `public` | OnJoinRoomButtonClick |  | `Void` |  |
| `public` | AddToList | RoomInfo info, Boolean animate | `Void` |  |
| `public` | RemoveFromList |  | `Void` |  |
| `private` | AnimateAddition |  | `IEnumerator` |  |
| `private` | AnimateRemove |  | `IEnumerator` |  |

---

