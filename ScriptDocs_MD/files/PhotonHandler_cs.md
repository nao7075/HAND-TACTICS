# File: PhotonHandler.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/PhotonHandler.cs`

<a id='PhotonHandler'></a>
## Class PhotonHandler
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonHandler : ConnectionHandler, IMatchmakingCallbacks, IInRoomCallbacks`

> Internal MonoBehaviour that allows Photon to run an Update loop.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | instance | `PhotonHandler` |  |  |
| `public` | MaxDatagrams | `Int32` | Limits the number of datagrams that are created in each LateUpdate. |  |
| `public` | SendAsap | `Boolean` | Signals that outgoing messages should be sent in the next LateUpdate call.<br>immediately send when synchronization code was running |  |
| `private` | SerializeRateFrameCorrection | `Int32` | This corrects the "next time to serialize the state" value by some ms. |  |
| `protected internal` | UpdateInterval | `Int32` | time [ms] between consecutive SendOutgoingCommands calls |  |
| `protected internal` | UpdateIntervalOnSerialize | `Int32` | time [ms] between consecutive RunViewUpdate calls (sending syncs, etc) |  |
| `private` | swSendOutgoing | `Stopwatch` |  |  |
| `private` | swViewUpdate | `Stopwatch` |  |  |
| `private` | supportLoggerComponent | `SupportLogger` |  |  |
| `protected` | reusableIntList | `List`1` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `internal` | Instance <br><small>{ get;  }</small> | `PhotonHandler` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `protected` | ⚡ Awake |  | `Void` | Unity Event Function |
| `protected` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `protected` | ⚡ Start |  | `Void` | Unity Event Function |
| `protected` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `protected` | ⚡ FixedUpdate |  | `Void` | Called in intervals by UnityEngine. Affected by Time.timeScale. |
| `protected` | ⚡ LateUpdate |  | `Void` | Called in intervals by UnityEngine, after running the normal game code and physics. |
| `protected` | Dispatch |  | `Void` | Dispatches incoming network messages for PUN. Called in FixedUpdate or LateUpdate. |
| `public` | OnCreatedRoom |  | `Void` |  |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player targetPlayer, Hashtable changedProps | `Void` |  |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` |  |
| `public` | OnFriendListUpdate | List`1 friendList | `Void` |  |
| `public` | OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinedRoom |  | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | OnPlayerEnteredRoom | Player newPlayer | `Void` |  |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |

---

