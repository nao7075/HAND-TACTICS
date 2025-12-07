# File: PlayerListView.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists/PlayerListView.cs`

<a id='PlayerListView'></a>
## Class PlayerListView
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `PlayerListView : MonoBehaviourPunCallbacks`

> Player list UI View.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | PlayerDetailManager | `PlayerDetailsController` |  |  |
| `public` | CellPrototype | `PlayerListCell` |  |  |
| `public` | PlayerCountsText | `Text` |  |  |
| `public` | UpdateStatusText | `Text` |  |  |
| `private` | playerCellList | `Dictionary`2` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | SelectPlayer | Player player | `Void` |  |
| `public` | OnPlayerEnteredRoom | Player newPlayer | `Void` |  |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player target, Hashtable changedProps | `Void` |  |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `private` | RefreshCount |  | `Void` |  |
| `private` | UpdateUIPing |  | `IEnumerator` |  |
| `public` | ResetList |  | `Void` |  |

---

