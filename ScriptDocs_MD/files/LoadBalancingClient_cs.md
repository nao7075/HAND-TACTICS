# File: LoadBalancingClient.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/LoadBalancingClient.cs`

<a id='LoadBalancingClient'></a>
## Class LoadBalancingClient
**Namespace:** `Photon.Realtime`<br>
**Signature:** `LoadBalancingClient : IPhotonPeerListener`

> This class implements the Photon LoadBalancing workflow by using a LoadBalancingPeer.  
> It keeps a state and will automatically execute transitions between the Master and Game Servers.  
> Creates a LoadBalancingClient with UDP protocol or the one specified.  
> Creates a LoadBalancingClient, setting various values needed before connecting.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | AuthMode | `AuthModeOption` | Enables the new Authentication workflow. |  |
| `public` | EncryptionMode | `EncryptionMode` | Realtime apps are for gaming / interaction. Also used by PUN 2.<br>Defines how the communication gets encrypted. |  |
| `private` | tokenCache | `Object` | Internally used cache for the server's token. Identifies a user/session and can be used to rejoin. |  |
| `public` | NameServerHost | `String` | Name Server Host Name for Photon Cloud. Without port and without any prefix. |  |
| `private` | ProtocolToNameServerPort | `Dictionary`2` | Name Server port per protocol (the UDP port is different than TCP, etc). |  |
| `public` | ServerPortOverrides | `PhotonPortDefinition` | Defines overrides for server ports. Used per server-type if > 0. Important: You must change these when the protocol changes! |  |
| `public` | ProxyServerAddress | `String` | Defines a proxy URL for WebSocket connections. Can be the proxy or point to a .pac file. |  |
| `private` | state | `ClientState` | Backing field for property. |  |
| `public` | ConnectionCallbackTargets | `ConnectionCallbacksContainer` | Wraps up the target objects for a group of callbacks, so they can be called conveniently. |  |
| `public` | MatchMakingCallbackTargets | `MatchMakingCallbacksContainer` | Wraps up the target objects for a group of callbacks, so they can be called conveniently. |  |
| `internal` | InRoomCallbackTargets | `InRoomCallbacksContainer` | Wraps up the target objects for a group of callbacks, so they can be called conveniently. |  |
| `internal` | LobbyCallbackTargets | `LobbyCallbacksContainer` | Wraps up the target objects for a group of callbacks, so they can be called conveniently. |  |
| `internal` | WebRpcCallbackTargets | `WebRpcCallbacksContainer` | Wraps up the target objects for a group of callbacks, so they can be called conveniently. |  |
| `internal` | ErrorInfoCallbackTargets | `ErrorInfoCallbacksContainer` | Wraps up the target objects for a group of callbacks, so they can be called conveniently. |  |
| `public` | SystemConnectionSummary | `SystemConnectionSummary` | After a to a connection loss or timeout, this summarizes the most relevant system conditions which might have contributed to the loss. |  |
| `public` | EnableLobbyStatistics | `Boolean` | If enabled, the client will get a list of available lobbies from the Master Server. |  |
| `private` | lobbyStatistics | `List`1` | Internal lobby stats cache, used by LobbyStatistics. |  |
| `private` | lastJoinType | `JoinType` | Internally used to decide if a room must be created or joined on game server. |  |
| `private` | enterRoomParamsCache | `EnterRoomParams` | Used when the client arrives on the GS, to join the room with the correct values. |  |
| `private` | failedRoomEntryOperation | `OperationResponse` | Used to cache a failed "enter room" operation on the Game Server, to return to the Master Server before calling a fail-callback. |  |
| `private` | FriendRequestListMax | `Int32` | Maximum of userIDs that can be sent in one friend list request. |  |
| `private` | friendListRequested | `String[]` | Contains the list of names of friends to look up their state on the server. |  |
| `public` | RegionHandler | `RegionHandler` | Contains the list if enabled regions this client may use. Null, unless the client got a response to OpGetRegions. |  |
| `private` | bestRegionSummaryFromStorage | `String` | Stores the best region summary of a previous session to speed up connecting. |  |
| `public` | SummaryToCache | `String` | Set when the best region pinging is done. |  |
| `private` | connectToBestRegion | `Boolean` | Internal connection setting/flag. If the client should connect to the best region or not. |  |
| `private` | callbackTargetChanges | `Queue`1` |  |  |
| `private` | callbackTargets | `HashSet`1` |  |  |
| `public` | NameServerPortInAppSettings | `Int32` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | LoadBalancingPeer <br><small>{ get; set; }</small> | `LoadBalancingPeer` | The client uses a LoadBalancingPeer as API to communicate with the server.<br>This is public for ease-of-use: Some methods like OpRaiseEvent are not relevant for the connection state and don't need a override. |
| `public` | SerializationProtocol <br><small>{ get; set; }</small> | `SerializationProtocol` | Gets or sets the binary protocol version used by this client |
| `public` | AppVersion <br><small>{ get; set; }</small> | `String` | Gets or sets the binary protocol version used by this client |
| `public` | AppId <br><small>{ get; set; }</small> | `String` | The AppID as assigned from the Photon Cloud. If you host yourself, this is the "regular" Photon Server Application Name (most likely: "LoadBalancing"). |
| `public` | ClientType <br><small>{ get; set; }</small> | `ClientAppType` | The ClientAppType defines which sort of AppId should be expected. The LoadBalancingClient supports Realtime and Voice app types. Default: Realtime. |
| `public` | AuthValues <br><small>{ get; set; }</small> | `AuthenticationValues` | User authentication values to be sent to the Photon server right after connecting. |
| `public` | ExpectedProtocol <br><small>{ get; set; }</small> | `Nullable`1` | Optionally contains a protocol which will be used on Master- and GameServer. |
| `private` | TokenForInit <br><small>{ get;  }</small> | `Object` | Simplifies getting the token for connect/init requests, if this feature is enabled. |
| `public` | IsUsingNameServer <br><small>{ get; set; }</small> | `Boolean` | True if this client uses a NameServer to get the Master Server address. |
| `public` | NameServerAddress <br><small>{ get;  }</small> | `String` | Name Server Address for Photon Cloud (based on current protocol). You can use the default values and usually won't have to set this value. |
| `public` | UseAlternativeUdpPorts <br><small>{ get; set; }</small> | `Boolean` | Replaced by ServerPortOverrides. |
| `public` | EnableProtocolFallback <br><small>{ get; set; }</small> | `Boolean` | Enables a fallback to another protocol in case a connect to the Name Server fails. |
| `public` | CurrentServerAddress <br><small>{ get;  }</small> | `String` | The currently used server address (if any). The type of server is define by Server property. |
| `public` | MasterServerAddress <br><small>{ get; set; }</small> | `String` | Your Master Server address. In PhotonCloud, call ConnectToRegionMaster() to find your Master Server. |
| `public` | GameServerAddress <br><small>{ get; set; }</small> | `String` | The game server's address for a particular room. In use temporarily, as assigned by master. |
| `public` | Server <br><small>{ get; set; }</small> | `ServerConnection` | The server this client is currently connected or connecting to. |
| `public` | State <br><small>{ get; set; }</small> | `ClientState` | Current state this client is in. Careful: several states are "transitions" that lead to other states. |
| `public` | IsConnected <br><small>{ get;  }</small> | `Boolean` | Returns if this client is currently connected or connecting to some type of server. |
| `public` | IsConnectedAndReady <br><small>{ get;  }</small> | `Boolean` | A refined version of IsConnected which is true only if your connection is ready to send operations. |
| `public` | DisconnectedCause <br><small>{ get; set; }</small> | `DisconnectCause` | Summarizes (aggregates) the different causes for disconnects of a client. |
| `public` | InLobby <br><small>{ get;  }</small> | `Boolean` | Internal value if the client is in a lobby. |
| `public` | CurrentLobby <br><small>{ get; set; }</small> | `TypedLobby` | Internal value if the client is in a lobby. |
| `public` | LocalPlayer <br><small>{ get; set; }</small> | `Player` | The local player is never null but not valid unless the client is in a room, too. The ID will be -1 outside of rooms. |
| `public` | NickName <br><small>{ get; set; }</small> | `String` | The nickname of the player (synced with others). Same as client.LocalPlayer.NickName. |
| `public` | UserId <br><small>{ get; set; }</small> | `String` | An ID for this user. Sent in OpAuthenticate when you connect. If not set, the PlayerName is applied during connect. |
| `public` | CurrentRoom <br><small>{ get; set; }</small> | `Room` | The current room this client is connected to (null if none available). |
| `public` | InRoom <br><small>{ get;  }</small> | `Boolean` | Is true while being in a room (this.state == ClientState.Joined). |
| `public` | PlayersOnMasterCount <br><small>{ get; set; }</small> | `Int32` | Is true while being in a room (this.state == ClientState.Joined). |
| `public` | PlayersInRoomsCount <br><small>{ get; set; }</small> | `Int32` | Statistic value available on master server: Players in rooms (playing). |
| `public` | RoomsCount <br><small>{ get; set; }</small> | `Int32` | Statistic value available on master server: Rooms currently created. |
| `public` | IsFetchingFriendList <br><small>{ get;  }</small> | `Boolean` | Internal flag to know if the client currently fetches a friend list. |
| `public` | CloudRegion <br><small>{ get; set; }</small> | `String` | The cloud region this client connects to. Set by ConnectToRegionMaster(). Not set if you don't use a NameServer! |
| `public` | CurrentCluster <br><small>{ get; set; }</small> | `String` | The cluster name provided by the Name Server. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | LoadBalancingClient | ConnectionProtocol protocol | Constructor |
| `public` | LoadBalancingClient | String masterAddress, String appId, String gameVersion, ConnectionProtocol protocol | Constructor |
| `private` | LoadBalancingClient |  | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | GetNameServerAddress |  | `String` | Gets the NameServer Address (with prefix and port), based on the set protocol (this.LoadBalancingPeer.UsedProtocol). |
| `public` | ConnectUsingSettings | AppSettings appSettings | `Boolean` | Starts the "process" to connect as defined by the appSettings (AppId, AppVersion, Transport Protocol, Port and more). |
| `public` | Connect |  | `Boolean` | Privately used only for reconnecting. |
| `public` | ConnectToMasterServer |  | `Boolean` | Starts the "process" to connect to a Master Server, using MasterServerAddress and AppId properties. |
| `public` | ConnectToNameServer |  | `Boolean` | Connects to the NameServer for Photon Cloud, where a region and server list can be obtained. |
| `public` | ConnectToRegionMaster | String region | `Boolean` | Connects you to a specific region's Master Server, using the Name Server to get the IP. |
| `private` | CheckConnectSetupWebGl |  | `Void` |  |
| `private` | Connect | String serverAddress, String proxyServerAddress, ServerConnection serverType | `Boolean` | Privately used only for reconnecting. |
| `public` | ReconnectToMaster |  | `Boolean` | Can be used to reconnect to the master server after a disconnect. |
| `public` | ReconnectAndRejoin |  | `Boolean` | Can be used to return to a room quickly by directly reconnecting to a game server to rejoin a room. |
| `public` | Disconnect | DisconnectCause cause | `Void` | Disconnects the peer from a server or stays disconnected. If the client / peer was connected, a callback will be triggered. |
| `private` | DisconnectToReconnect |  | `Void` | Private Disconnect variant that sets the state, too. |
| `public` | SimulateConnectionLoss | Boolean simulateTimeout | `Void` | Useful to test loss of connection which will end in a client timeout. This modifies LoadBalancingPeer.NetworkSimulationSettings. Read remarks. |
| `private` | CallAuthenticate |  | `Boolean` |  |
| `public` | Service |  | `Void` | This method dispatches all available incoming commands and then sends this client's outgoing commands.<br>It uses DispatchIncomingCommands and SendOutgoingCommands to do that. |
| `private` | OpGetRegions |  | `Boolean` | While on the NameServer, this gets you the list of regional servers (short names and their IPs to ping them). |
| `public` | OpFindFriends | String[] friendsToFind, FindFriendsOptions options | `Boolean` | Request the rooms and online status for a list of friends. All clients should set a unique UserId before connecting. The result is available in this.FriendList. |
| `public` | OpJoinLobby | TypedLobby lobby | `Boolean` | If already connected to a Master Server, this joins the specified lobby. This request triggers an OnOperationResponse() call and the callback OnJoinedLobby(). |
| `public` | OpLeaveLobby |  | `Boolean` | Opposite of joining a lobby. You don't have to explicitly leave a lobby to join another (client can be in one max, at any time). |
| `public` | OpJoinRandomRoom | OpJoinRandomRoomParams opJoinRandomRoomParams | `Boolean` | Joins a random room that matches the filter. Will callback: OnJoinedRoom or OnJoinRandomFailed. |
| `public` | OpJoinRandomOrCreateRoom | OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams | `Boolean` | Attempts to join a room that matches the specified filter and creates a room if none found. |
| `public` | OpCreateRoom | EnterRoomParams enterRoomParams | `Boolean` | Creates a new room. Will callback: OnCreatedRoom and OnJoinedRoom or OnCreateRoomFailed. |
| `public` | OpJoinOrCreateRoom | EnterRoomParams enterRoomParams | `Boolean` | Joins a specific room by name and creates it on demand. Will callback: OnJoinedRoom or OnJoinRoomFailed. |
| `public` | OpJoinRoom | EnterRoomParams enterRoomParams | `Boolean` | Joins a room by name. Will callback: OnJoinedRoom or OnJoinRoomFailed. |
| `public` | OpRejoinRoom | String roomName | `Boolean` | Rejoins a room by roomName (using the userID internally to return).  Will callback: OnJoinedRoom or OnJoinRoomFailed. |
| `public` | OpLeaveRoom | Boolean becomeInactive, Boolean sendAuthCookie | `Boolean` | Leaves the current room, optionally telling the server that the user is just becoming inactive. Will callback: OnLeftRoom. |
| `public` | OpGetGameList | TypedLobby typedLobby, String sqlLobbyFilter | `Boolean` | Gets a list of rooms matching the (non empty) SQL filter for the given SQL-typed lobby. |
| `public` | OpSetCustomPropertiesOfActor | Int32 actorNr, Hashtable propertiesToSet, Hashtable expectedProperties, WebFlags webFlags | `Boolean` | Updates and synchronizes a Player's Custom Properties. Optionally, expectedProperties can be provided as condition. |
| `protected internal` | OpSetPropertiesOfActor | Int32 actorNr, Hashtable actorProperties, Hashtable expectedProperties, WebFlags webFlags | `Boolean` | Internally used to cache and set properties (including well known properties). |
| `public` | OpSetCustomPropertiesOfRoom | Hashtable propertiesToSet, Hashtable expectedProperties, WebFlags webFlags | `Boolean` | Updates and synchronizes this Room's Custom Properties. Optionally, expectedProperties can be provided as condition. |
| `protected internal` | OpSetPropertyOfRoom | Byte propCode, Object value | `Boolean` |  |
| `protected internal` | OpSetPropertiesOfRoom | Hashtable gameProperties, Hashtable expectedProperties, WebFlags webFlags | `Boolean` | Internally used to cache and set properties (including well known properties). |
| `public` | OpRaiseEvent | Byte eventCode, Object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions | `Boolean` | Send an event with custom code/type and any content to the other players in the same room. |
| `public` | OpChangeGroups | Byte[] groupsToRemove, Byte[] groupsToAdd | `Boolean` | Operation to handle this client's interest groups (for events in room). |
| `private` | ReadoutProperties | Hashtable gameProperties, Hashtable actorProperties, Int32 targetActorNr | `Void` | Privately used to read-out properties coming from the server in events and operation responses (which might be a bit tricky). |
| `private` | ReadoutPropertiesForActorNr | Hashtable actorProperties, Int32 actorNr | `Hashtable` | Privately used only to read properties for a distinct actor (which might be the hashtable OR a key-pair value IN the actorProperties). |
| `public` | ChangeLocalID | Int32 newID | `Void` | Internally used to set the LocalPlayer's ID (from -1 to the actual in-room ID). |
| `private` | GameEnteredOnGameServer | OperationResponse operationResponse | `Void` | Called internally, when a game was joined or created on the game server successfully. |
| `private` | UpdatedActorList | Int32[] actorsInGame | `Void` |  |
| `protected internal` | CreatePlayer | String actorName, Int32 actorNumber, Boolean isLocal, Hashtable actorProperties | `Player` | Factory method to create a player instance - override to get your own player-type with custom features. |
| `protected internal` | CreateRoom | String roomName, RoomOptions opt | `Room` | This client creates a room, gets into it (no need to join) and can set room properties.<br>Internal "factory" method to create a room-instance. |
| `private` | CheckIfOpAllowedOnServer | Byte opCode, ServerConnection serverConnection | `Boolean` |  |
| `private` | CheckIfOpCanBeSent | Byte opCode, ServerConnection serverConnection, String opName | `Boolean` |  |
| `private` | CheckIfClientIsReadyToCallOperation | Byte opCode | `Boolean` |  |
| `public` | DebugReturn | DebugLevel level, String message | `Void` | Debug output of low level api (and this client). |
| `private` | CallbackRoomEnterFailed | OperationResponse operationResponse | `Void` |  |
| `public` | OnOperationResponse | OperationResponse operationResponse | `Void` | Uses the OperationResponses provided by the server to advance the internal state and call ops as needed. |
| `public` | OnStatusChanged | StatusCode statusCode | `Void` | Uses the connection's statusCodes to advance the internal state and call operations as needed. |
| `public` | OnEvent | EventData photonEvent | `Void` | Uses the photonEvent's provided by the server to advance the internal state and call ops as needed.<br>Called for any incoming events. |
| `public` | OnMessage | Object message | `Void` | In Photon 4, "raw messages" will get their own callback method in the interface. Not used yet. |
| `private` | OnDisconnectMessageReceived | DisconnectMessage obj | `Void` |  |
| `private` | OnRegionPingCompleted | RegionHandler regionHandler | `Void` | A callback of the RegionHandler, provided in OnRegionListReceived. |
| `protected internal` | S ReplacePortWithAlternative | String address, UInt16 replacementPort | `String` |  |
| `private` | SetupEncryption | Dictionary`2 encryptionData | `Void` |  |
| `public` | OpWebRpc | String uriPath, Object parameters, Boolean sendAuthCookie | `Boolean` | This operation makes Photon call your custom web-service by path/name with the given parameters (converted into Json).<br>Use  as a callback. |
| `public` | AddCallbackTarget | Object target | `Void` | Registers an object for callbacks for the implemented callback-interfaces. |
| `public` | RemoveCallbackTarget | Object target | `Void` | Unregisters an object from callbacks for the implemented callback-interfaces. |
| `protected internal` | UpdateCallbackTargets |  | `Void` | Applies queued callback cahnges from a queue to the actual containers. Will cause exceptions if used while callbacks execute. |
| `private` | UpdateCallbackTarget | CallbackTargetChange change, List`1 container | `Void` |  |

---

