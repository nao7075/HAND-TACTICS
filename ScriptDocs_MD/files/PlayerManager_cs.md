# File: PlayerManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_PunBasics-Tutorial_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts/PlayerManager.cs`

<a id='PlayerManager'></a>
## Class PlayerManager
**Namespace:** `Photon.Pun.Demo.PunBasics`<br>
**Signature:** `PlayerManager : MonoBehaviourPunCallbacks, IPunObservable`

> Player manager.  
> Handles fire Input and Beams.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Health | `Single` |  |  |
| `public` | LocalPlayerInstance | `GameObject` |  |  |
| `private` | playerUiPrefab | `GameObject` |  |  |
| `private` | beams | `GameObject` |  |  |
| `private` | IsFiring | `Boolean` |  |  |
| `private` | leavingRoom | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | MonoBehaviour method called on GameObject by Unity during early initialization phase. |
| `public` | ⚡ Start |  | `Void` | MonoBehaviour method called on GameObject by Unity during initialization phase. |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | ⚡ Update |  | `Void` | MonoBehaviour method called on GameObject by Unity on every frame.<br>Process Inputs if local player.<br>Show and hide the beams<br>Watch for end of game, when local player health is 0. |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | ⚡ OnTriggerEnter | Collider other | `Void` | MonoBehaviour method called when the Collider 'other' enters the trigger.<br>Affect Health of the Player if the collider is a beam<br>Note: when jumping and firing at the same, you'll find that the player's own beam intersects with itself<br>One could move the collider further away to prevent this or check if the beam belongs to the player. |
| `public` | ⚡ OnTriggerStay | Collider other | `Void` | MonoBehaviour method called once per frame for every Collider 'other' that is touching the trigger.<br>We're going to affect health while the beams are interesting the player |
| `private` | CalledOnLevelWasLoaded | Int32 level | `Void` | MonoBehaviour method called after a new level of index 'level' was loaded.<br>We recreate the Player UI because it was destroy when we switched level.<br>Also reposition the player if outside the current arena. |
| `private` | OnSceneLoaded | Scene scene, LoadSceneMode loadingMode | `Void` |  |
| `private` | ProcessInputs |  | `Void` | Processes the inputs. This MUST ONLY BE USED when the player has authority over this Networked GameObject (photonView.isMine == true) |
| `public` | OnPhotonSerializeView | PhotonStream stream, PhotonMessageInfo info | `Void` |  |

---

