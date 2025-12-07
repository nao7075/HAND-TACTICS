# File: CameraController.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_TextMesh_Pro_Examples_&_Extras_Scripts.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/CameraController.cs`

<a id='CameraController'></a>
## Class CameraController
**Namespace:** `TMPro.Examples`<br>
**Signature:** `CameraController : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | cameraTransform | `Transform` |  |  |
| `private` | dummyTarget | `Transform` |  |  |
| `public` | CameraTarget | `Transform` |  |  |
| `public` | FollowDistance | `Single` |  |  |
| `public` | MaxFollowDistance | `Single` |  |  |
| `public` | MinFollowDistance | `Single` |  |  |
| `public` | ElevationAngle | `Single` |  |  |
| `public` | MaxElevationAngle | `Single` |  |  |
| `public` | MinElevationAngle | `Single` |  |  |
| `public` | OrbitalAngle | `Single` |  |  |
| `public` | CameraMode | `CameraModes` |  |  |
| `public` | MovementSmoothing | `Boolean` |  |  |
| `public` | RotationSmoothing | `Boolean` |  |  |
| `private` | previousSmoothing | `Boolean` |  |  |
| `public` | MovementSmoothingValue | `Single` |  |  |
| `public` | RotationSmoothingValue | `Single` |  |  |
| `public` | MoveSensitivity | `Single` |  |  |
| `private` | currentVelocity | `Vector3` |  |  |
| `private` | desiredPosition | `Vector3` |  |  |
| `private` | mouseX | `Single` |  |  |
| `private` | mouseY | `Single` |  |  |
| `private` | moveVector | `Vector3` |  |  |
| `private` | mouseWheel | `Single` |  |  |
| `private` | event_SmoothingValue | `String` |  |  |
| `private` | event_FollowDistance | `String` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | ⚡ LateUpdate |  | `Void` | Unity Event Function |
| `private` | GetPlayerInput |  | `Void` |  |

---

