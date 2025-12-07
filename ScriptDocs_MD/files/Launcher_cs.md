# File: Launcher.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_PunBasics-Tutorial_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts/Launcher.cs`

<a id='Launcher'></a>
## Class Launcher
**Namespace:** `Photon.Pun.Demo.PunBasics`<br>
**Signature:** `Launcher : MonoBehaviourPunCallbacks`

> Launch manager. Connect, join a random room or create one if none or all full.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | controlPanel | `GameObject` |  |  |
| `private` | feedbackText | `Text` |  |  |
| `private` | maxPlayersPerRoom | `Byte` |  |  |
| `private` | loaderAnime | `LoaderAnime` |  |  |
| `private` | isConnecting | `Boolean` | Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,<br>we need to keep track of this to properly adjust the behavior when we receive call back by Photon.<br>Typically this is used for the OnConnectedToMaster() callback. |  |
| `private` | gameVersion | `String` | This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes). |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | MonoBehaviour method called on GameObject by Unity during early initialization phase. |
| `public` | Connect |  | `Void` | Start the connection process.<br>- If already connected, we attempt joining a random room<br>- if not yet connected, Connect this application instance to Photon Cloud Network |
| `private` | LogFeedback | String message | `Void` | Logs the feedback in the UI view for the player, as opposed to inside the Unity Editor for the developer. |
| `public` | OnConnectedToMaster |  | `Void` | Called after the connection to the master is established and authenticated |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` | Called when a JoinRandom() call failed. The parameter provides ErrorCode and message. |
| `public` | OnDisconnected | DisconnectCause cause | `Void` | Called after disconnecting from the Photon server. |
| `public` | OnJoinedRoom |  | `Void` | Called when entering a room (by creating or joining it). Called on all clients (including the Master Client). |

---

