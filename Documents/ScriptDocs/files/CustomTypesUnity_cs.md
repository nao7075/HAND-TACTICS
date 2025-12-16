# File: CustomTypesUnity.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/CustomTypesUnity.cs`

<a id='CustomTypesUnity'></a>
## Class CustomTypesUnity
**Namespace:** `Photon.Realtime`<br>
**Signature:** `CustomTypesUnity`

> Internally used class, containing de/serialization methods for various Unity-specific classes.  
> Adding those to the Photon serialization protocol allows you to send them in events, etc.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | SizeV2 | `Int32` |  |  |
| `private` | SizeV3 | `Int32` |  |  |
| `private` | SizeQuat | `Int32` |  |  |
| `public` | memVector3 | `Byte[]` |  |  |
| `public` | memVector2 | `Byte[]` |  |  |
| `public` | memQuarternion | `Byte[]` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `internal` | S Register |  | `Void` | Register de/serializer methods for Unity specific types. Makes the types usable in RaiseEvent and PUN. |
| `private` | S SerializeVector3 | StreamBuffer outStream, Object customobject | `Int16` |  |
| `private` | S DeserializeVector3 | StreamBuffer inStream, Int16 length | `Object` |  |
| `private` | S SerializeVector2 | StreamBuffer outStream, Object customobject | `Int16` |  |
| `private` | S DeserializeVector2 | StreamBuffer inStream, Int16 length | `Object` |  |
| `private` | S SerializeQuaternion | StreamBuffer outStream, Object customobject | `Int16` |  |
| `private` | S DeserializeQuaternion | StreamBuffer inStream, Int16 length | `Object` |  |

---

