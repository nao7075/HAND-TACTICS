using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;
using System.Linq;
using UnityEngine.SceneManagement;
/// <summary>
/// バトルシーン全体の進行管理、ルール処理、通信同期を行うクラス
/// </summary>
public class BattleManager : MonoBehaviourPunCallbacks
{
    [SerializeField] UIManager uIManager;//UIManagerをアタッチ
    [SerializeField] GameObject EnemyHandCard;//敵の手札（裏面）プレハブ
    [SerializeField] CardController cardPrefab;//カード生成用プレハブ
    [SerializeField] public Transform playerHand,enemyHand, playerField, enemyField, MulliganField;//各パネルへの場所へアクセス       
    [SerializeField] TextMeshProUGUI playerLeaderHPText;//HPテキストへのアクセス
    [SerializeField] TextMeshProUGUI enemyLeaderHPText;//敵HPテキストへのアクセス
    [SerializeField] TextMeshProUGUI playerManaPointText;//マナポイントへのアクセス
    [SerializeField] TextMeshProUGUI playerDefaultManaPointText;//デフォルトマナポイントへのアクセス
    [SerializeField] TextMeshProUGUI enemyManaPointText;//敵マナポイントへのアクセス
    [SerializeField] TextMeshProUGUI enemyDefaultManaPointText;//敵デフォルトマナポイントへのアクセス

    [SerializeField] TextMeshProUGUI enemyGText; // 敵の手札にあるグーの数
    [SerializeField] TextMeshProUGUI enemyCText; // 敵の手札にあるチョキの数
    [SerializeField] TextMeshProUGUI enemyPText; // 敵の手札にあるパーの数

    [SerializeField] Transform playerLeaderTransform;//プレイヤーのリーダーの位置
    [SerializeField] Transform enemyLeaderTransform;//エネミーのリーダーの位置

    [SerializeField] public Button turnEndButton;//ターンエンドボタン
    [SerializeField] public Button RestartButton;//リスタートボタン
    //[SerializeField] public Button MulliganButton;
    [SerializeField] GameObject BattleBgmManager;//BGMのゲームオブジェクト

    


    public int playerManaPoint; // 使用すると減るマナポイント
    public int playerDefaultManaPoint; // 毎ターン増えていくベースのマナポイント

    public int enemyManaPoint; // 敵の使用すると減るマナポイント
    public int enemyDefaultManaPoint; // 毎ターン増えていくベースの敵のマナポイント

    public bool isPlayerTurn = false; // 現在プレイヤーのターンかどうか
    public bool GameStart = false; // ゲーム（ターン進行）を開始していいか
    public bool MulliganFinished = false;// プレイヤーのマリガンが終わったか
    public bool EnemyMulliganFinished = false;//相手がマリガンが終わったか
    // --- じゃんけん関連 ---

    /// <summary>  プレイヤーが出した手 (1:G, 2:C, 3:P) </summary>
    public static int PlayerJanken=0;
    /// <summary>   敵が出した手(1:G, 2:C, 3:P) </summary>
    public static int EnemyJanken=0;
    /// <summary>  プレイヤーの勝敗結果 (1:Win, 2:Lose, 3:Draw) </summary>
    public static int PlayerResult=0;
    /// <summary>  敵の勝敗結果 (1:Win, 2:Lose, 3:Draw) </summary>
    public static int EnemyResult=0;

    public int playerLeaderHP;//プレイヤーのHP
    public int enemyLeaderHP;//敵のHP

    // 手札の属性カウント用
    public int playerGCount;//プレイヤーの手札のグーの枚数
    public int enemyGCount;//敵のの手札のグーの枚数
    public int playerCCount;////プレイヤーの手札のチョキの枚数
    public int enemyCCount;//敵のの手札のチョキの枚数
    public int playerPCount;////プレイヤーの手札のパーの枚数
    public int enemyPCount;//敵のの手札のパーの枚数

    bool playerRetryReady;// 自分が再戦準備完了したか
    bool enemyRetryReady;// 相手が再戦準備完了したか

    

    //public static List<int> deck = DeckSelectManager.deckList;  //デッキ
    //List<int> deck= new List<int>(DeckSelectManager.deckList);
    
    List<int> Battledeck = DeckSelectManager.deckList;//デッキ選択あり　対戦に使用するデッキリスト
    //List<int> Battledeck = new List<int>() {3,4,5,9,9,10,11,10,11,12,13,14,15,15,15,18,19,20,21,22,23,27,28,29,30,31,32,39,40,41,42,47};//デフォルトデッキ

    List<int> deck = new List<int>() {};// ゲーム中に使用するデッキ（変動する）
    
    // CPU用デッキ・手札管理
    List<int> enemyBattledeck = DeckSelectManager.deckList; // CPU用デッキ（デフォルトデッキ）
    List<int> enemyDeck = new List<int>() {}; // CPU用ゲーム中デッキ
    public static BattleManager instance;// シングルトン化
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()//unityのスタート
    {
        StartCoroutine(StartGame());
    }

