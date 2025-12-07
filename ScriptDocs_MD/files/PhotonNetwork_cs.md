# File: PhotonNetwork.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/PhotonNetwork.cs`

<a id='PhotonNetwork'></a>
## Class PhotonNetwork
**Namespace:** `Photon.Pun`<br>
**Signature:** `PhotonNetwork`

> The main class to use the PhotonNetwork plugin.  
> This class is static.  
> Static constructor used for basic setup.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | PunVersion | `String` | Version number of PUN. Used in the AppVersion, which separates your playerbase in matchmaking. |  |
| `private` | gameVersion | `String` | Version number of your game. Setting this updates the AppVersion, which separates your playerbase in matchmaking. |  |
| `public` | NetworkingClient | `LoadBalancingClient` | Sent to Photon Server to specify the "Virtual AppId". |  |
| `public` | MAX_VIEW_IDS | `Int32` | The maximum number of assigned PhotonViews per player (or scene). See the [General Documentation](@ref general) topic "Limitations" on how to raise this limitation.<br>VIEW & PLAYER LIMIT CAN BE EASILY CHANGED, SEE DOCS |  |
| `public` | ServerSettingsFileName | `String` | Name of the PhotonServerSettings file (used to load and by PhotonEditor to save new files). |  |
| `private` | photonServerSettings | `ServerSettings` | PhotonEditor will use this to load and save the settings delayed |  |
| `private` | PlayerPrefsKey | `String` | Key to save the "Best Region Summary" in the Player Preferences. |  |
| `public` | ConnectMethod | `ConnectMethod` | Tracks, which Connect method was called last. |  |
| `public` | LogLevel | `PunLogLevel` | Controls how verbose PUN is. |  |
| `public` | EnableCloseConnection | `Boolean` | Used to enable reaction to CloseConnection events. Default: false. |  |
| `public` | PrecisionForVectorSynchronization | `Single` | The minimum difference that a Vector2 or Vector3(e.g. a transforms rotation) needs to change before we send it via a PhotonView's OnSerialize/ObservingComponent. |  |
| `public` | PrecisionForQuaternionSynchronization | `Single` | The minimum angle that a rotation needs to change before we send it via a PhotonView's OnSerialize/ObservingComponent. |  |
| `public` | PrecisionForFloatSynchronization | `Single` | The minimum difference between floats before we send it via a PhotonView's OnSerialize/ObservingComponent. |  |
| `private` | offlineMode | `Boolean` | Offline mode can be set to re-use your multiplayer code in singleplayer game modes.<br>When this is on PhotonNetwork will not create any connections and there is near to<br>no overhead. Mostly usefull for reusing RPC's and PhotonNetwork.Instantiate |  |
| `private` | offlineModeRoom | `Room` |  |  |
| `private` | automaticallySyncScene | `Boolean` | Defines if all clients in a room should automatically load the same level as the Master Client. |  |
| `private` | sendFrequency | `Int32` | If enabled, the client will get a list of available lobbies from the Master Server.<br>in milliseconds. |  |
| `private` | serializationFrequency | `Int32` | Defines how many times per second OnPhotonSerialize should be called on PhotonViews for controlled objects.<br>in milliseconds. I.e. 100 = 100ms which makes 10 times/second |  |
| `private` | isMessageQueueRunning | `Boolean` | Can be used to pause dispatching of incoming events (RPCs, Instantiates and anything else incoming).<br>Backup for property IsMessageQueueRunning. |  |
| `private` | frametime | `Double` |  |  |
| `private` | frame | `Int32` |  |  |
| `private` | StartupStopwatch | `Stopwatch` | Used for Photon/PUN timing, as Time.time can't be called from Threads. |  |
| `public` | MinimalTimeScaleToDispatchInFixedUpdate | `Single` | Affects if the PhotonHandler dispatches incoming messages in LateUpdate or FixedUpdate (default). |  |
| `private` | lastUsedViewSubId | `Int32` | each player only needs to remember it's own (!) last used subId to speed up assignment |  |
| `private` | lastUsedViewSubIdStatic | `Int32` | per room, the master is able to instantiate GOs. the subId for this must be unique too |  |
| `private` | PrefabsWithoutMagicCallback | `HashSet`1` |  |  |
| `private` | SendInstantiateEvHashtable | `Hashtable` | SendInstantiate reuses this to reduce GC |  |
| `private` | SendInstantiateRaiseEventOptions | `RaiseEventOptions` | SendInstantiate reuses this to reduce GC |  |
| `private` | allowedReceivingGroups | `HashSet`1` |  |  |
| `private` | blockedSendingGroups | `HashSet`1` |  |  |
| `private` | reusablePVHashset | `HashSet`1` |  |  |
| `private` | photonViewList | `NonAllocDictionary`2` |  |  |
| `internal` | currentLevelPrefix | `Byte` |  |  |
| `internal` | loadingLevelAndPausedNetwork | `Boolean` |  |  |
| `internal` | CurrentSceneProperty | `String` |  |  |
| `internal` | CurrentScenePropertyLoadAsync | `String` |  |  |
| `private` | prefabPool | `IPunPrefabPool` |  |  |
| `public` | UseRpcMonoBehaviourCache | `Boolean` |  |  |
| `private` | monoRPCMethodsCache | `Dictionary`2` |  |  |
| `private` | rpcShortcuts | `Dictionary`2` |  |  |
| `public` | RunRpcCoroutines | `Boolean` |  |  |
| `private` | _AsyncLevelLoadingOperation | `AsyncOperation` |  |  |
| `private` | _levelLoadingProgress | `Single` |  |  |
| `private` | typePunRPC | `Type` |  |  |
| `private` | typePhotonMessageInfo | `Type` |  |  |
| `private` | keyByteZero | `Object` |  |  |
| `private` | keyByteOne | `Object` |  |  |
| `private` | keyByteTwo | `Object` |  |  |
| `private` | keyByteThree | `Object` |  |  |
| `private` | keyByteFour | `Object` |  |  |
| `private` | keyByteFive | `Object` |  |  |
| `private` | keyByteSix | `Object` |  |  |
| `private` | keyByteSeven | `Object` |  |  |
| `private` | keyByteEight | `Object` |  |  |
| `private` | emptyObjectArray | `Object[]` |  |  |
| `private` | emptyTypeArray | `Type[]` |  |  |
| `internal` | foundPVs | `List`1` |  |  |
| `private` | removeFilter | `Hashtable` |  |  |
| `private` | ServerCleanDestroyEvent | `Hashtable` |  |  |
| `private` | ServerCleanOptions | `RaiseEventOptions` |  |  |
| `internal` | SendToAllOptions | `RaiseEventOptions` |  |  |
| `internal` | SendToOthersOptions | `RaiseEventOptions` |  |  |
| `internal` | SendToSingleOptions | `RaiseEventOptions` |  |  |
| `private` | rpcFilterByViewId | `Hashtable` |  |  |
| `private` | OpCleanRpcBufferOptions | `RaiseEventOptions` |  |  |
| `private` | rpcEvent | `Hashtable` |  |  |
| `private` | RpcOptionsToAll | `RaiseEventOptions` |  |  |
| `public` | ObjectsInOneUpdate | `Int32` |  |  |
| `private` | serializeStreamOut | `PhotonStream` |  |  |
| `private` | serializeStreamIn | `PhotonStream` |  |  |
| `private` | serializeRaiseEvOptions | `RaiseEventOptions` |  |  |
| `private` | serializeViewBatches | `Dictionary`2` |  |  |
| `public` | SyncViewId | `Int32` |  |  |
| `public` | SyncCompressed | `Int32` |  |  |
| `public` | SyncNullValues | `Int32` |  |  |
| `public` | SyncFirstValue | `Int32` |  |  |
| `private` | _cachedRegionHandler | `RegionHandler` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | GameVersion <br><small>{ get; set; }</small> | `String` | Version number of your game. Setting this updates the AppVersion, which separates your playerbase in matchmaking. |
| `public` | AppVersion <br><small>{ get;  }</small> | `String` | Sent to Photon Server to specify the "Virtual AppId". |
| `public` | PhotonServerSettings <br><small>{ get; set; }</small> | `ServerSettings` | Serialized server settings, written by the Setup Wizard for use in ConnectUsingSettings. |
| `public` | ServerAddress <br><small>{ get;  }</small> | `String` | Currently used server address (no matter if master or game server). |
| `public` | CloudRegion <br><small>{ get;  }</small> | `String` | Currently used Cloud Region (if any). As long as the client is not on a Master Server or Game Server, the region is not yet defined. |
| `public` | CurrentCluster <br><small>{ get;  }</small> | `String` | The cluster name provided by the Name Server. |
| `public` | BestRegionSummaryInPreferences <br><small>{ get; set; }</small> | `String` | Used to store and access the "Best Region Summary" in the Player Preferences. |
| `public` | IsConnected <br><small>{ get;  }</small> | `Boolean` | False until you connected to Photon initially. True immediately after Connect-call, in offline mode, while connected to any server and even while switching servers. |
| `public` | IsConnectedAndReady <br><small>{ get;  }</small> | `Boolean` | A refined version of connected which is true only if your connection to the server is ready to accept operations like join, leave, etc. |
| `public` | NetworkClientState <br><small>{ get;  }</small> | `ClientState` | Directly provides the network-level client state, unless in OfflineMode.<br>Is true while being in a room (NetworkClientState == ClientState.Joined). |
| `public` | Server <br><small>{ get;  }</small> | `ServerConnection` | The server (type) this client is currently connected or connecting to. |
| `public` | AuthValues <br><small>{ get; set; }</small> | `AuthenticationValues` | A user's authentication values used during connect. |
| `public` | CurrentLobby <br><small>{ get;  }</small> | `TypedLobby` | The lobby that will be used when PUN joins a lobby or creates a game.<br>This is defined when joining a lobby or creating rooms |
| `public` | CurrentRoom <br><small>{ get;  }</small> | `Room` | The lobby that will be used when PUN joins a lobby or creates a game.<br>This is defined when joining a lobby or creating rooms |
| `public` | LocalPlayer <br><small>{ get;  }</small> | `Player` | This client's Player instance is always available, unless the app shuts down. |
| `public` | NickName <br><small>{ get; set; }</small> | `String` | Set to synchronize the player's nickname with everyone in the room(s) you enter. This sets PhotonNetwork.player.NickName. |
| `public` | PlayerList <br><small>{ get;  }</small> | `Player[]` | Set to synchronize the player's nickname with everyone in the room(s) you enter. This sets PhotonNetwork.player.NickName. |
| `public` | PlayerListOthers <br><small>{ get;  }</small> | `Player[]` | A sorted copy of the players-list of the current room, excluding this client. This is using Linq, so better cache this value. Update when players join / leave. |
| `public` | OfflineMode <br><small>{ get; set; }</small> | `Boolean` | Offline mode can be set to re-use your multiplayer code in singleplayer game modes.<br>When this is on PhotonNetwork will not create any connections and there is near to<br>no overhead. Mostly usefull for reusing RPC's and PhotonNetwork.Instantiate<br>Cleanup offline mode |
| `public` | AutomaticallySyncScene <br><small>{ get; set; }</small> | `Boolean` | Defines if all clients in a room should automatically load the same level as the Master Client. |
| `public` | EnableLobbyStatistics <br><small>{ get;  }</small> | `Boolean` | If enabled, the client will get a list of available lobbies from the Master Server. |
| `public` | InLobby <br><small>{ get;  }</small> | `Boolean` | If enabled, the client will get a list of available lobbies from the Master Server. |
| `public` | SendRate <br><small>{ get; set; }</small> | `Int32` | If enabled, the client will get a list of available lobbies from the Master Server. |
| `public` | SerializationRate <br><small>{ get; set; }</small> | `Int32` | Defines how many times per second OnPhotonSerialize should be called on PhotonViews for controlled objects. |
| `public` | IsMessageQueueRunning <br><small>{ get; set; }</small> | `Boolean` | Can be used to pause dispatching of incoming events (RPCs, Instantiates and anything else incoming). |
| `public` | Time <br><small>{ get;  }</small> | `Double` | Photon network time, synched with the server. |
| `public` | ServerTimestamp <br><small>{ get;  }</small> | `Int32` | The current server's millisecond timestamp. |
| `public` | KeepAliveInBackground <br><small>{ get; set; }</small> | `Single` | Defines how many seconds PUN keeps the connection after Unity's OnApplicationPause(true) call. Default: 60 seconds. |
| `public` | IsMasterClient <br><small>{ get;  }</small> | `Boolean` | Are we the master client? |
| `public` | MasterClient <br><small>{ get;  }</small> | `Player` | The Master Client of the current room or null (outside of rooms). |
| `public` | InRoom <br><small>{ get;  }</small> | `Boolean` | Is true while being in a room (NetworkClientState == ClientState.Joined). |
| `public` | CountOfPlayersOnMaster <br><small>{ get;  }</small> | `Int32` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | CountOfPlayersInRooms <br><small>{ get;  }</small> | `Int32` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | CountOfPlayers <br><small>{ get;  }</small> | `Int32` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | CountOfRooms <br><small>{ get;  }</small> | `Int32` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | NetworkStatisticsEnabled <br><small>{ get; set; }</small> | `Boolean` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | ResentReliableCommands <br><small>{ get;  }</small> | `Int32` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | CrcCheckEnabled <br><small>{ get; set; }</small> | `Boolean` | The count of players currently looking for a room (available on MasterServer in 5sec intervals). |
| `public` | PacketLossByCrcCheck <br><small>{ get;  }</small> | `Int32` | If CrcCheckEnabled, this counts the incoming packages that don't have a valid CRC checksum and got rejected. |
| `public` | MaxResendsBeforeDisconnect <br><small>{ get; set; }</small> | `Int32` | If CrcCheckEnabled, this counts the incoming packages that don't have a valid CRC checksum and got rejected. |
| `public` | QuickResends <br><small>{ get; set; }</small> | `Int32` | In case of network loss, reliable messages can be repeated quickly up to 3 times. |
| `public` | UseAlternativeUdpPorts <br><small>{ get; set; }</small> | `Boolean` | Replaced by ServerPortOverrides. |
| `public` | ServerPortOverrides <br><small>{ get; set; }</small> | `PhotonPortDefinition` | Defines overrides for server ports. Used per server-type if > 0. Important: If you change the transport protocol, adjust the overrides, too. |
| `public` | PhotonViews <br><small>{ get;  }</small> | `PhotonView[]` |  |
| `public` | PhotonViewCollection <br><small>{ get;  }</small> | `ValueIterator` |  |
| `public` | ViewCount <br><small>{ get;  }</small> | `Int32` |  |
| `public` | PrefabPool <br><small>{ get; set; }</small> | `IPunPrefabPool` |  |
| `public` | LevelLoadingProgress <br><small>{ get;  }</small> | `Single` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | S StaticReset |  | `Void` | in builds, we just reset/init the client once<br>in OLDER unity editor versions there is no RuntimeInitializeOnLoadMethod, so call reset |
| `public` | S ConnectUsingSettings |  | `Boolean` | Connect to Photon as configured in the PhotonServerSettings file.<br>parameter name hides static class member |
| `public` | S ConnectUsingSettings | AppSettings appSettings, Boolean startInOfflineMode | `Boolean` | Connect to Photon as configured in the PhotonServerSettings file.<br>parameter name hides static class member |
| `public` | S ConnectToMaster | String masterServerAddress, Int32 port, String appID | `Boolean` | Connect to a Photon Master Server by address, port, appID. |
| `public` | S ConnectToBestCloudServer |  | `Boolean` | Connect to the Photon Cloud region with the lowest ping (on platforms that support Unity's Ping). |
| `public` | S ConnectToRegion | String region | `Boolean` | Connects to the Photon Cloud region of choice. |
| `public` | S Disconnect |  | `Void` | Makes this client disconnect from the photon server, a process that leaves any room and calls OnDisconnected on completion. |
| `public` | S Reconnect |  | `Boolean` | Can be used to reconnect to the master server after a disconnect. |
| `public` | S NetworkStatisticsReset |  | `Void` | Resets the traffic stats and re-enables them. |
| `public` | S NetworkStatisticsToString |  | `String` | Only available when NetworkStatisticsEnabled was used to gather some stats. |
| `private` | S VerifyCanUseNetwork |  | `Boolean` | Helper function which is called inside this class to erify if certain functions can be used (e.g. RPC when not connected) |
| `public` | S GetPing |  | `Int32` | The current roundtrip time to the photon server. |
| `public` | S FetchServerTimestamp |  | `Void` | Refreshes the server timestamp (async operation, takes a roundtrip). |
| `public` | S SendAllOutgoingCommands |  | `Void` | Can be used to immediately send the RPCs and Instantiates just called, so they are on their way to the other players. |
| `public` | S CloseConnection | Player kickPlayer | `Boolean` | Request a client to disconnect/kick, which happens if EnableCloseConnection is set to true. Only the master client can do this. |
| `public` | S SetMasterClient | Player masterClientPlayer | `Boolean` | Asks the server to assign another player as Master Client of your current room. |
| `public` | S JoinRandomRoom |  | `Boolean` | Joins a random room that matches the filter. Will callback: OnJoinedRoom or OnJoinRandomFailed. |
| `public` | S JoinRandomRoom | Hashtable expectedCustomRoomProperties, Byte expectedMaxPlayers | `Boolean` | Joins a random room that matches the filter. Will callback: OnJoinedRoom or OnJoinRandomFailed. |
| `public` | S JoinRandomRoom | Hashtable expectedCustomRoomProperties, Byte expectedMaxPlayers, MatchmakingMode matchingType, TypedLobby typedLobby, String sqlLobbyFilter, String[] expectedUsers | `Boolean` | Joins a random room that matches the filter. Will callback: OnJoinedRoom or OnJoinRandomFailed. |
| `public` | S JoinRandomOrCreateRoom | Hashtable expectedCustomRoomProperties, Byte expectedMaxPlayers, MatchmakingMode matchingType, TypedLobby typedLobby, String sqlLobbyFilter, String roomName, RoomOptions roomOptions, String[] expectedUsers | `Boolean` | Attempts to join a room that matches the specified filter and creates a room if none found. |
| `public` | S CreateRoom | String roomName, RoomOptions roomOptions, TypedLobby typedLobby, String[] expectedUsers | `Boolean` | Creates a new room. Will callback: OnCreatedRoom and OnJoinedRoom or OnCreateRoomFailed. |
| `public` | S JoinOrCreateRoom | String roomName, RoomOptions roomOptions, TypedLobby typedLobby, String[] expectedUsers | `Boolean` | Joins a specific room by name and creates it on demand. Will callback: OnJoinedRoom or OnJoinRoomFailed. |
| `public` | S JoinRoom | String roomName, String[] expectedUsers | `Boolean` | Joins a room by name. Will callback: OnJoinedRoom or OnJoinRoomFailed. |
| `public` | S RejoinRoom | String roomName | `Boolean` | Rejoins a room by roomName (using the userID internally to return).  Will callback: OnJoinedRoom or OnJoinRoomFailed. |
| `public` | S ReconnectAndRejoin |  | `Boolean` | When the client lost connection during gameplay, this method attempts to reconnect and rejoin the room. |
| `public` | S LeaveRoom | Boolean becomeInactive | `Boolean` | Leave the current room and return to the Master Server where you can join or create rooms (see remarks). |
| `private` | S EnterOfflineRoom | String roomName, RoomOptions roomOptions, Boolean createdRoom | `Void` | in offline mode, JoinOrCreateRoom assumes you create the room<br>Internally used helper-method to setup an offline room, the numbers for actor and master-client and to do the callbacks. |
| `public` | S JoinLobby |  | `Boolean` | On MasterServer this joins the default lobby which list rooms currently in use.<br>On a Master Server you can join a lobby to get lists of available rooms. |
| `public` | S JoinLobby | TypedLobby typedLobby | `Boolean` | On MasterServer this joins the default lobby which list rooms currently in use.<br>On a Master Server you can join a lobby to get lists of available rooms. |
| `public` | S LeaveLobby |  | `Boolean` | Leave a lobby to stop getting updates about available rooms. |
| `public` | S FindFriends | String[] friendsToFind | `Boolean` | Requests the rooms and online status for a list of friends and saves the result in PhotonNetwork.Friends. |
| `public` | S GetCustomRoomList | TypedLobby typedLobby, String sqlLobbyFilter | `Boolean` | Fetches a custom list of games from the server, matching a (non-empty) SQL-like filter. Triggers OnRoomListUpdate callback. |
| `public` | S SetPlayerCustomProperties | Hashtable customProperties | `Boolean` | Sets this (local) player's properties and synchronizes them to the other players (don't modify them directly). |
| `public` | S RemovePlayerCustomProperties | String[] customPropertiesToDelete | `Void` | Locally removes Custom Properties of "this" player. Important: This does not synchronize the change! Useful when you switch rooms. |
| `public` | S RaiseEvent | Byte eventCode, Object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions | `Boolean` | Sends fully customizable events in a room. Events consist of at least an EventCode (0..199) and can have content. |
| `private` | S RaiseEventInternal | Byte eventCode, Object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions | `Boolean` | Sends PUN-specific events to the server, unless in offlineMode. |
| `public` | S AllocateViewID | PhotonView view | `Boolean` | Allocates a viewID for the current/local player.<br>Allocates a viewID for the current/local player or the room. |
| `public` | S AllocateSceneViewID | PhotonView view | `Boolean` |  |
| `public` | S AllocateRoomViewID | PhotonView view | `Boolean` | Enables the Master Client to allocate a viewID for room objects. |
| `public` | S AllocateViewID | Boolean roomObject | `Int32` | Allocates a viewID for the current/local player.<br>Allocates a viewID for the current/local player or the room. |
| `public` | S AllocateViewID | Int32 ownerId | `Int32` | Allocates a viewID for the current/local player.<br>Allocates a viewID for the current/local player or the room. |
| `public` | S Instantiate | String prefabName, Vector3 position, Quaternion rotation, Byte group, Object[] data | `GameObject` |  |
| `public` | S InstantiateSceneObject | String prefabName, Vector3 position, Quaternion rotation, Byte group, Object[] data | `GameObject` |  |
| `public` | S InstantiateRoomObject | String prefabName, Vector3 position, Quaternion rotation, Byte group, Object[] data | `GameObject` |  |
| `private` | S NetworkInstantiate | Hashtable networkEvent, Player creator | `GameObject` |  |
| `private` | S NetworkInstantiate | InstantiateParameters parameters, Boolean roomObject, Boolean instantiateEvent | `GameObject` |  |
| `internal` | S SendInstantiate | InstantiateParameters parameters, Boolean roomObject | `Boolean` |  |
| `public` | S Destroy | PhotonView targetView | `Void` | Network-Destroy the GameObject associated with the PhotonView, unless the PhotonView is static or not under this client's control.<br>Network-Destroy the GameObject, unless it is static or not under this client's control. |
| `public` | S Destroy | GameObject targetGo | `Void` | Network-Destroy the GameObject associated with the PhotonView, unless the PhotonView is static or not under this client's control.<br>Network-Destroy the GameObject, unless it is static or not under this client's control. |
| `public` | S DestroyPlayerObjects | Player targetPlayer | `Void` | Network-Destroy all GameObjects, PhotonViews and their RPCs of targetPlayer. Can only be called on local player (for "self") or Master Client (for anyone).<br>Network-Destroy all GameObjects, PhotonViews and their RPCs of this player (by ID). Can only be called on local player (for "self") or Master Client (for anyone). |
| `public` | S DestroyPlayerObjects | Int32 targetPlayerId | `Void` | Network-Destroy all GameObjects, PhotonViews and their RPCs of targetPlayer. Can only be called on local player (for "self") or Master Client (for anyone).<br>Network-Destroy all GameObjects, PhotonViews and their RPCs of this player (by ID). Can only be called on local player (for "self") or Master Client (for anyone). |
| `public` | S DestroyAll |  | `Void` | Network-Destroy all GameObjects, PhotonViews and their RPCs in the room. Removes anything buffered from the server. Can only be called by Master Client (for anyone). |
| `public` | S RemoveRPCs | Player targetPlayer | `Void` | Remove all buffered RPCs from server that were sent by targetPlayer. Can only be called on local player (for "self") or Master Client (for anyone).<br>Remove all buffered RPCs from server that were sent via targetPhotonView. The Master Client and the owner of the targetPhotonView may call this. |
| `public` | S RemoveRPCs | PhotonView targetPhotonView | `Void` | Remove all buffered RPCs from server that were sent by targetPlayer. Can only be called on local player (for "self") or Master Client (for anyone).<br>Remove all buffered RPCs from server that were sent via targetPhotonView. The Master Client and the owner of the targetPhotonView may call this. |
| `internal` | S RPC | PhotonView view, String methodName, RpcTarget target, Boolean encrypt, Object[] parameters | `Void` | Internal to send an RPC on given PhotonView. Do not call this directly but use: PhotonView.RPC! |
| `internal` | S RPC | PhotonView view, String methodName, Player targetPlayer, Boolean encrypt, Object[] parameters | `Void` | Internal to send an RPC on given PhotonView. Do not call this directly but use: PhotonView.RPC! |
| `public` | S FindGameObjectsWithComponent | Type type | `HashSet`1` | Finds the GameObjects with Components of a specific type (using FindObjectsOfType). |
| `public` | S SetInterestGroups | Byte group, Boolean enabled | `Void` | Enable/disable receiving events from a given Interest Group. |
| `public` | S LoadLevel | Int32 levelNumber | `Void` | This method wraps loading a level asynchronously and pausing network messages during the process. |
| `public` | S LoadLevel | String levelName | `Void` | This method wraps loading a level asynchronously and pausing network messages during the process. |
| `public` | S WebRpc | String name, Object parameters, Boolean sendAuthCookie | `Boolean` | This operation makes Photon call your custom web-service by name (path) with the given parameters. |
| `private` | S SetupLogging |  | `Void` | Applies default log settings if they are not set up programmatically. |
| `public` | S LoadOrCreateSettings | Boolean reload | `Void` |  |
| `public` | S FindAssetPath | String asset | `String` | Finds the asset path base on its name or search query: https://docs.unity3d.com/ScriptReference/AssetDatabase.FindAssets.html |
| `public` | S FindPunAssetFolder |  | `String` | Finds the pun asset folder. Something like Assets/Photon Unity Networking/Resources/ |
| `public` | S InternalCleanPhotonMonoFromSceneIfStuck |  | `Void` | Internally used by Editor scripts, called on Hierarchy change (includes scene save) to remove surplus hidden PhotonHandlers. |
| `public` | S AddCallbackTarget | Object target | `Void` |  |
| `public` | S RemoveCallbackTarget | Object target | `Void` |  |
| `internal` | S CallbacksToString |  | `String` |  |
| `private` | S LeftRoomCleanup |  | `Void` |  |
| `internal` | S LocalCleanupAnythingInstantiated | Boolean destroyInstantiatedGameObjects | `Void` |  |
| `private` | S ResetPhotonViewsOnSerialize |  | `Void` |  |
| `internal` | S ExecuteRpc | Hashtable rpcData, Player sender | `Void` |  |
| `private` | S CheckTypeMatch | ParameterInfo[] methodParameters, Type[] callParameterTypes | `Boolean` |  |
| `public` | S DestroyPlayerObjects | Int32 playerId, Boolean localOnly | `Void` | Network-Destroy all GameObjects, PhotonViews and their RPCs of targetPlayer. Can only be called on local player (for "self") or Master Client (for anyone).<br>Network-Destroy all GameObjects, PhotonViews and their RPCs of this player (by ID). Can only be called on local player (for "self") or Master Client (for anyone). |
| `public` | S DestroyAll | Boolean localOnly | `Void` | Network-Destroy all GameObjects, PhotonViews and their RPCs in the room. Removes anything buffered from the server. Can only be called by Master Client (for anyone). |
| `internal` | S RemoveInstantiatedGO | GameObject go, Boolean localOnly | `Void` |  |
| `private` | S ServerCleanInstantiateAndDestroy | PhotonView photonView | `Void` |  |
| `private` | S SendDestroyOfPlayer | Int32 actorNr | `Void` |  |
| `private` | S SendDestroyOfAll |  | `Void` |  |
| `private` | S OpRemoveFromServerInstantiationsOfPlayer | Int32 actorNr | `Void` |  |
| `internal` | S RequestOwnership | Int32 viewID, Int32 fromOwner | `Void` |  |
| `internal` | S TransferOwnership | Int32 viewID, Int32 playerID | `Void` |  |
| `internal` | S OwnershipUpdate | Int32[] viewOwnerPairs, Int32 targetActor | `Void` |  |
| `public` | S LocalCleanPhotonView | PhotonView view | `Boolean` |  |
| `public` | S GetPhotonView | Int32 viewID | `PhotonView` |  |
| `public` | S RegisterPhotonView | PhotonView netView | `Void` |  |
| `public` | S OpCleanActorRpcBuffer | Int32 actorNumber | `Void` |  |
| `public` | S OpRemoveCompleteCacheOfPlayer | Int32 actorNumber | `Void` |  |
| `public` | S OpRemoveCompleteCache |  | `Void` |  |
| `private` | S RemoveCacheOfLeftPlayers |  | `Void` |  |
| `public` | S CleanRpcBufferIfMine | PhotonView view | `Void` |  |
| `public` | S OpCleanRpcBuffer | PhotonView view | `Void` |  |
| `public` | S RemoveRPCsInGroup | Int32 group | `Void` |  |
| `public` | S RemoveBufferedRPCs | Int32 viewId, String methodName, Int32[] callersActorNumbers | `Boolean` |  |
| `public` | S SetLevelPrefix | Byte prefix | `Void` |  |
| `internal` | S RPC | PhotonView view, String methodName, RpcTarget target, Player player, Boolean encrypt, Object[] parameters | `Void` | Internal to send an RPC on given PhotonView. Do not call this directly but use: PhotonView.RPC! |
| `public` | S SetInterestGroups | Byte[] disableGroups, Byte[] enableGroups | `Void` | Enable/disable receiving events from a given Interest Group. |
| `public` | S SetSendingEnabled | Byte group, Boolean enabled | `Void` |  |
| `public` | S SetSendingEnabled | Byte[] disableGroups, Byte[] enableGroups | `Void` |  |
| `internal` | S NewSceneLoaded |  | `Void` |  |
| `internal` | S RunViewUpdate |  | `Void` |  |
| `private` | S SendSerializeViewBatch | SerializeViewBatch batch | `Void` |  |
| `private` | S OnSerializeWrite | PhotonView view | `List`1` |  |
| `private` | S OnSerializeRead | Object[] data, Player sender, Int32 networkTime, Int16 correctPrefix | `Void` |  |
| `private` | S DeltaCompressionWrite | List`1 previousContent, List`1 currentContent | `List`1` |  |
| `private` | S DeltaCompressionRead | Object[] lastOnSerializeDataReceived, Object[] incomingData | `Object[]` |  |
| `private` | S AlmostEquals | IList`1 lastData, IList`1 currentContent | `Boolean` |  |
| `private` | S AlmostEquals | Object one, Object two | `Boolean` |  |
| `internal` | S GetMethod | MonoBehaviour monob, String methodType, MethodInfo& mi | `Boolean` |  |
| `internal` | S LoadLevelIfSynced |  | `Void` |  |
| `internal` | S SetLevelInPropsIfSynced | Object levelId | `Void` |  |
| `private` | S OnEvent | EventData photonEvent | `Void` |  |
| `private` | S OnOperation | OperationResponse opResponse | `Void` |  |
| `private` | S OnClientStateChanged | ClientState previousState, ClientState state | `Void` |  |
| `private` | S OnRegionsPinged | RegionHandler regionHandler | `Void` |  |

---

