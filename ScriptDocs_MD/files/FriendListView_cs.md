# File: FriendListView.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists/FriendListView.cs`

<a id='FriendListView'></a>
## Class FriendListView
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `FriendListView : MonoBehaviourPunCallbacks`

> Friend list UI view.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | CellPrototype | `FriendListCell` |  |  |
| `public` | ContentFeedback | `Text` |  |  |
| `public` | UpdateStatusText | `Text` |  |  |
| `public` | OnJoinRoom | `OnJoinRoomEvent` |  |  |
| `private` | FriendCellList | `Dictionary`2` |  |  |
| `private` | FriendsLUT | `String[]` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | SetFriendDetails | FriendDetail[] friendList | `Void` |  |
| `public` | FindFriends |  | `Void` |  |
| `public` | OnFriendListUpdate | List`1 friendList | `Void` |  |
| `public` | OnRoomListUpdateCallBack | List`1 roomList | `Void` |  |
| `public` | JoinFriendRoom | String RoomName | `Void` |  |
| `private` | UpdateUIPing |  | `IEnumerator` |  |
| `public` | ResetList |  | `Void` |  |

---

