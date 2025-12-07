# File: LobbyMainPanel.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Lobby/LobbyMainPanel.cs`

<a id='LobbyMainPanel'></a>
## Class LobbyMainPanel
**Namespace:** `Photon.Pun.Demo.Asteroids`<br>
**Signature:** `LobbyMainPanel : MonoBehaviourPunCallbacks`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | LoginPanel | `GameObject` | **[Login Panel]**<br> |  |
| `public` | PlayerNameInput | `InputField` |  |  |
| `public` | SelectionPanel | `GameObject` | **[Selection Panel]**<br> |  |
| `public` | CreateRoomPanel | `GameObject` | **[Create Room Panel]**<br> |  |
| `public` | RoomNameInputField | `InputField` |  |  |
| `public` | MaxPlayersInputField | `InputField` |  |  |
| `public` | JoinRandomRoomPanel | `GameObject` | **[Join Random Room Panel]**<br> |  |
| `public` | RoomListPanel | `GameObject` | **[Room List Panel]**<br> |  |
| `public` | RoomListContent | `GameObject` |  |  |
| `public` | RoomListEntryPrefab | `GameObject` |  |  |
| `public` | InsideRoomPanel | `GameObject` | **[Inside Room Panel]**<br> |  |
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

