# File: PhotonTransformView.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/Views/PhotonTransformView.cs`

<a id='PhotonTransformView'></a>
## Class PhotonTransformView
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonTransformView : MonoBehaviourPun, IPunObservable`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_Distance | `Single` |  |  |
| `private` | m_Angle | `Single` |  |  |
| `private` | m_Direction | `Vector3` |  |  |
| `private` | m_NetworkPosition | `Vector3` |  |  |
| `private` | m_StoredPosition | `Vector3` |  |  |
| `private` | m_NetworkRotation | `Quaternion` |  |  |
| `public` | m_SynchronizePosition | `Boolean` |  |  |
| `public` | m_SynchronizeRotation | `Boolean` |  |  |
| `public` | m_SynchronizeScale | `Boolean` |  |  |
| `public` | m_UseLocal | `Boolean` |  |  |
| `private` | m_firstTake | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Reset |  | `Void` | Unity Event Function |
| `private` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |

---

