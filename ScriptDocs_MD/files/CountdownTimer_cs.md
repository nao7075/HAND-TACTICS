# File: CountdownTimer.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Room/CountdownTimer.cs`

<a id='CountdownTimer'></a>
## Class CountdownTimer
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `CountdownTimer : MonoBehaviourPunCallbacks`

> This is a basic, network-synced CountdownTimer based on properties.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | CountdownStartTime | `String` |  |  |
| `public` | Countdown | `Single` | **[Countdown time in seconds]**<br> |  |
| `private` | isTimerRunning | `Boolean` |  |  |
| `private` | startTime | `Int32` |  |  |
| `public` | Text | `Text` | **[Reference to a Text component for visualizing the countdown]**<br> |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | OnTimerRuns |  | `Void` |  |
| `private` | OnTimerEnds |  | `Void` |  |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` |  |
| `private` | Initialize |  | `Void` |  |
| `private` | TimeRemaining |  | `Single` |  |
| `public` | S TryGetStartTime | Int32& startTimestamp | `Boolean` |  |
| `public` | S SetStartTime |  | `Void` |  |

---

