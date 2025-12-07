# File: Room.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/Room.cs`

<a id='Room'></a>
## Class Room
**Namespace:** `Photon.Realtime`<br>
**Signature:** `Room : RoomInfo`

> This class represents a room a client joins/joined.  
> Creates a Room (representation) with given name and properties and the "listing options" as provided by parameters.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | isOffline | `Boolean` | The name of a room. Unique identifier (per region and virtual appid) for a room/match. |  |
| `private` | players | `Dictionary`2` | While inside a Room, this is the list of players who are also in that room. |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | LoadBalancingClient <br><small>{ get; set; }</small> | `LoadBalancingClient` | A reference to the LoadBalancingClient which is currently keeping the connection and state. |
| `public` | Name <br><small>{ get; set; }</small> | `String` | The name of a room. Unique identifier (per region and virtual appid) for a room/match. |
| `public` | IsOffline <br><small>{ get; set; }</small> | `Boolean` |  |
| `public` | IsOpen <br><small>{ get; set; }</small> | `Boolean` | Defines if the room can be joined. |
| `public` | IsVisible <br><small>{ get; set; }</small> | `Boolean` | Defines if the room is listed in its lobby. |
| `public` | MaxPlayers <br><small>{ get; set; }</small> | `Int32` | Sets a limit of players to this room. This property is synced and shown in lobby, too.<br>If the room is full (players count == maxplayers), joining this room will fail. |
| `public` | PlayerCount <br><small>{ get;  }</small> | `Int32` | The count of players in this Room (using this.Players.Count). |
| `public` | Players <br><small>{ get; set; }</small> | `Dictionary`2` | While inside a Room, this is the list of players who are also in that room. |
| `public` | ExpectedUsers <br><small>{ get;  }</small> | `String[]` | While inside a Room, this is the list of players who are also in that room. |
| `public` | PlayerTtl <br><small>{ get; set; }</small> | `Int32` | While inside a Room, this is the list of players who are also in that room. |
| `public` | EmptyRoomTtl <br><small>{ get; set; }</small> | `Int32` | Room Time To Live. How long a room stays available (and in server-memory), after the last player becomes inactive. After this time, the room gets persisted or destroyed. |
| `public` | MasterClientId <br><small>{ get;  }</small> | `Int32` | The ID (actorNumber, actorNumber) of the player who's the master of this Room.<br>Note: This changes when the current master leaves the room. |
| `public` | PropertiesListedInLobby <br><small>{ get; set; }</small> | `String[]` | Gets a list of custom properties that are in the RoomInfo of the Lobby.<br>This list is defined when creating the room and can't be changed afterwards. Compare: LoadBalancingClient.OpCreateRoom() |
| `public` | AutoCleanUp <br><small>{ get;  }</small> | `Boolean` | Gets a list of custom properties that are in the RoomInfo of the Lobby.<br>This list is defined when creating the room and can't be changed afterwards. Compare: LoadBalancingClient.OpCreateRoom() |
| `public` | BroadcastPropertiesChangeToAll <br><small>{ get; set; }</small> | `Boolean` | Gets a list of custom properties that are in the RoomInfo of the Lobby.<br>This list is defined when creating the room and can't be changed afterwards. Compare: LoadBalancingClient.OpCreateRoom() |
| `public` | SuppressRoomEvents <br><small>{ get; set; }</small> | `Boolean` | Define if Join and Leave events should not be sent to clients in the room. |
| `public` | SuppressPlayerInfo <br><small>{ get; set; }</small> | `Boolean` | Extends SuppressRoomEvents: Define if Join and Leave events but also the actors' list and their respective properties should not be sent to clients. |
| `public` | PublishUserId <br><small>{ get; set; }</small> | `Boolean` | Define if UserIds of the players are broadcast in the room. Useful for FindFriends and reserving slots for expected users. |
| `public` | DeleteNullProperties <br><small>{ get; set; }</small> | `Boolean` | Define if actor or room properties with null values are removed on the server or kept. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | Room | String roomName, RoomOptions options, Boolean isOffline | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `internal` | InternalCacheRoomFlags | Int32 roomFlags | `Void` | Read (received) room option flags into related bool parameters. |
| `protected internal` | InternalCacheProperties | Hashtable propertiesToCache | `Void` |  |
| `public` | SetCustomProperties | Hashtable propertiesToSet, Hashtable expectedProperties, WebFlags webFlags | `Boolean` | Updates and synchronizes this Room's Custom Properties. Optionally, expectedProperties can be provided as condition. |
| `public` | SetPropertiesListedInLobby | String[] lobbyProps | `Boolean` | Enables you to define the properties available in the lobby if not all properties are needed to pick a room. |
| `protected internal` | RemovePlayer | Player player | `Void` | Removes a player from this room's Players Dictionary.<br>This is internally used by the LoadBalancing API. There is usually no need to remove players yourself.<br>This is not a way to "kick" players. |
| `protected internal` | RemovePlayer | Int32 id | `Void` | Removes a player from this room's Players Dictionary.<br>This is internally used by the LoadBalancing API. There is usually no need to remove players yourself.<br>This is not a way to "kick" players. |
| `public` | SetMasterClient | Player masterClientPlayer | `Boolean` | Asks the server to assign another player as Master Client of your current room. |
| `public` | AddPlayer | Player player | `Boolean` | Checks if the player is in the room's list already and calls StorePlayer() if not. |
| `public` | StorePlayer | Player player | `Player` | Updates a player reference in the Players dictionary (no matter if it existed before or not). |
| `public` | GetPlayer | Int32 id, Boolean findMaster | `Player` | Tries to find the player with given actorNumber (a.k.a. ID).<br>Only useful when in a Room, as IDs are only valid per Room. |
| `public` | ClearExpectedUsers |  | `Boolean` | Attempts to remove all current expected users from the server's Slot Reservation list. |
| `public` | SetExpectedUsers | String[] newExpectedUsers | `Boolean` | Attempts to update the expected users from the server's Slot Reservation list. |
| `private` | SetExpectedUsers | String[] newExpectedUsers, String[] oldExpectedUsers | `Boolean` | Attempts to update the expected users from the server's Slot Reservation list. |
| `public` | ToString |  | `String` | Returns a summary of this Room instance as string. |
| `public` | ToStringFull |  | `String` | Returns a summary of this Room instance as longer string, including Custom Properties. |

---

