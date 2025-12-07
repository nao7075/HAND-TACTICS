# File: Player.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/Player.cs`

<a id='Player'></a>
## Class Player
**Namespace:** `Photon.Realtime`<br>
**Signature:** `Player`

> Summarizes a "player" within a room, identified (in that room) by ID (or "actorNumber").  
> Creates a player instance.  
> To extend and replace this Player, override LoadBalancingPeer.CreatePlayer().

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | actorNumber | `Int32` | Backing field for property. |  |
| `public` | IsLocal | `Boolean` | Identifier of this player in current room. Also known as: actorNumber or actorNumber. It's -1 outside of rooms. |  |
| `private` | nickName | `String` | Background field for nickName. |  |
| `public` | TagObject | `Object` | Can be used to store a reference that's useful to know "by player". |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `private` | RoomReference <br><small>{ get; set; }</small> | `Room` | Used internally to identify the masterclient of a room. |
| `public` | ActorNumber <br><small>{ get;  }</small> | `Int32` | Identifier of this player in current room. Also known as: actorNumber or actorNumber. It's -1 outside of rooms. |
| `public` | HasRejoined <br><small>{ get; set; }</small> | `Boolean` |  |
| `public` | NickName <br><small>{ get; set; }</small> | `String` | Non-unique nickname of this player. Synced automatically in a room. |
| `public` | UserId <br><small>{ get; set; }</small> | `String` | UserId of the player, available when the room got created with RoomOptions.PublishUserId = true. |
| `public` | IsMasterClient <br><small>{ get;  }</small> | `Boolean` | True if this player is the Master Client of the current room. |
| `public` | IsInactive <br><small>{ get; set; }</small> | `Boolean` | If this player is active in the room (and getting events which are currently being sent). |
| `public` | CustomProperties <br><small>{ get; set; }</small> | `Hashtable` | Read-only cache for custom properties of player. Set via Player.SetCustomProperties. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `private` | Player | String nickName, Int32 actorNumber, Boolean isLocal | Constructor |
| `private` | Player | String nickName, Int32 actorNumber, Boolean isLocal, Hashtable playerProperties | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | Get | Int32 id | `Player` | Get a Player by ActorNumber (Player.ID). |
| `public` | GetNext |  | `Player` | Gets this Player's next Player, as sorted by ActorNumber (Player.ID). Wraps around. |
| `public` | GetNextFor | Player currentPlayer | `Player` | Gets a Player's next Player, as sorted by ActorNumber (Player.ID). Wraps around. |
| `public` | GetNextFor | Int32 currentPlayerId | `Player` | Gets a Player's next Player, as sorted by ActorNumber (Player.ID). Wraps around. |
| `protected internal` | InternalCacheProperties | Hashtable properties | `Void` | Caches properties for new Players or when updates of remote players are received. Use SetCustomProperties() for a synced update. |
| `public` | ToString |  | `String` | Brief summary string of the Player: ActorNumber and NickName |
| `public` | ToStringFull |  | `String` | String summary of the Player: player.ID, name and all custom properties of this user. |
| `public` | Equals | Object p | `Boolean` | If players are equal (by GetHasCode, which returns this.ID). |
| `public` | GetHashCode |  | `Int32` | Accompanies Equals, using the ID (actorNumber) as HashCode to return. |
| `protected internal` | ChangeLocalID | Int32 newID | `Void` | Used internally, to update this client's playerID when assigned (doesn't change after assignment). |
| `public` | SetCustomProperties | Hashtable propertiesToSet, Hashtable expectedValues, WebFlags webFlags | `Boolean` | Updates and synchronizes this Player's Custom Properties. Optionally, expectedProperties can be provided as condition. |
| `private` | SetPlayerNameProperty |  | `Boolean` | Uses OpSetPropertiesOfActor to sync this player's NickName (server is being updated with this.NickName). |

---

