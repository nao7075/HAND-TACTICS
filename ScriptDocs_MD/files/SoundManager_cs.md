# File: SoundManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/SoundManager.cs`

<a id='SoundManager'></a>
## Class SoundManager
**Namespace:** `(Global)`<br>
**Signature:** `SoundManager : MonoBehaviour`

> ゲーム内のSE（効果音）再生を一元管理するクラス。  
> シングルトンとして動作する（各シーンに配置されているパターンもある）。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | instance | `SoundManager` | シングルストン化 |  |
| `private` | seAudioSource | `AudioSource` | SEを再生するためのAudioSource（インスペクターで設定） |  |
| `public` | audioSourceSE | `AudioSource` | SEを再生するためのAudioSource（インスペクターで設定、publicなので外部から参照可能） |  |
| `public` | audioClipsSE | `AudioClip[]` | index: 再生したいSEのインデックス（audioClipsSE配列の要素番号） |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | SetSEVolume | Single volume | `Void` | SEの音量を設定する |
| `public` | PlaySE | Int32 index | `Void` | 指定されたインデックスのSEを再生する |

---

