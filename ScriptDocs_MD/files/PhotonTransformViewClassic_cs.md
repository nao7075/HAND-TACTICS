# File: PhotonTransformViewClassic.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code_Views.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/Views/PhotonTransformViewClassic.cs`

<a id='PhotonTransformViewClassic'></a>
## Class PhotonTransformViewClassic
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonTransformViewClassic : MonoBehaviourPun, IPunObservable`

> This class helps you to synchronize position, rotation and scale  
> of a GameObject. It also gives you many different options to make  
> the synchronized values appear smooth, even when the data is only  
> send a couple of times per second.  
> Simply add the component to your GameObject and make sure that  
> the PhotonTransformViewClassic is added to the list of observed components

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | m_PositionModel | `PhotonTransformViewPositionModel` |  |  |
| `public` | m_RotationModel | `PhotonTransformViewRotationModel` |  |  |
| `public` | m_ScaleModel | `PhotonTransformViewScaleModel` |  |  |
| `private` | m_PositionControl | `PhotonTransformViewPositionControl` |  |  |
| `private` | m_RotationControl | `PhotonTransformViewRotationControl` |  |  |
| `private` | m_ScaleControl | `PhotonTransformViewScaleControl` |  |  |
| `private` | m_PhotonView | `PhotonView` |  |  |
| `private` | m_ReceivedNetworkUpdate | `Boolean` |  |  |
| `private` | m_firstTake | `Boolean` | Flag to skip initial data when Object is instantiated and rely on the first deserialized data instead. |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | UpdatePosition |  | `Void` | Calculates the new position based on the values setup in the inspector |
| `private` | UpdateRotation |  | `Void` |  |
| `private` | UpdateScale |  | `Void` |  |
| `public` | SetSynchronizedValues | Vector3 speed, Single turnSpeed | `Void` | These values are synchronized to the remote objects if the interpolation mode<br>or the extrapolation mode SynchronizeValues is used. Your movement script should pass on<br>the current speed (in units/second) and turning speed (in angles/second) so the remote<br>object can use them to predict the objects movement. |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |

---

