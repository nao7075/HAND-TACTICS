# File: WebSocket.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonLibs_WebSocket.md)

> **Path:** `Assets/Photon/PhotonLibs/WebSocket/WebSocket.cs`

<a id='WebSocket'></a>
## Class WebSocket
**Namespace:** `ExitGames.Client.Photon`<br>
**Signature:** `WebSocket`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | mUrl | `Uri` |  |  |
| `private` | mProxyAddress | `String` |  |  |
| `private` | protocols | `String` | Photon uses this to agree on a serialization protocol. Either: GpBinaryV16 or GpBinaryV18. Based on enum SerializationProtocol. |  |
| `private` | m_Socket | `WebSocket` |  |  |
| `private` | m_Messages | `Queue`1` |  |  |
| `private` | m_IsConnected | `Boolean` |  |  |
| `private` | m_Error | `String` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | DebugReturn <br><small>{ get; set; }</small> | `Action`2` |  |
| `public` | ProxyAddress <br><small>{ get;  }</small> | `String` |  |
| `public` | Connected <br><small>{ get;  }</small> | `Boolean` |  |
| `public` | Error <br><small>{ get;  }</small> | `String` |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | WebSocket | Uri url, String proxyAddress, String protocols | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | SendString | String str | `Void` |  |
| `public` | RecvString |  | `String` |  |
| `public` | Connect |  | `Void` |  |
| `private` | SocketOnClose | Object sender, CloseEventArgs e | `Void` |  |
| `public` | Send | Byte[] buffer | `Void` |  |
| `public` | Recv |  | `Byte[]` |  |
| `public` | Close |  | `Void` |  |

---

