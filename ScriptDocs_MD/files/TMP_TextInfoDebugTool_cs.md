# File: TMP_TextInfoDebugTool.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/TMP_TextInfoDebugTool.cs`

<a id='TMP_TextInfoDebugTool'></a>
## Class TMP_TextInfoDebugTool
**Namespace:** `TMPro.Examples`<br>
**Signature:** `TMP_TextInfoDebugTool : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | ShowCharacters | `Boolean` |  |  |
| `public` | ShowWords | `Boolean` |  |  |
| `public` | ShowLinks | `Boolean` |  |  |
| `public` | ShowLines | `Boolean` |  |  |
| `public` | ShowMeshBounds | `Boolean` |  |  |
| `public` | ShowTextBounds | `Boolean` |  |  |
| `public` | ObjectStats | `String` |  |  |
| `private` | m_TextComponent | `TMP_Text` |  |  |
| `private` | m_Transform | `Transform` |  |  |
| `private` | m_TextInfo | `TMP_TextInfo` |  |  |
| `private` | m_ScaleMultiplier | `Single` |  |  |
| `private` | m_HandleSize | `Single` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | OnDrawGizmos |  | `Void` |  |
| `private` | DrawCharactersBounds |  | `Void` | Method to draw a rectangle around each character. |
| `private` | DrawWordBounds |  | `Void` | Method to draw rectangles around each word of the text. |
| `private` | DrawLinkBounds |  | `Void` | Draw rectangle around each of the links contained in the text. |
| `private` | DrawLineBounds |  | `Void` | Draw Rectangles around each lines of the text. |
| `private` | DrawBounds |  | `Void` | Draw Rectangle around the bounds of the text object. |
| `private` | DrawTextBounds |  | `Void` |  |
| `private` | DrawRectangle | Vector3 BL, Vector3 TR, Color color | `Void` |  |
| `private` | DrawDottedRectangle | Vector3 bottomLeft, Vector3 topRight, Color color, Single size | `Void` |  |
| `private` | DrawSolidRectangle | Vector3 bottomLeft, Vector3 topRight, Color color, Single size | `Void` |  |
| `private` | DrawSquare | Vector3 position, Single size, Color color | `Void` |  |
| `private` | DrawCrosshair | Vector3 position, Single size, Color color | `Void` |  |
| `private` | DrawRectangle | Vector3 bl, Vector3 tl, Vector3 tr, Vector3 br, Color color | `Void` |  |
| `private` | DrawDottedRectangle | Vector3 bl, Vector3 tl, Vector3 tr, Vector3 br, Color color | `Void` |  |

---

