# File: RegionHandler.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/RegionHandler.cs`

<a id='RegionHandler'></a>
## Class RegionHandler
**Namespace:** `Photon.Realtime`<br>
**Signature:** `RegionHandler`

> Provides methods to work with Photon's regions (Photon Cloud) and can be use to find the one with best ping.  
> Creates a new RegionHandler.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | PingImplementation | `Type` | The implementation of PhotonPing to use for region pinging (Best Region detection). |  |
| `private` | availableRegionCodes | `String` |  |  |
| `private` | bestRegionCache | `Region` |  |  |
| `private` | pingerList | `List`1` |  |  |
| `private` | onCompleteCall | `Action`1` |  |  |
| `private` | previousPing | `Int32` |  |  |
| `private` | previousSummaryProvided | `String` |  |  |
| `protected internal` | PortToPingOverride | `UInt16` | If non-zero, this port will be used to ping Master Servers on. |  |
| `private` | rePingFactor | `Single` | If the previous Best Region's ping is now higher by this much, ping all regions and find a new Best Region. |  |
| `private` | pingSimilarityFactor | `Single` | How much higher a region's ping can be from the absolute best, to be considered the Best Region (by ping and name). |  |
| `public` | BestRegionSummaryPingLimit | `Int32` | If the region from a previous BestRegionSummary now has a ping higher than this limit, all regions get pinged again to find a better. Default: 90ms. |  |
| `private` | emptyMonoBehavior | `MonoBehaviourEmpty` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | EnabledRegions <br><small>{ get; set; }</small> | `List`1` | A list of region names for the Photon Cloud. Set by the result of OpGetRegions(). |
| `public` | BestRegion <br><small>{ get;  }</small> | `Region` | When PingMinimumOfRegions was called and completed, the BestRegion is identified by best ping. |
| `public` | SummaryToCache <br><small>{ get;  }</small> | `String` | This value summarizes the results of pinging currently available regions (after PingMinimumOfRegions finished). |
| `public` | IsPinging <br><small>{ get; set; }</small> | `Boolean` | True if the available regions are being pinged currently. |
| `public` | Aborted <br><small>{ get; set; }</small> | `Boolean` | True if the pinging of regions is being aborted.<br>Set to true to abort pining this region. |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | RegionHandler | UInt16 masterServerPortOverride | Constructor |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | GetResults |  | `String` | Provides a list of regions and their pings as string.<br>Gets this region's results as string summary. |
| `public` | SetRegions | OperationResponse opGetRegions | `Void` | Initializes the regions of this RegionHandler with values provided from the Name Server (as OperationResponse for OpGetRegions). |
| `public` | PingMinimumOfRegions | Action`1 onCompleteCallback, String previousSummary | `Boolean` | Starts the process of pinging of all available regions. |
| `public` | Abort |  | `Void` | Calling this will stop pinging the regions and suppress the onComplete callback.<br>Calling this will stop pinging the regions and cancel the onComplete callback. |
| `private` | OnPreferredRegionPinged | Region preferredRegion | `Void` |  |
| `private` | PingEnabledRegions |  | `Boolean` | Privately used to ping regions if the current best one isn't as fast as earlier. |
| `private` | OnRegionDone | Region region | `Void` |  |

---

