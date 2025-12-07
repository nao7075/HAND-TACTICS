# File: PlayerListEntry.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Lobby/PlayerListEntry.cs`

<a id='PlayerListEntry'></a>
## Class PlayerListEntry
**Namespace:** `Photon.Pun.Demo.Asteroids`<br>
**Signature:** `PlayerListEntry : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | PlayerNameText | `Text` | **[UI References]**<br> |  |
| `public` | PlayerColorImage | `Image` |  |  |
| `public` | PlayerReadyButton | `Button` |  |  |
| `public` | PlayerReadyImage | `Image` |  |  |
| `private` | ownerId | `Int32` |  |  |
| `private` | isPlayerReady | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | Initialize | Int32 playerId, String playerName | `Void` |  |
| `private` | OnPlayerNumberingChanged |  | `Void` |  |
| `public` | SetPlayerReady | Boolean playerReady | `Void` |  |

---

