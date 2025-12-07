# File: PlayerControl.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoSlotRacer_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoSlotRacer/Scripts/PlayerControl.cs`

<a id='PlayerControl'></a>
## Class PlayerControl
**Namespace:** `Photon.Pun.Demo.SlotRacer`<br>
**Signature:** `PlayerControl : MonoBehaviourPun, IPunObservable`

> Player control.  
> Interface the User Inputs and PUN  
> Handle the Car instance

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | CarPrefabs | `GameObject[]` | The car prefabs to pick depending on the grid position. |  |
| `public` | MaximumSpeed | `Single` | The maximum speed. Maximum speed is reached with a 1 unit per seconds acceleration |  |
| `public` | Drag | `Single` | The drag when user is not accelerating |  |
| `private` | CurrentSpeed | `Single` | The current speed.<br>Only used for locaPlayer |  |
| `private` | CurrentDistance | `Single` | The current distance on the spline<br>Only used for locaPlayer |  |
| `private` | CarInstance | `GameObject` | The car instance. |  |
| `private` | SplineWalker | `SplineWalker` | The spline walker. Must be on this GameObject |  |
| `private` | m_firstTake | `Boolean` | flag to force latest data to avoid initial drifts when player is instantiated. |  |
| `private` | m_input | `Single` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | Photon.Pun.IPunObservable.OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |
| `private` | SetupCarOnTrack | Int32 gridStartIndex | `Void` | Setups the car on track. |
| `private` | ⚡ Awake |  | `Void` | Cache the SplineWalker and flag context for clean serialization when joining late. |
| `private` | ⚡ Start |  | `IEnumerator` | Start this instance as a coroutine<br>Waits for a Playernumber to be assigned and only then setup the car and put it on the right starting position on the lane. |
| `private` | ⚡ OnDestroy |  | `Void` | Make sure we delete instances linked to this component, else when user is leaving the room, its car instance would remain |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |

---

