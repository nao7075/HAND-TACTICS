# File: AsteroidsGameManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoAsteroids_Scripts_Game.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Game/AsteroidsGameManager.cs`

<a id='AsteroidsGameManager'></a>
## Class AsteroidsGameManager
**Namespace:** `Photon.Pun.Demo.Asteroids`<br>
**Signature:** `AsteroidsGameManager : MonoBehaviourPunCallbacks`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Instance | `AsteroidsGameManager` |  |  |
| `public` | InfoText | `Text` |  |  |
| `public` | AsteroidPrefabs | `GameObject[]` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `private` | SpawnAsteroid |  | `IEnumerator` |  |
| `private` | EndOfGame | String winner, Int32 score | `IEnumerator` |  |
| `public` | OnDisconnected | DisconnectCause cause | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | OnMasterClientSwitched | Player newMasterClient | `Void` |  |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` |  |
| `public` | OnPlayerPropertiesUpdate | Player targetPlayer, Hashtable changedProps | `Void` |  |
| `private` | StartGame |  | `Void` |  |
| `private` | CheckAllPlayerLoadedLevel |  | `Boolean` |  |
| `private` | CheckEndOfGame |  | `Void` |  |
| `private` | OnCountdownTimerIsExpired |  | `Void` |  |

---

