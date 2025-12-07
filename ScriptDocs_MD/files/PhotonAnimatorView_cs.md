# File: PhotonAnimatorView.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code_Views.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/Views/PhotonAnimatorView.cs`

<a id='PhotonAnimatorView'></a>
## Class PhotonAnimatorView
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonAnimatorView : MonoBehaviourPun, IPunObservable`

> This class helps you to synchronize Mecanim animations  
> Simply add the component to your GameObject and make sure that  
> the PhotonAnimatorView is added to the list of observed components

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | TriggerUsageWarningDone | `Boolean` |  |  |
| `private` | m_Animator | `Animator` |  |  |
| `private` | m_StreamQueue | `PhotonStreamQueue` |  |  |
| `private` | ShowLayerWeightsInspector | `Boolean` |  |  |
| `private` | ShowParameterInspector | `Boolean` |  |  |
| `private` | m_SynchronizeParameters | `List`1` |  |  |
| `private` | m_SynchronizeLayers | `List`1` |  |  |
| `private` | m_ReceiverPosition | `Vector3` |  |  |
| `private` | m_LastDeserializeTime | `Single` |  |  |
| `private` | m_WasSynchronizeTypeChanged | `Boolean` |  |  |
| `private` | m_raisedDiscreteTriggersCache | `List`1` | Cached raised triggers that are set to be synchronized in discrete mode. since a Trigger only stay up for less than a frame,<br>We need to cache it until the next discrete serialization call. |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | CacheDiscreteTriggers |  | `Void` | Caches the discrete triggers values for keeping track of raised triggers, and will be reseted after the sync routine got performed |
| `public` | DoesLayerSynchronizeTypeExist | Int32 layerIndex | `Boolean` | Check if a specific layer is configured to be synchronize |
| `public` | DoesParameterSynchronizeTypeExist | String name | `Boolean` | Check if the specified parameter is configured to be synchronized |
| `public` | GetSynchronizedLayers |  | `List`1` | Get a list of all synchronized layers |
| `public` | GetSynchronizedParameters |  | `List`1` | Get a list of all synchronized parameters |
| `public` | GetLayerSynchronizeType | Int32 layerIndex | `SynchronizeType` | Gets the type how the layer is synchronized |
| `public` | GetParameterSynchronizeType | String name | `SynchronizeType` | Gets the type how the parameter is synchronized |
| `public` | SetLayerSynchronized | Int32 layerIndex, SynchronizeType synchronizeType | `Void` | Sets the how a layer should be synchronized |
| `public` | SetParameterSynchronized | String name, ParameterType type, SynchronizeType synchronizeType | `Void` | Sets the how a parameter should be synchronized |
| `private` | SerializeDataContinuously |  | `Void` |  |
| `private` | DeserializeDataContinuously |  | `Void` |  |
| `private` | SerializeDataDiscretly | PhotonStream stream | `Void` |  |
| `private` | DeserializeDataDiscretly | PhotonStream stream | `Void` |  |
| `private` | SerializeSynchronizationTypeState | PhotonStream stream | `Void` |  |
| `private` | DeserializeSynchronizationTypeState | PhotonStream stream | `Void` |  |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |

---

