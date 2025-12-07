# File: TMP_TextEventHandler.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/TMP_TextEventHandler.cs`

<a id='TMP_TextEventHandler'></a>
## Class TMP_TextEventHandler
**Namespace:** `TMPro`<br>
**Signature:** `TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_OnCharacterSelection | `CharacterSelectionEvent` | Event delegate triggered when pointer is over a character. |  |
| `private` | m_OnSpriteSelection | `SpriteSelectionEvent` | Event delegate triggered when pointer is over a sprite. |  |
| `private` | m_OnWordSelection | `WordSelectionEvent` | Event delegate triggered when pointer is over a word. |  |
| `private` | m_OnLineSelection | `LineSelectionEvent` | Event delegate triggered when pointer is over a line. |  |
| `private` | m_OnLinkSelection | `LinkSelectionEvent` | Event delegate triggered when pointer is over a link. |  |
| `private` | m_TextComponent | `TMP_Text` |  |  |
| `private` | m_Camera | `Camera` |  |  |
| `private` | m_Canvas | `Canvas` |  |  |
| `private` | m_selectedLink | `Int32` |  |  |
| `private` | m_lastCharIndex | `Int32` |  |  |
| `private` | m_lastWordIndex | `Int32` |  |  |
| `private` | m_lastLineIndex | `Int32` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | onCharacterSelection <br><small>{ get; set; }</small> | `CharacterSelectionEvent` | Event delegate triggered when pointer is over a character. |
| `public` | onSpriteSelection <br><small>{ get; set; }</small> | `SpriteSelectionEvent` | Event delegate triggered when pointer is over a sprite. |
| `public` | onWordSelection <br><small>{ get; set; }</small> | `WordSelectionEvent` | Event delegate triggered when pointer is over a word. |
| `public` | onLineSelection <br><small>{ get; set; }</small> | `LineSelectionEvent` | Event delegate triggered when pointer is over a line. |
| `public` | onLinkSelection <br><small>{ get; set; }</small> | `LinkSelectionEvent` | Event delegate triggered when pointer is over a link. |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ LateUpdate |  | `Void` | Unity Event Function |
| `public` | OnPointerEnter | PointerEventData eventData | `Void` |  |
| `public` | OnPointerExit | PointerEventData eventData | `Void` |  |
| `private` | SendOnCharacterSelection | Char character, Int32 characterIndex | `Void` |  |
| `private` | SendOnSpriteSelection | Char character, Int32 characterIndex | `Void` |  |
| `private` | SendOnWordSelection | String word, Int32 charIndex, Int32 length | `Void` |  |
| `private` | SendOnLineSelection | String line, Int32 charIndex, Int32 length | `Void` |  |
| `private` | SendOnLinkSelection | String linkID, String linkText, Int32 linkIndex | `Void` |  |

---

