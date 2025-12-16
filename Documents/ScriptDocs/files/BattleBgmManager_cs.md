# File: BattleBgmManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/BattleBgmManager.cs`

<a id='BattleBgmManager'></a>
## Class BattleBgmManager
**Namespace:** `(Global)`<br>
**Signature:** `BattleBgmManager : MonoBehaviour`

> バトルシーン専用のBGM管理クラス。  
> バトル用のBGM音量などを制御する。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | instance | `BattleBgmManager` | シングルトン化：どこからでもアクセスできるようにするためのインスタンス |  |
| `private` | BattleBgmAudioSource | `AudioSource` | BGMを再生するためのAudioSource（インスペクターで設定） |  |
| `public` | audioSourceSE | `AudioSource` | SEを再生するためのAudioSource（インスペクターで設定、publicなので外部から参照可能） |  |
| `public` | audioClipsSE | `AudioClip[]` | 再生するSEのクリップリスト（インスペクターで設定、publicなので外部から参照可能） |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `public` | SetBattleBGMVolume | Single volume | `Void` | バトルBGMの音量を設定する |
| `public` | PlaySE | Int32 index | `Void` | 指定されたインデックスのSEを再生するメソッド |

---

