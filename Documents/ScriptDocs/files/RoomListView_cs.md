# File: RoomListView.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_PunCockpit_Scripts_Lists.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists/RoomListView.cs`

<a id='RoomListView'></a>
## Class RoomListView
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `RoomListView : MonoBehaviourPunCallbacks`

> Room list UI View.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | OnJoinRoom | `OnJoinRoomEvent` |  |  |
| `public` | CellPrototype | `RoomListCell` |  |  |
| `public` | UpdateStatusText | `Text` |  |  |
| `public` | ContentFeedback | `Text` |  |  |
| `public` | LobbyNameInputField | `InputField` |  |  |
| `public` | SqlQueryInputField | `InputField` |  |  |
| `private` | _firstUpdate | `Boolean` |  |  |
| `private` | roomCellList | `Dictionary`2` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | OnRoomCellJoinButtonClick | String roomName | `Void` |  |
| `public` | OnRoomListUpdate | List`1 roomList | `Void` |  |
| `private` | clearStatus |  | `IEnumerator` |  |
| `public` | OnJoinedLobbyCallBack |  | `Void` |  |
| `public` | GetRoomList |  | `Void` |  |
| `public` | ResetList |  | `Void` |  |

---

