# File: ChatAppSettings.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonChat_Code.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatAppSettings.cs`

<a id='ChatAppSettings'></a>
## Class ChatAppSettings
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatAppSettings`

> Settings for Photon application(s) and the server to connect to.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | AppIdChat | `String` | AppId for the Chat Api. |  |
| `public` | AppVersion | `String` | The AppVersion can be used to identify builds and will split the AppId distinct "Virtual AppIds" (important for the users to find each other). |  |
| `public` | FixedRegion | `String` | Can be set to any of the Photon Cloud's region names to directly connect to that region. |  |
| `public` | Server | `String` | The address (hostname or IP) of the server to connect to. |  |
| `public` | Port | `UInt16` | If not null, this sets the port of the first Photon server to connect to (that will "forward" the client as needed). |  |
| `public` | ProxyServer | `String` | The address (hostname or IP and port) of the proxy server. |  |
| `public` | Protocol | `ConnectionProtocol` | The network level protocol to use. |  |
| `public` | EnableProtocolFallback | `Boolean` | Enables a fallback to another protocol in case a connect to the Name Server fails. |  |
| `public` | NetworkLogging | `DebugLevel` | Log level for the network lib. |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | IsDefaultNameServer <br><small>{ get;  }</small> | `Boolean` | If true, the default nameserver address for the Photon Cloud should be used. |

---

