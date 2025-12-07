# File: CameraWork.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts/CameraWork.cs`

<a id='CameraWork'></a>
## Class CameraWork
**Namespace:** `Photon.Pun.Demo.PunBasics`<br>
**Signature:** `CameraWork : MonoBehaviour`

> Camera work. Follow a target

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | distance | `Single` |  |  |
| `private` | height | `Single` |  |  |
| `private` | centerOffset | `Vector3` |  |  |
| `private` | followOnStart | `Boolean` |  |  |
| `private` | smoothSpeed | `Single` |  |  |
| `private` | cameraTransform | `Transform` |  |  |
| `private` | isFollowing | `Boolean` |  |  |
| `private` | cameraOffset | `Vector3` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | MonoBehaviour method called on GameObject by Unity during initialization phase |
| `private` | ⚡ LateUpdate |  | `Void` | Unity Event Function |
| `public` | OnStartFollowing |  | `Void` | Raises the start following event.<br>Use this when you don't know at the time of editing what to follow, typically instances managed by the photon network. |
| `private` | Follow |  | `Void` | Follow the target smoothly |
| `private` | Cut |  | `Void` |  |

---

