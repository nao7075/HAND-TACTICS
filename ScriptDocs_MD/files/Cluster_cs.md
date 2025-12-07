# File: Cluster.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoProcedural_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoProcedural/Scripts/Cluster.cs`

<a id='Cluster'></a>
## Class Cluster
**Namespace:** `Photon.Pun.Demo.Procedural`<br>
**Signature:** `Cluster : MonoBehaviourPunCallbacks`

> The Cluster component has references to all Blocks that are part of this Cluster.  
> It provides functions for modifying single Blocks inside this Cluster.  
> It also handles modifications made to the world by other clients.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | propertiesKey | `String` |  |  |
| `private` | propertiesValue | `Dictionary`2` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | ClusterId <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | Blocks <br><small>{ get; set; }</small> | `Dictionary`2` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Sets the unique key of this Cluster used for storing modifications within the Custom Room Properties. |
| `public` | AddBlock | Int32 blockId, GameObject block | `Void` | Adds a Block to the Cluster.<br>This is called by the WorldGenerator while the generation process is running.<br>In order to modify Blocks directly, we are storing the ID as well as a reference to the certain GameObject. |
| `public` | DestroyCluster |  | `Void` | Gets called before a new world can be generated.<br>Destroys each Block from this Cluster and removes the data stored in the Custom Room Properties. |
| `public` | DecreaseBlockHeight | Int32 blockId | `Void` | Decreases a Block's height locally before applying the modification to the Custom Room Properties. |
| `public` | IncreaseBlockHeight | Int32 blockId | `Void` | Increases a Block's height locally before applying the modification to the Custom Room Properties. |
| `public` | SetBlockHeightRemote | Int32 blockId, Single height | `Void` | Gets called when a remote client has modified a certain Block within this Cluster.<br>Called by the WorldGenerator or the Cluster itself after the Custom Room Properties have been updated. |
| `private` | SetBlockHeightLocal | Int32 blockId, Single height | `Void` | Gets called whenever the local client modifies any Block within this Cluster.<br>The modification will be applied to the Block first before it is published to the Custom Room Properties. |
| `private` | UpdateRoomProperties | Int32 blockId, Single height | `Void` | Gets called in order to update the Custom Room Properties with the modification made by the local client. |
| `private` | RemoveClusterFromRoomProperties |  | `Void` | Removes the modifications of this Cluster from the Custom Room Properties. |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` | Gets called whenever the Custom Room Properties are updated.<br>When the changed properties contain the previously set PropertiesKey (basically the Cluster ID),<br>the Cluster and its Blocks will be updated accordingly. |

---

