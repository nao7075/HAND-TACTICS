# File: PhotonLagSimulationGui.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_Debugging.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Debugging/PhotonLagSimulationGui.cs`

<a id='PhotonLagSimulationGui'></a>
## Class PhotonLagSimulationGui
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `PhotonLagSimulationGui : MonoBehaviour`

> This MonoBehaviour is a basic GUI for the Photon client's network-simulation feature.  
> It can modify lag (fixed delay), jitter (random lag) and packet loss.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | WindowRect | `Rect` | Positioning rect for window. |  |
| `public` | WindowId | `Int32` | Unity GUI Window ID (must be unique or will cause issues). |  |
| `public` | Visible | `Boolean` | Shows or hides GUI (does not affect settings). |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Peer <br><small>{ get; set; }</small> | `PhotonPeer` | The peer currently in use (to set the network simulation). |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ OnGUI |  | `Void` | Unity Event Function |
| `private` | NetSimHasNoPeerWindow | Int32 windowId | `Void` |  |
| `private` | NetSimWindow | Int32 windowId | `Void` |  |

---

