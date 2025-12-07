# File: FriendItem.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonChat/Demos/DemoChat/FriendItem.cs`

<a id='FriendItem'></a>
## Class FriendItem
**Namespace:** `Photon.Chat.Demo`<br>
**Signature:** `FriendItem : MonoBehaviour`

> Friend UI item used to represent the friend status as well as message.  
> It aims at showing how to share health for a friend that plays on a different room than you for example.  
> But of course the message can be anything and a lot more complex.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | NameLabel | `Text` |  |  |
| `public` | StatusLabel | `Text` |  |  |
| `public` | Health | `Text` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | FriendId <br><small>{ get; set; }</small> | `String` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | OnFriendStatusUpdate | Int32 status, Boolean gotMessage, Object message | `Void` |  |

---

