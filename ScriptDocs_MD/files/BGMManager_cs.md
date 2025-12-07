# File: BGMManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/BGMManager.cs`

<a id='BGMManager'></a>
## Class BGMManager
**Namespace:** `(Global)`<br>
**Signature:** `BGMManager : MonoBehaviour`

> メニュー画面などのBGM再生を管理するクラス。  
> DontDestroyOnLoadによりシーンを跨いでBGMを流し続ける。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | instance | `BGMManager` | シングルストン化 |  |
| `private` | BGMAudioSource | `AudioSource` | BGMを再生するためのAudioSource（インスペクターで設定） |  |
| `public` | audioSourceSE | `AudioSource` | SEを再生するためのAudioSource（インスペクターで設定、publicなので外部から参照可能） |  |
| `public` | audioClipsSE | `AudioClip[]` | index: 再生したいSEのインデックス（audioClipsSE配列の要素番号） |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | SetBGMVolume | Single volume | `Void` | BGMの音量を設定する<br>volume: 設定したい音量（0.0〜1.0） |
| `public` | PlaySE | Int32 index | `Void` | 指定されたインデックスのSEを再生するメソッド |

---

