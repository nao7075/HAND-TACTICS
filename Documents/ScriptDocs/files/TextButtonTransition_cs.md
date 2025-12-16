# File: TextButtonTransition.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_UI.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI/TextButtonTransition.cs`

<a id='TextButtonTransition'></a>
## Class TextButtonTransition
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `TextButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler`

> Use this on Button texts to have some color transition on the text as well without corrupting button's behaviour.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | _text | `Text` |  |  |
| `public` | Selectable | `Selectable` | The selectable Component. |  |
| `public` | NormalColor | `Color` | The color of the normal of the transition state. |  |
| `public` | HoverColor | `Color` | The color of the hover of the transition state. |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | OnPointerEnter | PointerEventData eventData | `Void` |  |
| `public` | OnPointerExit | PointerEventData eventData | `Void` |  |

---

