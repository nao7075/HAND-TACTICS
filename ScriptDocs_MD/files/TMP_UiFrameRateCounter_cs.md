# File: TMP_UiFrameRateCounter.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/TMP_UiFrameRateCounter.cs`

<a id='TMP_UiFrameRateCounter'></a>
## Class TMP_UiFrameRateCounter
**Namespace:** `TMPro.Examples`<br>
**Signature:** `TMP_UiFrameRateCounter : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | UpdateInterval | `Single` |  |  |
| `private` | m_LastInterval | `Single` |  |  |
| `private` | m_Frames | `Int32` |  |  |
| `public` | AnchorPosition | `FpsCounterAnchorPositions` |  |  |
| `private` | htmlColorTag | `String` |  |  |
| `private` | fpsLabel | `String` |  |  |
| `private` | m_TextMeshPro | `TextMeshProUGUI` |  |  |
| `private` | m_frameCounter_transform | `RectTransform` |  |  |
| `private` | last_AnchorPosition | `FpsCounterAnchorPositions` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | Set_FrameCounter_Position | FpsCounterAnchorPositions anchor_position | `Void` |  |

---

