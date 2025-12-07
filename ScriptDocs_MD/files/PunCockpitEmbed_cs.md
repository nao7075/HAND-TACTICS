# File: PunCockpitEmbed.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/ThirdParty/PunCockpitEmbed.cs`

<a id='PunCockpitEmbed'></a>
## Class PunCockpitEmbed
**Namespace:** `Photon.Pun.Demo.Cockpit`<br>
**Signature:** `PunCockpitEmbed : MonoBehaviourPunCallbacks`

> Use this in scenes you want to leave Control for connection and pun related commands to Cockpit.  
> It requires ConnectAndJoinRandom, which it will control for connecting should the Cockpit scene not be present or succesfully loaded.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | PunCockpit_scene | `String` |  |  |
| `public` | EmbeddCockpit | `Boolean` |  |  |
| `public` | CockpitGameTitle | `String` |  |  |
| `public` | LoadingIndicator | `GameObject` |  |  |
| `public` | AutoConnect | `ConnectAndJoinRandom` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `IEnumerator` | Unity Event Function |
| `public` | OnJoinedRoom |  | `Void` |  |

---