    /// <summary>
    /// ゲーム開始時の初期化処理。
    /// HP、マナのリセット、デッキの準備、最初の手札配布、マリガン処理を行う。
    /// </summary>
    IEnumerator StartGame() // 初期値の設定 、メソッド
    {   

        turnEndButton.interactable = false;
        GameStart = false; // ターン開始していいか
        MulliganFinished = false;//マリガンが終わったか
        EnemyMulliganFinished = false;//相手がマリガンが終わったか
        PlayerJanken=0;
        EnemyJanken=0;
        PlayerResult=0;
        EnemyResult=0;
        BattleBgmManager.SetActive(true);
        Debug.Log("スタート:");
        CardController.PlayerNumberth=0;
        
        playerRetryReady = false;
        enemyRetryReady = false;
        // デッキリストをディープコピーして初期化
        deck.Clear();
        foreach (int card in Battledeck)
        {
            deck.Add(card); // ディープコピー        
        }
        
        // CPU用デッキ初期化（オフライン時のみ）
        if (GameManager.instance.IsOnlineBattle == false)
        {
            enemyDeck.Clear();
            foreach (int card in enemyBattledeck)
            {
                enemyDeck.Add(card); // CPU用デッキディープコピー
            }
        }
        
        // HP初期化
        enemyLeaderHP = 20;
        playerLeaderHP = 20;
        ShowLeaderHP();

        // マナ初期化
        playerManaPoint = 0;
        playerDefaultManaPoint = 0;

        enemyManaPoint = 0;
        enemyDefaultManaPoint = 0;
        ShowManaPoint();
        
        // 初期手札を3枚配る
        yield return StartCoroutine (SetStartHand(3));
        Debug.Log("Deck contents: " + string.Join(", ", deck));

        // オフライン(CPU戦)の場合、プレイヤーと同じタイミングでCPUにも初期手札を配る
        if (GameManager.instance.IsOnlineBattle == false)
        {
            yield return StartCoroutine(CPUDrawInitialHand(3));
        }

        // マリガン（手札引き直し）フェーズ開始
        SetCanMulliganPanelHand(true);
        uIManager.OpenMulliganPanel();//マリガンパネルを開く

        // 自分のマリガン完了待ち
        yield return new WaitUntil(() => MulliganFinished); 
        SetCanMulliganPanelHand(false);
        
        Debug.Log("Deck contents: " + string.Join(", ", deck));

        // 敵にマリガン完了を通知し、敵の完了を待つ
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCMulliganBool), RpcTarget.Others);//敵にマリガンが完了したことを伝える
            yield return new WaitUntil(() => EnemyMulliganFinished);
        }
        else
        {
            // オフライン(CPU戦)ではCPUもマリガン実行（既に初期手札は配布済み）
            yield return StartCoroutine(CPUMulligan());
            EnemyMulliganFinished = true;
        }

        // 先攻後攻の決定
        if (GameManager.instance.IsOnlineBattle == true)
        {
            Debug.Log("マスタークライアントか:"+PhotonNetwork.LocalPlayer.IsMasterClient);
            // オンライン時はマスタークライアントが決定する
            if(PhotonNetwork.LocalPlayer.IsMasterClient)//自分がマスタークライアントなら
            {
                int randomValue2 = Random.Range(0, 2);
                // 0なら自分が先攻、1なら後攻
                if(randomValue2 == 0)
                {
                    SoundManager.instance.PlaySE(0);
                    isPlayerTurn = true;
                    turnEndButton.interactable = true;
                    photonView.RPC(nameof(RPCTurnDecision), RpcTarget.Others, true);// 相手に通知
                }
                else
                {
                    isPlayerTurn = false;
                    turnEndButton.interactable = false;
                    SetCanUsePanelHand(false); // 手札のカードを使用不可にする
                    photonView.RPC(nameof(RPCTurnDecision), RpcTarget.Others, false);// 相手に通知
                }
                GameStart = true;
            }
        }
        else
        {
            // オフライン(CPU戦)時はローカルで先攻/後攻を決定
            int randomValue2 = Random.Range(0, 2);
            if(randomValue2 == 0)
            {
                SoundManager.instance.PlaySE(0);
                isPlayerTurn = true;
                turnEndButton.interactable = true;
            }
            else
            {
                isPlayerTurn = false;
                turnEndButton.interactable = false;
                SetCanUsePanelHand(false);
            }
            GameStart = true;
        }
        //else
        //{
        //    StartCoroutine (Stopsec());
        //}

        
        // ゲーム開始フラグが立つまで待機
        yield return new WaitUntil(() => GameStart); 
        Debug.Log("どっちのターンか:"+isPlayerTurn);
        uIManager.OpenJankenCountPanel();// じゃんけんカウントパネル表示
        StartCoroutine (TurnCalc());// ターン進行開始
    }

    
    IEnumerator Stopsec()
    {
        yield return null;
    }
    
    /// <summary>
    /// マナポイントをUIに表示し、相手にも同期する
    /// </summary>
    public void ShowManaPoint() 
    {
        playerManaPointText.text = playerManaPoint.ToString();
        playerDefaultManaPointText.text = playerDefaultManaPoint.ToString();
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(ShowEnemyManaPoint), RpcTarget.Others,playerManaPoint,playerDefaultManaPoint);
        }
    }

    /// <summary>
    /// コストの分、マナポイントを減らす
    /// </summary>
    public void ReduceManaPoint(int cost)
    {
        playerManaPoint -= cost;
        ShowManaPoint();
        
        // コスト支払い後、残りのマナで手札が使えるか再判定
        if (isPlayerTurn)
        {
            SetCanUsePanelHand(true);
        }
    }

    /// <summary>
    /// CPU マリガン処理（UI の選択を真似るなどを実装する余地あり）。
    /// 既に初期手札は `CPUDrawInitialHand` で配られているため、ここでは属性再計算のみ行う。
    /// </summary>
    IEnumerator CPUMulligan()
    {
        // CPUのマリガンロジック
        // 手札を確認し、コストが4以上のカードはデッキに戻して引き直す
        
        CardController[] currentHand = enemyHand.GetComponentsInChildren<CardController>();
        List<CardController> cardsToSwap = new List<CardController>();

        foreach (CardController card in currentHand)
        {
            // コスト4以上なら交換対象
            if (card.model.cost >= 4)
            {
                cardsToSwap.Add(card);
            }
        }

        int swapCount = cardsToSwap.Count;

        if (swapCount > 0)
        {
            // 交換するカードをデッキに戻して破壊
            foreach (CardController card in cardsToSwap)
            {
                enemyDeck.Add(card.model.cardId);
                Destroy(card.gameObject);
            }

            // 少し待つ（演出用）
            yield return new WaitForSeconds(0.5f);

            // 同数引き直す
            yield return StartCoroutine(CPUDrawInitialHand(swapCount));
        }

        UpdateCPUJankenCount();
    }

    /// <summary>
    /// CPU の初期手札をプレイヤーと同じタイミングで配るためのヘルパー
    /// </summary>
    public IEnumerator CPUDrawInitialHand(int n)
    {
        for (int i = 0; i < n; i++)
        {
            EnemyDrawCard();
            yield return new WaitForSeconds(0.25f);
        }
    }

    /// <summary>
    /// CPU の手札からじゃんけん属性カウントを更新して敵側に表示
    /// </summary>
    public void UpdateCPUJankenCount()
    {
        enemyGCount = 0;
        enemyCCount = 0;
        enemyPCount = 0;
        
        // CPU の手札オブジェクトから属性をカウント
        CardController[] cards = enemyHand.GetComponentsInChildren<CardController>();
        foreach (CardController card in cards)
        {
            int janken = card.model.janken;
            if (janken == 1) enemyGCount++;
            else if (janken == 2) enemyCCount++;
            else if (janken == 3) enemyPCount++;
        }
        
        // 敵側 UI に表示
        enemyGText.text = enemyGCount.ToString();
        enemyCText.text = enemyCCount.ToString();
        enemyPText.text = enemyPCount.ToString();
    }

    /// <summary>
    /// マリガン処理。選択されたカードをデッキに戻し、同数引き直す
    /// </summary>
    public void Mulligan()
    {
        CardController[] MulliganCardList = MulliganField.GetComponentsInChildren<CardController>();

        // MulliganCardListが空でない場合
        if (MulliganCardList.Length != 0)
        {
            // 追加したカードの数をカウント
            int cardsAdded = 0;

            // 各CardControllerについて
            foreach (CardController card in MulliganCardList)
            {
                // card.model.cardIdをdeckリストに追加  デッキに戻す
                deck.Add(card.model.cardId);
                
                // cardのゲームオブジェクトを破壊        オブジェクト削除
                Destroy(card.gameObject);

                // 追加したカードの数をインクリメント
                cardsAdded++;
            }

            // 追加したカードの数だけDrawCardを実行
            
            
            StartCoroutine(SetStartHand(cardsAdded));// 戻した枚数分ドロー
            
        }

        uIManager.CloseMulliganPanel(); //マリガンパネルを閉じる
        MulliganFinished = true;    //マリガン完了
    }

    /// <summary>
    /// マリガン時に手札を選択可能状態にすることでコスト関係なく動かせるようにする,trueなら動かせるように、falseなら動かせなくする
    /// </summary>
    public void SetCanMulliganPanelHand(bool isAttachPanel)
    {
        // 手札のカードを取得
        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        //使用可能なカードにCanUseパネルを付ける
        if (isAttachPanel)
        {
            foreach (CardController card in playerHandCardList)
            {

                card.model.canUse = true;
                card.view.SetCanUsePanel(card.model.canUse);
            }
        }
        else
        {
            foreach (CardController card in playerHandCardList)
            {
                card.model.canUse = false;
                card.view.SetCanUsePanel(card.model.canUse);
            }
        }
    }

    
    
    /// <summary>
    /// 自分のターン中、コスト条件を満たす手札を使用可能表示にする
    /// </summary>        
    public void SetCanUsePanelHand(bool isAttachPanel)
    {
        // 手札のカードを取得
        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        //使用可能なカードにCanUseパネルを付ける
        if (isAttachPanel)
        {
            foreach (CardController card in playerHandCardList)
            {
                if (card.model.cost <= playerManaPoint)// コストが足りていれば使用可能
                {
                    card.model.canUse = true;
                    card.view.SetCanUsePanel(card.model.canUse);
                }
                else
                {
                    card.model.canUse = false;
                    card.view.SetCanUsePanel(card.model.canUse);
                }
            }
        }
        else//falseを受け取っているので手札のカードすべて使用不可能にする
        {
            foreach (CardController card in playerHandCardList)
            {
                card.model.canUse = false;
                card.view.SetCanUsePanel(card.model.canUse);
            }
        }
    }

    /// <summary>
    /// コストダウン効果をリセットし、元のコストに戻す
    /// </summary>
    public void CostBackOrigin()
    {
        //手札のカードのリスト取得
        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        //自フィールドのカードのリスト取得
        CardController[] playerFieldCardList = playerField.GetComponentsInChildren<CardController>();

        //敵のフィールドのカードのリスト取得   
        CardController[] enemyFieldCardList = enemyField.GetComponentsInChildren<CardController>();

        // 全エリアのカードのコストを元に戻す
        foreach (CardController card in playerHandCardList)
        {
            if (card.model.isCostDown == true)
            {
                card.model.cost++;
                card.model.isCostDown = false;
                card.view.Show(card.model);
            }
        }
        foreach (CardController card in playerFieldCardList)
        {
            if (card.model.isCostDown == true)
            {
                card.model.cost++;
                card.model.isCostDown = false;
                card.view.Show(card.model);
            }
        }
        foreach (CardController card in enemyFieldCardList)
        {
            if (card.model.isCostDown == true)
            {
                card.model.cost++;
                card.model.isCostDown = false;
                card.view.Show(card.model);
            }
        }
    }

    /// <summary>
    /// プレイヤー側のカードのみコストを元に戻す
    /// </summary>
    public void PlayerCardCostBackOrigin()//じゃんけん効果の際に使用 
    {   
        //手札のカードのリスト取得
        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        //フィールドのカードのリスト取得
        CardController[] playerFieldCardList = playerField.GetComponentsInChildren<CardController>();
         

        foreach (CardController card in playerHandCardList)
        {
            if (card.model.isCostDown == true)
            {
                card.model.cost++;
                card.model.isCostDown = false;
                card.view.Show(card.model);
            }
        }
        foreach (CardController card in playerFieldCardList)
        {
            if (card.model.isCostDown == true)
            {
                card.model.cost++;
                card.model.isCostDown = false;
                card.view.Show(card.model);
            }
        }
    }

    /// <summary>
    /// 敵側のカードのみコストを元に戻す
    /// </summary>
    public void EnemyCardCostBackOrigin()
    {   
        //手札のカードのリスト取得
        CardController[] enemyHandCardList = enemyHand.GetComponentsInChildren<CardController>();

        foreach (CardController card in enemyHandCardList)
        {
            if (card.model.isCostDown == true)
            {
                card.model.cost++;
                card.model.isCostDown = false;
                card.view.Show(card.model);
            }
        }
    }

    /// <summary>
    /// 手札のカードの属性（グー・チョキ・パー）を集計し、相手に通知する
    /// </summary>
    public void CountHandJanken()
    {
        playerGCount = 0;//グーの枚数
        playerCCount = 0;//チョキの枚数
        playerPCount = 0;//パーの枚数

        //手札のカードリストを取得
        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        foreach (CardController card in playerHandCardList)//カウント
        {
            if (card.model.janken == 1)
            {
                playerGCount++;
            }
            else if(card.model.janken == 2)
            {
                playerCCount++;
            }
            else if(card.model.janken == 3)
            {
                playerPCount++;
            }
        }

        //同期
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCShowJankenCount), RpcTarget.Others, playerGCount, playerCCount, playerPCount);
        }
    }
    
    /// <summary>
    /// カードオブジェクトを生成し、初期化する
    /// </summary>
    public void CreateCard(int cardID, Transform trans)
    {
        
        CardController card = Instantiate(cardPrefab, trans);//Instantiate(CardPrefab,PlayerField)だと、自分のフィールドにカードを出す。
        
        
        
        if (trans == playerHand)
        {   
            card.PlayerInit(cardID, true);// Playerの手札に生成されたカードはPlayerのカードとする
            if(GameManager.instance.IsOnlineBattle == true)
            {
                CreateEnemyCard();// 相手画面に手札枚数同期用カードを生成
            }
            CountHandJanken();//じゃんけんカウント更新
            Debug.Log("手札生成:");
        }
        
        /*else //if (trans == enemyHand)
        {   
            card.EnemyInit(cardID, false);
            //photonView.RPC(nameof(RPCCreatePlayerHand), RpcTarget.Others, cardID);
            //相手の手札に生成することはない
        }*/
        /* 敵の手札には直接生成しない（RPCで同期） */
       
    }

    /// <summary>
    /// カードをフィールドに召喚する（トークン生成などに使用）
    /// </summary>
    public IEnumerator SummonCard(int cardID, bool isPlayer)
    {
        if (isPlayer == true)
        {
            //フィールドのカードリストを取得
            CardController[] playerFieldCardList = playerField.GetComponentsInChildren<CardController>();

            if (playerFieldCardList.Length >= 6)//フィールドがが6枚以上なら
            {
                yield break;
            }

            CardController card = Instantiate(cardPrefab, playerField);
            card.PlayerInit(cardID, true);
            
            card.model.FieldCard = true;
            //card.CostDown();
            if(GameManager.instance.IsOnlineBattle == true)
            {
                SendPlayerCard(cardID, card.model.playerNumberth);// 相手に召喚を通知
            }
            yield return StartCoroutine(card.activateAbility());// 出た時効果発動
        }
        else
        {
            if(GameManager.instance.IsOnlineBattle == false)
            {
                //敵フィールドのカードリストを取得
                CardController[] enemyFieldCardList = enemyField.GetComponentsInChildren<CardController>();

                if (enemyFieldCardList.Length >= 6)//フィールドが6枚以上なら
                {
                    yield break;
                }

                CardController card = Instantiate(cardPrefab, enemyField);
                card.EnemyInit(cardID, false, 0);
                card.model.FieldCard = true;
                yield return StartCoroutine(card.activateAbility());// 出た時効果発動
            }
        }
    }

    /// <summary>
    /// デッキからカードを1枚引く
    /// </summary>
    public void DrawCard(Transform hand) 
    {
        // デッキが０枚なら引かない
        if (deck.Count == 0)
        {
            return;
        }
        //手札のカードリストを取得
        CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

        if (playerHandCardList.Length < 6)//手札が6枚未満なら
        {
            // デッキからランダムなカードを引く
            int randomIndex = Random.Range(0, deck.Count);//デッキのリストからランダムに一つ選ぶ
            int cardID = deck[randomIndex];
            deck.RemoveAt(randomIndex);// 選んだカードをデッキから削除
            CreateCard(cardID, hand);
            SoundManager.instance.PlaySE(7);
        }
        CountHandJanken();
        SetCanUsePanelHand(true);
    }

    /// <summary>
    /// CPUの手札カードを生成する
    /// </summary>
    public void CreateCPUHandCard(int cardID)
    {
        if (GameManager.instance.IsOnlineBattle == false) // CPU対戦時
        {
            // 実カードプレハブを生成
            CardController card = Instantiate(cardPrefab, enemyHand);
            card.Init(cardID, false); // 敵カードとして初期化
        }
    }

    /// <summary>
    /// CPUがデッキからカードを1枚引く
    /// </summary>
    public void EnemyDrawCard()
    {
        // デッキが０枚なら引かない
        if (enemyDeck.Count == 0)
        {
            return;
        }

        // 手札が6枚未満なら
        if (enemyHand.childCount < 6)
        {
            int randomIndex = Random.Range(0, enemyDeck.Count);
            int cardID = enemyDeck[randomIndex];
            enemyDeck.RemoveAt(randomIndex);

            CreateCPUHandCard(cardID);
            SoundManager.instance.PlaySE(7);
        }
        UpdateCPUJankenCount();
    }

    /// <summary>
    /// 指定枚数(n)カードを配る
    /// </summary>
    IEnumerator SetStartHand(int n)
    {
        for (int i = 0; i < n; i++)
        {
            DrawCard(playerHand);
            yield return new WaitForSeconds(0.25f);
        }
    }

    /// <summary>
    /// ターンの進行管理（ターン開始演出、フェーズ移行）
    /// </summary>
    IEnumerator TurnCalc() 
    {   //Debug.Log("ターン管理:");
        //Debug.Log("どっちのターンか:"+isPlayerTurn);
        //StartCoroutine (Stopsec());

        // 少し待機してからターン切り替えパネルを表示
        for(int r = 1; r <= 3; r++)
        {
            yield return null;
        }
        SoundManager.instance.PlaySE(6);
        yield return StartCoroutine(uIManager.ShowChangeTurnPanel());

        //Debug.Log("ターン管理:");
        //Debug.Log("どっちのターンか:"+isPlayerTurn);

        if (isPlayerTurn)//BattleManager.isPlayerTurnフラグがtrueなら
        {
            PlayerTurn();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    /// <summary>
    /// ターン終了処理。攻守の切り替えを行う
    /// </summary>
    public void ChangeTurn() // ターンエンドボタンにつける処理
    {   
        if (isPlayerTurn)
        {
            CardController[] playerFieldCardList = playerField.GetComponentsInChildren<CardController>();
            SetAttackableFieldCard(playerFieldCardList,false); // Playerの場のカードを攻撃不可にする
            SetCanUsePanelHand(false); // 手札のカードを使用不可にする
            CostBackOrigin();   // コストリセット
            SoundManager.instance.PlaySE(0);
        }
        else if (!isPlayerTurn && GameManager.instance.IsOnlineBattle == false)
        {
            CardController[] enemyFieldCardList = enemyField.GetComponentsInChildren<CardController>();
            SetAttackableFieldCard(enemyFieldCardList, false); // Enemyの場のカードを攻撃不可にする
            SoundManager.instance.PlaySE(0);
        }
        // ターンエンドボタンを押下可能/不可能にする
        turnEndButton.interactable = !turnEndButton.interactable;

        isPlayerTurn = !isPlayerTurn; // ターンフラグ反転
        StartCoroutine(TurnCalc()); // 次のターンへ
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCChangeTurn), RpcTarget.Others);// 相手にターン変更を通知
        }
    }

    /// <summary>
    /// プレイヤーターンの開始処理
    /// </summary>
    void PlayerTurn()
    {   Debug.Log("Playerのターン");
        
        DrawCard(playerHand); // ドロー
        CostBackOrigin();
        StartCoroutine(JankenProcess());// じゃんけんフェイズ開始

        //自フィールドのカードリストを取得
        CardController[] playerFieldCardList = playerField.GetComponentsInChildren<CardController>();

        // 場のカードを攻撃可能にする
        SetAttackableFieldCard(playerFieldCardList, true);

         /// デフォルトマナを1増やしてさらに回復
        if(playerDefaultManaPoint <= 9)
        {
            playerDefaultManaPoint++;
        }
        playerManaPoint = playerDefaultManaPoint;
        ShowManaPoint();
    }

    /// <summary>
    /// 敵ターンの開始処理（ローカル側での処理）
    /// </summary>
    /// <summary>
    /// CPUがカードを評価するためのスコア計算メソッド (ラッパー)
    /// </summary>
    int GetCardScore(CardController card)
    {
        return GetCardScore(card, EnemyJanken, EnemyResult);
    }

    /// <summary>
    /// CPUがカードを評価するためのスコア計算メソッド (シミュレーション用)
    /// </summary>
    int GetCardScore(CardController card, int currentHand, int currentResult)
    {
        CardModel m = card.model;
        int score = 0;

        // 基本スコア: パワーとコスト
        score += m.power * 100;
        score += m.cost * 300;

        // --- 常時発動効果 ---
        
        // スピードアタッカー (即戦力)
        if (m.isSpeedAttacker) score += 500;
        
        // ドロー効果 (手札補充)
        if (m.drawCardNum > 0) score += m.drawCardNum * 200;
        
        // マナブースト (次ターン以降有利)
        if (m.manaBoostNum > 0) score += m.manaBoostNum * 300;

        // 破壊効果 (相手の場にターゲットがいるか確認)
        if (m.destroyjan != 0)
        {
            bool targetExists = false;
            foreach (CardController enemyCard in playerField.GetComponentsInChildren<CardController>())
            {
                if (enemyCard.model.janken == m.destroyjan)
                {
                    targetExists = true;
                    break;
                }
            }
            if (targetExists) score += 1000; // ターゲットがいれば高評価
        }
        
        // 全破壊 (自分の被害が少なく、相手の被害が大きいなら高評価)
        if (m.alldestroy)
        {
            int myCount = enemyField.childCount;
            int enemyCount = playerField.childCount;
            if (enemyCount > myCount) score += 1500;
            else score -= 500; // 自爆になるなら避ける
        }

        // --- 条件付き効果 (現在のじゃんけん結果に基づく) ---

        // じゃんけん勝利時
        if (currentResult == 1) // Win
        {
            if (m.janwinspeed) score += 500;
            if (m.janwinpower > 0) score += m.janwinpower * 100;
            if (m.janwindraw > 0) score += m.janwindraw * 200;
            if (m.janwinPHp > 0) score += m.janwinPHp * 50; // 回復
            if (m.janwinEHp < 0) score += Math.Abs(m.janwinEHp) * 100; // ダメージ
            
            // 召喚効果
            if (m.janwinsummonCardsList != null && m.janwinsummonCardsList.Length > 0)
            {
                score += m.janwinsummonCardsList.Length * 300;
            }
        }
        // じゃんけん敗北時
        else if (currentResult == 2) // Lose
        {
            if (m.janlosespeed) score += 500;
            if (m.janlosepower > 0) score += m.janlosepower * 100;
            if (m.janlosedraw > 0) score += m.janlosedraw * 200;
            // ... 他の負け効果も同様に加点
        }

        // 手札一致時 (自分が出した手とカードの属性が一致)
        if (currentHand == m.janken)
        {
            if (m.janhandspeed) score += 500;
            if (m.janhandpower > 0) score += m.janhandpower * 100;
            if (m.janhanddraw > 0) score += m.janhanddraw * 200;
            if (m.janhandPHp > 0) score += m.janhandPHp * 50;
            if (m.janhandEHp < 0) score += Math.Abs(m.janhandEHp) * 100;
            
            if (m.janhandsummonCardsList != null && m.janhandsummonCardsList.Length > 0)
            {
                score += m.janhandsummonCardsList.Length * 300;
            }
        }

        return score;
    }

    /// <summary>
    /// CPUの最適なじゃんけん手を選択する
    /// </summary>
    int GetBestCPUJankenHand()
    {
        // プレイヤーのターン（防御時）は、相手の手札予測に基づいて勝てる手を選ぶ
        if (isPlayerTurn)
        {
            int predictedPlayerHand = PredictPlayerHand();
            
            // 予測した手に勝つ手を選ぶ
            // 1(グー) -> 3(パー)
            // 2(チョキ) -> 1(グー)
            // 3(パー) -> 2(チョキ)
            int bestHand = 0;
            if (predictedPlayerHand == 1) bestHand = 3;
            else if (predictedPlayerHand == 2) bestHand = 1;
            else if (predictedPlayerHand == 3) bestHand = 2;

            // ランダム性を持たせる (30%の確率でランダムな手にする)
            if (UnityEngine.Random.Range(0, 100) < 30)
            {
                return UnityEngine.Random.Range(1, 4);
            }
            
            return bestHand;
        }

        // --- 以下、CPUターン（攻撃時）のロジック ---

        int[] scores = new int[4]; // 1:グー, 2:チョキ, 3:パー
        CardController[] myHand = enemyHand.GetComponentsInChildren<CardController>();
        int playerLikelyHand = PredictPlayerHand();
        Debug.Log($"CPU Prediction: Player will play {playerLikelyHand}");

        int initialMana = enemyManaPoint; // 現在のマナ

        // 各手(1,2,3)を出した場合のシミュレーション
        for (int hand = 1; hand <= 3; hand++)
        {
            // 対プレイヤー予想
            int diff = hand - playerLikelyHand;
            bool cpuWins = (diff == -1 || diff == 2);
            bool cpuLoses = (diff == 1 || diff == -2);
            
            int predictedResult = 0; // 0:Draw
            if (cpuWins) predictedResult = 1; // Win
            else if (cpuLoses) predictedResult = 2; // Lose

            // 基本勝敗スコアは加算しない（カードの効果とコストダウンのみで判断する）

            // この手を出したときの手札の状態をシミュレート
            // (コスト, スコア) のリストを作成
            List<KeyValuePair<int, int>> simulCards = new List<KeyValuePair<int, int>>();

            foreach (var card in myHand)
            {
                CardModel m = card.model;
                int tempCost = m.cost;
                bool isMatch = (m.janken == hand);

                // コストダウンのシミュレーション (属性一致かつ勝利ならコスト-1)
                if (isMatch && cpuWins)
                {
                    tempCost--;
                }
                if (tempCost < 0) tempCost = 0;

                // シミュレーション条件下でのカードスコアを計算
                int cardScore = GetCardScore(card, hand, predictedResult);
                
                simulCards.Add(new KeyValuePair<int, int>(tempCost, cardScore));
            }

            // 召喚シミュレーション: スコアが高い順にマナが尽きるまで採用
            // これにより「このターンに実際に召喚できるカード」の価値を合計する
            simulCards.Sort((a, b) => b.Value.CompareTo(a.Value)); // スコア降順

            int currentMana = initialMana;
            int fieldSpace = 5 - enemyField.childCount; // 空きスペース

            foreach (var sc in simulCards)
            {
                if (fieldSpace <= 0) break;
                
                int cost = sc.Key;
                int score = sc.Value;

                if (cost <= currentMana)
                {
                    // 採用
                    scores[hand] += score;
                    currentMana -= cost;
                    fieldSpace--;
                }
            }
            Debug.Log($"Hand {hand} Score: {scores[hand]}");
        }

        // スコア最大のカードを選択
        int maxScore = -99999;
        List<int> candidates = new List<int>();

        for(int h=1; h<=3; h++)
        {
            if(scores[h] > maxScore)
            {
                maxScore = scores[h];
                candidates.Clear();
                candidates.Add(h);
            }
            else if(scores[h] == maxScore)
            {
                candidates.Add(h);
            }
        }

        // 同点ならランダム
        return candidates[UnityEngine.Random.Range(0, candidates.Count)];
    }

    /// <summary>
    /// プレイヤーが出す手を予測する
    /// </summary>
    int PredictPlayerHand()
    {
        // プレイヤーの手札で最も多い属性を出すと予測（シナジー狙い）
        CardController[] pHand = playerHand.GetComponentsInChildren<CardController>();
        
        // 手札がない場合はランダム予測
        if(pHand.Length == 0) return UnityEngine.Random.Range(1, 4);

        int[] counts = new int[4];
        foreach(var c in pHand) counts[c.model.janken]++;
        
        int maxCount = -1;
        List<int> candidates = new List<int>();

        for(int i=1; i<=3; i++)
        {
            if(counts[i] > maxCount)
            {
                maxCount = counts[i];
                candidates.Clear();
                candidates.Add(i);
            }
            else if(counts[i] == maxCount)
            {
                candidates.Add(i);
            }
        }
        
        return candidates[UnityEngine.Random.Range(0, candidates.Count)];
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemyのターン");
        Debug.Log("どっちのターンか:" + isPlayerTurn);

        // オフライン(CPU戦)時のターンドローとマナ回復処理
        if (GameManager.instance.IsOnlineBattle == false)
        {
            // デフォルトマナを1増やしてさらに回復
            if (enemyDefaultManaPoint <= 9)
            {
                enemyDefaultManaPoint++;
            }
            enemyManaPoint = enemyDefaultManaPoint;
            // 敵のマナ表示を更新
            ShowEnemyManaPoint(enemyManaPoint, enemyDefaultManaPoint);

            // 敵のドロー
            EnemyDrawCard();
            yield return new WaitForSeconds(0.25f);
        }

        EnemyCardCostBackOrigin();
        // マナ回復とドローを終えたらじゃんけんフェイズを開始
        yield return StartCoroutine(JankenProcess());

        // オンライン時は相手側で行動が発生するためローカルでのCPU行動は行わない
        if (GameManager.instance.IsOnlineBattle == true)
        {
            yield break;
        }

        // 簡易CPUの挙動: 少し待ってから場を整え、召喚→攻撃→ターン終了
        yield return new WaitForSeconds(1f);
        CardController[] enemyFieldCardList = enemyField.GetComponentsInChildren<CardController>();
        SetAttackableFieldCard(enemyFieldCardList, true);
        yield return new WaitForSeconds(1f);

        // --- 召喚ロジック（状況に合わせて最適なカードを選択） ---
        
        // 召喚ループ
        while (true)
        {
            // フィールド上限チェック
            if (enemyField.GetComponentsInChildren<CardController>().Length >= 5) break;

            // 手札を取得
            CardController[] enemyHandCards = enemyHand.GetComponentsInChildren<CardController>();
            
            // マナが足りるカードを抽出
            List<CardController> affordableCards = new List<CardController>();
            foreach (CardController card in enemyHandCards)
            {
                if (card.model.cost <= enemyManaPoint)
                {
                    affordableCards.Add(card);
                }
            }

            // 出せるカードがなければ終了
            if (affordableCards.Count == 0) break;

            // 各カードを評価してスコア付け
            CardController bestCard = null;
            int bestScore = -9999;

            foreach (CardController card in affordableCards)
            {
                int score = GetCardScore(card);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestCard = card;
                }
            }

            // 最もスコアの高いカードを召喚
            if (bestCard != null)
            {
                int cardID = bestCard.model.cardId;
                int cardCost = bestCard.model.cost;

                // マナ消費
                enemyManaPoint -= cardCost;
                if (enemyManaPoint < 0) enemyManaPoint = 0;
                ShowEnemyManaPoint(enemyManaPoint, enemyDefaultManaPoint);

                // 選択したカードオブジェクトを破壊
                Destroy(bestCard.gameObject);

                // 召喚実行
                yield return StartCoroutine(SummonCard(cardID, false));

                // 属性カウント更新
                UpdateCPUJankenCount();

                yield return new WaitForSeconds(0.25f);
            }
            else
            {
                break;
            }
        }

        yield return new WaitForSeconds(1f);

        // --- 攻撃フェーズ（有利な相手を選んで攻撃） ---
        
        // リーサルチェック：攻撃可能な全ユニットの攻撃力合計がプレイヤーHP以上なら、全てリーダーへ攻撃
        CardController[] allAttackers = Array.FindAll(enemyField.GetComponentsInChildren<CardController>(), c => c.model.canAttack);
        int totalAttackPower = 0;
        foreach (var card in allAttackers) totalAttackPower += card.model.power;

        if (totalAttackPower >= playerLeaderHP)
        {
            foreach (var attacker in allAttackers)
            {
                yield return StartCoroutine(attacker.Battlemovement.AttackMotion(playerLeaderTransform));
                
                attacker.model.canAttack = false;
                attacker.view.SetCanAttackPanel(false);
                playerLeaderHP -= attacker.model.power;
                ShowLeaderHP();
                yield return new WaitForSeconds(0.5f);

                if (playerLeaderHP <= 0) break;
            }
        }
        else
        {
            while (true)
            {
                // 攻撃可能なカードと防御側のカードを再取得
                CardController[] attackers = Array.FindAll(enemyField.GetComponentsInChildren<CardController>(), c => c.model.canAttack);
                CardController[] defenders = playerField.GetComponentsInChildren<CardController>();

                // 攻撃できるカードがいなければ終了
                if (attackers.Length == 0) break;

                // 最適な攻撃対象を探す
                CardController bestAttacker = null;
                CardController bestTarget = null;
                int bestScore = -999;

                // 防御側がいる場合のみ、ユニット攻撃の可能性を探る
                if (defenders.Length > 0)
                {
                    foreach (var attacker in attackers)
                    {
                        foreach (var defender in defenders)
                        {
                            int score = -9999;
                            int jan = attacker.model.janken - defender.model.janken;
                            
                            // じゃんけん勝利 (-1 or 2)
                            if (jan == -1 || jan == 2) 
                            {
                                score = 1000; 
                                score += defender.model.power * 10; // 強い敵を倒すほど高評価
                            }
                            // あいこ (0) かつ パワー勝ち
                            else if (jan == 0 && attacker.model.power > defender.model.power)
                            {
                                score = 500; 
                                score += defender.model.power * 10;
                            }
                            
                            // 勝てる場合、攻撃者のパワーが低いほど評価を上げる（強いカードをリーダー攻撃用に温存するため）
                            if (score > 0)
                            {
                                score -= attacker.model.power;
                            }

                            // 勝てる場合のみ更新
                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestAttacker = attacker;
                                bestTarget = defender;
                            }
                        }
                    }
                }

                // 勝てる相手がいる場合 (スコアが更新されている)
                if (bestAttacker != null && bestScore >= 100)
                {
                    // 攻撃実行
                    yield return StartCoroutine(bestAttacker.Battlemovement.AttackMotion(bestTarget.transform));
                    
                    // 攻撃側勝利（ロジック上、勝てる相手しか選んでいないため、相手を破壊）
                    bestAttacker.model.canAttack = false;
                    bestAttacker.view.SetCanAttackPanel(false);
                    StartCoroutine(bestTarget.DestroyCard(bestTarget));
                    
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    // 勝てる相手がいない、または相手がいない場合はリーダーを攻撃
                    foreach (var attacker in attackers)
                    {
                        yield return StartCoroutine(attacker.Battlemovement.AttackMotion(playerLeaderTransform));
                        
                        attacker.model.canAttack = false;
                        attacker.view.SetCanAttackPanel(false);
                        playerLeaderHP -= attacker.model.power;
                        ShowLeaderHP();
                        yield return new WaitForSeconds(0.5f);
                    }
                    break; // 全員攻撃したので終了
                }
            }
        }

        yield return new WaitForSeconds(1f);
        ChangeTurn(); // ターンエンド
    }

    /// <summary>
    /// カード同士のバトル処理。じゃんけん属性相性とパワーによる勝敗判定を行う
    /// </summary>
    public IEnumerator CardBattle(CardController attackCard, CardController defenceCard)
    {
        // 属性相性判定（1:グー, 2:チョキ, 3:パー）
        // 差分 jan = 攻撃 - 防御

        // グー(1) - チョキ(2) = -1 (勝)
        // チョキ(2) - パー(3) = -1 (勝)
        // パー(3) - グー(1) = 2 (勝)

        // グー(1) - パー(3) = -2 (負)
        // チョキ(2) - グー(1) = 1 (負)
        // パー(3) - チョキ(2) = 1 (負)

        int jan=attackCard.model.janken-defenceCard.model.janken;
        // 攻撃カードと攻撃されるカードが同じプレイヤーのカードならバトルしない
        if (attackCard.model.PlayerCard == defenceCard.model.PlayerCard)
        {
            yield break;;
        }

        // 攻撃カードがアタック可能でなければ攻撃しないで処理終了する
        if (attackCard.model.canAttack == false)
        {
            yield break;;
        }
        SetCanUsePanelHand(false);//攻撃中は手札を使用不可能にする
        

        // --- 攻撃側勝利 (有利属性) ---
        if (jan==-1 || jan==2)
        {
            //自画面でのアタックモーションはDragを終えた地点がtransformParentになってしまい元の位置に戻らない
            StartCoroutine (attackCard.Battlemovement.PlayerAttackMotion(defenceCard.transform));//自画面でのアタックモーション　1S
            if(GameManager.instance.IsOnlineBattle == true)
            {
                photonView.RPC(nameof(RPCAttackMotion), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面のアタックモーション1S
            }
            yield return new WaitForSeconds(1.1f);

            // 相手側の破壊処理同期
            if(GameManager.instance.IsOnlineBattle == true)
            {
                photonView.RPC(nameof(RPCattackwinBattle), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面での破壊
            }
            
            // 攻撃済み状態へ
            attackCard.model.canAttack = false;     
            attackCard.view.SetCanAttackPanel(false); 

            // 防御側カード破壊（自分画面）
            StartCoroutine(defenceCard.DestroyCard(defenceCard));
            
            
        }

        // --- 防御側勝利 (不利属性) ---
        else if (jan==1 || jan==-2)
        {
            //自画面でのアタックモーションはDragを終えた地点がtransformParentになってしまい元の位置に戻らない
            StartCoroutine (attackCard.Battlemovement.PlayerAttackMotion(defenceCard.transform));//自画面のアタックモーション
            if(GameManager.instance.IsOnlineBattle == true)
            {
                photonView.RPC(nameof(RPCAttackMotion), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面のアタックモーション
            }
            yield return new WaitForSeconds(1.1f);

            // 相手側の破壊処理同期
            if(GameManager.instance.IsOnlineBattle == true)
            {
                photonView.RPC(nameof(RPCattackloseBattle), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面での破壊
            }
            
            // 攻撃済み状態へ
            attackCard.model.canAttack = false;     
            attackCard.view.SetCanAttackPanel(false); 
            
            // 防御側カード破壊（自分画面）
            StartCoroutine(attackCard.DestroyCard(attackCard));//自画面での破壊

        }
        // あいこの場合、パワーで勝負する
        else if (jan==0)
        {
            
            // 攻撃側のパワーが高かった場合、攻撃されたカードを破壊する
            if (attackCard.model.power > defenceCard.model.power)
            {
                //自画面でのアタックモーションはDragを終えた地点がtransformParentになってしまい元の位置に戻らない
                StartCoroutine (attackCard.Battlemovement.PlayerAttackMotion(defenceCard.transform));//自画面でのアタックモーション　1S
                if(GameManager.instance.IsOnlineBattle == true)
                {
                    photonView.RPC(nameof(RPCAttackMotion), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面のアタックモーション1S
                }
                yield return new WaitForSeconds(1.1f);

                if(GameManager.instance.IsOnlineBattle == true)
                {
                    photonView.RPC(nameof(RPCattackwinBattle), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面での破壊
                }
                
                attackCard.model.canAttack = false;     
                attackCard.view.SetCanAttackPanel(false); 
                
                StartCoroutine(defenceCard.DestroyCard(defenceCard));
            }

            // 攻撃された側のパワーが高かった場合、攻撃側のカードを破壊する
            else if (attackCard.model.power < defenceCard.model.power)
            {
                StartCoroutine (attackCard.Battlemovement.PlayerAttackMotion(defenceCard.transform));//自画面のアタックモーション
                if(GameManager.instance.IsOnlineBattle == true)
                {
                    photonView.RPC(nameof(RPCAttackMotion), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面のアタックモーション
                }
                yield return new WaitForSeconds(1.1f);
                
                if(GameManager.instance.IsOnlineBattle == true)
                {
                    photonView.RPC(nameof(RPCattackloseBattle), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面での破壊
                }
                
                attackCard.model.canAttack = false;     
                attackCard.view.SetCanAttackPanel(false); 
                
                StartCoroutine(attackCard.DestroyCard(attackCard));
            }

            // パワーが同じだった場合、両方のカードを破壊する
            else if (attackCard.model.power == defenceCard.model.power)
            {
                //自画面でのアタックモーションはDragを終えた地点がtransformParentになってしまい元の位置に戻らない
                StartCoroutine (attackCard.Battlemovement.PlayerAttackMotion(defenceCard.transform));//自画面でのアタックモーション
                if(GameManager.instance.IsOnlineBattle == true)
                {
                    photonView.RPC(nameof(RPCAttackMotion), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面のアタックモーション
                }
                yield return new WaitForSeconds(1.1f);
                
                if(GameManager.instance.IsOnlineBattle == true)
                {
                    photonView.RPC(nameof(RPCdrawBattle), RpcTarget.Others, attackCard.model.playerNumberth, defenceCard.model.enemyNumberth);//敵画面での破壊
                }
                
                attackCard.model.canAttack = false;     
                attackCard.view.SetCanAttackPanel(false); 

                //両方破壊
                StartCoroutine(attackCard.DestroyCard(attackCard));
                StartCoroutine(defenceCard.DestroyCard(defenceCard));
            }
        }

        if (attackCard.model.PlayerCard)
        {
            //SoundManager.instance.PlaySE(1); // 攻撃時の音を鳴らす
        }
        attackCard.model.canAttack = false;     
        attackCard.view.SetCanAttackPanel(false);  
        SetCanUsePanelHand(true); //制限解除
    }

    /// <summary>
    /// フィールドカードの攻撃可否フラグを一括設定する
    /// </summary>
    void SetAttackableFieldCard(CardController[] cardList, bool canAttack)
    {
        foreach (CardController card in cardList)
        {
            card.model.canAttack = canAttack;
            card.view.SetCanAttackPanel(canAttack);
        }
    }


    /// <summary>
    /// リーダーへの攻撃処理
    /// </summary>
    public IEnumerator AttackToLeader(CardController attackCard, bool isPlayerCard)
    {
        if (attackCard.model.canAttack == false)
        {
            yield break;;
        }

       SetCanUsePanelHand(false);//攻撃中は手札を使用不可能にする
       

        //enemyLeaderHP -= attackCard.model.power; // コメントアウトする

        attackCard.model.canAttack = false;
        attackCard.view.SetCanAttackPanel(false);

        StartCoroutine(attackCard.Battlemovement.PlayerAttackMotion(enemyLeaderTransform));//RPCとモーション
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCAttackLeaderMotion), RpcTarget.Others, attackCard.model.playerNumberth);//敵画面のアタックモーション
        }
        yield return new WaitForSeconds(1.1f);
        Debug.Log("敵のHPは、" + enemyLeaderHP);

        if (attackCard.model.PlayerCard == true) // attackCardがプレイヤーのカードなら
        {
            //SoundManager.instance.PlaySE(1); // 攻撃時の音を鳴らす
            enemyLeaderHP -= attackCard.model.power; // 敵のリーダーのHPを減らす
        }
        else // attackCardが敵のカードなら
        {
            playerLeaderHP -= attackCard.model.power; // プレイヤーのリーダーのHPを減らす
        } 
        Debug.Log("敵のHPは、" + enemyLeaderHP);
        ShowLeaderHP();
        SetCanUsePanelHand(true);//制限解除
    }

    /// <summary>
    /// リーダーHPを更新表示し、ゲーム終了判定を行う
    /// </summary>
    public void ShowLeaderHP()
    {
        if (playerLeaderHP <= 0)
        {
            playerLeaderHP = 0;
            uIManager.ShowGameEndPanel(false);// 敗北
            BattleBgmManager.SetActive(false);//BGM停止
            StopAllCoroutines();
            
        }
        if (enemyLeaderHP <= 0)
        {
            enemyLeaderHP = 0;
            uIManager.ShowGameEndPanel(true);// 勝利
            BattleBgmManager.SetActive(false);//BGM停止
            StopAllCoroutines();
            
        }

        playerLeaderHPText.text = playerLeaderHP.ToString();
        enemyLeaderHPText.text = enemyLeaderHP.ToString();
        // HP同期
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCSendHP), RpcTarget.Others, playerLeaderHP, enemyLeaderHP);
        }
    }

    /// <summary>
    /// 再戦処理。盤面をリセットして再開する
    /// </summary>
    public void RestartGame()
    {
        SoundManager.instance.PlaySE(17);
        foreach (Transform n in playerHand.transform)// Playerの手札のカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform n in enemyHand.transform)// 敵の手札のカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
            Debug.Log("手札破壊:");
        }
        foreach (Transform n in playerField.transform)// Playerのフィールドのカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform n in enemyField.transform)// Enemyのフィールドのカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }    
        
        //UIリセットとフラグの初期化
        RestartButton.interactable = false;
        GameStart = false;
        uIManager.HideResultPanel();
        uIManager.WaitMessage();
        playerRetryReady = true;
        EnemyMulliganFinished = false;

        if (GameManager.instance.IsOnlineBattle)
        {
            // オンライン対戦の再戦処理
            if(GameManager.instance.IsOnlineBattle == true)
            {
                SendRetryMessage();// 再戦希望を送信
            }

            // 双方が準備完了ならリスタート
            if (playerRetryReady && enemyRetryReady)
            {   
                RestartButton.interactable = true;
                uIManager.HideGameEndPanel();
                StartCoroutine(StartGame());
            }
        }
        else
        {
            // CPU対戦（オフライン）の再戦処理
            uIManager.HideGameEndPanel();
            StartCoroutine(StartGame());
        }
        //SceneTransitionManager.instance.Load("Battle");
        
    }

    /// <summary>
    /// ホーム画面へ戻る処理
    /// </summary>
    public void BackHomeButtom()
    {
        SoundManager.instance.PlaySE(17);
        foreach (Transform n in playerHand.transform)// Playerの手札のカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform n in enemyHand.transform)// 敵の手札のカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform n in playerField.transform)// Playerのフィールドのカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform n in enemyField.transform)// Enemyのフィールドのカードを全て破壊する
        {
            GameObject.Destroy(n.gameObject);
        }
        /*isPlayerTurn = true; // 敵ターンだった場合に、リスタート後に敵ターンから始まってしまう為
        if(turnEndButton.interactable == false)
        {
            turnEndButton.interactable = !turnEndButton.interactable;
        }*/

        // UIリセット
        uIManager.HideGameEndPanel();
        uIManager.HideLeftPlayerPanel();
        uIManager.HideResultPanel();
        uIManager.CloseGearPanel();


        // ルーム退出
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
        }
        GameStart = false;
        SceneTransitionManager.instance.Load("Home");
        
    }

    // --- じゃんけん関連処理 ---

    /// <summary>
    /// プレイヤーのじゃんけんボタンを押したとき
    /// </summary>
    public void PlayerHandButton(int PlayerjHand)
    {
        SoundManager.instance.PlaySE(17);
        PlayerJanken=PlayerjHand;
        uIManager.HideP2JankenPanel(PlayerjHand);// 選んだ手以外を非表示
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCSendJanken), RpcTarget.Others,PlayerjHand);
        }
    }
    public void EnemyHandButton(int EnemyjHand)//敵のじゃんけんボタンを押したとき
    {
        EnemyJanken=EnemyjHand;
        uIManager.HideE2JankenPanel(EnemyjHand);
    }

    /// <summary>
    /// じゃんけんの勝敗判定ロジック
    /// </summary>
    public void JankenBattle(int PlayerJanken,int EnemyJanken)
    {
        // グー(1) - チョキ(2) = -1 (勝)
        // チョキ(2) - パー(3) = -1 (勝)
        // パー(3) - グー(1) = 2 (勝)

        // グー(1) - パー(3) = -2 (負)
        // チョキ(2) - グー(1) = 1 (負)
        // パー(3) - チョキ(2) = 1 (負)

        if(PlayerJanken-EnemyJanken==-1 || PlayerJanken-EnemyJanken==2)//playerWIN
        {
            PlayerResult=1;// Win
            EnemyResult=2;// Lose
        }
        else if(PlayerJanken-EnemyJanken==1 || PlayerJanken-EnemyJanken==-2)//EnemyWIN
        {
            PlayerResult=2;// Lose
            EnemyResult=1;// Win
        }
        else//あいこ
        {
            PlayerResult=3;// Draw
            EnemyResult=3;// Draw
        }
    }

    /// <summary>
    /// ターン開始時のじゃんけんフェイズを実行するコルーチン
    /// </summary>
    public IEnumerator JankenProcess()
    {
        if (isPlayerTurn == true) // じゃんけん終わるまで押せないように,相手ターンなら元々OFF
        {
            turnEndButton.interactable = false;
            SetCanUsePanelHand(false);
        }
        //yield return null;
        PlayerJanken=0;//プレイヤーのじゃんけんの手の初期化
        EnemyJanken=0;//敵プレイヤーのじゃんけんの手の初期化
        uIManager.ShowJankenPanel();

        // オフライン時は敵のじゃんけん手を自動選択
        if (GameManager.instance.IsOnlineBattle == false)
        {
            EnemyJanken = GetBestCPUJankenHand();
            uIManager.HideE2JankenPanel(EnemyJanken);
        }

        //両者ともにじゃんけんボタンが押されるまで待機
        yield return new WaitUntil(() => PlayerJanken!=0 & EnemyJanken!=0);
        yield return null;
        uIManager.EHidePanel(EnemyJanken);// 相手の手を表示
        
        JankenBattle(PlayerJanken,EnemyJanken);//じゃんけん判定
        
        yield return new WaitForSeconds(2f);
        uIManager.HideAllJankenPanel();
        yield return null;

        //Resultを表示する
        uIManager.PlayerResultPanel(PlayerJanken);
        uIManager.EnemyResultPanel(EnemyJanken);

        if (isPlayerTurn == true) // じゃんけん終わるまで押せないように,相手ターンなら元々OFF
        {
            turnEndButton.interactable = true;
            SetCanUsePanelHand(true);

            // じゃんけん結果に応じたコストダウン処理
            //手札のカードリストを取得
            CardController[] playerHandCardList = playerHand.GetComponentsInChildren<CardController>();

            foreach (CardController card in playerHandCardList)
            {
                card.CostDown();
            }

            SetCanUsePanelHand(true);
        }
        else if (isPlayerTurn == false && GameManager.instance.IsOnlineBattle == false)
        {
            // じゃんけん結果に応じたコストダウン処理
            //手札のカードリストを取得
            CardController[] enemyHandCardList = enemyHand.GetComponentsInChildren<CardController>();

            foreach (CardController card in enemyHandCardList)
            {
                card.CostDown();
            }
        }
    }

    // --- 通信同期用RPCメソッド群 ---

    /// <summary>
    /// プレイヤーがカードを場に出した情報を相手に送信
    /// </summary>
    public void SendPlayerCard(int cardID,int playerNumberth)
    {
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCOnRecievedCard), RpcTarget.Others, cardID, playerNumberth);
        }
    }
    /// <summary>
    /// 手札生成通知
    /// </summary>
    public void CreateEnemyCard()
    {
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCCreateEnemyHand), RpcTarget.Others);
        }
    }
    /// <summary>
    /// 手札使用通知
    /// </summary>
    public void RemoveEnemyHand()//手札
    {
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCRemoveEnemyHand), RpcTarget.Others);
        }
        else
        {
            Debug.Log("エネミー手札破壊:");
            if (enemyHand.transform.childCount > 0) 
            {
                Transform firstChild = enemyHand.transform.GetChild(0);
                GameObject.Destroy(firstChild.gameObject);
            }
        }
    }
    /// <summary>
    /// ランダム破壊同期
    /// </summary>
    public void DestroyRamdomJan(int ENumberth)
    {
        if(GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(RPCdestroyjan), RpcTarget.Others, ENumberth);//選択したカードの敵画面での破壊
        }
    }


    // 以下、受信側(Others)で実行されるRPC

    [PunRPC]
    void RPCOnRecievedCard(int cardID,int playerNumberth)
    {
        // 相手画面ではEnemyFieldに生成
        CardController card = Instantiate(cardPrefab, enemyField);
        card.EnemyInit(cardID, false, playerNumberth);
        card.model.FieldCard = true;
        card.CostDown();
        StartCoroutine(card.activateAbility());
        //view.Show(model);
    }

    //void RPCBattleCard(CardController card)
    //{
        //card.DestroyCard(card);
    //}
    [PunRPC]
    void RPCCreateEnemyHand()//自分の手札生成を相手の画面のenemyhandと同期
    {   
        //CardController[] EnemyHandCardList = enemyHand.GetComponentsInChildren<CardController>();
        Instantiate(EnemyHandCard, enemyHand);// 裏面カードを生成
        
        
    }

    [PunRPC]
    void RPCRemoveEnemyHand()//自分の手札破壊を相手の画面のenemyhandと同期
    {
        if (enemyHand.transform.childCount > 0) 
        {
            Transform firstChild = enemyHand.transform.GetChild(0);
            GameObject.Destroy(firstChild.gameObject);
        }
    }
    /*
    void RPCCreateEnemyField(int cardID)//自分のフィールドを相手の画面のenemyfieldと同期
    {
        CardController card = Instantiate(cardPrefab, enemyField);
        card.PlayerInit(cardID, false);
    }
    void RPCCreatePlayerHand(int cardID)//相手の手札をこちら側で変化させたときの同期(生成)
    {
        CardController card = Instantiate(cardPrefab, playerHand);
        card.PlayerInit(cardID, true);
    }
    void RPCCreatePlayerField(int cardID)//相手のフィールドをこちら側で変化させたときの同期(生成)
    {
        CardController card = Instantiate(cardPrefab, playerField);
        card.PlayerInit(cardID, true);
    }
    */
    // カードが破壊される際に、PUN2を使用して識別子を伝達する
    

    /// <summary>
    /// アタックが勝つ、ディフェンス破壊
    /// </summary>
    [PunRPC]
    void RPCattackwinBattle(int PNumberth/*アタックしたカード*/, int ENumberth/*アタックされたカード*/)
    {   
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        
        
        // 条件を満たすカードを格納する変数
        GameObject card1 = null;
        GameObject card2 = null;

        // 条件を満たすカードを探す
        foreach (GameObject card in cards)
        {
            // ID照合で対象カードを特定
            if (card.GetComponent<CardController>().model.PlayerCard == false && card.GetComponent<CardController>().model.enemyNumberth == PNumberth)//アタックしたカードの固有IDと一致するエネミーカード(相手画面)をみつける
            {
                card1 = card; // 条件1を満たすカード
            }
            else if (card.GetComponent<CardController>().model.PlayerCard == true && card.GetComponent<CardController>().model.playerNumberth == ENumberth)//アタックされたカードの固有IDと一致するプレイヤーカード(相手画面)をみつける
            {
                card2 = card; // 条件2を満たすカード
            }

            // 条件1と条件2の両方のカードが見つかった場合に処理を行う
            if (card1 != null && card2 != null)
            {
                // コルーチンを開始し、攻撃アニメーションを実行
                //StartCoroutine(card1.GetComponent<CardController>().Battlemovement.AttackMotion(card2.GetComponent<CardController>().transform));//モーション
                
                // カード2を破壊
                

                StartCoroutine(card2.GetComponent<CardController>().DestroyCard(card2.GetComponent<CardController>()));

                // これ以上ループを続ける必要がないので break
                break;
            }
        }
    }
    
    /// <summary>
    /// アタックが負ける、アタック側破壊
    /// </summary>
    [PunRPC]
    void RPCattackloseBattle(int PNumberth/*アタックしたカード*/, int ENumberth/*アタックされたカード*/)//アタックが負ける、破壊
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        //CardController[] cards = new CardController[cardObjects.Length];
        
        
        // 条件を満たすカードを格納する変数
        GameObject card1 = null;
        GameObject card2 = null;

        // 条件を満たすカードを探す
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<CardController>().model.PlayerCard == false && card.GetComponent<CardController>().model.enemyNumberth == PNumberth)//アタックしたカードの固有IDと一致するエネミーカード(相手画面)をみつける
            {
                card1 = card; // 条件1を満たすカード
            }
            else if (card.GetComponent<CardController>().model.PlayerCard == true && card.GetComponent<CardController>().model.playerNumberth == ENumberth)//アタックされたカードの固有IDと一致するプレイヤーカード(相手画面)をみつける
            {
                card2 = card; // 条件2を満たすカード
            }

            // 条件1と条件2の両方のカードが見つかった場合に処理を行う
            if (card1 != null && card2 != null)
            {
                // コルーチンを開始し、攻撃アニメーションを実行
                //StartCoroutine(card1.GetComponent<CardController>().Battlemovement.AttackMotion(card2.GetComponent<CardController>().transform));//モーション
                
                // カード1を破壊
                StartCoroutine(card1.GetComponent<CardController>().DestroyCard(card1.GetComponent<CardController>()));

                // これ以上ループを続ける必要がないので break
                break;
            }
        }
        /*
        Debug.Log("破壊する側:"+ENumberth);
        Debug.Log("破壊される側:"+PNumberth);
        Debug.Log("破壊される側:"+atkCard.GetComponent<CardController>().model.enemyNumberth);
        Debug.Log("どっち:" + atkCard.GetComponent<CardController>().model.PlayerCard +"/名前:"+atkCard.GetComponent<CardController>().model.name+"/破壊される側::"+atkCard.GetComponent<CardController>().model.enemyNumberth);
        */
    }

    /// <summary>
    /// 攻撃モーションのみ
    /// </summary>
    [PunRPC]
    void RPCAttackMotion(int PNumberth/*アタックしたカード*/, int ENumberth/*アタックされたカード*/)//モーションのみ
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        //CardController[] cards = new CardController[cardObjects.Length];
        
        
        // 条件を満たすカードを格納する変数
        GameObject card1 = null;
        GameObject card2 = null;

        // 条件を満たすカードを探す
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<CardController>().model.PlayerCard == false && card.GetComponent<CardController>().model.enemyNumberth == PNumberth)//アタックしたカードの固有IDと一致するエネミーカード(相手画面)をみつける
            {
                card1 = card; // 条件1を満たすカード
                card.GetComponent<CardController>().model.canAttack = false;     
                card.GetComponent<CardController>().view.SetCanAttackPanel(false);
            }
            else if (card.GetComponent<CardController>().model.PlayerCard == true && card.GetComponent<CardController>().model.playerNumberth == ENumberth)//アタックされたカードの固有IDと一致するプレイヤーカード(相手画面)をみつける
            {
                card2 = card; // 条件2を満たすカード
            }

            // 条件1と条件2の両方のカードが見つかった場合に処理を行う
            if (card1 != null && card2 != null)
            {
                // コルーチンを開始し、攻撃アニメーションを実行
                StartCoroutine(card1.GetComponent<CardController>().Battlemovement.AttackMotion(card2.GetComponent<CardController>().transform));//モーション

                // カードを破壊しない
                

                // これ以上ループを続ける必要がないので break
                break;
            }
        }
        /*
        Debug.Log("破壊する側:"+ENumberth);
        Debug.Log("破壊される側:"+PNumberth);
        Debug.Log("破壊される側:"+atkCard.GetComponent<CardController>().model.enemyNumberth);
        Debug.Log("どっち:" + atkCard.GetComponent<CardController>().model.PlayerCard +"/名前:"+atkCard.GetComponent<CardController>().model.name+"/破壊される側::"+atkCard.GetComponent<CardController>().model.enemyNumberth);
        */
    }
    /// <summary>
    /// リーダー攻撃モーション同期
    /// </summary>
    [PunRPC]
    void RPCAttackLeaderMotion(int PNumberth/*アタックしたカード*/)
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        //CardController[] cards = new CardController[cardObjects.Length];
        // 条件を満たすカードを格納する変数
        // 条件を満たすカードを探す
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<CardController>().model.PlayerCard == false && card.GetComponent<CardController>().model.enemyNumberth == PNumberth)//アタックしたカードの固有IDと一致するエネミーカード(相手画面)をみつける
            {
                
                card.GetComponent<CardController>().model.canAttack = false;     
                card.GetComponent<CardController>().view.SetCanAttackPanel(false);
                // コルーチンを開始し、攻撃アニメーションを実行
                StartCoroutine(card.GetComponent<CardController>().Battlemovement.AttackMotion(playerLeaderTransform));//モーション
                // カードを破壊しない
                // これ以上ループを続ける必要がないので break
                break;
            }
            
                
            
        }
    }

    /// <summary>
    /// 相打ち
    /// </summary>
    [PunRPC]
    void RPCdrawBattle(int PNumberth/*アタックしたカード*/, int ENumberth/*アタックされたカード*/)
    {   
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        
        
        // 条件を満たすカードを格納する変数
        GameObject card1 = null;
        GameObject card2 = null;

        // 条件を満たすカードを探す
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<CardController>().model.PlayerCard == false && card.GetComponent<CardController>().model.enemyNumberth == PNumberth)//アタックしたカードの固有IDと一致するエネミーカード(相手画面)をみつける
            {
                card1 = card; // 条件1を満たすカード
            }
            else if (card.GetComponent<CardController>().model.PlayerCard == true && card.GetComponent<CardController>().model.playerNumberth == ENumberth)//アタックされたカードの固有IDと一致するプレイヤーカード(相手画面)をみつける
            {
                card2 = card; // 条件2を満たすカード
            }

            // 条件1と条件2の両方のカードが見つかった場合に処理を行う
            if (card1 != null && card2 != null)
            {
                // コルーチンを開始し、攻撃アニメーションを実行
                //StartCoroutine(card1.GetComponent<CardController>().Battlemovement.AttackMotion(card2.GetComponent<CardController>().transform));//モーション
                
                // カード1,2を破壊
                StartCoroutine(card1.GetComponent<CardController>().DestroyCard(card1.GetComponent<CardController>()));
                StartCoroutine(card2.GetComponent<CardController>().DestroyCard(card2.GetComponent<CardController>()));
                // これ以上ループを続ける必要がないので break
                break;
            }
        }
    }

    /// <summary>
    /// 先攻後攻の決定通知
    /// </summary>
    [PunRPC]
    void RPCTurnDecision(bool MasterTurn)
    {
        if(MasterTurn == true)//クライアントマスターのisPlayerTurn==trueなら
        {
            isPlayerTurn = false;//後攻
            turnEndButton.interactable = false;
            SetCanUsePanelHand(false); // 手札のカードを使用不可にする
 
            SoundManager.instance.PlaySE(0);
        }
        else//クライアントマスターのisPlayerTurn==falseなら
        {
            isPlayerTurn = true;//先攻
            turnEndButton.interactable = true;
        }
        GameStart = true;
    }

    /// <summary>
    /// ターン変更通知
    /// </summary>
    [PunRPC]
    void RPCChangeTurn()
    {
        if (isPlayerTurn == false)
        {
            CardController[] enemyFieldCardList = enemyField.GetComponentsInChildren<CardController>();
            SetAttackableFieldCard(enemyFieldCardList,false); // エネミーの場のカードを攻撃不可にする
            //SetCanUsePanelHand(false); // 手札のカードを使用不可にする、敵の手札をoffにする必要はない
            CostBackOrigin();
            SoundManager.instance.PlaySE(0);
        }
        // ターンエンドボタンを押下可能/不可能にする
        turnEndButton.interactable = !turnEndButton.interactable;

        isPlayerTurn = !isPlayerTurn; // ターンを逆にする
        StartCoroutine(TurnCalc()); // ターンを相手に回す
    }

    /// <summary>
    /// じゃんけんの手を受信
    /// </summary>
    [PunRPC]
    void RPCSendJanken(int PlayerjHand)
    {
        EnemyJanken=PlayerjHand;//P2のエネミーじゃんけんをP1の押したじゃんけんにする
        uIManager.HideE2JankenPanel(PlayerjHand);
    }

    /// <summary>
    /// HP同期
    /// </summary>
    [PunRPC]
    void RPCSendHP(int pLeaderHP,int eLeaderHP)
    {
        playerLeaderHP = eLeaderHP;
        enemyLeaderHP = pLeaderHP;
        playerLeaderHPText.text = eLeaderHP.ToString();
        enemyLeaderHPText.text = pLeaderHP.ToString();
        if (playerLeaderHP <= 0)
        {
            playerLeaderHP = 0;
            uIManager.ShowGameEndPanel(false);
            BattleBgmManager.SetActive(false);
            StopAllCoroutines();
        }
        if (enemyLeaderHP <= 0)
        {
            enemyLeaderHP = 0;
            uIManager.ShowGameEndPanel(true);
            BattleBgmManager.SetActive(false);
            StopAllCoroutines();
        }
    }

    /// <summary>
    /// 相手が退出した際の処理
    /// </summary>
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (GameManager.instance.IsOnlineBattle)
        {
            uIManager.ShowLeftPlayerPanel();
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LeaveRoom();
                PhotonNetwork.Disconnect();
            }
        }
    }

    /// <summary>
    /// リトライメッセージを送信:retryを押した方
    /// </summary>
    void SendRetryMessage()
    {
        if (GameManager.instance.IsOnlineBattle == true)
        {
            photonView.RPC(nameof(OnRecieveRetryMessage), RpcTarget.Others);
        }
    }

    /// <summary>
    /// リトライメッセージ受け取った時に実行
    /// </summary>
    [PunRPC]
    void OnRecieveRetryMessage()
    {
        enemyRetryReady = true;
        if (playerRetryReady)
        {   
            RestartButton.interactable = true;
            uIManager.HideGameEndPanel();
            Debug.Log("enemyRetryReady:"+enemyRetryReady);
            Debug.Log("playerRetryReady:"+playerRetryReady);
            StartCoroutine(StartGame());
            //SceneManager.LoadScene("Battle", LoadSceneMode.Single);
        }
        else
        {
            uIManager.ShowRetryMessage();
            
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [PunRPC]
    void RPCRestart()
    {
        SceneTransitionManager.instance.Load("Battle");
    }

    /// <summary>
    /// マナポイントを表示するメソッド
    /// </summary>
    [PunRPC]
    public void ShowEnemyManaPoint(int pManaPoint,int pDefaultManaPoint) 
    {
        enemyManaPointText.text = pManaPoint.ToString();
        enemyDefaultManaPointText.text = pDefaultManaPoint.ToString();
        enemyManaPoint = pManaPoint;
        enemyDefaultManaPoint = pDefaultManaPoint;

    }

    /// <summary>
    /// 条件に合うカードを破壊
    /// </summary>
    [PunRPC]
    void RPCdestroyjan(int ENumberth)
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<CardController>().model.PlayerCard == true && card.GetComponent<CardController>().model.playerNumberth == ENumberth)//破壊されたカード固有IDと一致するプレイヤーカード(相手画面)をみつける
            {
                Destroy(card);
                SoundManager.instance.PlaySE(12);
            }
        }
    }

    /// <summary>
    /// マリガン完了通知
    /// </summary>
    [PunRPC]
    void RPCMulliganBool()
    {
        EnemyMulliganFinished = true;
    }

    /// <summary>
    /// 相手の手札のじゃんけん属性の数を反映
    /// </summary>
    [PunRPC]
    void RPCShowJankenCount(int GCount,int CCount,int PCount)
    {
        enemyGText.text = GCount.ToString();
        enemyCText.text = CCount.ToString();
        enemyPText.text = PCount.ToString();
    }

}
    /*
    [PunRPC]
    void RPCEnemyDeckList(List<int> EnemyDeckList)//相手に自分のデッキリストを与える.EnemyDeckListは与える自分のデッキリスト
    {
        Enemydeck = EnemyDeckList;
        foreach(int Id in Enemydeck){
            
        }
    }*/



