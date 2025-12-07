# File: TabViewManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI/TabViewManager.cs`

<a id='TabViewManager'></a>
## Class TabViewManager
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `TabViewManager : MonoBehaviour`

> Tab view manager. Handles Tab views activation and deactivation, and provides a Unity Event Callback when a tab was selected.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ToggleGroup | `ToggleGroup` | The toggle group component target. |  |
| `public` | Tabs | `Tab[]` | all the tabs for this group |  |
| `public` | OnTabChanged | `TabChangeEvent` | The on tab changed Event. |  |
| `protected` | CurrentTab | `Tab` |  |  |
| `private` | Tab_lut | `Dictionary`2` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | SelectTab | String id | `Void` | Selects a given tab. |
| `private` | OnTabSelected | Tab tab | `Void` | final method for a tab selection routine |

---

