# File: ChatClient.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonChat_Code.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatClient.cs`

<a id='ChatClient'></a>
## Class ChatClient
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatClient : IPhotonPeerListener`

> Central class of the Photon Chat API to connect, handle channels and messages.  
> Defines which IPhotonSocket class to use per ConnectionProtocol.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | FriendRequestListMax | `Int32` |  |  |
| `public` | DefaultMaxSubscribers | `Int32` | Default maximum value possible for  when  is enabled |  |
| `private` | HttpForwardWebFlag | `Byte` |  |  |
| `private` | chatRegion | `String` | Region used to connect to. Currently all chat is done in EU. It can make sense to use only one region for the whole game. |  |
| `public` | ProxyServerAddress | `String` | Settable only before you connect! Defaults to "EU". |  |
| `public` | MessageLimit | `Int32` | If greater than 0, new channels will limit the number of messages they cache locally. |  |
| `public` | PrivateChatHistoryLength | `Int32` | Limits the number of messages from private channel histories. |  |
| `public` | PublicChannels | `Dictionary`2` | Public channels this client is subscribed to. |  |
| `public` | PrivateChannels | `Dictionary`2` | Private channels in which this client has exchanged messages. |  |
| `private` | PublicChannelsUnsubscribing | `HashSet`1` |  |  |
| `private` | listener | `IChatClientListener` |  |  |
| `public` | chatPeer | `ChatPeer` | The Chat Peer used by this client. |  |
| `private` | ChatAppName | `String` |  |  |
| `private` | didAuthenticate | `Boolean` |  |  |
| `private` | statusToSetWhenConnected | `Nullable`1` |  |  |
| `private` | messageToSetWhenConnected | `Object` |  |  |
| `private` | msDeltaForServiceCalls | `Int32` |  |  |
| `private` | msTimestampOfLastServiceCall | `Int32` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | EnableProtocolFallback <br><small>{ get; set; }</small> | `Boolean` | Enables a fallback to another protocol in case a connect to the Name Server fails. |
| `public` | NameServerAddress <br><small>{ get; set; }</small> | `String` | The address of last connected Name Server. |
| `public` | FrontendAddress <br><small>{ get; set; }</small> | `String` | The address of the actual chat server assigned from NameServer. Public for read only. |
| `public` | ChatRegion <br><small>{ get; set; }</small> | `String` | Settable only before you connect! Defaults to "EU". |
| `public` | State <br><small>{ get; set; }</small> | `ChatState` | Current state of the ChatClient. Also use CanChat. |
| `public` | DisconnectedCause <br><small>{ get; set; }</small> | `ChatDisconnectCause` | Disconnection cause. Check this inside . |
| `public` | CanChat <br><small>{ get;  }</small> | `Boolean` | Checks if this client is ready to send messages. |
| `private` | HasPeer <br><small>{ get;  }</small> | `Boolean` |  |
| `public` | AppVersion <br><small>{ get; set; }</small> | `String` | The version of your client. A new version also creates a new "virtual app" to separate players from older client versions. |
| `public` | AppId <br><small>{ get; set; }</small> | `String` | The AppID as assigned from the Photon Cloud. |
| `public` | AuthValues <br><small>{ get; set; }</small> | `AuthenticationValues` | Settable only before you connect! |
| `public` | UserId <br><small>{ get; set; }</small> | `String` | The unique ID of a user/person, stored in AuthValues.UserId. Set it before you connect. |
| `public` | UseBackgroundWorkerForSending <br><small>{ get; set; }</small> | `Boolean` | Defines if a background thread will call SendOutgoingCommands, while your code calls Service to dispatch received messages. |
| `public` | TransportProtocol <br><small>{ get; set; }</small> | `ConnectionProtocol` | Exposes the TransportProtocol of the used PhotonPeer. Settable while not connected. |
| `public` | SocketImplementationConfig <br><small>{ get;  }</small> | `Dictionary`2` | Defines which IPhotonSocket class to use per ConnectionProtocol. |
| `public` | DebugOut <br><small>{ get; set; }</small> | `DebugLevel` | Sets the level (and amount) of debug output provided by the library. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | ChatClient | IChatClientListener listener, ConnectionProtocol protocol | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | CanChatInChannel | String channelName | `Boolean` | Checks if this client is ready to send messages. |
| `public` | ConnectUsingSettings | ChatAppSettings appSettings | `Boolean` |  |
| `public` | Connect | String appId, String appVersion, AuthenticationValues authValues | `Boolean` | Connects this client to the Photon Chat Cloud service, which will also authenticate the user (and set a UserId). |
| `public` | ConnectAndSetStatus | String appId, String appVersion, AuthenticationValues authValues, Int32 status, Object message | `Boolean` | Connects this client to the Photon Chat Cloud service, which will also authenticate the user (and set a UserId).<br>This also sets an online status once connected. By default it will set user status to .<br>See  for more information. |
| `public` | Service |  | `Void` | Must be called regularly to keep connection between client and server alive and to process incoming messages. |
| `private` | SendOutgoingInBackground |  | `Boolean` | Called by a separate thread, this sends outgoing commands of this peer, as long as it's connected. |
| `public` | SendAcksOnly |  | `Void` | Obsolete: Better use UseBackgroundWorkerForSending and Service(). |
| `public` | Disconnect | ChatDisconnectCause cause | `Void` | Disconnects from the Chat Server by sending a "disconnect command", which prevents a timeout server-side. |
| `public` | StopThread |  | `Void` | Locally shuts down the connection to the Chat Server. This resets states locally but the server will have to timeout this peer. |
| `public` | Subscribe | String[] channels | `Boolean` | Sends operation to subscribe to a list of channels by name.<br>Sends operation to subscribe to a list of channels by name and possibly retrieve messages we did not receive while unsubscribed.<br>Sends operation to subscribe client to channels, optionally fetching a number of messages from the cache.<br>Subscribe to a single channel and optionally sets its well-know channel properties in case the channel is created. |
| `public` | Subscribe | String[] channels, Int32[] lastMsgIds | `Boolean` | Sends operation to subscribe to a list of channels by name.<br>Sends operation to subscribe to a list of channels by name and possibly retrieve messages we did not receive while unsubscribed.<br>Sends operation to subscribe client to channels, optionally fetching a number of messages from the cache.<br>Subscribe to a single channel and optionally sets its well-know channel properties in case the channel is created. |
| `public` | Subscribe | String[] channels, Int32 messagesFromHistory | `Boolean` | Sends operation to subscribe to a list of channels by name.<br>Sends operation to subscribe to a list of channels by name and possibly retrieve messages we did not receive while unsubscribed.<br>Sends operation to subscribe client to channels, optionally fetching a number of messages from the cache.<br>Subscribe to a single channel and optionally sets its well-know channel properties in case the channel is created. |
| `public` | Unsubscribe | String[] channels | `Boolean` | Unsubscribes from a list of channels, which stops getting messages from those. |
| `public` | PublishMessage | String channelName, Object message, Boolean forwardAsWebhook | `Boolean` | Sends a message to a public channel which this client subscribed to. |
| `internal` | PublishMessageUnreliable | String channelName, Object message, Boolean forwardAsWebhook | `Boolean` |  |
| `private` | publishMessage | String channelName, Object message, Boolean reliable, Boolean forwardAsWebhook | `Boolean` |  |
| `public` | SendPrivateMessage | String target, Object message, Boolean forwardAsWebhook | `Boolean` | Sends a private message to a single target user. Calls OnPrivateMessage on the receiving client. |
| `public` | SendPrivateMessage | String target, Object message, Boolean encrypt, Boolean forwardAsWebhook | `Boolean` | Sends a private message to a single target user. Calls OnPrivateMessage on the receiving client. |
| `internal` | SendPrivateMessageUnreliable | String target, Object message, Boolean encrypt, Boolean forwardAsWebhook | `Boolean` |  |
| `private` | sendPrivateMessage | String target, Object message, Boolean encrypt, Boolean reliable, Boolean forwardAsWebhook | `Boolean` |  |
| `private` | SetOnlineStatus | Int32 status, Object message, Boolean skipMessage | `Boolean` | Sets the user's status (pre-defined or custom) and an optional message.<br>Sets the user's status without changing your status-message. |
| `public` | SetOnlineStatus | Int32 status | `Boolean` | Sets the user's status (pre-defined or custom) and an optional message.<br>Sets the user's status without changing your status-message. |
| `public` | SetOnlineStatus | Int32 status, Object message | `Boolean` | Sets the user's status (pre-defined or custom) and an optional message.<br>Sets the user's status without changing your status-message. |
| `public` | AddFriends | String[] friends | `Boolean` | Adds friends to a list on the Chat Server which will send you status updates for those. |
| `public` | RemoveFriends | String[] friends | `Boolean` | Removes the provided entries from the list on the Chat Server and stops their status updates. |
| `public` | GetPrivateChannelNameByUser | String userName | `String` | Get you the (locally used) channel name for the chat between this client and another user. |
| `public` | TryGetChannel | String channelName, Boolean isPrivate, ChatChannel& channel | `Boolean` | Simplified access to either private or public channels by name.<br>Simplified access to all channels by name. Checks public channels first, then private ones. |
| `public` | TryGetChannel | String channelName, ChatChannel& channel | `Boolean` | Simplified access to either private or public channels by name.<br>Simplified access to all channels by name. Checks public channels first, then private ones. |
| `public` | TryGetPrivateChannelByUser | String userId, ChatChannel& channel | `Boolean` | Simplified access to private channels by target user. |
| `private` | ExitGames.Client.Photon.IPhotonPeerListener.DebugReturn | DebugLevel level, String message | `Void` |  |
| `private` | ExitGames.Client.Photon.IPhotonPeerListener.OnEvent | EventData eventData | `Void` |  |
| `private` | ExitGames.Client.Photon.IPhotonPeerListener.OnOperationResponse | OperationResponse operationResponse | `Void` |  |
| `private` | ExitGames.Client.Photon.IPhotonPeerListener.OnStatusChanged | StatusCode statusCode | `Void` |  |
| `private` | TryAuthenticateOnNameServer |  | `Void` |  |
| `private` | SendChannelOperation | String[] channels, Byte operation, Int32 historyLength | `Boolean` |  |
| `private` | HandlePrivateMessageEvent | EventData eventData | `Void` |  |
| `private` | HandleChatMessagesEvent | EventData eventData | `Void` |  |
| `private` | HandleSubscribeEvent | EventData eventData | `Void` |  |
| `private` | HandleUnsubscribeEvent | EventData eventData | `Void` |  |
| `private` | HandleAuthResponse | OperationResponse operationResponse | `Void` |  |
| `private` | HandleStatusUpdate | EventData eventData | `Void` |  |
| `private` | ConnectToFrontEnd |  | `Boolean` |  |
| `private` | AuthenticateOnFrontEnd |  | `Boolean` |  |
| `private` | HandleUserUnsubscribedEvent | EventData eventData | `Void` |  |
| `private` | HandleUserSubscribedEvent | EventData eventData | `Void` |  |
| `public` | Subscribe | String channel, Int32 lastMsgId, Int32 messagesFromHistory, ChannelCreationOptions creationOptions | `Boolean` | Sends operation to subscribe to a list of channels by name.<br>Sends operation to subscribe to a list of channels by name and possibly retrieve messages we did not receive while unsubscribed.<br>Sends operation to subscribe client to channels, optionally fetching a number of messages from the cache.<br>Subscribe to a single channel and optionally sets its well-know channel properties in case the channel is created. |

---

