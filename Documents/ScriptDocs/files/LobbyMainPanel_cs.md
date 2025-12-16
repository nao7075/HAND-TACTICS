# File: LobbyMainPanel.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoAsteroids_Scripts_Lobby.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Lobby/LobbyMainPanel.cs`

<a id='LobbyMainPanel'></a>
## Class LobbyMainPanel
**Namespace:** `Photon.Pun.Demo.Asteroids`<br>
**Signature:** `LobbyMainPanel : MonoBehaviourPunCallbacks`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| | **【Login Panel】** | | | |
| `public` | LoginPanel | `GameObject` |  |  |
| `public` | PlayerNameInput | `InputField` |  |  |
| | **【Selection Panel】** | | | |
| `public` | SelectionPanel | `GameObject` |  |  |
| | **【Create Room Panel】** | | | |
| `public` | CreateRoomPanel | `GameObject` |  |  |
| `public` | RoomNameInputField | `InputField` |  |  |
| `public` | MaxPlayersInputField | `InputField` |  |  |
| | **【Join Random Room Panel】** | | | |
| `public` | JoinRandomRoomPanel | `GameObject` |  |  |
| | **【Room List Panel】** | | | |
| `public` | RoomListPanel | `GameObject` |  |  |
| `public` | RoomListContent | `GameObject` |  |  |
| `public` | RoomListEntryPrefab | `GameObject` |  |  |
| | **【Inside Room Panel】** | | | |
| `public` | InsideRoomPanel | `GameObject` |  |  |
| `public` | StartGameButton | `Button` |  |  |
| `public` | PlayerListEntryPrefab | `GameObject` |  |  |
| `private` | cachedRoomList | `Dictionary`2` |  |  |
| `private` | roomListEntries | `Dictionary`2` |  |  |
| `private` | playerListEntries | `Dictionary`2` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | OnConnectedToMaster |  | `Void` |  |
| `public` | OnRoomListUpdate | List`1 roomList | `Void` |  |
| `public` | OnJoinedLobby |  | `Void` |  |
| `public` | OnLeftLobby |  | `Void` |  |
| `public` | OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinedRoom |  | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | OnPlayerEnteredRoom | Player newPlayer | `Void` |  |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player targetPlayer, Hashtable changedProps | `Void` |  |
| `public` | OnBackButtonClicked |  | `Void` |  |
| `public` | OnCreateRoomButtonClicked |  | `Void` |  |
| `public` | OnJoinRandomRoomButtonClicked |  | `Void` |  |
| `public` | OnLeaveGameButtonClicked |  | `Void` |  |
| `public` | OnLoginButtonClicked |  | `Void` |  |
| `public` | OnRoomListButtonClicked |  | `Void` |  |
| `public` | OnStartGameButtonClicked |  | `Void` |  |
| `private` | CheckPlayersReady |  | `Boolean` |  |
| `private` | ClearRoomListView |  | `Void` |  |
| `public` | LocalPlayerPropertiesUpdated |  | `Void` |  |
| `private` | SetActivePanel | String activePanel | `Void` |  |
| `private` | UpdateCachedRoomList | List`1 roomList | `Void` |  |
| `private` | UpdateRoomListView |  | `Void` |  |

---

