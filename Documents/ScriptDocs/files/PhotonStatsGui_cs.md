# File: PhotonStatsGui.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_Debugging.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Debugging/PhotonStatsGui.cs`

<a id='PhotonStatsGui'></a>
## Class PhotonStatsGui
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `PhotonStatsGui : MonoBehaviour`

> Basic GUI to show traffic and health statistics of the connection to Photon,  
> toggled by shift+tab.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | statsWindowOn | `Boolean` | Shows or hides GUI (does not affect if stats are collected). |  |
| `public` | statsOn | `Boolean` | Option to turn collecting stats on or off (used in Update()). |  |
| `public` | healthStatsVisible | `Boolean` | Shows additional "health" values of connection. |  |
| `public` | trafficStatsOn | `Boolean` | Shows additional "lower level" traffic stats. |  |
| `public` | buttonsOn | `Boolean` | Show buttons to control stats and reset them. |  |
| `public` | statsRect | `Rect` | Positioning rect for window. |  |
| `public` | WindowId | `Int32` | Unity GUI Window ID (must be unique or will cause issues). |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | Checks for shift+tab input combination (to toggle statsOn). |
| `public` | ⚡ OnGUI |  | `Void` | Unity Event Function |
| `public` | TrafficStatsWindow | Int32 windowID | `Void` |  |

---

