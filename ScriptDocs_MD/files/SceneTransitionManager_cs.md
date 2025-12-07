# File: SceneTransitionManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/SceneTransitionManager.cs`

<a id='SceneTransitionManager'></a>
## Class SceneTransitionManager
**Namespace:** `(Global)`<br>
**Signature:** `SceneTransitionManager : MonoBehaviour`

> シーン遷移を一元管理するクラス。  
> シングルトンとして常駐し、どのシーンからでもロードを呼び出せる。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | instance | `SceneTransitionManager` | シングルストン化 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | Load | String sceneName | `Void` | 指定された名前のシーンをロードする |

---

