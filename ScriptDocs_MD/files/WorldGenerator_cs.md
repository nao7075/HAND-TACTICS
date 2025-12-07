# File: WorldGenerator.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoProcedural_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoProcedural/Scripts/WorldGenerator.cs`

<a id='WorldGenerator'></a>
## Class WorldGenerator
**Namespace:** `Photon.Pun.Demo.Procedural`<br>
**Signature:** `WorldGenerator : MonoBehaviour`

> The World Generator creates a world based on four options the current MasterClient can set.  
> These options are available on the Ingame Control Panel. If those options are confirmed by the current MasterClient,  
> they will be stored in the Custom Room Properties to make them available on all clients.  
> These options are:  
> 1) a numerical Seed to make sure that each client generates the same world and to avoid Random functions and 'network-instantiate' everything  
> 2) the World Size to describe how large the generated world should be  
> 3) the Cluster Size to describe how many Blocks are inside each Cluster  
> 4) the World Type to make the generated world appear in different 'looks'.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | SeedPropertiesKey | `String` |  |  |
| `public` | WorldSizePropertiesKey | `String` |  |  |
| `public` | ClusterSizePropertiesKey | `String` |  |  |
| `public` | WorldTypePropertiesKey | `String` |  |  |
| `private` | instance | `WorldGenerator` |  |  |
| `private` | clusterList | `Dictionary`2` |  |  |
| `public` | WorldMaterials | `Material[]` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Instance <br><small>{ get;  }</small> | `WorldGenerator` |  |
| `public` | Seed <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | WorldSize <br><small>{ get; set; }</small> | `WorldSize` | Describes the Size of the World.<br>A 'Tiny' world for example will be created with 16 x 16 Blocks. |
| `public` | ClusterSize <br><small>{ get; set; }</small> | `ClusterSize` | Describes how many Blocks are part of one CLuster.<br>Having a 'Small' ClusterSize increases the amount of Clusters being created,<br>whereat generating a world with a 'Large' ClusterSize doesn't create that many Clusters. |
| `public` | WorldType <br><small>{ get; set; }</small> | `WorldType` | Describes the type of the generated world.<br>This basically influences the maximum height of a Block. |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | CreateWorld |  | `Void` | Called whenever a client receives a Custom Room Properties update containing all necessary information for creating a world.<br>If there is currently a world generation process running, it will be stopped automatically.<br>Also if there is a world already existing, it will be destroyed before the new one gets created. |
| `private` | DestroyWorld |  | `Void` | Destroys each Block from each Cluster before actually destroying the Cluster itself. |
| `public` | ConfirmAndUpdateProperties |  | `Void` | Whenever the 'Confirm' button on the Control Panel is clicked by the MasterClient,<br>the Room Properties will be updated with the settings he defined. |
| `public` | DecreaseBlockHeight | Int32 clusterId, Int32 blockId | `Void` | Decreases the height of a certain Block from a certain Cluster. |
| `public` | IncreaseBlockHeight | Int32 clusterId, Int32 blockId | `Void` | Increases the height of a certain Block from a certain Cluster. |
| `private` | GenerateWorld |  | `IEnumerator` | Generates a new world based on the settings made either by the MasterClient on the<br>Ingame Control Panel or after receiving the new settings from the Custom Room Properties update. |

---

