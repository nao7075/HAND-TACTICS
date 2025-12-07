# File: PhotonView.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/PhotonView.cs`

<a id='PhotonView'></a>
## Class PhotonView
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonView : MonoBehaviour`

> A PhotonView identifies an object across the network (viewID) and configures how the controlling client updates remote instances.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | ObservedComponentsFoldoutOpen | `Boolean` |  |  |
| `public` | Group | `Byte` |  |  |
| `public` | prefixField | `Int32` |  |  |
| `internal` | instantiationDataField | `Object[]` | This is the InstantiationData that was passed when calling PhotonNetwork.Instantiate* (if that was used to spawn this prefab) |  |
| `protected internal` | lastOnSerializeDataSent | `List`1` | For internal use only, don't use |  |
| `protected internal` | syncValues | `List`1` |  |  |
| `protected internal` | lastOnSerializeDataReceived | `Object[]` | For internal use only, don't use |  |
| `public` | Synchronization | `ViewSynchronization` |  |  |
| `protected internal` | mixedModeIsReliable | `Boolean` |  |  |
| `public` | OwnershipTransfer | `OwnershipOption` | Defines if ownership of this PhotonView is fixed, can be requested or simply taken. |  |
| `public` | observableSearch | `ObservableSearch` |  |  |
| `public` | ObservedComponents | `List`1` |  |  |
| `internal` | RpcMonoBehaviours | `MonoBehaviour[]` |  |  |
| `private` | ownerActorNr | `Int32` |  |  |
| `private` | controllerActorNr | `Int32` |  |  |
| `public` | sceneViewId | `Int32` | TODO: in best case, this is not public |  |
| `private` | viewIdField | `Int32` |  |  |
| `public` | InstantiationId | `Int32` | if the view was instantiated with a GO, this GO has a instantiationID (first view's viewID) |  |
| `public` | isRuntimeInstantiated | `Boolean` |  |  |
| `protected internal` | removedFromLocalViewList | `Boolean` |  |  |
| `private` | CallbackChangeQueue | `Queue`1` |  |  |
| `private` | OnPreNetDestroyCallbacks | `List`1` |  |  |
| `private` | OnOwnerChangeCallbacks | `List`1` |  |  |
| `private` | OnControllerChangeCallbacks | `List`1` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Prefix <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | InstantiationData <br><small>{ get; set; }</small> | `Object[]` | This is the InstantiationData that was passed when calling PhotonNetwork.Instantiate* (if that was used to spawn this prefab) |
| `public` | IsSceneView <br><small>{ get;  }</small> | `Boolean` |  |
| `public` | IsRoomView <br><small>{ get;  }</small> | `Boolean` | True if the PhotonView was loaded with the scene (game object) or instantiated with InstantiateRoomObject. |
| `public` | IsOwnerActive <br><small>{ get;  }</small> | `Boolean` | True if the PhotonView was loaded with the scene (game object) or instantiated with InstantiateRoomObject. |
| `public` | IsMine <br><small>{ get; set; }</small> | `Boolean` | True if the PhotonView was loaded with the scene (game object) or instantiated with InstantiateRoomObject. |
| `public` | AmController <br><small>{ get;  }</small> | `Boolean` |  |
| `public` | Controller <br><small>{ get; set; }</small> | `Player` |  |
| `public` | CreatorActorNr <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | AmOwner <br><small>{ get; set; }</small> | `Boolean` |  |
| `public` | Owner <br><small>{ get; set; }</small> | `Player` | The owner of a PhotonView is the creator of an object by default Ownership can be transferred and the owner may not be in the room anymore. Objects in the scene don't have an owner. |
| `public` | OwnerActorNr <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | ControllerActorNr <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | ViewID <br><small>{ get; set; }</small> | `Int32` | The ID of the PhotonView. Identifies it in a networked game (per room). |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | S SetPhotonViewExecutionOrder |  | `Void` |  |
| `private` | OpenPunWizard |  | `Void` |  |
| `private` | ⚡ Reset |  | `Void` | Unity Event Function |
| `protected internal` | ⚡ Awake |  | `Void` | Will FindObservables() and assign the sceneViewId, if that is != 0. This initializes the PhotonView if loaded with the scene. Called once by Unity, when this instance is created. |
| `internal` | ResetPhotonView | Boolean resetOwner | `Void` |  |
| `internal` | RebuildControllerCache | Boolean ownerHasChanged | `Void` |  |
| `public` | OnPreNetDestroy | PhotonView rootView | `Void` |  |
| `protected internal` | ⚡ OnDestroy |  | `Void` | Unity Event Function |
| `public` | RequestOwnership |  | `Void` | Depending on the PhotonView's OwnershipTransfer setting, any client can request to become owner of the PhotonView. |
| `public` | TransferOwnership | Player newOwner | `Void` | Transfers the ownership of this PhotonView (and GameObject) to another player. |
| `public` | TransferOwnership | Int32 newOwnerId | `Void` | Transfers the ownership of this PhotonView (and GameObject) to another player. |
| `public` | FindObservables | Boolean force | `Void` | Will find IPunObservable components on this GameObject and nested children and add them to the ObservedComponents list. |
| `public` | SerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |
| `public` | DeserializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |
| `protected internal` | DeserializeComponent | Component component, PhotonStream stream, PhotonMessageInfo info | `Void` |  |
| `protected internal` | SerializeComponent | Component component, PhotonStream stream, PhotonMessageInfo info | `Void` |  |
| `public` | RefreshRpcMonoBehaviourCache |  | `Void` | Can be used to refesh the list of MonoBehaviours on this GameObject while PhotonNetwork.UseRpcMonoBehaviourCache is true. |
| `public` | RPC | String methodName, RpcTarget target, Object[] parameters | `Void` | Call a RPC method of this GameObject on remote clients of this room (or on all, including this client). |
| `public` | RpcSecure | String methodName, RpcTarget target, Boolean encrypt, Object[] parameters | `Void` | Call a RPC method of this GameObject on remote clients of this room (or on all, including this client). |
| `public` | RPC | String methodName, Player targetPlayer, Object[] parameters | `Void` | Call a RPC method of this GameObject on remote clients of this room (or on all, including this client). |
| `public` | RpcSecure | String methodName, Player targetPlayer, Boolean encrypt, Object[] parameters | `Void` | Call a RPC method of this GameObject on remote clients of this room (or on all, including this client). |
| `public` | S Get | Component component | `PhotonView` |  |
| `public` | S Get | GameObject gameObj | `PhotonView` |  |
| `public` | S Find | Int32 viewID | `PhotonView` | Finds the PhotonView Component with a viewID in the scene |
| `public` | AddCallbackTarget | IPhotonViewCallback obj | `Void` | Add object to all applicable callback interfaces. Object must implement at least one IOnPhotonViewCallback derived interface. |
| `public` | RemoveCallbackTarget | IPhotonViewCallback obj | `Void` | Remove object from all applicable callback interfaces. Object must implement at least one IOnPhotonViewCallback derived interface. |
| `public` | AddCallback | IPhotonViewCallback obj | `Void` |  |
| `public` | RemoveCallback | IPhotonViewCallback obj | `Void` |  |
| `private` | UpdateCallbackLists |  | `Void` | Apply any queued add/remove of interfaces from the callback lists. Typically called before looping callback lists. |
| `private` | TryRegisterCallback | IPhotonViewCallback obj, List`1& list, Boolean add | `Void` |  |
| `private` | RegisterCallback | T obj, List`1& list, Boolean add | `Void` |  |
| `public` | ToString |  | `String` |  |

---

