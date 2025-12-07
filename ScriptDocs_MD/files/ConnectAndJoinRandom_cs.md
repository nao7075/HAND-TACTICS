# File: ConnectAndJoinRandom.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Prototyping/ConnectAndJoinRandom.cs`

<a id='ConnectAndJoinRandom'></a>
## Class ConnectAndJoinRandom
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `ConnectAndJoinRandom : MonoBehaviourPunCallbacks`

> Simple component to call ConnectUsingSettings and to get into a PUN room easily.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | AutoConnect | `Boolean` | Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts. |  |
| `public` | Version | `Byte` | Used as PhotonNetwork.GameVersion. |  |
| `public` | MaxPlayers | `Byte` | Max number of players allowed in room. Once full, a new room will be created by the next connection attemping to join. |  |
| `public` | playerTTL | `Int32` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ConnectNow |  | `Void` |  |
| `public` | OnConnectedToMaster |  | `Void` |  |
| `public` | OnJoinedLobby |  | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnDisconnected | DisconnectCause cause | `Void` |  |
| `public` | OnJoinedRoom |  | `Void` |  |

---

