# File: PunTeams.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonPlayer/PunTeams.cs`

<a id='PunTeams'></a>
## Class PunTeams
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `PunTeams : MonoBehaviourPunCallbacks`

> Implements teams in a room/game with help of player properties. Access them by Player.GetTeam extension.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | PlayersPerTeam | `Dictionary`2` | The main list of teams with their player-lists. Automatically kept up to date. |  |
| `public` | TeamPlayerProp | `String` | Defines the player custom property name to use for team affinity of "this" player. |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | OnJoinedRoom |  | `Void` | Needed to update the team lists when joining a room. |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player targetPlayer, Hashtable changedProps | `Void` | Refreshes the team lists. It could be a non-team related property change, too. |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `public` | OnPlayerEnteredRoom | Player newPlayer | `Void` |  |
| `public` | UpdateTeams |  | `Void` |  |

---

