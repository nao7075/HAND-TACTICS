# File: CountdownTimer.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_Room.md)

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
| | **【Countdown time in seconds】** | | | |
| `public` | Countdown | `Single` |  |  |
| `private` | isTimerRunning | `Boolean` |  |  |
| `private` | startTime | `Int32` |  |  |
| | **【Reference to a Text component for visualizing the countdown】** | | | |
| `public` | Text | `Text` |  |  |

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

