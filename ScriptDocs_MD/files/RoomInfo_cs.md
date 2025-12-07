# File: RoomInfo.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/RoomInfo.cs`

<a id='RoomInfo'></a>
## Class RoomInfo
**Namespace:** `Photon.Realtime`<br>
**Signature:** `RoomInfo`

> A simplified room with just the info required to list and join, used for the room listing in the lobby.  
> The properties are not settable (IsOpen, MaxPlayers, etc).  
> The limit of players for this room. This property is shown in lobby, too.  
> If the room is full (players count == maxplayers), joining this room will fail.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | RemovedFromList | `Boolean` | Used in lobby, to mark rooms that are no longer listed (for being full, closed or hidden). |  |
| `private` | customProperties | `Hashtable` | Backing field for property. |  |
| `protected` | maxPlayers | `Int32` | Backing field for property. |  |
| `protected` | emptyRoomTtl | `Int32` | Backing field for property. |  |
| `protected` | playerTtl | `Int32` | Backing field for property. |  |
| `protected` | expectedUsers | `String[]` | Backing field for property. |  |
| `protected` | isOpen | `Boolean` | Backing field for property. |  |
| `protected` | isVisible | `Boolean` | Backing field for property. |  |
| `protected` | autoCleanUp | `Boolean` | Backing field for property. False unless the GameProperty is set to true (else it's not sent). |  |
| `protected` | name | `String` | Backing field for property. |  |
| `public` | masterClientId | `Int32` | Backing field for master client id (actorNumber). defined by server in room props and ev leave. |  |
| `protected` | propertiesListedInLobby | `String[]` | Backing field for property. |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | CustomProperties <br><small>{ get;  }</small> | `Hashtable` | Read-only "cache" of custom properties of a room. Set via Room.SetCustomProperties (not available for RoomInfo class!). |
| `public` | Name <br><small>{ get;  }</small> | `String` | Read-only "cache" of custom properties of a room. Set via Room.SetCustomProperties (not available for RoomInfo class!). |
| `public` | PlayerCount <br><small>{ get; set; }</small> | `Int32` | Read-only "cache" of custom properties of a room. Set via Room.SetCustomProperties (not available for RoomInfo class!). |
| `public` | MaxPlayers <br><small>{ get;  }</small> | `Int32` | The limit of players for this room. This property is shown in lobby, too.<br>If the room is full (players count == maxplayers), joining this room will fail. |
| `public` | IsOpen <br><small>{ get;  }</small> | `Boolean` | The limit of players for this room. This property is shown in lobby, too.<br>If the room is full (players count == maxplayers), joining this room will fail. |
| `public` | IsVisible <br><small>{ get;  }</small> | `Boolean` | The limit of players for this room. This property is shown in lobby, too.<br>If the room is full (players count == maxplayers), joining this room will fail. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `private` | RoomInfo | String roomName, Hashtable roomProperties | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | Equals | Object other | `Boolean` | Makes RoomInfo comparable (by name). |
| `public` | GetHashCode |  | `Int32` | Accompanies Equals, using the name's HashCode as return. |
| `public` | ToString |  | `String` | Returns most interesting room values as string. |
| `public` | ToStringFull |  | `String` | Returns most interesting room values as string, including custom properties. |
| `protected internal` | InternalCacheProperties | Hashtable propertiesToCache | `Void` | Copies "well known" properties to fields (IsVisible, etc) and caches the custom properties (string-keys only) in a local hashtable. |

---

