# File: WebRpcImplementationExample.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/WebRpcImplementationExample.cs`

<a id='WebRpcImplementationExample'></a>
## Class WebRpcImplementationExample
**Namespace:** `Photon.Pun.Demo`<br>
**Signature:** `WebRpcImplementationExample : MonoBehaviour, IWebRpcCallback`

> This class is a sample of how to implement WebRPCs calling & callbacks.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | GetGameListWebRpcMethodName | `String` | example of WebRPC method name, add yours as enum or constants to avoid typos and have them in one place |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | OnWebRpcResponse | OperationResponse response | `Void` |  |
| `public` | WebRpcExampleCall |  | `Void` |  |
| `public` | S WebRpcCall | String methodName, Object parameters, Boolean sendAuthCookieIfAny | `Void` |  |
| `private` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `private` | ⚡ OnDisable |  | `Void` | Unity Event Function |

---

