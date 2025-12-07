# File: PunTurnManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/TurnBased/PunTurnManager.cs`

<a id='PunTurnManager'></a>
## Class PunTurnManager
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `PunTurnManager : MonoBehaviourPunCallbacks, IOnEventCallback`

> Pun turnBased Game manager.  
> Provides an Interface (IPunTurnManagerCallbacks) for the typical turn flow and logic, between players  
> Provides Extensions for Player, Room and RoomInfo to feature dedicated api for TurnBased Needs

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | sender | `Player` | External definition for better garbage collection management, used in ProcessEvent. |  |
| `public` | TurnDuration | `Single` | The duration of the turn in seconds. |  |
| `public` | TurnManagerListener | `IPunTurnManagerCallbacks` | Gets the elapsed time in the current turn in seconds |  |
| `private` | finishedPlayers | `HashSet`1` | The finished players. |  |
| `public` | TurnManagerEventOffset | `Byte` | The turn manager event offset event message byte. Used internaly for defining data in Room Custom Properties |  |
| `public` | EvMove | `Byte` | The Move event message byte. Used internaly for saving data in Room Custom Properties |  |
| `public` | EvFinalMove | `Byte` | The Final Move event message byte. Used internaly for saving data in Room Custom Properties |  |
| `private` | _isOverCallProcessed | `Boolean` | Wraps accessing the "turn" custom properties of a room. |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Turn <br><small>{ get; set; }</small> | `Int32` | Wraps accessing the "turn" custom properties of a room.<br>note: this will set a property in the room, which is available to the other players. |
| `public` | ElapsedTimeInTurn <br><small>{ get;  }</small> | `Single` | Gets the elapsed time in the current turn in seconds |
| `public` | RemainingSecondsInTurn <br><small>{ get;  }</small> | `Single` | Gets the elapsed time in the current turn in seconds |
| `public` | IsCompletedByAll <br><small>{ get;  }</small> | `Boolean` | Gets the elapsed time in the current turn in seconds |
| `public` | IsFinishedByMe <br><small>{ get;  }</small> | `Boolean` | Gets the elapsed time in the current turn in seconds |
| `public` | IsOver <br><small>{ get;  }</small> | `Boolean` | Gets the elapsed time in the current turn in seconds |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | BeginTurn |  | `Void` | Tells the TurnManager to begins a new turn. |
| `public` | SendMove | Object move, Boolean finished | `Void` | Call to send an action. Optionally finish the turn, too.<br>The move object can be anything. Try to optimize though and only send the strict minimum set of information to define the turn move. |
| `public` | GetPlayerFinishedTurn | Player player | `Boolean` | Gets if the player finished the current turn. |
| `private` | ProcessOnEvent | Byte eventCode, Object content, Int32 senderId | `Void` |  |
| `public` | OnEvent | EventData photonEvent | `Void` | Called by PhotonNetwork.OnEventCall registration |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` | Called by PhotonNetwork |

---

