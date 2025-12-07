# File: CullingHandler.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Culling/CullingHandler.cs`

<a id='CullingHandler'></a>
## Class CullingHandler
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `CullingHandler : MonoBehaviour, IPunObservable`

> Handles the network culling.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | orderIndex | `Int32` |  |  |
| `private` | cullArea | `CullArea` |  |  |
| `private` | previousActiveCells | `List`1` |  |  |
| `private` | activeCells | `List`1` |  |  |
| `private` | pView | `PhotonView` |  |  |
| `private` | lastPosition | `Vector3` |  |  |
| `private` | currentPosition | `Vector3` |  |  |
| `private` | timeSinceUpdate | `Single` |  |  |
| `private` | timeBetweenUpdatesMin | `Single` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ OnEnable |  | `Void` | Gets references to the PhotonView component and the cull area game object. |
| `private` | ⚡ Start |  | `Void` | Initializes the right interest group or prepares the permanent change of the interest Group of the PhotonView component. |
| `private` | ⚡ Update |  | `Void` | Checks if the player has moved previously and updates the interest groups if necessary. |
| `private` | ⚡ OnGUI |  | `Void` | Drawing informations. |
| `private` | HaveActiveCellsChanged |  | `Boolean` | Checks if the previously active cells have changed. |
| `private` | UpdateInterestGroups |  | `Void` | Unsubscribes from old and subscribes to new interest groups. |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` | This time OnPhotonSerializeView is not used to send or receive any kind of data.<br>It is used to change the currently active group of the PhotonView component, making it work together with PUN more directly.<br>Keep in mind that this function is only executed, when there is at least one more player in the room. |

---

