# File: PunCockpit.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_PunCockpit.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/PunCockpit.cs`

<a id='PunCockpit'></a>
## Class PunCockpit
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `PunCockpit : MonoBehaviourPunCallbacks`

> UI based work in progress to test out api and act as foundation when dealing with room, friends and player list

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Instance | `PunCockpit` |  |  |
| `public` | Embedded | `Boolean` |  |  |
| `public` | EmbeddedGameTitle | `String` |  |  |
| `public` | debug | `Boolean` |  |  |
| `public` | Title | `Text` |  |  |
| `public` | StateText | `Text` | set in inspector |  |
| `public` | UserIdText | `Text` | set in inspector |  |
| `public` | MinimalCanvasGroup | `CanvasGroup` | **[Demo Integration]**<br> |  |
| `public` | MaximalCanvasGroup | `CanvasGroup` |  |  |
| `public` | MinimizeButton | `GameObject` |  |  |
| `public` | MinimalUIEmbeddHelp | `GameObject` |  |  |
| `public` | ConnectingLabel | `GameObject` | **[Connection UI]**<br> |  |
| `public` | ConnectionPanel | `GameObject` |  |  |
| `public` | AdvancedConnectionPanel | `GameObject` |  |  |
| `public` | ConnectAsDropDown | `Dropdown` |  |  |
| `public` | InfosPanel | `GameObject` | **[Common UI]**<br> |  |
| `public` | MinimalUiInfosPanel | `GameObject` |  |  |
| `public` | LobbyPanel | `GameObject` | **[Lobby UI]**<br> |  |
| `public` | JoinLobbyButton | `Selectable` |  |  |
| `public` | RoomListManager | `RoomListView` |  |  |
| `public` | FriendListManager | `FriendListView` |  |  |
| `public` | RoomListMatchMakingForm | `GameObject` |  |  |
| `public` | GamePanel | `GameObject` | **[Game UI]**<br> |  |
| `public` | PlayerListManager | `PlayerListView` |  |  |
| `public` | PlayerDetailsManager | `PlayerDetailsController` |  |  |
| `public` | RoomCustomPropertyInputfield | `InputField` |  |  |
| `public` | GameVersionOverride | `String` | **[Photon Settings]**<br>The game version override. This is one way to let the user define the gameversion, and set it properly right after we call connect to override the server settings<br>Check ConnectAndJoinRandom.cs for another example of gameversion overriding |  |
| `public` | ResetBestRegionCodeInPreferences | `Boolean` | The reset flag for best cloud ServerSettings.<br>This is one way to let the user define if bestcloud cache should be reseted when connecting. |  |
| `public` | MaxPlayers | `Int32` | **[Room Options]**<br> |  |
| `public` | PlayerTtl | `Int32` |  |  |
| `public` | EmptyRoomTtl | `Int32` |  |  |
| `public` | Plugins | `String` |  |  |
| `public` | PublishUserId | `Boolean` |  |  |
| `public` | IsVisible | `Boolean` |  |  |
| `public` | IsOpen | `Boolean` |  |  |
| `public` | CleanupCacheOnLeave | `Boolean` |  |  |
| `public` | DeleteNullProperties | `Boolean` |  |  |
| `public` | PlayerTtlField | `IntInputField` | **[Room Options UI]**<br> |  |
| `public` | EmptyRoomTtlField | `IntInputField` |  |  |
| `public` | MaxPlayersField | `IntInputField` |  |  |
| `public` | PluginsField | `StringInputField` |  |  |
| `public` | PublishUserIdField | `BoolInputField` |  |  |
| `public` | IsVisibleField | `BoolInputField` |  |  |
| `public` | IsOpenField | `BoolInputField` |  |  |
| `public` | CleanupCacheOnLeaveField | `BoolInputField` |  |  |
| `public` | DeleteNullPropertiesField | `BoolInputField` |  |  |
| `public` | FriendsList | `FriendDetail[]` | **[Friends Options]**<br> |  |
| `public` | ModalWindow | `CanvasGroup` | **[Modal window]**<br> |  |
| `public` | RegionListView | `RegionListView` |  |  |
| `public` | RegionListLoadingFeedback | `Text` |  |  |
| `private` | _lbc | `LoadBalancingClient` |  |  |
| `private` | _regionPingProcessActive | `Boolean` |  |  |
| `private` | RegionsList | `List`1` |  |  |
| `private` | roomNameToEnter | `String` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | UserId <br><small>{ get; set; }</small> | `String` | made-up username |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | SwitchtoMinimalPanel |  | `Void` |  |
| `public` | SwitchtoMaximalPanel |  | `Void` |  |
| `public` | SwitchToAdvancedConnection |  | `Void` |  |
| `public` | SwitchToSimpleConnection |  | `Void` |  |
| `public` | ToggleInfosInMinimalPanel |  | `Void` |  |
| `public` | RequestInfosPanel | GameObject Parent | `Void` |  |
| `public` | OnUserIdSubmited | String userId | `Void` |  |
| `public` | SetPlayerTtlRoomOption | Int32 value | `Void` |  |
| `public` | SetEmptyRoomTtlRoomOption | Int32 value | `Void` |  |
| `public` | SetMaxPlayersRoomOption | Int32 value | `Void` |  |
| `public` | SetPluginsRoomOption | String value | `Void` |  |
| `public` | SetPublishUserId | Boolean value | `Void` |  |
| `public` | SetIsVisible | Boolean value | `Void` |  |
| `public` | SetIsOpen | Boolean value | `Void` |  |
| `public` | SetResetBestRegionCodeInPreferences | Boolean value | `Void` |  |
| `public` | SetCleanupCacheOnLeave | Boolean value | `Void` |  |
| `public` | SetDeleteNullProperties | Boolean value | `Void` |  |
| `public` | PingRegions |  | `Void` | in progress, not fully working |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | OnStateChanged | ClientState previousState, ClientState state | `Void` |  |
| `public` | OnRegionListReceived | RegionHandler regionHandler | `Void` |  |
| `private` | OnRegionsPinged | RegionHandler regionHandler | `Void` |  |
| `public` | CloseRegionListView |  | `Void` |  |
| `public` | LoadLevel | String level | `Void` |  |
| `public` | SetRoomCustomProperty | String value | `Void` |  |
| `public` | JoinRoom | String roomName | `Void` |  |
| `public` | CreateRoom |  | `Void` |  |
| `public` | CreateRoom | String roomName, String lobbyName, LobbyType lobbyType, String[] expectedUsers | `Void` |  |
| `public` | JoinRandomRoom |  | `Void` |  |
| `public` | LeaveRoom |  | `Void` |  |
| `public` | Connect |  | `Void` |  |
| `public` | ReConnect |  | `Void` |  |
| `public` | ReconnectAndRejoin |  | `Void` |  |
| `public` | ConnectToBestCloudServer |  | `Void` |  |
| `public` | ConnectToRegion | String region | `Void` |  |
| `public` | ConnectOffline |  | `Void` |  |
| `public` | JoinLobby |  | `Void` |  |
| `public` | Disconnect |  | `Void` |  |
| `public` | OpenDashboard |  | `Void` |  |
| `public` | OnDropdownConnectAs | Int32 dropdownIndex | `Void` |  |
| `private` | OnDropdownConnectAs_CB |  | `IEnumerator` |  |
| `public` | OnLobbyToolsViewTabChanged | String tabId | `Void` |  |
| `public` | OnSelectPlayer |  | `Void` |  |
| `public` | OnConnected |  | `Void` |  |
| `public` | OnDisconnected | DisconnectCause cause | `Void` |  |
| `public` | OnConnectedToMaster |  | `Void` |  |
| `public` | OnJoinedLobby |  | `Void` |  |
| `private` | SetUpLobbyGenericUI |  | `Void` |  |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` |  |
| `public` | OnLeftLobby |  | `Void` |  |
| `public` | OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinedRoom |  | `Void` |  |
| `public` | OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `private` | GetRoomOptions |  | `RoomOptions` |  |

---

