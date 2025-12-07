# File: PlayerUI.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts/PlayerUI.cs`

<a id='PlayerUI'></a>
## Class PlayerUI
**Namespace:** `Photon.Pun.Demo.PunBasics`<br>
**Signature:** `PlayerUI : MonoBehaviour`

> Player UI. Constraint the UI to follow a PlayerManager GameObject in the world,  
> Affect a slider and text to display Player's name and health

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | screenOffset | `Vector3` |  |  |
| `private` | playerNameText | `Text` |  |  |
| `private` | playerHealthSlider | `Slider` |  |  |
| `private` | target | `PlayerManager` |  |  |
| `private` | characterControllerHeight | `Single` |  |  |
| `private` | targetTransform | `Transform` |  |  |
| `private` | targetRenderer | `Renderer` |  |  |
| `private` | _canvasGroup | `CanvasGroup` |  |  |
| `private` | targetPosition | `Vector3` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | MonoBehaviour method called on GameObject by Unity during early initialization phase |
| `private` | ⚡ Update |  | `Void` | MonoBehaviour method called on GameObject by Unity on every frame.<br>update the health slider to reflect the Player's health |
| `private` | ⚡ LateUpdate |  | `Void` | MonoBehaviour method called after all Update functions have been called. This is useful to order script execution.<br>In our case since we are following a moving GameObject, we need to proceed after the player was moved during a particular frame. |
| `public` | SetTarget | PlayerManager _target | `Void` | Assigns a Player Target to Follow and represent. |

---

