# File: SystemConnectionSummary.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/SystemConnectionSummary.cs`

<a id='SystemConnectionSummary'></a>
## Class SystemConnectionSummary
**Namespace:** `Photon.Realtime`<br>
**Signature:** `SystemConnectionSummary`

> The SystemConnectionSummary (SBS) is useful to analyze low level connection issues in Unity. This requires a ConnectionHandler in the scene.  
> Creates a SystemConnectionSummary for an incident of a local LoadBalancingClient. This gets used automatically by the LoadBalancingClient!  
> Creates a SystemConnectionSummary instance from an int (reversing ToInt()). This can then be turned into a string again.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Version | `Byte` | 28 and up. 4 bits. |  |
| `public` | UsedProtocol | `Byte` | 25 and up. 3 bits. |  |
| `public` | AppQuits | `Boolean` |  |  |
| `public` | AppPause | `Boolean` |  |  |
| `public` | AppPauseRecent | `Boolean` |  |  |
| `public` | AppOutOfFocus | `Boolean` |  |  |
| `public` | AppOutOfFocusRecent | `Boolean` |  |  |
| `public` | NetworkReachable | `Boolean` |  |  |
| `public` | ErrorCodeFits | `Boolean` |  |  |
| `public` | ErrorCodeWinSock | `Boolean` |  |  |
| `public` | SocketErrorCode | `Int32` |  |  |
| `private` | ProtocolIdToName | `String[]` |  |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | SystemConnectionSummary | LoadBalancingClient client | Constructor |
| `public` | SystemConnectionSummary | Int32 summary | Constructor |
| `private` | SystemConnectionSummary |  | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ToInt |  | `Int32` | Turns the SystemConnectionSummary into an integer, which can be be used for analytics purposes. It contains a lot of info and can be used to instantiate a new SystemConnectionSummary. |
| `public` | ToString |  | `String` | A readable debug log string of the context for network problems. |
| `public` | S GetBit | Int32& value, Int32 bitpos | `Boolean` |  |
| `public` | S GetBits | Int32& value, Int32 bitpos, Byte mask | `Byte` |  |
| `public` | S SetBit | Int32& value, Boolean bitval, Int32 bitpos | `Void` | Applies bitval to bitpos (no matter value's initial bit value). |
| `public` | S SetBits | Int32& value, Byte bitvals, Int32 bitpos | `Void` | Applies bitvals via OR operation (expects bits in value to be 0 initially). |

---

