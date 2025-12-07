# File: OnClickRpc.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Prototyping/OnClickRpc.cs`

<a id='OnClickRpc'></a>
## Class OnClickRpc
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `OnClickRpc : MonoBehaviourPun, IPointerClickHandler`

> This component will instantiate a network GameObject when in a room and the user click on that component's GameObject.  
> Uses PhysicsRaycaster for positioning.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Button | `InputButton` |  |  |
| `public` | ModifierKey | `KeyCode` |  |  |
| `public` | Target | `RpcTarget` |  |  |
| `private` | originalMaterial | `Material` |  |  |
| `private` | originalColor | `Color` |  |  |
| `private` | isFlashing | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick | PointerEventData eventData | `Void` |  |
| `public` | ClickRpc |  | `Void` |  |
| `public` | ClickFlash |  | `IEnumerator` |  |

---

