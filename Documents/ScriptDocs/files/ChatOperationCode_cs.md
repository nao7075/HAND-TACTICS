# File: ChatOperationCode.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonChat_Code.md)

> **Path:** `Assets/Photon/PhotonChat/Code/ChatOperationCode.cs`

<a id='ChatOperationCode'></a>
## Class ChatOperationCode
**Namespace:** `Photon.Chat`<br>
**Signature:** `ChatOperationCode`

> Wraps up codes for operations used internally in Photon Chat. You don't have to use them directly usually.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Authenticate | `Byte` | (230) Operation Authenticate. |  |
| `public` | Subscribe | `Byte` | (0) Operation to subscribe to chat channels. |  |
| `public` | Unsubscribe | `Byte` | (1) Operation to unsubscribe from chat channels. |  |
| `public` | Publish | `Byte` | (2) Operation to publish a message in a chat channel. |  |
| `public` | SendPrivate | `Byte` | (3) Operation to send a private message to some other user. |  |
| `public` | ChannelHistory | `Byte` | (4) Not used yet. |  |
| `public` | UpdateStatus | `Byte` | (5) Set your (client's) status. |  |
| `public` | AddFriends | `Byte` | (6) Add friends the list of friends that should update you of their status. |  |
| `public` | RemoveFriends | `Byte` | (7) Remove friends from list of friends that should update you of their status. |  |
| `public` | SetProperties | `Byte` | (8) Operation to set properties of public chat channel or users in public chat channels. |  |

---

