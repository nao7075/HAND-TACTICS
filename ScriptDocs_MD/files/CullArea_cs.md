# File: CullArea.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_Culling.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Culling/CullArea.cs`

<a id='CullArea'></a>
## Class CullArea
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `CullArea : MonoBehaviour`

> Represents the cull area used for network culling.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | MAX_NUMBER_OF_ALLOWED_CELLS | `Int32` |  |  |
| `public` | MAX_NUMBER_OF_SUBDIVISIONS | `Int32` |  |  |
| `public` | FIRST_GROUP_ID | `Byte` | This represents the first ID which is assigned to the first created cell.<br>If you already have some interest groups blocking this first ID, fell free to change it.<br>However increasing the first group ID decreases the maximum amount of allowed cells.<br>Allowed values are in range from 1 to 250. |  |
| `public` | SUBDIVISION_FIRST_LEVEL_ORDER | `Int32[]` | This represents the order in which updates are sent.<br>The number represents the subdivision of the cell hierarchy:<br>- 0: message is sent to all players<br>- 1: message is sent to players who are interested in the matching cell of the first subdivision<br>If there is only one subdivision we are sending one update to all players<br>before sending three consequent updates only to players who are in the same cell<br>or interested in updates of the current cell. |  |
| `public` | SUBDIVISION_SECOND_LEVEL_ORDER | `Int32[]` | This represents the order in which updates are sent.<br>The number represents the subdivision of the cell hierarchy:<br>- 0: message is sent to all players<br>- 1: message is sent to players who are interested in the matching cell of the first subdivision<br>- 2: message is sent to players who are interested in the matching cell of the second subdivision<br>If there are two subdivisions we are sending every second update only to players<br>who are in the same cell or interested in updates of the current cell. |  |
| `public` | SUBDIVISION_THIRD_LEVEL_ORDER | `Int32[]` | This represents the order in which updates are sent.<br>The number represents the subdivision of the cell hierarchy:<br>- 0: message is sent to all players<br>- 1: message is sent to players who are interested in the matching cell of the first subdivision<br>- 2: message is sent to players who are interested in the matching cell of the second subdivision<br>- 3: message is sent to players who are interested in the matching cell of the third subdivision<br>If there are two subdivisions we are sending every second update only to players<br>who are in the same cell or interested in updates of the current cell. |  |
| `public` | Center | `Vector2` | Represents the center, top-left or bottom-right position of the cell<br>or the size of the cell. |  |
| `public` | Size | `Vector2` | Represents the center, top-left or bottom-right position of the cell<br>or the size of the cell. |  |
| `public` | Subdivisions | `Vector2[]` |  |  |
| `public` | NumberOfSubdivisions | `Int32` |  |  |
| `public` | YIsUpAxis | `Boolean` |  |  |
| `public` | RecreateCellHierarchy | `Boolean` |  |  |
| `private` | idCounter | `Byte` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | CellCount <br><small>{ get; set; }</small> | `Int32` |  |
| `public` | CellTree <br><small>{ get; set; }</small> | `CellTree` | Represents the tree accessible from its root node.<br>Default constructor.<br>Constructor to define the root node. |
| `public` | Map <br><small>{ get; set; }</small> | `Dictionary`2` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Creates the cell hierarchy at runtime. |
| `public` | OnDrawGizmos |  | `Void` | Creates the cell hierarchy in editor and draws the cell view. |
| `private` | CreateCellHierarchy |  | `Void` | Creates the cell hierarchy. |
| `private` | CreateChildCells | CellTreeNode parent, Int32 cellLevelInHierarchy | `Void` | Creates all child cells. |
| `private` | DrawCells |  | `Void` | Draws the cells. |
| `private` | IsCellCountAllowed |  | `Boolean` | Checks if the cell count is allowed. |
| `public` | GetActiveCells | Vector3 position | `List`1` | Gets a list of all cell IDs the player is currently inside or nearby.<br>Gathers all cell IDs the player is currently inside or nearby. |

---

