# File: AppSettings.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/AppSettings.cs`

<a id='AppSettings'></a>
## Class AppSettings
**Namespace:** `Photon.Realtime`<br>
**Signature:** `AppSettings`

> Settings for Photon application(s) and the server to connect to.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | AppIdRealtime | `String` | AppId for Realtime or PUN. |  |
| `public` | AppIdFusion | `String` | AppId for Photon Fusion. |  |
| `public` | AppIdChat | `String` | AppId for Photon Chat. |  |
| `public` | AppIdVoice | `String` | AppId for Photon Voice. |  |
| `public` | AppVersion | `String` | The AppVersion can be used to identify builds and will split the AppId distinct "Virtual AppIds" (important for matchmaking). |  |
| `public` | UseNameServer | `Boolean` | If false, the app will attempt to connect to a Master Server (which is obsolete but sometimes still necessary). |  |
| `public` | FixedRegion | `String` | Can be set to any of the Photon Cloud's region names to directly connect to that region. |  |
| `public` | BestRegionSummaryFromStorage | `String` | Set to a previous BestRegionSummary value before connecting. |  |
| `public` | Server | `String` | The address (hostname or IP) of the server to connect to. |  |
| `public` | Port | `Int32` | If not null, this sets the port of the first Photon server to connect to (that will "forward" the client as needed). |  |
| `public` | ProxyServer | `String` | The address (hostname or IP and port) of the proxy server. |  |
| `public` | Protocol | `ConnectionProtocol` | The network level protocol to use. |  |
| `public` | EnableProtocolFallback | `Boolean` | Enables a fallback to another protocol in case a connect to the Name Server fails. |  |
| `public` | AuthMode | `AuthModeOption` | Defines how authentication is done. On each system, once or once via a WSS connection (safe). |  |
| `public` | EnableLobbyStatistics | `Boolean` | If true, the client will request the list of currently available lobbies. |  |
| `public` | NetworkLogging | `DebugLevel` | Log level for the network lib. |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | IsMasterServerAddress <br><small>{ get;  }</small> | `Boolean` | If true, the Server field contains a Master Server address (if any address at all). |
| `public` | IsBestRegion <br><small>{ get;  }</small> | `Boolean` | If true, the Server field contains a Master Server address (if any address at all). |
| `public` | IsDefaultNameServer <br><small>{ get;  }</small> | `Boolean` | If true, the Server field contains a Master Server address (if any address at all). |
| `public` | IsDefaultPort <br><small>{ get;  }</small> | `Boolean` | If true, the Server field contains a Master Server address (if any address at all). |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ToStringFull |  | `String` | If true, the Server field contains a Master Server address (if any address at all). |
| `public` | S IsAppId | String val | `Boolean` | Checks if a string is a Guid by attempting to create one. |
| `private` | HideAppId | String appId | `String` |  |
| `public` | CopyTo | AppSettings d | `AppSettings` |  |

---

