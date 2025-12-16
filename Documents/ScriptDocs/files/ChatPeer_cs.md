# File: ChatPeer.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonChat_Code.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatPeer.cs`

<a id='ChatPeer'></a>
## Class ChatPeer
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatPeer : PhotonPeer`

> Provides basic operations of the Photon Chat server. This internal class is used by public ChatClient.  
> Chat Peer constructor.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | NameServerHost | `String` | Name Server Host Name for Photon Cloud. Without port and without any prefix. |  |
| `private` | ProtocolToNameServerPort | `Dictionary`2` | Name Server port per protocol (the UDP port is different than TCP, etc). |  |
| `public` | NameServerPortOverride | `UInt16` | If not zero, this is used for the name server port on connect. Independent of protocol (so this better matches). Set by ChatClient.ConnectUsingSettings. |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | NameServerAddress <br><small>{ get;  }</small> | `String` | Name Server Address for Photon Cloud (based on current protocol). You can use the default values and usually won't have to set this value. |
| `internal` | IsProtocolSecure <br><small>{ get;  }</small> | `Boolean` |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | ChatPeer | IPhotonPeerListener listener, ConnectionProtocol protocol | Constructor |
| `private` | ChatPeer |  | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ConfigUnitySockets |  | `Void` |  |
| `private` | GetNameServerAddress |  | `String` | Gets the NameServer Address (with prefix and port), based on the set protocol (this.UsedProtocol). |
| `public` | AuthenticateOnNameServer | String appId, String appVersion, String region, AuthenticationValues authValues | `Boolean` | Authenticates on NameServer. |

---

