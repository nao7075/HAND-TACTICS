# File: Spaceship.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoAsteroids_Scripts_Game.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Game/Spaceship.cs`

<a id='Spaceship'></a>
## Class Spaceship
**Namespace:** `Photon.Pun.Demo.Asteroids`<br>
**Signature:** `Spaceship : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | RotationSpeed | `Single` |  |  |
| `public` | MovementSpeed | `Single` |  |  |
| `public` | MaxSpeed | `Single` |  |  |
| `public` | Destruction | `ParticleSystem` |  |  |
| `public` | EngineTrail | `GameObject` |  |  |
| `public` | BulletPrefab | `GameObject` |  |  |
| `private` | photonView | `PhotonView` |  |  |
| `private` | rigidbody | `Rigidbody` |  |  |
| `private` | collider | `Collider` |  |  |
| `private` | renderer | `Renderer` |  |  |
| `private` | rotation | `Single` |  |  |
| `private` | acceleration | `Single` |  |  |
| `private` | shootingTimer | `Single` |  |  |
| `private` | controllable | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | Unity Event Function |
| `public` | ⚡ FixedUpdate |  | `Void` | Unity Event Function |
| `private` | WaitForRespawn |  | `IEnumerator` |  |
| `public` | DestroySpaceship |  | `Void` |  |
| `public` | Fire | Vector3 position, Quaternion rotation, PhotonMessageInfo info | `Void` |  |
| `public` | RespawnSpaceship |  | `Void` |  |
| `private` | CheckExitScreen |  | `Void` |  |

---

