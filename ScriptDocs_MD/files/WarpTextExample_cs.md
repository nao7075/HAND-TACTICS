# File: WarpTextExample.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/TextMesh Pro/Examples & Extras/Scripts/WarpTextExample.cs`

<a id='WarpTextExample'></a>
## Class WarpTextExample
**Namespace:** `TMPro.Examples`<br>
**Signature:** `WarpTextExample : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_TextComponent | `TMP_Text` |  |  |
| `public` | VertexCurve | `AnimationCurve` |  |  |
| `public` | AngleMultiplier | `Single` |  |  |
| `public` | SpeedMultiplier | `Single` |  |  |
| `public` | CurveScale | `Single` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | CopyAnimationCurve | AnimationCurve curve | `AnimationCurve` |  |
| `private` | WarpText |  | `IEnumerator` | Method to curve text along a Unity animation curve. |

---

