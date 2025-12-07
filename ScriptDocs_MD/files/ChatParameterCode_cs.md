# File: ChatParameterCode.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatParameterCode.cs`

<a id='ChatParameterCode'></a>
## Class ChatParameterCode
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatParameterCode`

> Wraps up codes for parameters (in operations and events) used internally in Photon Chat. You don't have to use them directly usually.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Channels | `Byte` | (0) Array of chat channels. |  |
| `public` | Channel | `Byte` | (1) Name of a single chat channel. |  |
| `public` | Messages | `Byte` | (2) Array of chat messages. |  |
| `public` | Message | `Byte` | (3) A single chat message. |  |
| `public` | Senders | `Byte` | (4) Array of names of the users who sent the array of chat messages. |  |
| `public` | Sender | `Byte` | (5) Name of a the user who sent a chat message. |  |
| `public` | ChannelUserCount | `Byte` | (6) Not used. |  |
| `public` | UserId | `Byte` | (225) Name of user to send a (private) message to. |  |
| `public` | MsgId | `Byte` | (8) Id of a message. |  |
| `public` | MsgIds | `Byte` | (9) Not used. |  |
| `public` | Secret | `Byte` | (221) Secret token to identify an authorized user. |  |
| `public` | SubscribeResults | `Byte` | (15) Subscribe operation result parameter. A bool[] with result per channel. |  |
| `public` | Status | `Byte` | (10) Status |  |
| `public` | Friends | `Byte` | (11) Friends |  |
| `public` | SkipMessage | `Byte` | (12) SkipMessage is used in SetOnlineStatus and if true, the message is not being broadcast. |  |
| `public` | HistoryLength | `Byte` | (14) Number of message to fetch from history. 0: no history. 1 and higher: number of messages in history. -1: all history. |  |
| `public` | DebugMessage | `Byte` |  |  |
| `public` | WebFlags | `Byte` | (21) WebFlags object for changing behaviour of webhooks from client. |  |
| `public` | Properties | `Byte` | (22) WellKnown or custom properties of channel or user. |  |
| `public` | ChannelSubscribers | `Byte` | (23) Array of UserIds of users already subscribed to a channel. |  |
| `public` | DebugData | `Byte` | (24) Optional data sent in ErrorInfo event from Chat WebHooks. |  |
| `public` | ExpectedValues | `Byte` | (25) Code for values to be used for "Check And Swap" (CAS) when changing properties. |  |
| `public` | Broadcast | `Byte` | (26) Code for broadcast parameter of  method. |  |
| `public` | UserProperties | `Byte` | WellKnown and custom user properties. |  |
| `public` | UniqueRoomId | `Byte` | Generated unique reusable room id |  |

---

