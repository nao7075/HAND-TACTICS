# File: OnlineMenuManager.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/OnlineMenuManager.cs`

<a id='OnlineMenuManager'></a>
## Class OnlineMenuManager
**Namespace:** `(Global)`<br>
**Signature:** `OnlineMenuManager : MonoBehaviourPunCallbacks`

> オンラインマッチング画面の制御クラス。  
> Photonサーバーへの接続、ルームへの参加・作成を行う。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | matchingButton | `GameObject` | マッチングボタン |  |
| `private` | inRoom | `Boolean` | roomにいるかどうか |  |
| `private` | isMatching | `Boolean` | マッチングしたかどうか |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | OnMatchingButton |  | `Void` | マッチング開始ボタン処理 |
| `public` | OnConnectedToMaster |  | `Void` | マスターサーバーへの接続が成功した時に呼ばれるコールバック |
| `public` | OnJoinedRoom |  | `Void` | ゲームサーバーへの接続が成功した時に呼ばれるコールバック |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` | ランダム参加失敗（部屋がない）コールバック |
| `private` | ⚡ Update |  | `Void` | 毎フレーム監視し、部屋が2人ならシーンを変える |
| `public` | BackDeckSelectButtom |  | `Void` | マッチングキャンセル・戻るボタン処理 |

---

