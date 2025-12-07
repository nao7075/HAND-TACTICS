# File: PhotonTeamsManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_PhotonPlayer.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonPlayer/PhotonTeamsManager.cs`

<a id='PhotonTeamsManager'></a>
## Class PhotonTeamsManager
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `PhotonTeamsManager : MonoBehaviour, IMatchmakingCallbacks, IInRoomCallbacks`

> Implements teams in a room/game with help of player properties. Access them by Player.GetTeam extension.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | listFoldIsOpen | `Boolean` |  |  |
| `private` | teamsList | `List`1` |  |  |
| `private` | teamsByCode | `Dictionary`2` |  |  |
| `private` | teamsByName | `Dictionary`2` |  |  |
| `private` | playersPerTeam | `Dictionary`2` | The main list of teams with their player-lists. Automatically kept up to date. |  |
| `public` | TeamPlayerProp | `String` | Defines the player custom property name to use for team affinity of "this" player. |  |
| `private` | instance | `PhotonTeamsManager` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Instance <br><small>{ get;  }</small> | `PhotonTeamsManager` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `private` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `private` | Init |  | `Void` |  |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnJoinedRoom |  | `Void` |  |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnLeftRoom |  | `Void` |  |
| `private` | Photon.Realtime.IInRoomCallbacks.OnPlayerPropertiesUpdate | Player targetPlayer, Hashtable changedProps | `Void` |  |
| `private` | Photon.Realtime.IInRoomCallbacks.OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `private` | Photon.Realtime.IInRoomCallbacks.OnPlayerEnteredRoom | Player newPlayer | `Void` |  |
| `private` | UpdateTeams |  | `Void` |  |
| `private` | ClearTeams |  | `Void` |  |
| `public` | TryGetTeamByCode | Byte code, PhotonTeam& team | `Boolean` | Find a PhotonTeam using a team code. |
| `public` | TryGetTeamByName | String teamName, PhotonTeam& team | `Boolean` | Find a PhotonTeam using a team name. |
| `public` | GetAvailableTeams |  | `PhotonTeam[]` | Gets all teams available. |
| `public` | TryGetTeamMembers | Byte code, Player[]& members | `Boolean` | Gets all players joined to a team using a team code.<br>Gets all players joined to a team using a team name.<br>Gets all players joined to a team. |
| `public` | TryGetTeamMembers | String teamName, Player[]& members | `Boolean` | Gets all players joined to a team using a team code.<br>Gets all players joined to a team using a team name.<br>Gets all players joined to a team. |
| `public` | TryGetTeamMembers | PhotonTeam team, Player[]& members | `Boolean` | Gets all players joined to a team using a team code.<br>Gets all players joined to a team using a team name.<br>Gets all players joined to a team. |
| `public` | TryGetTeamMatesOfPlayer | Player player, Player[]& teamMates | `Boolean` | Gets all team mates of a player. |
| `public` | GetTeamMembersCount | Byte code | `Int32` | Gets the number of players in a team by team code.<br>Gets the number of players in a team by team name.<br>Gets the number of players in a team. |
| `public` | GetTeamMembersCount | String name | `Int32` | Gets the number of players in a team by team code.<br>Gets the number of players in a team by team name.<br>Gets the number of players in a team. |
| `public` | GetTeamMembersCount | PhotonTeam team | `Int32` | Gets the number of players in a team by team code.<br>Gets the number of players in a team by team name.<br>Gets the number of players in a team. |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnFriendListUpdate | List`1 friendList | `Void` |  |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnCreatedRoom |  | `Void` |  |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `private` | Photon.Realtime.IMatchmakingCallbacks.OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `private` | Photon.Realtime.IInRoomCallbacks.OnRoomPropertiesUpdate | Hashtable propertiesThatChanged | `Void` |  |
| `private` | Photon.Realtime.IInRoomCallbacks.OnMasterClientSwitched | Player newMasterClient | `Void` |  |

---

