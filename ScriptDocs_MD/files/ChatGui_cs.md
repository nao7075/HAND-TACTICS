# File: ChatGui.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonChat_Demos_DemoChat.md)

> **Path:** `Assets/Photon/PhotonChat/Demos/DemoChat/ChatGui.cs`

<a id='ChatGui'></a>
## Class ChatGui
**Namespace:** `Photon.Chat.Demo`<br>
**Signature:** `ChatGui : MonoBehaviour, IChatClientListener`

> This simple Chat UI demonstrate basics usages of the Chat Api

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ChannelsToJoinOnConnect | `String[]` | set in inspector. Demo channels to join automatically. |  |
| `public` | FriendsList | `String[]` |  |  |
| `public` | HistoryLengthToFetch | `Int32` | set in inspector. Up to a certain degree, previously sent messages can be fetched for context |  |
| `private` | selectedChannelName | `String` | mainly used for GUI/input |  |
| `public` | chatClient | `ChatClient` |  |  |
| `protected internal` | chatAppSettings | `ChatAppSettings` |  |  |
| `public` | missingAppIdErrorPanel | `GameObject` |  |  |
| `public` | ConnectingLabel | `GameObject` |  |  |
| `public` | ChatPanel | `RectTransform` | set in inspector (to enable/disable panel) |  |
| `public` | UserIdFormPanel | `GameObject` |  |  |
| `public` | InputFieldChat | `InputField` | set in inspector |  |
| `public` | CurrentChannelText | `Text` | set in inspector |  |
| `public` | ChannelToggleToInstantiate | `Toggle` | set in inspector |  |
| `public` | FriendListUiItemtoInstantiate | `GameObject` |  |  |
| `private` | channelToggles | `Dictionary`2` |  |  |
| `private` | friendListItemLUT | `Dictionary`2` |  |  |
| `public` | ShowState | `Boolean` |  |  |
| `public` | Title | `GameObject` |  |  |
| `public` | StateText | `Text` | set in inspector |  |
| `public` | UserIdText | `Text` | set in inspector |  |
| `private` | HelpText | `String` |  |  |
| `public` | TestLength | `Int32` |  |  |
| `private` | testBytes | `Byte[]` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | UserName <br><small>{ get; set; }</small> | `String` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | Connect |  | `Void` |  |
| `public` | ⚡ OnDestroy |  | `Void` | To avoid that the Editor becomes unresponsive, disconnect all Photon connections in OnDestroy. |
| `public` | OnApplicationQuit |  | `Void` | To avoid that the Editor becomes unresponsive, disconnect all Photon connections in OnApplicationQuit. |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | OnEnterSend |  | `Void` |  |
| `public` | OnClickSend |  | `Void` |  |
| `private` | SendChatMessage | String inputLine | `Void` |  |
| `public` | PostHelpToCurrentChannel |  | `Void` |  |
| `public` | DebugReturn | DebugLevel level, String message | `Void` |  |
| `public` | OnConnected |  | `Void` |  |
| `public` | OnDisconnected |  | `Void` |  |
| `public` | OnChatStateChange | ChatState state | `Void` |  |
| `public` | OnSubscribed | String[] channels, Boolean[] results | `Void` |  |
| `public` | OnSubscribed | String channel, String[] users, Dictionary`2 properties | `Void` |  |
| `private` | InstantiateChannelButton | String channelName | `Void` |  |
| `private` | InstantiateFriendButton | String friendId | `Void` |  |
| `public` | OnUnsubscribed | String[] channels | `Void` |  |
| `public` | OnGetMessages | String channelName, String[] senders, Object[] messages | `Void` |  |
| `public` | OnPrivateMessage | String sender, Object message, String channelName | `Void` |  |
| `public` | OnStatusUpdate | String user, Int32 status, Boolean gotMessage, Object message | `Void` | New status of another user (you get updates for users set in your friends list). |
| `public` | OnUserSubscribed | String channel, String user | `Void` |  |
| `public` | OnUserUnsubscribed | String channel, String user | `Void` |  |
| `public` | OnChannelPropertiesChanged | String channel, String userId, Dictionary`2 properties | `Void` |  |
| `public` | OnUserPropertiesChanged | String channel, String targetUserId, String senderUserId, Dictionary`2 properties | `Void` |  |
| `public` | OnErrorInfo | String channel, String error, Object data | `Void` |  |
| `public` | AddMessageToSelectedChannel | String msg | `Void` |  |
| `public` | ShowChannel | String channelName | `Void` |  |
| `public` | OpenDashboard |  | `Void` |  |

---

