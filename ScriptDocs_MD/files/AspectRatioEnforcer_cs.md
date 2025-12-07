# File: AspectRatioEnforcer.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/AspectRatioEnforcer.cs`

<a id='AspectRatioEnforcer'></a>
## Class AspectRatioEnforcer
**Namespace:** `(Global)`<br>
**Signature:** `AspectRatioEnforcer : MonoBehaviour`

> 画面のアスペクト比を強制的に固定するクラス。  
> ウィンドウサイズが変更された場合、指定したアスペクト比（targetAspect）を維持するように  
> 解像度（幅または高さ）を自動的に調整します。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | targetAspect | `Single` | 1. 維持したいアスペクト比 (例: 16:9 = 1.777...) |  |
| `private` | lastWidth | `Int32` | 前のフレームのウィンドウサイズを記憶する変数 |  |
| `private` | lastHeight | `Int32` | 前のフレームのウィンドウサイズを記憶する変数 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |

---

