# File: TextToggleIsOnTransition.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI/TextToggleIsOnTransition.cs`

<a id='TextToggleIsOnTransition'></a>
## Class TextToggleIsOnTransition
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `TextToggleIsOnTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler`

> Use this on toggles texts to have some color transition on the text depending on the isOn State.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | toggle | `Toggle` | The toggle Component. |  |
| `private` | _text | `Text` |  |  |
| `public` | NormalOnColor | `Color` | The color of the normal on transition state. |  |
| `public` | NormalOffColor | `Color` | The color of the normal off transition state. |  |
| `public` | HoverOnColor | `Color` | The color of the hover on transition state. |  |
| `public` | HoverOffColor | `Color` | The color of the hover off transition state. |  |
| `private` | isHover | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | OnValueChanged | Boolean isOn | `Void` |  |
| `public` | OnPointerEnter | PointerEventData eventData | `Void` |  |
| `public` | OnPointerExit | PointerEventData eventData | `Void` |  |

---

