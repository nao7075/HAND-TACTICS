# File: BattleManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/BattleManager.cs`

<a id='BattleManager'></a>
## Class BattleManager
**Namespace:** `(Global)`<br>
**Signature:** `BattleManager : MonoBehaviourPunCallbacks`

> バトルシーン全体の進行管理、ルール処理、通信同期を行うクラス

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | uIManager | `UIManager` | UIManagerをアタッチ |  |
| `private` | EnemyHandCard | `GameObject` | 敵の手札（裏面）プレハブ |  |
| `private` | cardPrefab | `CardController` | カード生成用プレハブ |  |
| `public` | playerHand | `Transform` | 各パネルへの場所へアクセス |  |
| `public` | enemyHand | `Transform` | 各パネルへの場所へアクセス |  |
| `public` | playerField | `Transform` | 各パネルへの場所へアクセス |  |
| `public` | enemyField | `Transform` | 各パネルへの場所へアクセス |  |
| `public` | MulliganField | `Transform` | 各パネルへの場所へアクセス |  |
| `private` | playerLeaderHPText | `TextMeshProUGUI` | HPテキストへのアクセス |  |
| `private` | enemyLeaderHPText | `TextMeshProUGUI` | 敵HPテキストへのアクセス |  |
| `private` | playerManaPointText | `TextMeshProUGUI` | マナポイントへのアクセス |  |
| `private` | playerDefaultManaPointText | `TextMeshProUGUI` | デフォルトマナポイントへのアクセス |  |
| `private` | enemyManaPointText | `TextMeshProUGUI` | 敵マナポイントへのアクセス |  |
| `private` | enemyDefaultManaPointText | `TextMeshProUGUI` | 敵デフォルトマナポイントへのアクセス |  |
| `private` | enemyGText | `TextMeshProUGUI` | 敵の手札にあるグーの数 |  |
| `private` | enemyCText | `TextMeshProUGUI` | 敵の手札にあるチョキの数 |  |
| `private` | enemyPText | `TextMeshProUGUI` | 敵の手札にあるパーの数 |  |
| `private` | playerLeaderTransform | `Transform` | プレイヤーのリーダーの位置 |  |
| `private` | enemyLeaderTransform | `Transform` | エネミーのリーダーの位置 |  |
| `public` | turnEndButton | `Button` | ターンエンドボタン |  |
| `public` | RestartButton | `Button` | リスタートボタン |  |
| `private` | BattleBgmManager | `GameObject` | BGMのゲームオブジェクト |  |
| `public` | playerManaPoint | `Int32` | 使用すると減るマナポイント |  |
| `public` | playerDefaultManaPoint | `Int32` | 毎ターン増えていくベースのマナポイント |  |
| `public` | enemyManaPoint | `Int32` | 敵の使用すると減るマナポイント |  |
| `public` | enemyDefaultManaPoint | `Int32` | 毎ターン増えていくベースの敵のマナポイント |  |
| `public` | isPlayerTurn | `Boolean` | 現在プレイヤーのターンかどうか<br>ターンフラグ反転<br>後攻<br>先攻<br>ターンを逆にする |  |
| `public` | GameStart | `Boolean` | ゲーム（ターン進行）を開始していいか<br>ターン開始していいか |  |
| `public` | MulliganFinished | `Boolean` | プレイヤーのマリガンが終わったか<br>マリガン完了 |  |
| `public` | EnemyMulliganFinished | `Boolean` | 相手がマリガンが終わったか |  |
| `public` | PlayerJanken | `Int32` | プレイヤーが出した手 (1:G, 2:C, 3:P)<br>プレイヤーのじゃんけんの手の初期化 |  |
| `public` | EnemyJanken | `Int32` | 敵が出した手(1:G, 2:C, 3:P)<br>敵プレイヤーのじゃんけんの手の初期化<br>P2のエネミーじゃんけんをP1の押したじゃんけんにする |  |
| `public` | PlayerResult | `Int32` | プレイヤーの勝敗結果 (1:Win, 2:Lose, 3:Draw) |  |
| `public` | EnemyResult | `Int32` | 敵の勝敗結果 (1:Win, 2:Lose, 3:Draw) |  |
| `public` | playerLeaderHP | `Int32` | プレイヤーのHP<br>プレイヤーのリーダーのHPを減らす |  |
| `public` | enemyLeaderHP | `Int32` | 敵のHP<br>敵のリーダーのHPを減らす |  |
| `public` | playerGCount | `Int32` | プレイヤーの手札のグーの枚数 |  |
| `public` | enemyGCount | `Int32` | 敵のの手札のグーの枚数 |  |
| `public` | playerCCount | `Int32` | //プレイヤーの手札のチョキの枚数 |  |
| `public` | enemyCCount | `Int32` | 敵のの手札のチョキの枚数 |  |
| `public` | playerPCount | `Int32` | //プレイヤーの手札のパーの枚数 |  |
| `public` | enemyPCount | `Int32` | 敵のの手札のパーの枚数 |  |
| `private` | playerRetryReady | `Boolean` | 自分が再戦準備完了したか |  |
| `private` | enemyRetryReady | `Boolean` | 相手が再戦準備完了したか |  |
| `private` | Battledeck | `List`1` | デッキ選択あり　対戦に使用するデッキリスト |  |
| `private` | deck | `List`1` | ゲーム中に使用するデッキ（変動する） |  |
| `public` | instance | `BattleManager` | シングルトン化 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | Unity Event Function |
| `private` | ⚡ Start |  | `Void` | unityのスタート |
| `private` | StartGame |  | `IEnumerator` | ゲーム開始時の初期化処理。<br>HP、マナのリセット、デッキの準備、最初の手札配布、マリガン処理を行う。<br>初期値の設定 、メソッド |
| `private` | Stopsec |  | `IEnumerator` |  |
| `public` | ShowManaPoint |  | `Void` | マナポイントをUIに表示し、相手にも同期する |
| `public` | ReduceManaPoint | Int32 cost | `Void` | コストの分、マナポイントを減らす |
| `public` | Mulligan |  | `Void` | マリガン処理。選択されたカードをデッキに戻し、同数引き直す |
| `public` | SetCanMulliganPanelHand | Boolean isAttachPanel | `Void` | マリガン時に手札を選択可能状態にすることでコスト関係なく動かせるようにする,trueなら動かせるように、falseなら動かせなくする |
| `public` | SetCanUsePanelHand | Boolean isAttachPanel | `Void` | 手札のカードを使用不可にする<br>自分のターン中、コスト条件を満たす手札を使用可能表示にする |
| `public` | CostBackOrigin |  | `Void` | コストダウン効果をリセットし、元のコストに戻す<br>コストリセット |
| `public` | PlayerCardCostBackOrigin |  | `Void` | プレイヤー側のカードのみコストを元に戻す<br>じゃんけん効果の際に使用 |
| `public` | CountHandJanken |  | `Void` | 手札のカードの属性（グー・チョキ・パー）を集計し、相手に通知する<br>じゃんけんカウント更新 |
| `public` | CreateCard | Int32 cardID, Transform trans | `Void` | カードオブジェクトを生成し、初期化する |
| `public` | SummonCard | Int32 cardID, Boolean isPlayer | `IEnumerator` | カードをフィールドに召喚する（トークン生成などに使用） |
| `public` | DrawCard | Transform hand | `Void` | デッキからカードを1枚引く<br>ドロー |
| `private` | SetStartHand | Int32 n | `IEnumerator` | 指定枚数(n)カードを配る |
| `private` | TurnCalc |  | `IEnumerator` | ターンの進行管理（ターン開始演出、フェーズ移行） |
| `public` | ChangeTurn |  | `Void` | ターン終了処理。攻守の切り替えを行う<br>ターンエンドボタンにつける処理<br>ターンエンドする |
| `private` | PlayerTurn |  | `Void` | プレイヤーターンの開始処理 |
| `private` | EnemyTurn |  | `Void` | 敵ターンの開始処理（ローカル側での処理）<br>CPU対戦ならIEnumeratorに変更 |
| `public` | CardBattle | CardController attackCard, CardController defenceCard | `IEnumerator` | カード同士のバトル処理。じゃんけん属性相性とパワーによる勝敗判定を行う |
| `private` | SetAttackableFieldCard | CardController[] cardList, Boolean canAttack | `Void` | Playerの場のカードを攻撃不可にする<br>フィールドカードの攻撃可否フラグを一括設定する<br>エネミーの場のカードを攻撃不可にする |
| `public` | AttackToLeader | CardController attackCard, Boolean isPlayerCard | `IEnumerator` | リーダーへの攻撃処理 |
| `public` | ShowLeaderHP |  | `Void` | リーダーHPを更新表示し、ゲーム終了判定を行う |
| `public` | RestartGame |  | `Void` | 再戦処理。盤面をリセットして再開する |
| `public` | BackHomeButtom |  | `Void` | ホーム画面へ戻る処理 |
| `public` | PlayerHandButton | Int32 PlayerjHand | `Void` | プレイヤーのじゃんけんボタンを押したとき |
| `public` | EnemyHandButton | Int32 EnemyjHand | `Void` | 敵のじゃんけんボタンを押したとき |
| `public` | JankenBattle | Int32 PlayerJanken, Int32 EnemyJanken | `Void` | じゃんけんの勝敗判定ロジック<br>じゃんけん判定 |
| `public` | JankenProcess |  | `IEnumerator` | ターン開始時のじゃんけんフェイズを実行するコルーチン |
| `public` | SendPlayerCard | Int32 cardID, Int32 playerNumberth | `Void` | 相手に召喚を通知<br>プレイヤーがカードを場に出した情報を相手に送信 |
| `public` | CreateEnemyCard |  | `Void` | 相手画面に手札枚数同期用カードを生成<br>手札生成通知 |
| `public` | RemoveEnemyHand |  | `Void` | 手札使用通知<br>手札 |
| `public` | DestroyRamdomJan | Int32 ENumberth | `Void` | ランダム破壊同期 |
| `private` | RPCOnRecievedCard | Int32 cardID, Int32 playerNumberth | `Void` |  |
| `private` | RPCCreateEnemyHand |  | `Void` | 自分の手札生成を相手の画面のenemyhandと同期 |
| `private` | RPCRemoveEnemyHand |  | `Void` | 自分の手札破壊を相手の画面のenemyhandと同期 |
| `private` | RPCattackwinBattle | Int32 PNumberth, Int32 ENumberth | `Void` | アタックが勝つ、ディフェンス破壊 |
| `private` | RPCattackloseBattle | Int32 PNumberth, Int32 ENumberth | `Void` | アタックが負ける、アタック側破壊<br>アタックが負ける、破壊 |
| `private` | RPCAttackMotion | Int32 PNumberth, Int32 ENumberth | `Void` | 攻撃モーションのみ<br>モーションのみ |
| `private` | RPCAttackLeaderMotion | Int32 PNumberth | `Void` | リーダー攻撃モーション同期 |
| `private` | RPCdrawBattle | Int32 PNumberth, Int32 ENumberth | `Void` | 相打ち |
| `private` | RPCTurnDecision | Boolean MasterTurn | `Void` | 先攻後攻の決定通知 |
| `private` | RPCChangeTurn |  | `Void` | ターン変更通知 |
| `private` | RPCSendJanken | Int32 PlayerjHand | `Void` | じゃんけんの手を受信 |
| `private` | RPCSendHP | Int32 pLeaderHP, Int32 eLeaderHP | `Void` | HP同期 |
| `public` | OnPlayerLeftRoom | Player otherPlayer | `Void` | 相手が退出した際の処理 |
| `private` | SendRetryMessage |  | `Void` | 再戦希望を送信<br>リトライメッセージを送信:retryを押した方 |
| `private` | OnRecieveRetryMessage |  | `Void` | リトライメッセージ受け取った時に実行 |
| `private` | RPCRestart |  | `Void` |  |
| `private` | ShowEnemyManaPoint | Int32 pManaPoint, Int32 pDefaultManaPoint | `Void` | マナポイントを表示するメソッド |
| `private` | RPCdestroyjan | Int32 ENumberth | `Void` | 条件に合うカードを破壊 |
| `private` | RPCMulliganBool |  | `Void` | マリガン完了通知 |
| `private` | RPCShowJankenCount | Int32 GCount, Int32 CCount, Int32 PCount | `Void` | 相手の手札のじゃんけん属性の数を反映 |

---

