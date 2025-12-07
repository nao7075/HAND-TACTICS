# File: PhotonStreamQueue.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/PhotonStreamQueue.cs`

<a id='PhotonStreamQueue'></a>
## Class PhotonStreamQueue
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonStreamQueue`

> The PhotonStreamQueue helps you poll object states at higher frequencies than what  
> PhotonNetwork.SendRate dictates and then sends all those states at once when  
> Serialize() is called.  
> On the receiving end you can call Deserialize() and then the stream will roll out  
> the received object states in the same order and timeStep they were recorded in.  
> Initializes a new instance of the  class.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_SampleRate | `Int32` |  |  |
| `private` | m_SampleCount | `Int32` |  |  |
| `private` | m_ObjectsPerSample | `Int32` |  |  |
| `private` | m_LastSampleTime | `Single` |  |  |
| `private` | m_LastFrameCount | `Int32` |  |  |
| `private` | m_NextObjectIndex | `Int32` |  |  |
| `private` | m_Objects | `List`1` |  |  |
| `private` | m_IsWriting | `Boolean` |  |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | PhotonStreamQueue | Int32 sampleRate | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | BeginWritePackage |  | `Void` |  |
| `public` | ⚡ Reset |  | `Void` | Resets the PhotonStreamQueue. You need to do this whenever the amount of objects you are observing changes |
| `public` | SendNext | Object obj | `Void` | Adds the next object to the queue. This works just like PhotonStream.SendNext |
| `public` | HasQueuedObjects |  | `Boolean` | Determines whether the queue has stored any objects |
| `public` | ReceiveNext |  | `Object` | Receives the next object from the queue. This works just like PhotonStream.ReceiveNext |
| `public` | Serialize | PhotonStream stream | `Void` | Serializes the specified stream. Call this in your OnPhotonSerializeView method to send the whole recorded stream. |
| `public` | Deserialize | PhotonStream stream | `Void` | Deserializes the specified stream. Call this in your OnPhotonSerializeView method to receive the whole recorded stream. |

---

