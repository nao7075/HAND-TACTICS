# File: TextMeshProFloatingText.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_TextMesh_Pro_Examples_&_Extras_Scripts.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/TextMeshProFloatingText.cs`

<a id='TextMeshProFloatingText'></a>
## Class TextMeshProFloatingText
**Namespace:** `TMPro.Examples`<br>
**Signature:** `TextMeshProFloatingText : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | TheFont | `Font` |  |  |
| `private` | m_floatingText | `GameObject` |  |  |
| `private` | m_textMeshPro | `TextMeshPro` |  |  |
| `private` | m_textMesh | `TextMesh` |  |  |
| `private` | m_transform | `Transform` |  |  |
| `private` | m_floatingText_Transform | `Transform` |  |  |
| `private` | m_cameraTransform | `Transform` |  |  |
| `private` | lastPOS | `Vector3` |  |  |
| `private` | lastRotation | `Quaternion` |  |  |
| `public` | SpawnType | `Int32` |  |  |
| `public` | IsTextObjectScaleStatic | `Boolean` |  |  |
| `private` | k_WaitForEndOfFrame | `WaitForEndOfFrame` |  |  |
| `private` | k_WaitForSecondsRandom | `WaitForSeconds[]` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | DisplayTextMeshProFloatingText |  | `IEnumerator` |  |
| `public` | DisplayTextMeshFloatingText |  | `IEnumerator` |  |

---

