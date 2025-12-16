# File: ButtonInsideScrollList.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_UtilityScripts_UI.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI/ButtonInsideScrollList.cs`

<a id='ButtonInsideScrollList'></a>
## Class ButtonInsideScrollList
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `ButtonInsideScrollList : MonoBehaviour, IPointerDownHandler, IPointerUpHandler`

> Button inside scroll list will stop scrolling ability of scrollRect container, so that when pressing down on a button and draggin up and down will not affect scrolling.  
> this doesn't do anything if no scrollRect component found in Parent Hierarchy.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | scrollRect | `ScrollRect` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | UnityEngine.EventSystems.IPointerDownHandler.OnPointerDown | PointerEventData eventData | `Void` |  |
| `private` | UnityEngine.EventSystems.IPointerUpHandler.OnPointerUp | PointerEventData eventData | `Void` |  |

---

