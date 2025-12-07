# File: SceneFadeManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/SceneFadeManager.cs`

<a id='SceneFadeManager'></a>
## Class SceneFadeManager
**Namespace:** `(Global)`<br>
**Signature:** `SceneFadeManager : MonoBehaviour`

> シーン遷移時のフェードイン・フェードアウト演出を管理するクラス。  
> DontDestroyOnLoadによりシーンを跨いで存在し続ける。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | isFadeOut | `Boolean` | フェードアウト処理の開始、完了を管理するフラグ |  |
| `private` | isFadeIn | `Boolean` | フェードイン処理の開始、完了を管理するフラグ |  |
| `private` | fadeSpeed | `Single` | 透明度が変わるスピード |  |
| `public` | fadeImage | `Image` | 画面をフェードさせるための画像をパブリックで取得 |  |
| `private` | red | `Single` | フェードアウト開始時の画像のRGBA値 |  |
| `private` | green | `Single` | フェードアウト開始時の画像のRGBA値 |  |
| `private` | blue | `Single` | フェードアウト開始時の画像のRGBA値 |  |
| `private` | alfa | `Single` | フェードアウト開始時の画像のRGBA値 |  |
| `private` | afterScene | `String` | シーン遷移のための型 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | fadeInStart | Scene scene, LoadSceneMode mode | `Void` | シーン遷移が完了した際にフェードインを開始するように設定 |
| `public` | fadeOutStart | Int32 red, Int32 green, Int32 blue, Int32 alfa, String nextScene | `Void` | フェードアウト開始時の画像のRGBA値と次のシーン名を指定 |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | SetColor |  | `Void` | 画像に色を代入する関数 |
| `public` | SetRGBA | Int32 r, Int32 g, Int32 b, Int32 a | `Void` | 色の値を設定するための関数 |

---

