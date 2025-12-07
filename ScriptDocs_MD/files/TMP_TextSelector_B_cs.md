# File: TMP_TextSelector_B.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_TextMesh_Pro_Examples_&_Extras_Scripts.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/TMP_TextSelector_B.cs`

<a id='TMP_TextSelector_B'></a>
## Class TMP_TextSelector_B
**Namespace:** `TMPro.Examples`<br>
**Signature:** `TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | TextPopup_Prefab_01 | `RectTransform` |  |  |
| `private` | m_TextPopup_RectTransform | `RectTransform` |  |  |
| `private` | m_TextPopup_TMPComponent | `TextMeshProUGUI` |  |  |
| `private` | k_LinkText | `String` |  |  |
| `private` | k_WordText | `String` |  |  |
| `private` | m_TextMeshPro | `TextMeshProUGUI` |  |  |
| `private` | m_Canvas | `Canvas` |  |  |
| `private` | m_Camera | `Camera` |  |  |
| `private` | isHoveringObject | `Boolean` |  |  |
| `private` | m_selectedWord | `Int32` |  |  |
| `private` | m_selectedLink | `Int32` |  |  |
| `private` | m_lastIndex | `Int32` |  |  |
| `private` | m_matrix | `Matrix4x4` |  |  |
| `private` | m_cachedMeshInfoVertexData | `TMP_MeshInfo[]` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `private` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `private` | ON_TEXT_CHANGED | Object obj | `Void` |  |
| `private` | ⚡ LateUpdate |  | `Void` | Unity Event Function |
| `public` | OnPointerEnter | PointerEventData eventData | `Void` |  |
| `public` | OnPointerExit | PointerEventData eventData | `Void` |  |
| `public` | OnPointerClick | PointerEventData eventData | `Void` |  |
| `public` | OnPointerUp | PointerEventData eventData | `Void` |  |
| `private` | RestoreCachedVertexAttributes | Int32 index | `Void` |  |

---

