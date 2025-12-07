# File: PhotonRigidbodyView.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/Views/PhotonRigidbodyView.cs`

<a id='PhotonRigidbodyView'></a>
## Class PhotonRigidbodyView
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonRigidbodyView : MonoBehaviourPun, IPunObservable`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_Distance | `Single` |  |  |
| `private` | m_Angle | `Single` |  |  |
| `private` | m_Body | `Rigidbody` |  |  |
| `private` | m_NetworkPosition | `Vector3` |  |  |
| `private` | m_NetworkRotation | `Quaternion` |  |  |
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

