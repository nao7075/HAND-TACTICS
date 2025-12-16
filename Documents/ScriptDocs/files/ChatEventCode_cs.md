# File: ChatEventCode.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonChat_Code.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatEventCode.cs`

<a id='ChatEventCode'></a>
## Class ChatEventCode
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatEventCode`

> Wraps up internally used constants in Photon Chat events. You don't have to use them directly usually.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ChatMessages | `Byte` | (0) Event code for messages published in public channels. |  |
| `public` | Users | `Byte` | (1) Not Used.<br>List of users or List of changes for List of users |  |
| `public` | PrivateMessage | `Byte` | (2) Event code for messages published in private channels |  |
| `public` | FriendsList | `Byte` | (3) Not Used. |  |
| `public` | StatusUpdate | `Byte` | (4) Event code for status updates. |  |
| `public` | Subscribe | `Byte` | (5) Event code for subscription acks. |  |
| `public` | Unsubscribe | `Byte` | (6) Event code for unsubscribe acks. |  |
| `public` | PropertiesChanged | `Byte` | (7) Event code for properties update. |  |
| `public` | UserSubscribed | `Byte` | (8) Event code for new user subscription to a channel where  is enabled. |  |
| `public` | UserUnsubscribed | `Byte` | (9) Event code for when user unsubscribes from a channel where  is enabled. |  |
| `public` | ErrorInfo | `Byte` | (10) Event code for when the server sends an error to the client. |  |

---

