# File: GraphicToggleIsOnTransition.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_UI.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI/GraphicToggleIsOnTransition.cs`

<a id='GraphicToggleIsOnTransition'></a>
## Class GraphicToggleIsOnTransition
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `GraphicToggleIsOnTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler`

> Use this on toggles texts to have some color transition on the text depending on the isOn State.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | toggle | `Toggle` |  |  |
| `private` | _graphic | `Graphic` |  |  |
| `public` | NormalOnColor | `Color` |  |  |
| `public` | NormalOffColor | `Color` |  |  |
| `public` | HoverOnColor | `Color` |  |  |
| `public` | HoverOffColor | `Color` |  |  |
| `private` | isHover | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | OnPointerEnter | PointerEventData eventData | `Void` |  |
| `public` | OnPointerExit | PointerEventData eventData | `Void` |  |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | OnValueChanged | Boolean isOn | `Void` |  |

---

