# File: ConnectAndJoinRandomLb.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Demos_DemoLoadBalancing.md)

> **Path:** `Assets/Photon/PhotonRealtime/Demos/DemoLoadBalancing/ConnectAndJoinRandomLb.cs`

<a id='ConnectAndJoinRandomLb'></a>
## Class ConnectAndJoinRandomLb
**Namespace:** `Photon.Realtime.Demo`<br>
**Signature:** `ConnectAndJoinRandomLb : MonoBehaviour, IConnectionCallbacks, ILobbyCallbacks, IMatchmakingCallbacks`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | appSettings | `AppSettings` |  |  |
| `private` | lbc | `LoadBalancingClient` |  |  |
| `private` | ch | `ConnectionHandler` |  |  |
| `public` | StateUiText | `Text` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | OnConnected |  | `Void` |  |
| `public` | OnConnectedToMaster |  | `Void` |  |
| `public` | OnDisconnected | DisconnectCause cause | `Void` |  |
| `public` | OnCustomAuthenticationResponse | Dictionary`2 data | `Void` |  |
| `public` | OnCustomAuthenticationFailed | String debugMessage | `Void` |  |
| `public` | OnRegionListReceived | RegionHandler regionHandler | `Void` |  |
| `public` | OnRoomListUpdate | List`1 roomList | `Void` |  |
| `public` | OnLobbyStatisticsUpdate | List`1 lobbyStatistics | `Void` |  |
| `public` | OnJoinedLobby |  | `Void` |  |
| `public` | OnLeftLobby |  | `Void` |  |
| `public` | OnFriendListUpdate | List`1 friendList | `Void` |  |
| `public` | OnCreatedRoom |  | `Void` |  |
| `public` | OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinedRoom |  | `Void` |  |
| `public` | OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `private` | OnRegionPingCompleted | RegionHandler regionHandler | `Void` | A callback of the RegionHandler, provided in OnRegionListReceived. |

---

