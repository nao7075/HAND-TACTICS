# File: IngameControlPanel.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoProcedural/Scripts/IngameControlPanel.cs`

<a id='IngameControlPanel'></a>
## Class IngameControlPanel
**Namespace:** `Photon.Pun.Demo.Procedural`<br>
**Signature:** `IngameControlPanel : MonoBehaviourPunCallbacks`

> The Ingame Control Panel basically controls the WorldGenerator.  
> It is only interactable for the current MasterClient in the room.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | isSeedValid | `Boolean` |  |  |
| `private` | seedInputField | `InputField` |  |  |
| `private` | worldSizeDropdown | `Dropdown` |  |  |
| `private` | clusterSizeDropdown | `Dropdown` |  |  |
| `private` | worldTypeDropdown | `Dropdown` |  |  |
| `private` | generateWorldButton | `Button` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | When the object gets created, all necessary references are set up.<br>Also the UI elements get set up properly in order to control the WorldGenerator. |
| `public` | OnJoinedRoom |  | `Void` | Gets called when the local client has joined the room.<br>Since only the MasterClient can control the WorldGenerator,<br>we are checking if we have to make the UI controls available for the local client. |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` | Gets called whenever the current MasterClient has left the room and a new one is selected.<br>If the local client is the new MasterClient, we make the UI controls available for him. |
| `public` | OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` | Gets called whenever the Custom Room Properties are updated.<br>In this callback we are interested in the settings the MasterClient can apply to the WorldGenerator.<br>If all possible settings are updated (and available within the updated properties), these settings are also used<br>to update the Ingame Control Panel as well as the WorldGenerator on all clients.<br>Afterwards the WorldGenerator creates a new world with the new settings. |

---

