# File: TMP_TextEventCheck.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_TextMesh_Pro_Examples_&_Extras_Scripts.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/TMP_TextEventCheck.cs`

<a id='TMP_TextEventCheck'></a>
## Class TMP_TextEventCheck
**Namespace:** `TMPro.Examples`<br>
**Signature:** `TMP_TextEventCheck : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | TextEventHandler | `TMP_TextEventHandler` |  |  |
| `private` | m_TextComponent | `TMP_Text` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `private` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `private` | OnCharacterSelection | Char c, Int32 index | `Void` |  |
| `private` | OnSpriteSelection | Char c, Int32 index | `Void` |  |
| `private` | OnWordSelection | String word, Int32 firstCharacterIndex, Int32 length | `Void` |  |
| `private` | OnLineSelection | String lineText, Int32 firstCharacterIndex, Int32 length | `Void` |  |
| `private` | OnLinkSelection | String linkID, String linkText, Int32 linkIndex | `Void` |  |

---

