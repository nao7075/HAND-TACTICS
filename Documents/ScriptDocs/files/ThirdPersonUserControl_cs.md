# File: ThirdPersonUserControl.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_Shared_Assets_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/Shared Assets/Scripts/ThirdPersonUserControl.cs`

<a id='ThirdPersonUserControl'></a>
## Class ThirdPersonUserControl
**Namespace:** `UnityStandardAssets.Characters.ThirdPerson.PunDemos`<br>
**Signature:** `ThirdPersonUserControl : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_Character | `ThirdPersonCharacter` | A reference to the ThirdPersonCharacter on the object |  |
| `private` | m_Cam | `Transform` | A reference to the main camera in the scenes transform |  |
| `private` | m_CamForward | `Vector3` | The current forward direction of the camera |  |
| `private` | m_Move | `Vector3` |  |  |
| `private` | m_Jump | `Boolean` | the world-relative desired move direction, calculated from the camForward and user input. |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | ⚡ FixedUpdate |  | `Void` | Unity Event Function |

---

