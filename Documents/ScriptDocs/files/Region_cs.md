# File: Region.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/Region.cs`

<a id='Region'></a>
## Class Region
**Namespace:** `Photon.Realtime`<br>
**Signature:** `Region`

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Code <br><small>{ get; set; }</small> | `String` |  |
| `public` | Cluster <br><small>{ get; set; }</small> | `String` | Unlike the CloudRegionCode, this may contain cluster information. |
| `public` | HostAndPort <br><small>{ get; set; }</small> | `String` |  |
| `public` | Ping <br><small>{ get; set; }</small> | `Int32` | Weighted ping time. |
| `public` | WasPinged <br><small>{ get;  }</small> | `Boolean` |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | Region | String code, String address | Constructor |
| `public` | Region | String code, Int32 ping | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | SetCodeAndCluster | String codeAsString | `Void` |  |
| `public` | ToString |  | `String` |  |
| `public` | ToString | Boolean compact | `String` |  |

---

