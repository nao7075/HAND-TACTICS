# File: ConnectionHandler.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/ConnectionHandler.cs`

<a id='ConnectionHandler'></a>
## Class ConnectionHandler
**Namespace:** `Photon.Realtime`<br>
**Signature:** `ConnectionHandler : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | DisconnectAfterKeepAlive | `Boolean` | Option to let the fallback thread call Disconnect after the KeepAliveInBackground time. Default: false. |  |
| `public` | KeepAliveInBackground | `Int32` | Defines for how long the Fallback Thread should keep the connection, before it may time out as usual. |  |
| `public` | ApplyDontDestroyOnLoad | `Boolean` | True if a fallback thread is running. Will call the client's SendAcksOnly() method to keep the connection up. |  |
| `public` | AppQuits | `Boolean` | Indicates that the app is closing. Set in OnApplicationQuit(). |  |
| `public` | AppPause | `Boolean` |  |  |
| `public` | AppPauseRecent | `Boolean` |  |  |
| `public` | AppOutOfFocus | `Boolean` |  |  |
| `public` | AppOutOfFocusRecent | `Boolean` |  |  |
| `private` | fallbackThreadId | `Byte` |  |  |
| `private` | didSendAcks | `Boolean` |  |  |
| `private` | backgroundStopwatch | `Stopwatch` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Client <br><small>{ get; set; }</small> | `LoadBalancingClient` | Photon client to log information and statistics from. |
| `public` | CountSendAcksOnly <br><small>{ get; set; }</small> | `Int32` | Counts how often the Fallback Thread called SendAcksOnly, which is purely of interest to monitor if the game logic called SendOutgoingCommands as intended. |
| `public` | FallbackThreadRunning <br><small>{ get;  }</small> | `Boolean` | True if a fallback thread is running. Will call the client's SendAcksOnly() method to keep the connection up. |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | S StaticReset |  | `Void` | Resets statics for Domain Reload |
| `protected` | ⚡ Awake |  | `Void` | Unity Event Function |
| `protected` | ⚡ OnDisable |  | `Void` | Called by Unity when the application gets closed. Disconnects if OnApplicationQuit() was called before. |
| `public` | OnApplicationQuit |  | `Void` | Called by Unity when the application gets closed. The UnityEngine will also call OnDisable, which disconnects. |
| `public` | OnApplicationPause | Boolean pause | `Void` | Called by Unity when the application gets paused or resumed. |
| `private` | ResetAppPauseRecent |  | `Void` |  |
| `public` | OnApplicationFocus | Boolean focus | `Void` | Called by Unity when the application changes focus. |
| `private` | ResetAppOutOfFocusRecent |  | `Void` |  |
| `public` | S IsNetworkReachableUnity |  | `Boolean` | When run in Unity, this returns Application.internetReachability != NetworkReachability.NotReachable. |
| `public` | StartFallbackSendAckThread |  | `Void` |  |
| `public` | StopFallbackSendAckThread |  | `Void` |  |
| `public` | RealtimeFallbackThread |  | `Boolean` | A thread which runs independent from the Update() calls. Keeps connections online while loading or in background. See . |

---

