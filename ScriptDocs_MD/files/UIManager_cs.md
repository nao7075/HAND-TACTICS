# File: UIManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/UIManager.cs`

<a id='UIManager'></a>
## Class UIManager
**Namespace:** `(Global)`<br>
**Signature:** `UIManager : MonoBehaviour`

> ゲーム内のUI（ユーザーインターフェース）を一元管理するクラス。  
> 各種パネルの表示切り替え、テキスト更新、ボタンの挙動制御などを行う。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | changeTurnPanel | `GameObject` | ターン切り替え時のカットインパネル |  |
| `private` | GameEndPanel | `GameObject` | リザルト（勝敗）パネル |  |
| `private` | LeftPlayerPanel | `GameObject` | 相手切断時の通知パネル |  |
| `private` | GearPanel | `GameObject` | 設定（歯車）パネル |  |
| `private` | SoundPanel | `GameObject` | サウンド設定パネル |  |
| `private` | changeTurnText | `TextMeshProUGUI` | ターン切り替えテキスト |  |
| `private` | GameEndText | `TextMeshProUGUI` | 勝敗テキスト |  |
| `private` | restartGameButton | `GameObject` | 再戦ボタン |  |
| `private` | BackHomeButton | `GameObject` | ホームへ戻るボタン |  |
| `private` | BackHomeButton2 | `GameObject` | 切断時のホームへ戻るボタン |  |
| `private` | GearButton | `GameObject` | 設定ボタンアイコン |  |
| `private` | SoundButton | `GameObject` | サウンドボタンアイコン |  |
| `private` | BackHomeButton3 | `GameObject` | 設定画面内のホームボタン |  |
| `private` | CloseButton | `GameObject` | 設定画面を閉じるボタン |  |
| `private` | SoundCloseButton | `GameObject` | サウンド画面を閉じるボタン |  |
| `private` | MulliganPanel | `GameObject` | マリガン（手札引き直し）画面 |  |
| `private` | JankenPanel | `GameObject` | じゃんけん選択画面全体 |  |
| `private` | PlayerJankenPanel | `GameObject` | プレイヤーの選択肢パネル |  |
| `private` | EnemyJankenPanel | `GameObject` | 相手の選択肢パネル |  |
| `private` | PGPanel | `GameObject` | Player Goo Panel |  |
| `private` | PCPanel | `GameObject` | Player Choki Panel |  |
| `private` | PPPanel | `GameObject` | Player Pa Panel |  |
| `private` | EGPanel | `GameObject` | Enemy Goo Panel |  |
| `private` | ECPanel | `GameObject` | Enemy Choki Panel |  |
| `private` | EPPanel | `GameObject` | Enemy Pa Panel |  |
| `private` | PGButton | `GameObject` | グーボタン |  |
| `private` | PCButton | `GameObject` | チョキボタン |  |
| `private` | PPButton | `GameObject` | パーボタン |  |
| `private` | EGButton | `GameObject` | 敵グー表示（アイコン） |  |
| `private` | ECButton | `GameObject` | 敵チョキ表示 |  |
| `private` | EPButton | `GameObject` | 敵パー表示 |  |
| `private` | EGHidePanel | `GameObject` | 敵の選択隠し用パネル（グー） |  |
| `private` | ECHidePanel | `GameObject` | 敵の選択隠し用パネル（チョキ） |  |
| `private` | EPHidePanel | `GameObject` | 敵の選択隠し用パネル（パー） |  |
| `private` | PGResultPanel | `GameObject` | 自分のじゃんけん結果表示 |  |
| `private` | PCResultPanel | `GameObject` | 自分のじゃんけん結果表示 |  |
| `private` | PPResultPanel | `GameObject` | 自分のじゃんけん結果表示 |  |
| `private` | EGResultPanel | `GameObject` | 敵のじゃんけん結果表示 |  |
| `private` | ECResultPanel | `GameObject` | 敵のじゃんけん結果表示 |  |
| `private` | EPResultPanel | `GameObject` | 敵のじゃんけん結果表示 |  |
| `private` | JankenCountPanel | `GameObject` | 手札のじゃんけん内訳表示 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | ShowChangeTurnPanel |  | `IEnumerator` | ターン切り替え時のカットイン演出を表示するコルーチン |
| `public` | ShowGameEndPanel | Boolean isPlayerWinnig | `Void` | ゲーム終了時（勝敗決定時）のパネルを表示する |
| `public` | ShowRetryMessage |  | `Void` | 再戦待機中のメッセージを表示する |
| `public` | WaitMessage |  | `Void` | 相手の選択待ちメッセージを表示する |
| `public` | ShowLeftPlayerPanel |  | `Void` | 相手が切断（退出）した際のパネルを表示する |
| `public` | HideGameEndPanel |  | `Void` | リザルトパネルを非表示にする（再戦時など） |
| `public` | HideLeftPlayerPanel |  | `Void` | 退出通知パネルを非表示にする（再戦時など） |
| `public` | ShowJankenPanel |  | `Void` | じゃんけんフェイズのUI一式を表示する |
| `public` | HideAllJankenPanel |  | `Void` | じゃんけんUIを全て非表示にする |
| `public` | HideP2JankenPanel | Int32 PHand | `Void` | プレイヤーが手を選んだ後、選ばなかった手を非表示にする<br>プレイヤーの押したボタン以外をオフにする |
| `public` | HideE2JankenPanel | Int32 EHand | `Void` | 相手が手を選んだ後（同期後）、選ばなかった手を非表示にする<br>敵の押したボタン以外をオフにする |
| `public` | PlayerResultPanel | Int32 result | `Void` | プレイヤーのじゃんけん結果（リーダー横のアイコン）を表示する |
| `public` | EnemyResultPanel | Int32 result | `Void` | 相手のじゃんけん結果を表示する |
| `public` | HideResultPanel |  | `Void` | じゃんけん結果表示をリセットする |
| `public` | EHidePanel | Int32 EHand | `Void` | 相手の手の隠しパネル（？マーク）を外して正解を表示する |
| `public` | OpenGearPanel |  | `Void` | 設定（ギア）パネルを開く<br>ギアボタンに着ける処理 |
| `public` | CloseGearPanel |  | `Void` | 設定（ギア）パネルを閉じる |
| `public` | OpenSoundPanel |  | `Void` | サウンド設定パネルを開く<br>サウンドボタンに着ける処理 |
| `public` | CloseSoundPanel |  | `Void` | サウンド設定パネルを閉じる |
| `public` | OpenMulliganPanel |  | `Void` | マリガンパネルを開く |
| `public` | CloseMulliganPanel |  | `Void` | マリガンパネルを閉じる |
| `public` | OpenJankenCountPanel |  | `Void` | じゃんけんカウントパネルを開く |
| `public` | CloseJankenCountPanel |  | `Void` | じゃんけんカウントパネルを閉じる |

---

