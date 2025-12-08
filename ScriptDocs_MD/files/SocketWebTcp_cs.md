# File: SocketWebTcp.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonLibs_WebSocket.md)

> **Path:** `Assets/Photon/PhotonLibs/WebSocket/SocketWebTcp.cs`

<a id='SocketWebTcp'></a>
## Class SocketWebTcp
**Namespace:** `ExitGames.Client.Photon`<br>
**Signature:** `SocketWebTcp : IPhotonSocket, IDisposable`

> Internal class to encapsulate the network i/o functionality for the realtime libary.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | sock | `WebSocket` |  |  |
| `private` | syncer | `Object` |  |  |
| `private` | websocketConnectionObject | `GameObject` |  |  |
| `internal` | ALL_HEADER_BYTES | `Int32` |  |  |
| `internal` | TCP_HEADER_BYTES | `Int32` |  |  |
| `internal` | MSG_HEADER_BYTES | `Int32` |  |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | SocketWebTcp | PeerBase npeer | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | Dispose |  | `Void` |  |
| `public` | Connect |  | `Boolean` |  |
| `private` | ReadProxyConfigScheme | String proxyAddress, String url, String& proxyUrl | `Boolean` | Attempts to read a proxy configuration defined by a address prefix. Only available to Industries Circle members on demand. |
| `public` | Disconnect |  | `Boolean` |  |
| `public` | Send | Byte[] data, Int32 length | `PhotonSocketError` | used by TPeer* |
| `public` | Receive | Byte[]& data | `PhotonSocketError` |  |
| `public` | ReceiveLoop |  | `IEnumerator` |  |

---

