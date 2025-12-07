# File: PhotonPing.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/PhotonPing.cs`

<a id='PhotonPing'></a>
## Class PhotonPing
**Namespace:** `Photon.Realtime`<br>
**Signature:** `PhotonPing : IDisposable`

> Abstract implementation of PhotonPing, ase for pinging servers to find the "Best Region".

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | DebugString | `String` | Caches the last exception/error message, if any. |  |
| `public` | Successful | `Boolean` | True of the ping was successful. |  |
| `protected internal` | GotResult | `Boolean` | True if there was any result. |  |
| `protected internal` | PingLength | `Int32` | Length of a ping. |  |
| `protected internal` | PingBytes | `Byte[]` | Bytes to send in a (Photon UDP) ping. |  |
| `protected internal` | PingId | `Byte` | Randomized number to identify a ping. |  |
| `private` | RandomIdProvider | `Random` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | StartPing | String ip | `Boolean` | Begins sending a ping.<br>Sends a "Photon Ping" to a server. |
| `public` | Done |  | `Boolean` | Check if done. |
| `public` | Dispose |  | `Void` | Dispose of this ping. |
| `protected internal` | Init |  | `Void` | Initialize this ping (GotResult, Successful, PingId). |

---

