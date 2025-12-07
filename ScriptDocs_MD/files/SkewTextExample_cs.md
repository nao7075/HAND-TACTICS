# File: SkewTextExample.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_TextMesh_Pro_Examples_&_Extras_Scripts.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/SkewTextExample.cs`

<a id='SkewTextExample'></a>
## Class SkewTextExample
**Namespace:** `TMPro.Examples`<br>
**Signature:** `SkewTextExample : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_TextComponent | `TMP_Text` |  |  |
| `public` | VertexCurve | `AnimationCurve` |  |  |
| `public` | CurveScale | `Single` |  |  |
| `public` | ShearAmount | `Single` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | CopyAnimationCurve | AnimationCurve curve | `AnimationCurve` |  |
| `private` | WarpText |  | `IEnumerator` | Method to curve text along a Unity animation curve. |

---

