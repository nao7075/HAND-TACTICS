# File: BezierSpline.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoSlotRacer/Scripts/BezierCurve/BezierSpline.cs`

<a id='BezierSpline'></a>
## Class BezierSpline
**Namespace:** `Photon.Pun.Demo.SlotRacer.Utils`<br>
**Signature:** `BezierSpline : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | points | `Vector3[]` |  |  |
| `private` | lengths | `Single[]` |  |  |
| `private` | lengthsTime | `Single[]` |  |  |
| `public` | TotalLength | `Single` |  |  |
| `private` | modes | `BezierControlPointMode[]` |  |  |
| `private` | loop | `Boolean` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Loop <br><small>{ get; set; }</small> | `Boolean` |  |
| `public` | ControlPointCount <br><small>{ get;  }</small> | `Int32` |  |
| `public` | CurveCount <br><small>{ get;  }</small> | `Int32` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | GetControlPoint | Int32 index | `Vector3` |  |
| `public` | SetControlPoint | Int32 index, Vector3 point | `Void` |  |
| `public` | GetControlPointMode | Int32 index | `BezierControlPointMode` |  |
| `public` | SetControlPointMode | Int32 index, BezierControlPointMode mode | `Void` |  |
| `private` | EnforceMode | Int32 index | `Void` |  |
| `public` | GetPoint | Single t | `Vector3` |  |
| `public` | GetVelocity | Single t | `Vector3` |  |
| `public` | GetDirection | Single t | `Vector3` |  |
| `public` | AddCurve |  | `Void` |  |
| `public` | ⚡ Reset |  | `Void` | Unity Event Function |
| `public` | ComputeLengths |  | `Void` |  |
| `public` | GetPositionAtDistance | Single distance, Boolean reverse | `Vector3` |  |

---

