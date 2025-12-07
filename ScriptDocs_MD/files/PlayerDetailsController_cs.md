# File: PlayerDetailsController.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_PunCockpit_Scripts_Controllers.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Controllers/PlayerDetailsController.cs`

<a id='PlayerDetailsController'></a>
## Class PlayerDetailsController
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `PlayerDetailsController : MonoBehaviourPunCallbacks`

> Controller for the Playerdetails UI view

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ContentPanel | `GameObject` |  |  |
| `public` | PropertyCellPrototype | `PropertyCell` |  |  |
| `public` | UpdateStatusText | `Text` |  |  |
| `public` | BuiltInPropertiesPanel | `Transform` |  |  |
| `public` | PlayerNumberingExtensionPanel | `Transform` |  |  |
| `public` | ScoreExtensionPanel | `Transform` |  |  |
| `public` | TeamExtensionPanel | `Transform` |  |  |
| `public` | TurnExtensionPanel | `Transform` |  |  |
| `public` | CustomPropertiesPanel | `Transform` |  |  |
| `public` | MasterClientToolBar | `GameObject` |  |  |
| `public` | NotInRoomLabel | `GameObject` |  |  |
| `private` | builtInPropsCellList | `Dictionary`2` |  |  |
| `private` | _player | `Player` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | SetPlayerTarget | Player player | `Void` |  |
| `private` | AddProperty | String property, String value, Transform parent | `Void` |  |
| `private` | ParseKey | Object key | `String` |  |
| `public` | KickOutPlayer |  | `Void` |  |
| `public` | SetAsMaster |  | `Void` |  |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player target, Hashtable changedProps | `Void` |  |
| `private` | OnPlayerNumberingChanged |  | `Void` |  |
| `private` | UpdateUIPing |  | `IEnumerator` |  |
| `public` | ResetList |  | `Void` |  |
| `private` | GetAllPlayerBuiltIntProperties |  | `Hashtable` |  |

---

