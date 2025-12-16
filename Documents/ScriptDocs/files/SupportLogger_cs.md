# File: SupportLogger.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/SupportLogger.cs`

<a id='SupportLogger'></a>
## Class SupportLogger
**Namespace:** `Photon.Realtime`<br>
**Signature:** `SupportLogger : MonoBehaviour, IConnectionCallbacks, ILobbyCallbacks, IMatchmakingCallbacks, IInRoomCallbacks, IErrorInfoCallback`

> Helper class to debug log basic information about Photon client and vital traffic statistics.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | LogTrafficStats | `Boolean` | Toggle to enable or disable traffic statistics logging. |  |
| `private` | client | `LoadBalancingClient` |  |  |
| `private` | startStopwatch | `Stopwatch` |  |  |
| `private` | initialOnApplicationPauseSkipped | `Boolean` |  |  |
| `private` | pingMax | `Int32` |  |  |
| `private` | pingMin | `Int32` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Client <br><small>{ get; set; }</small> | `LoadBalancingClient` | Photon client to log information and statistics from. |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `protected` | ⚡ Start |  | `Void` | Unity Event Function |
| `protected` | ⚡ OnDestroy |  | `Void` | Unity Event Function |
| `protected` | OnApplicationPause | Boolean pause | `Void` |  |
| `protected` | OnApplicationQuit |  | `Void` |  |
| `public` | StartLogStats |  | `Void` |  |
| `public` | StopLogStats |  | `Void` |  |
| `private` | StartTrackValues |  | `Void` |  |
| `private` | StopTrackValues |  | `Void` |  |
| `private` | GetFormattedTimestamp |  | `String` |  |
| `private` | TrackValues |  | `Void` |  |
| `public` | LogStats |  | `Void` | Debug logs vital traffic statistics about the attached Photon Client. |
| `private` | LogBasics |  | `Void` | Debug logs basic information (AppId, AppVersion, PeerID, Server address, Region) about the attached Photon Client. |
| `public` | OnConnected |  | `Void` |  |
| `public` | OnConnectedToMaster |  | `Void` |  |
| `public` | OnFriendListUpdate | List`1 friendList | `Void` |  |
| `public` | OnJoinedLobby |  | `Void` |  |
| `public` | OnLeftLobby |  | `Void` |  |
| `public` | OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinedRoom |  | `Void` |  |
| `public` | OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnCreatedRoom |  | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | OnDisconnected | DisconnectCause cause | `Void` |  |
| `public` | OnRegionListReceived | RegionHandler regionHandler | `Void` |  |
| `public` | OnRoomListUpdate | List`1 roomList | `Void` |  |
| `public` | OnPlayerEnteredRoom | Player newPlayer | `Void` |  |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player targetPlayer, Hashtable changedProps | `Void` |  |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` |  |
| `public` | OnCustomAuthenticationResponse | Dictionary`2 data | `Void` |  |
| `public` | OnCustomAuthenticationFailed | String debugMessage | `Void` |  |
| `public` | OnLobbyStatisticsUpdate | List`1 lobbyStatistics | `Void` |  |
| `public` | OnErrorInfo | ErrorInfo errorInfo | `Void` |  |

---

