# File: Asteroid.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoAsteroids_Scripts_Game.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Game/Asteroid.cs`

<a id='Asteroid'></a>
## Class Asteroid
**Namespace:** `Photon.Pun.Demo.Asteroids`<br>
**Signature:** `Asteroid : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | isLargeAsteroid | `Boolean` |  |  |
| `private` | isDestroyed | `Boolean` |  |  |
| `private` | photonView | `PhotonView` |  |  |
| `private` | rigidbody | `Rigidbody` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | ⚡ OnCollisionEnter | Collision collision | `Void` | Unity Event Function |
| `private` | DestroyAsteroidGlobally |  | `Void` |  |
| `private` | DestroyAsteroidLocally |  | `Void` |  |

---

