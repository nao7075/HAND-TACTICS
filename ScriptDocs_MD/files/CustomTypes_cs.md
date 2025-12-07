# File: CustomTypes.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/CustomTypes.cs`

<a id='CustomTypes'></a>
## Class CustomTypes
**Namespace:** `Photon.Pun`<br>
**Signature:** `CustomTypes`

> Internally used class, containing de/serialization method for PUN specific classes.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | memPlayer | `Byte[]` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `internal` | S Register |  | `Void` | Register de/serializer methods for PUN specific types. Makes the type usable in RaiseEvent, RPC and sync updates of PhotonViews. |
| `private` | S SerializePhotonPlayer | StreamBuffer outStream, Object customobject | `Int16` |  |
| `private` | S DeserializePhotonPlayer | StreamBuffer inStream, Int16 length | `Object` |  |

---

