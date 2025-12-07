# File: ChatChannel.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatChannel.cs`

<a id='ChatChannel'></a>
## Class ChatChannel
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatChannel`

> A channel of communication in Photon Chat, updated by ChatClient and provided as READ ONLY.  
> Used internally to create new channels. This does NOT create a channel on the server! Use ChatClient.Subscribe.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Name | `String` | Name of the channel (used to subscribe and unsubscribe). |  |
| `public` | Senders | `List`1` | Senders of messages in chronological order. Senders and Messages refer to each other by index. Senders[x] is the sender of Messages[x]. |  |
| `public` | Messages | `List`1` | Messages in chronological order. Senders and Messages refer to each other by index. Senders[x] is the sender of Messages[x]. |  |
| `public` | MessageLimit | `Int32` | If greater than 0, this channel will limit the number of messages, that it caches locally. |  |
| `public` | ChannelID | `Int32` | Unique channel ID. |  |
| `private` | properties | `Dictionary`2` |  |  |
| `public` | Subscribers | `HashSet`1` | Subscribed users. |  |
| `private` | usersProperties | `Dictionary`2` | Properties of subscribers |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | IsPrivate <br><small>{ get; set; }</small> | `Boolean` | Is this a private 1:1 channel? |
| `public` | MessageCount <br><small>{ get;  }</small> | `Int32` | Count of messages this client still buffers/knows for this channel. |
| `public` | LastMsgId <br><small>{ get; set; }</small> | `Int32` | ID of the last message received. |
| `public` | PublishSubscribers <br><small>{ get; set; }</small> | `Boolean` | Whether or not this channel keeps track of the list of its subscribers. |
| `public` | MaxSubscribers <br><small>{ get; set; }</small> | `Int32` | Maximum number of channel subscribers. 0 means infinite. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | ChatChannel | String name | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | Add | String sender, Object message, Int32 msgId | `Void` | Used internally to add messages to this channel. |
| `public` | Add | String[] senders, Object[] messages, Int32 lastMsgId | `Void` | Used internally to add messages to this channel. |
| `public` | TruncateMessages |  | `Void` | Reduces the number of locally cached messages in this channel to the MessageLimit (if set). |
| `public` | ClearMessages |  | `Void` | Clear the local cache of messages currently stored. This frees memory but doesn't affect the server. |
| `public` | ToStringMessages |  | `String` | Provides a string-representation of all messages in this channel. |
| `internal` | ReadChannelProperties | Dictionary`2 newProperties | `Void` |  |
| `internal` | AddSubscribers | String[] users | `Boolean` |  |
| `internal` | AddSubscriber | String userId | `Boolean` |  |
| `internal` | RemoveSubscriber | String userId | `Boolean` |  |

---

