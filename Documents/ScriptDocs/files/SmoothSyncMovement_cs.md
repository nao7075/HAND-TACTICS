# File: SmoothSyncMovement.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_PhotonView.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonView/SmoothSyncMovement.cs`

<a id='SmoothSyncMovement'></a>
## Class SmoothSyncMovement
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `SmoothSyncMovement : MonoBehaviourPun, IPunObservable`

> Smoothed out movement for network gameobjects

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | SmoothingDelay | `Single` |  |  |
| `private` | correctPlayerPos | `Vector3` | We lerp towards this |  |
| `private` | correctPlayerRot | `Quaternion` | We lerp towards this |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |

---

