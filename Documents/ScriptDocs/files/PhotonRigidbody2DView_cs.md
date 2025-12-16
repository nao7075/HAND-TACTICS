# File: PhotonRigidbody2DView.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code_Views.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/Views/PhotonRigidbody2DView.cs`

<a id='PhotonRigidbody2DView'></a>
## Class PhotonRigidbody2DView
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonRigidbody2DView : MonoBehaviourPun, IPunObservable`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_Distance | `Single` |  |  |
| `private` | m_Angle | `Single` |  |  |
| `private` | m_Body | `Rigidbody2D` |  |  |
| `private` | m_NetworkPosition | `Vector2` |  |  |
| `private` | m_NetworkRotation | `Single` |  |  |
| `public` | m_SynchronizeVelocity | `Boolean` |  |  |
| `public` | m_SynchronizeAngularVelocity | `Boolean` |  |  |
| `public` | m_TeleportEnabled | `Boolean` |  |  |
| `public` | m_TeleportIfDistanceGreaterThan | `Single` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ FixedUpdate |  | `Void` | Unity Event Function |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |

---

