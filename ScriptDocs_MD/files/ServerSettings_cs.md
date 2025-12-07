# File: ServerSettings.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/ServerSettings.cs`

<a id='ServerSettings'></a>
## Class ServerSettings
**Namespace:** `Photon.Pun`<br>
**Signature:** `ServerSettings : ScriptableObject`

> Collection of connection-relevant settings, used internally by PhotonNetwork.ConnectUsingSettings.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | AppSettings | `AppSettings` |  |  |
| `public` | DevRegion | `String` | Region that will be used by the Editor and Development Builds. This ensures all users will be in the same region for testing. |  |
| `public` | PunLogging | `PunLogLevel` |  |  |
| `public` | EnableSupportLogger | `Boolean` |  |  |
| `public` | RunInBackground | `Boolean` |  |  |
| `public` | StartInOfflineMode | `Boolean` |  |  |
| `public` | RpcList | `List`1` | set by scripts and or via Inspector |  |
| `public` | DisableAutoOpenWizard | `Boolean` |  |  |
| `public` | ShowSettings | `Boolean` |  |  |
| `public` | DevRegionSetOnce | `Boolean` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | BestRegionSummaryInPreferences <br><small>{ get;  }</small> | `String` | Gets the "best region summary" from the preferences. |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | UseCloud | String cloudAppid, String code | `Void` | Sets appid and region code in the AppSettings. Used in Editor. |
| `public` | S IsAppId | String val | `Boolean` | Checks if a string is a Guid by attempting to create one. |
| `public` | S ResetBestRegionCodeInPreferences |  | `Void` | Gets the "best region summary" from the preferences. |
| `public` | ToString |  | `String` | String summary of the AppSettings. |

---

