using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

////// <summary> </summary>

/// <summary>
/// カード個別の制御クラス。
/// カードデータの保持、移動処理、効果発動ロジックなどを管理する。
/// </summary>
public class CardController : MonoBehaviourPunCallbacks

{   
    /// <summary> カードの見た目の処理 </summary>
    public CardView view; 

    /// <summary> カードのデータを処理 </summary>
    public CardModel model; 

    /// <summary> カードの動きを処理（ドラッグ等） </summary>
    public CardMovement movement; 

    /// <summary> バトル中のカードの動きを処理 </summary>
    public BattleCardMovement Battlemovement;

    /// <summary> 1ゲーム内でのカード識別用の一意なID（プレイヤー側） </summary>
    public static int PlayerNumberth=0;
    //public static int EnemyNumberth=0;

    public bool destroycards = false;//カード破壊時音声のためのフラグ
    
    private void Awake()//
    {   
        view = GetComponent<CardView>();//
        movement = GetComponent<CardMovement>();//
        Battlemovement = GetComponent<BattleCardMovement>();
    }

    /// <summary>
    /// カード生成時の初期化（一般用）
    /// </summary>
    public void Init(int cardId, bool playerCard) 
    {
        model = new CardModel(cardId, playerCard); // カードデータを生成
        view.Show(model);// 表示
        Debug.Log("生成:");

    }

    /// <summary>
    /// プレイヤーカード生成時の初期化
    /// </summary>
    public void PlayerInit(int cardId, bool playerCard)
    {
        //nextcardid += 1;
        model = new CardModel(cardId, playerCard); // カードデータを生成
        //if(playerCard==true)
        //{
        model.playerNumberth = PlayerNumberth;//固有IDをつける（同期用）
        
        //}
        //else
        //{
            //model.nextcardid = nextcardid;
        //}
        
        view.Show(model);// 表示
        CostDown();// コスト計算
        PlayerNumberth += 1;// IDインクリメント
        Debug.Log("どっち:" + model.PlayerCard +"/名前:"+model.name+"/固有id:"+model.playerNumberth);
        
    }

    /// <summary>
    /// 敵カード生成時の初期化（RPC用）,敵に自分のカードを生成したいRPCで呼び出す関数
    /// </summary>
    public void EnemyInit(int cardId, bool playerCard,int PNumberth/*model.playerNumberthがはいる*/) 
    {
        model = new CardModel(cardId, playerCard);
        view.Show(model);
        model.enemyNumberth=PNumberth;// 相手側のIDを保持
        Debug.Log("どっち:" + model.PlayerCard +"/名前:"+model.name+"/固有id:"+model.enemyNumberth);
    }

    /// <summary>
    /// カード破壊処理
    /// </summary>
    public IEnumerator DestroyCard(CardController card)//
    {   
        card.view.SetDestoroyPanel();// 破壊エフェクト表示                
        yield return new WaitForSeconds(0.5f);
        Destroy(card.gameObject);
    }
    //public void DestroyOtherCard(int nextcardid)//
    //{   
       // GameObject RPCcard = GameObject.Find(nextcardid); // nextidが一致するオブジェクトを取得
        //Destroy(card.gameObject);
    //}




    public void ScaleCard(float scaleNum) // CardDetailPanelで使用、カードの大きさを変える
    {
        transform.localScale = new Vector3(scaleNum, scaleNum, 0);
    }

    /// <summary>
    /// カードがフィールドにドロップされた時の処理
    /// </summary>
    public void DropField()
    {    
        BattleManager.instance.ReduceManaPoint(model.cost);// マナ消費
        model.FieldCard = true; // フィールドのカードのフラグを立てる
        model.canUse = false;

        // 相手にカード生成を通知
        BattleManager.instance.SendPlayerCard(model.cardId,model.playerNumberth);
        BattleManager.instance.RemoveEnemyHand();// 相手の手札枚数表示を減らす
        BattleManager.instance.CountHandJanken();// じゃんけんカウント更新

        view.SetCanUsePanel(model.canUse); // 出した時にCanUsePanelを消す
        StartCoroutine(activateAbility()); // 効果発動
    }

    /// <summary>
    /// カードがマリガンフィールドにドロップされた時の処理
    /// </summary>
    public void DropMulliganField()  
    {
        BattleManager.instance.RemoveEnemyHand();
        model.canUse = false;
        view.SetCanUsePanel(model.canUse); // 出した時にCanUsePanelを消す
    }

    public IEnumerator StartCardMotion()//召喚時とスペル使用時の演出
    {
        switch (model.cardType)
        {
            case CardType.Monster:
                yield return StartCoroutine(Battlemovement.SummonMotion());
                break;

            case CardType.Spell:
                yield return StartCoroutine(Battlemovement.UseSpellMotion());
                break;
        }
    }

    /// <summary>
    /// じゃんけん結果に基づいてコストダウン判定を行う
    /// </summary>
    public void CostDown()
    {
        if (BattleManager.instance.isPlayerTurn == true)
        {
            // 自分のターン、じゃんけんの手とカードの手が一致、かつ勝利している場合
            if(BattleManager.PlayerJanken == model.janken && BattleManager.PlayerResult == 1)
            {
                model.cost--;   // コスト-1
                model.isCostDown = true;
            }
        }
        else //相手ターン(あいてのカード)
        {
            if(BattleManager.EnemyJanken == model.janken && BattleManager.EnemyResult == 1)
            {
                model.cost--;
                model.isCostDown = true;
            }
        }

        view.Show(model);// UI更新
    }
    
    /// <summary>
    /// カードの効果発動処理。
    /// 非常に多岐にわたる効果（ドロー、召喚、バフ、ダメージなど）をフラグに応じて処理する。
    /// </summary>
    public  IEnumerator activateAbility()
    {
        
        // 相手のactivateAbility()で発動しないように,自分のターンなら操作をロック
        if (BattleManager.instance.isPlayerTurn == true) 
        {
            BattleManager.instance.turnEndButton.interactable = false;
            BattleManager.instance.SetCanUsePanelHand(false);
        }
        // カード使用時のモーションを実行する
        yield return StartCoroutine(StartCardMotion());
        
        // スピードアタッカーなら攻撃可能にする
        if (model.isSpeedAttacker)
        {
                model.canAttack = true;
                SoundManager.instance.PlaySE(9);
                view.SetCanAttackPanel(true);
        }

        // ドローする枚数が1枚以上なら、その回数分カードを引く
        if (model.drawCardNum >= 1)
        {
            for (int i = 0; i < model.drawCardNum; i++)
            {
                if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                {
                    Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                    
                    BattleManager.instance.DrawCard(playerHand);
                }
            }
        }

        // 手札に加えるトークンカードのリストが1つ以上なら、そのリストの1番目から順番に手札に生成する
        if (model.addCardsList.Length >= 1) // リストの存在チェック
        {
            if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
            {
                for (int i = 0; i < model.addCardsList.Length; i++) // リストの個数分処理を繰り返す
                {
                
                Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();

                if (playerHand.GetComponentsInChildren<CardController>().Length < 6)//手札が六枚未満なら
                {
                    SoundManager.instance.PlaySE(7);
                    BattleManager.instance.CreateCard(model.addCardsList[i], playerHand); // リストの[i]番目のカードを手札に作る
                    yield return new WaitForSeconds(0.25f);
                }

                } 
            }
        }

        // 召喚するトークンカードのリストが1つ以上なら、そのリストの1番目から順番にフィールドに生成する
        if (model.summonCardsList.Length >= 1)
        {
                if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                {
                    for (int i = 0; i < model.summonCardsList.Length; i++)
                    {
                        yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], true));
                    }
                }
                /*else
                {
                    for (int i = 0; i < model.summonCardsList.Length; i++)
                    {
                        yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], false));
                    }
                }*/
        }

        // 自分リーダーのライフを変化
        if (model.chgMyLeaderHpNum != 0)
        {
            if (model.chgMyLeaderHpNum>0)
            {
                SoundManager.instance.PlaySE(4);
            }
            else
            {
                SoundManager.instance.PlaySE(5);
            }

            if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
            {
                BattleManager.instance.playerLeaderHP += model.chgMyLeaderHpNum;
                BattleManager.instance.ShowLeaderHP();
            }
            /*else//ライフの同期はshowHP側でやっている
            {
                BattleManager.instance.enemyLeaderHP += model.chgMyLeaderHpNum;
                BattleManager.instance.ShowLeaderHP();
            }*/
        }

        // 相手リーダーのライフを変化
        if (model.chgEnemyLeaderHpNum != 0)
        {   
            if (model.chgMyLeaderHpNum>0)
            {
                SoundManager.instance.PlaySE(4);
            }
            else
            {
                SoundManager.instance.PlaySE(5);
            }

            if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
            {
                BattleManager.instance.enemyLeaderHP += model.chgEnemyLeaderHpNum;
                BattleManager.instance.ShowLeaderHP();
            }
            /*else//ライフの同期はshowHP側でやっている
            {
                BattleManager.instance.playerLeaderHP += model.chgEnemyLeaderHpNum;
                BattleManager.instance.ShowLeaderHP();
            }*/
        }

        // マナポイントを増加
        if (model.manaBoostNum >= 1)
        {   
            if (BattleManager.instance.isPlayerTurn == true)
            {
                if( BattleManager.instance.playerDefaultManaPoint <= 9)
                {
                    BattleManager.instance.playerDefaultManaPoint += model.manaBoostNum;
                }
                BattleManager.instance.ShowManaPoint();
            }
            SoundManager.instance.PlaySE(11);
        }

        

        //強制じゃんけんスタート
        if(model.jankenstart == true)
        {
            BattleManager.instance.PlayerCardCostBackOrigin();
            yield return StartCoroutine(BattleManager.instance.JankenProcess());
            
        }

        // --- 条件付き効果判定 ---

        //じゃんけんに勝っているときに発動する効果

        if(model.specificHand == false)//勝ちのみ、出した手とじゃんけん属性が一致していない。
        {
            if(model.janwinpower != 0)//じゃんけん勝ってればパワーアップ
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 1)//勝ってれば
                    {
                        model.power += model.janwinpower;
                        view.Show(model);
                        SoundManager.instance.PlaySE(8);
                    }
                }
                else 
                {
                    if(BattleManager.EnemyResult == 1)//敵が勝ってれば
                    {
                        model.power += model.janwinpower;
                        view.Show(model);
                        SoundManager.instance.PlaySE(8);
                    }
                }
                
            }

            //じゃんけん勝ってればスピードアタッカー
            if(model.janwinspeed == true)//
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 1)//勝ってれば
                    {
                        
                        model.canAttack = true;
                        SoundManager.instance.PlaySE(9);
                        view.SetCanAttackPanel(true);
                    
                    }
                }
                else //相手ターン(あいてのカード)
                {
                    if(BattleManager.EnemyResult == 1)
                    {
                        model.canAttack = true;
                        SoundManager.instance.PlaySE(9);
                        view.SetCanAttackPanel(true);
                    }
                }
                
            }

            //じゃんけん勝ってれば自分のライフ変化
            if(model.janwinPHp != 0)//ライフの変化が０でなければ
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 1)//勝ってれば
                    {
                        if (model.janwinPHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }

                        
                        BattleManager.instance.playerLeaderHP += model.janwinPHp;
                        BattleManager.instance.ShowLeaderHP();
                        
        
                    
                    }
                }
                else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                {
                    if(BattleManager.EnemyResult == 1)
                    {
                        if (model.janwinPHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }
                    }
                    
                }
                
            }

            //じゃんけん勝ってれば相手のライフ変化
            if(model.janwinEHp != 0)//ライフの変化が０でなければ
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 1)//勝ってれば
                    {
                        if (model.janwinEHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }

                        
                        BattleManager.instance.enemyLeaderHP += model.janwinEHp;
                        BattleManager.instance.ShowLeaderHP();
                        
        
                    
                    }
                }
                else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                {
                    if(BattleManager.EnemyResult == 1)
                    {
                        if (model.janwinPHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }
                    }
                    
                }
                
            }
            //じゃんけん勝ってればサーチ
            if(model.janwinaddCardsList != null)
            {
                if (model.janwinaddCardsList.Length >= 1) // リストの存在チェック
                {
                    if(BattleManager.PlayerResult == 1)//勝ってれば
                    {
                        for (int i = 0; i < model.janwinaddCardsList.Length; i++) // リストの個数分処理を繰り返す
                        {
                            if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                            {
                                Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();

                                if (playerHand.GetComponentsInChildren<CardController>().Length < 6)//手札が六枚未満なら
                                {
                                    SoundManager.instance.PlaySE(7);
                                    BattleManager.instance.CreateCard(model.janwinaddCardsList[i], playerHand); // リストの[i]番目のカードを手札に作る
                                    yield return new WaitForSeconds(0.25f);
                                }
                            }

                        }
                    }
                }
            }
            //じゃんけん勝ってれば召喚
            if(model.janwinsummonCardsList != null)
            {
                if (model.janwinsummonCardsList.Length >= 1)
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 1)//勝ってれば
                        {
                            for (int i = 0; i < model.janwinsummonCardsList.Length; i++)
                            {
                                yield return StartCoroutine(BattleManager.instance.SummonCard(model.janwinsummonCardsList[i], true));
                            }
                        }
                    /*else//同期はsummon側でやっている
                    {
                        for (int i = 0; i < model.summonCardsList.Length; i++)
                        {
                            yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], false));
                        }
                    }*/
                    }
                }
            }
            //じゃんけん勝ってれば、ドロー
            if (model.janwindraw >= 1)
            {
                if(BattleManager.PlayerResult == 1)//勝ってれば
                {
                    for (int i = 0; i < model.janwindraw; i++)
                    {
                        if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                        {
                            Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                            
                            BattleManager.instance.DrawCard(playerHand);//同期取れる
                        }
                    }
                }
            }
        }
        else//自分の手とカードの手が一致していてじゃんけんに勝つ効果のフラグがtrue
        {
            if(BattleManager.PlayerJanken == model.janken)//実際に自分の手とカードの手が一致
            {
                if(model.janwinpower != 0)//じゃんけん勝ってればパワーアップ
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 1)
                        {
                            model.power += model.janwinpower;
                            view.Show(model);
                            SoundManager.instance.PlaySE(8);
                        }
                    }
                    else 
                    {
                        if(BattleManager.EnemyResult == 1)
                        {
                            model.power += model.janwinpower;
                            view.Show(model);
                            SoundManager.instance.PlaySE(8);
                        }
                    }
                
                }

                //じゃんけん勝ってればスピードアタッカー
                if(model.janwinspeed == true)//
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 1)//勝ってれば
                        {
                            
                            model.canAttack = true;
                            SoundManager.instance.PlaySE(9);
                            view.SetCanAttackPanel(true);
                        
                        }
                    }
                    else //相手ターン(あいてのカード)
                    {
                        if(BattleManager.EnemyResult == 1)
                        {
                            model.canAttack = true;
                            SoundManager.instance.PlaySE(9);
                            view.SetCanAttackPanel(true);
                        }
                    }
                    
                }

                //じゃんけん勝ってれば自分のライフ変化
                if(model.janwinPHp != 0)//ライフの変化が０でなければ
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 1)//勝ってれば
                        {
                            if (model.janwinPHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }

                            
                            BattleManager.instance.playerLeaderHP += model.janwinPHp;
                            BattleManager.instance.ShowLeaderHP();
                            
            
                        
                        }
                    }
                    else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                    {
                        if(BattleManager.EnemyResult == 1)
                        {
                            if (model.janwinPHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }
                        }
                        
                    }
                    
                }

                //じゃんけん勝ってれば相手のライフ変化
                if(model.janwinEHp != 0)//ライフの変化が０でなければ
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 1)//勝ってれば
                        {
                            if (model.janwinEHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }

                            
                            BattleManager.instance.enemyLeaderHP += model.janwinEHp;
                            BattleManager.instance.ShowLeaderHP();
                            
            
                        
                        }
                    }
                    else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                    {
                        if(BattleManager.EnemyResult == 1)
                        {
                            if (model.janwinPHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }
                        }
                        
                    }
                    
                }
                //じゃんけん勝ってればサーチ
                if(model.janwinaddCardsList != null)
                {
                    if (model.janwinaddCardsList.Length >= 1) // リストの存在チェック
                    {
                        if(BattleManager.PlayerResult == 1)//勝ってれば
                        {
                            for (int i = 0; i < model.janwinaddCardsList.Length; i++) // リストの個数分処理を繰り返す
                            {
                                if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                                {
                                    Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();

                                    if (playerHand.GetComponentsInChildren<CardController>().Length < 6)//手札が六枚未満なら
                                    {
                                        SoundManager.instance.PlaySE(7);
                                        BattleManager.instance.CreateCard(model.janwinaddCardsList[i], playerHand); // リストの[i]番目のカードを手札に作る
                                        yield return new WaitForSeconds(0.25f);
                                    }
                                } 

                            }
                        }
                    }
                }
                //じゃんけん勝ってれば召喚
                if(model.janwinsummonCardsList != null)
                {   
                    if (model.janwinsummonCardsList.Length >= 1)
                    {
                        if (BattleManager.instance.isPlayerTurn == true)
                        {
                            if(BattleManager.PlayerResult == 1)//勝ってれば
                            {
                                for (int i = 0; i < model.janwinsummonCardsList.Length; i++)
                                {
                                    yield return StartCoroutine(BattleManager.instance.SummonCard(model.janwinsummonCardsList[i], true));
                                }
                            }
                        /*else//ライフの同期はsummon側でやっている
                        {
                            for (int i = 0; i < model.summonCardsList.Length; i++)
                            {
                                yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], false));
                            }
                        }*/
                        }
                    }
                }
                //じゃんけん勝ってれば、ドロー
                if (model.janwindraw >= 1)
                {
                    if(BattleManager.PlayerResult == 1)//勝ってれば
                    {
                        for (int i = 0; i < model.janwindraw; i++)
                        {
                            if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                            {
                                Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                                
                                BattleManager.instance.DrawCard(playerHand);//同期取れる
                            }
                        }
                    }
                }
            }
        }

        //じゃんけんに負けているときに発動する効果
        
        if(model.specificHand == false)//出した手とじゃんけん属性が一致していない
        {
            if(model.janlosepower != 0)//じゃんけん負けてればパワーアップ
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 2)
                    {
                        model.power += model.janlosepower;
                        view.Show(model);
                        SoundManager.instance.PlaySE(8);
                    }
                }
                else 
                {
                    if(BattleManager.EnemyResult == 2)
                    {
                        model.power += model.janlosepower;
                        view.Show(model);
                        SoundManager.instance.PlaySE(8);
                    }
                }
                
            }

            //じゃんけん負けてればスピードアタッカー
            if(model.janlosespeed == true)//
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 2)//負けてれば
                    {
                        
                        model.canAttack = true;
                        SoundManager.instance.PlaySE(9);
                        view.SetCanAttackPanel(true);
                    
                    }
                }
                else //相手ターン(あいてのカード)
                {
                    if(BattleManager.EnemyResult == 2)
                    {
                        model.canAttack = true;
                        SoundManager.instance.PlaySE(9);
                        view.SetCanAttackPanel(true);
                    }
                }
                
            }

            //じゃんけん負けてれば自分のライフ変化
            if(model.janlosePHp != 0)//ライフの変化が０でなければ
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 2)//負けてれば
                    {
                        if (model.janlosePHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }

                        
                        BattleManager.instance.playerLeaderHP += model.janlosePHp;
                        BattleManager.instance.ShowLeaderHP();
                        
        
                    
                    }
                }
                else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                {
                    if(BattleManager.EnemyResult == 2)
                    {
                        if (model.janlosePHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }
                    }
                    
                }
                
            }

            //じゃんけん負けてれば相手のライフ変化
            if(model.janloseEHp != 0)//ライフの変化が０でなければ
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerResult == 2)//負けてれば
                    {
                        if (model.janloseEHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }

                        
                        BattleManager.instance.enemyLeaderHP += model.janloseEHp;
                        BattleManager.instance.ShowLeaderHP();
                        
        
                    
                    }
                }
                else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                {
                    if(BattleManager.EnemyResult == 2)
                    {
                        if (model.janlosePHp>0)
                        {
                            SoundManager.instance.PlaySE(4);
                        }
                        else
                        {
                            SoundManager.instance.PlaySE(5);
                        }
                    }
                    
                }
                
            }
            //じゃんけん負けてればサーチ
            if(model.janloseaddCardsList != null)
            {
                if (model.janloseaddCardsList.Length >= 1) // リストの存在チェック
                {
                    if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                    {
                        if(BattleManager.PlayerResult == 2)//負けてれば
                        {
                            for (int i = 0; i < model.janloseaddCardsList.Length; i++) // リストの個数分処理を繰り返す
                            {
                                Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();

                                if (playerHand.GetComponentsInChildren<CardController>().Length < 6)//手札が六枚未満なら
                                {
                                    SoundManager.instance.PlaySE(7);
                                    BattleManager.instance.CreateCard(model.janloseaddCardsList[i], playerHand); // リストの[i]番目のカードを手札に作る
                                    yield return new WaitForSeconds(0.25f);
                                }
                            } 

                        }
                    }
                }
            }
            //じゃんけん負けてれば召喚
            if(model.janlosesummonCardsList != null)
            {
                if (model.janlosesummonCardsList.Length >= 1)
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 2)//負けてれば
                        {
                            for (int i = 0; i < model.janlosesummonCardsList.Length; i++)
                            {
                                yield return StartCoroutine(BattleManager.instance.SummonCard(model.janlosesummonCardsList[i], true));
                            }
                        }
                    /*else//ライフの同期はsummon側でやっている
                    {
                        for (int i = 0; i < model.summonCardsList.Length; i++)
                        {
                            yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], false));
                        }
                    }*/
                    }
                }
            }
            //じゃんけん負けてれば、ドロー
            if (model.janlosedraw >= 1)
            {
                if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                {
                    if(BattleManager.PlayerResult == 2)//負けてれば
                    {
                        for (int i = 0; i < model.janlosedraw; i++)
                        {
                        
                            Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                            
                            BattleManager.instance.DrawCard(playerHand);//同期取れる
                        }
                    }
                }
            }
        }
        else//自分の手とカードの手が一致していてかつじゃんけんに負ける効果のフラグがtrue
        {
            if(BattleManager.PlayerJanken == model.janken)//実際に自分の手とカードの手が一致
            {
                if(model.janlosepower != 0)//じゃんけん負けてればパワーアップ
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 2)
                        {
                            model.power += model.janlosepower;
                            view.Show(model);
                            SoundManager.instance.PlaySE(8);
                        }
                    }
                    else 
                    {
                        if(BattleManager.EnemyResult == 2)
                        {
                            model.power += model.janlosepower;
                            view.Show(model);
                            SoundManager.instance.PlaySE(8);
                        }
                    }
                
                }

                //じゃんけん負けてればスピードアタッカー
                if(model.janlosespeed == true)//
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 2)//負けてれば
                        {
                            
                            model.canAttack = true;
                            SoundManager.instance.PlaySE(9);
                            view.SetCanAttackPanel(true);
                        
                        }
                    }
                    else //相手ターン(あいてのカード)
                    {
                        if(BattleManager.EnemyResult == 2)
                        {
                            model.canAttack = true;
                            SoundManager.instance.PlaySE(9);
                            view.SetCanAttackPanel(true);
                        }
                    }
                    
                }

                //じゃんけん負けてれば自分のライフ変化
                if(model.janlosePHp != 0)//ライフの変化が０でなければ
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 2)//負けてれば
                        {
                            if (model.janlosePHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }

                            
                            BattleManager.instance.playerLeaderHP += model.janlosePHp;
                            BattleManager.instance.ShowLeaderHP();
                            
            
                        
                        }
                    }
                    else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                    {
                        if(BattleManager.EnemyResult == 2)
                        {
                            if (model.janlosePHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }
                        }
                        
                    }
                    
                }

                //じゃんけん負けてれば相手のライフ変化
                if(model.janloseEHp != 0)//ライフの変化が０でなければ
                {
                    if (BattleManager.instance.isPlayerTurn == true)
                    {
                        if(BattleManager.PlayerResult == 2)//負けてれば
                        {
                            if (model.janloseEHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }

                            
                            BattleManager.instance.enemyLeaderHP += model.janloseEHp;
                            BattleManager.instance.ShowLeaderHP();
                            
            
                        
                        }
                    }
                    else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
                    {
                        if(BattleManager.EnemyResult == 2)
                        {
                            if (model.janlosePHp>0)
                            {
                                SoundManager.instance.PlaySE(4);
                            }
                            else
                            {
                                SoundManager.instance.PlaySE(5);
                            }
                        }
                        
                    }
                    
                }
                //じゃんけん負けてればサーチ
                if(model.janloseaddCardsList != null)
                {   
                    if (model.janloseaddCardsList.Length >= 1) // リストの存在チェック
                    {
                        if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                        {
                            if(BattleManager.EnemyResult == 2)
                            {
                                for (int i = 0; i < model.janloseaddCardsList.Length; i++) // リストの個数分処理を繰り返す
                                {
                                
                                    Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();

                                    if (playerHand.GetComponentsInChildren<CardController>().Length < 6)//手札が六枚未満なら
                                    {
                                        SoundManager.instance.PlaySE(7);
                                        BattleManager.instance.CreateCard(model.janloseaddCardsList[i], playerHand); // リストの[i]番目のカードを手札に作る
                                        yield return new WaitForSeconds(0.25f);
                                    }
                                } 

                            }
                        }
                    }
                }
                //じゃんけん負けてれば召喚
                if(model.janlosesummonCardsList != null)
                {
                    if (model.janlosesummonCardsList.Length >= 1)
                    {
                        if (BattleManager.instance.isPlayerTurn == true)
                        {
                            if(BattleManager.PlayerResult == 2)//負けてれば
                            {
                                for (int i = 0; i < model.janlosesummonCardsList.Length; i++)
                                {
                                    yield return StartCoroutine(BattleManager.instance.SummonCard(model.janlosesummonCardsList[i], true));
                                }
                            }
                        /*else//ライフの同期はsummon側でやっている
                        {
                            for (int i = 0; i < model.summonCardsList.Length; i++)
                            {
                                yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], false));
                            }
                        }*/
                        }
                    }
                }
                //じゃんけん負けてれば、ドロー
                if (model.janlosedraw >= 1)
                {
                    if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                    {
                        if(BattleManager.PlayerResult == 2)//負けてれば
                        {
                            for (int i = 0; i < model.janlosedraw; i++)
                            {
                            
                                Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                                
                                BattleManager.instance.DrawCard(playerHand);//同期取れる
                            }
                        }
                    }
                }
            }
        }

        //自分の手とカードの手が一致しているときに発動する効果

        if(model.janhandpower != 0)//じゃんけんの手とカードの手が一致していればパワーアップ
        {
            if (BattleManager.instance.isPlayerTurn == true)
            {
                if(BattleManager.PlayerJanken == model.janken)
                {
                    model.power += model.janhandpower;
                    view.Show(model);
                    SoundManager.instance.PlaySE(8);
                }
            }
            else 
            {
                if(BattleManager.EnemyJanken == model.janken)
                {
                    model.power += model.janhandpower;
                        view.Show(model);
                        SoundManager.instance.PlaySE(8);
                    }
            }
                
        }

        //じゃんけんの手とカードの手が一致していればスピードアタッカー
        if(model.janhandspeed == true)//
        {
            if (BattleManager.instance.isPlayerTurn == true)
            {
                if(BattleManager.PlayerJanken == model.janken)//じゃんけんの手とカードの手が一致していれば
                {
                    
                    model.canAttack = true;
                    SoundManager.instance.PlaySE(9);
                    view.SetCanAttackPanel(true);
                
                }
            }
            else //相手ターン(あいてのカード)
            {
                if(BattleManager.EnemyJanken == model.janken)
                {
                    model.canAttack = true;
                    SoundManager.instance.PlaySE(9);
                    view.SetCanAttackPanel(true);
                }
            }
            
        }

        //じゃんけんの手とカードの手が一致していれば自分のライフ変化
        if(model.janhandPHp != 0)//ライフの変化が０でなければ
        {
            if (BattleManager.instance.isPlayerTurn == true)
            {
                if(BattleManager.PlayerJanken == model.janken)//じゃんけんの手とカードの手が一致していれば
                {
                    if (model.janhandPHp>0)
                    {
                        SoundManager.instance.PlaySE(4);
                    }
                    else
                    {
                        SoundManager.instance.PlaySE(5);
                    }

                    
                    BattleManager.instance.playerLeaderHP += model.janhandPHp;
                    BattleManager.instance.ShowLeaderHP();
                    
    
                
                }
            }
            else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
            {
                if(BattleManager.EnemyJanken == model.janken)
                {
                    if (model.janhandPHp>0)
                    {
                        SoundManager.instance.PlaySE(4);
                    }
                    else
                    {
                        SoundManager.instance.PlaySE(5);
                    }
                }
                
            }
            
        }

        //じゃんけんの手とカードの手が一致していれば相手のライフ変化
        if(model.janhandEHp != 0)//ライフの変化が０でなければ
        {
            if (BattleManager.instance.isPlayerTurn == true)
            {
                if(BattleManager.PlayerJanken == model.janken)//じゃんけんの手とカードの手が一致していれば
                {
                    if (model.janhandEHp>0)
                    {
                        SoundManager.instance.PlaySE(4);
                    }
                    else
                    {
                        SoundManager.instance.PlaySE(5);
                    }

                    
                    BattleManager.instance.enemyLeaderHP += model.janhandEHp;
                    BattleManager.instance.ShowLeaderHP();
                    
    
                
                }
            }
            else //相手ターン(あいてのカード)//ライフの同期はshowHP側でやっている
            {
                if(BattleManager.EnemyJanken == model.janken)
                {
                    if (model.janhandPHp>0)
                    {
                        SoundManager.instance.PlaySE(4);
                    }
                    else
                    {
                        SoundManager.instance.PlaySE(5);
                    }
                }
                
            }
            
        }
        //じゃんけんの手とカードの手が一致していればサーチ
        if(model.janhandaddCardsList != null)
        {
            if (model.janhandaddCardsList.Length >= 1) // リストの存在チェック
            {
                if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
                {
                    if(BattleManager.EnemyJanken == model.janken)
                    {
                        for (int i = 0; i < model.janhandaddCardsList.Length; i++) // リストの個数分処理を繰り返す
                        {                            
                            Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                            
                            if (playerHand.GetComponentsInChildren<CardController>().Length < 6)//手札が六枚未満なら
                            {
                                SoundManager.instance.PlaySE(7);
                                BattleManager.instance.CreateCard(model.janhandaddCardsList[i], playerHand); // リストの[i]番目のカードを手札に作る
                                yield return new WaitForSeconds(0.25f);
                            }
                        } 

                    }
                }
            }
        }
        //じゃんけんの手とカードの手が一致していれば召喚
        if(model.janhandsummonCardsList != null)
        {
            if (model.janhandsummonCardsList.Length >= 1)
            {
                if (BattleManager.instance.isPlayerTurn == true)
                {
                    if(BattleManager.PlayerJanken == model.janken)//じゃんけんの手とカードの手が一致していれば
                    {
                        for (int i = 0; i < model.janhandsummonCardsList.Length; i++)
                        {
                            yield return StartCoroutine(BattleManager.instance.SummonCard(model.janhandsummonCardsList[i], true));
                        }
                    }
                /*else//ライフの同期はsummon側でやっている
                {
                    for (int i = 0; i < model.summonCardsList.Length; i++)
                    {
                        yield return StartCoroutine(BattleManager.instance.SummonCard(model.summonCardsList[i], false));
                    }
                }*/
                }
            }
        }
        //じゃんけんの手とカードの手が一致していれば、ドロー
        if (model.janhanddraw >= 1)
        {
            if (BattleManager.instance.isPlayerTurn == true) // 分岐を追加
            {
                if(BattleManager.PlayerJanken == model.janken)//じゃんけんの手とカードの手が一致していれば
                {
                    for (int i = 0; i < model.janhanddraw; i++)
                    {
                    
                        Transform playerHand = GameObject.Find("PlayerHands").GetComponent<Transform>();
                        
                        BattleManager.instance.DrawCard(playerHand);//同期取れる
                    }
                }
            }
        }
        
//破壊効果
        if (model.destroyjan != 0) // 相手をグチパをランダム破壊,1,2,3それぞれグチパ破壊
        {
            if (BattleManager.instance.isPlayerTurn == true)
            {
                GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");

                // 条件を満たすカードを格納するリスト
                List<GameObject> matchingCards = new List<GameObject>();

                // 条件を満たすカードを探してリストに追加する
                foreach (GameObject card in cards)
                {
                    CardController cardController = card.GetComponent<CardController>();
                    if (cardController.model.PlayerCard == false && cardController.model.janken == model.destroyjan)
                    {
                        matchingCards.Add(card);
                    }
                }

                // 条件を満たすカードが一つ以上あればランダムに一枚選んで破壊する
                if (matchingCards.Count > 0)
                {
                    // ランダムにインデックスを選択
                    int randomIndex = Random.Range(0, matchingCards.Count);

                    //破壊同期
                    BattleManager.instance.DestroyRamdomJan(matchingCards[randomIndex].GetComponent<CardController>().model.enemyNumberth);
                    
                    SoundManager.instance.PlaySE(12);
                    // 選択したカードを破壊
                   StartCoroutine(DestroyCard(matchingCards[randomIndex].GetComponent<CardController>()));
                    
                }
            }
        }
        
        //２種類破壊
        if (model.destroyjan2 != 0) 
        {
            
            GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
            // 条件を満たすカードを探して破壊する
            foreach (GameObject card in cards)
            {
                CardController cardController = card.GetComponent<CardController>();

                if (BattleManager.instance.isPlayerTurn == true)
                {       
                    if (cardController.model.PlayerCard == false && cardController.model.FieldCard == true)
                    {
                        // destroyjan の値に応じて条件を設定
                        if ((model.destroyjan2 == 1 && (cardController.model.janken == 1 || cardController.model.janken == 3)) ||
                            (model.destroyjan2 == 2 && (cardController.model.janken == 1 || cardController.model.janken == 2)) ||
                            (model.destroyjan2 == 3 && (cardController.model.janken == 2 || cardController.model.janken == 3)))
                        {
                            // 条件を満たすカードを破壊
                            StartCoroutine(DestroyCard(card.GetComponent<CardController>()));
                            if(destroycards == false)
                            {
                                destroycards = true;
                            }
                        }
                    }
                }
                else
                {
                    if(cardController.model.PlayerCard == true && cardController.model.FieldCard == true)
                    {
                        // destroyjan の値に応じて条件を設定
                        if ((model.destroyjan2 == 1 && (cardController.model.janken == 1 || cardController.model.janken == 3)) ||
                            (model.destroyjan2 == 2 && (cardController.model.janken == 1 || cardController.model.janken == 2)) ||
                            (model.destroyjan2 == 3 && (cardController.model.janken == 2 || cardController.model.janken == 3)))
                        {
                            // 条件を満たすカードを破壊
                            StartCoroutine(DestroyCard(card.GetComponent<CardController>()));
                            if(destroycards == false)
                            {
                                destroycards = true;
                            }
                        }
                    }
                }
            }
            if(destroycards == true)
            {
                SoundManager.instance.PlaySE(10);
                destroycards = false;
            }

        }

        //
        //
        
        
        
        //全破壊,相手ターンでも問題なし、同期必要なし
        if(model.alldestroy == true)
        {

            GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
            // 条件を満たすカードを探して破壊する
            foreach (GameObject card in cards)
            {
                CardController cardController = card.GetComponent<CardController>();

                     
                if (cardController.model.FieldCard == true)
                {
                    // 条件を満たすカードを破壊
                    StartCoroutine(DestroyCard(card.GetComponent<CardController>()));
                    //card.GetComponent<CardController>().view.SetDestoroyPanel();                
                    //yield return new WaitForSeconds(0.2f);
                    //Destroy(card);
                }

            }

            SoundManager.instance.PlaySE(10);
            //yield return new WaitForSeconds(0.6f);
        }

        // スペルカードなら使用後に消滅
        if (model.cardType == CardType.Spell)
        {
            if(model.alldestroy != true)
            {
                Destroy(this.gameObject);
            }
            
            
        }

        


        
        // 操作ロック解除
        if (BattleManager.instance.isPlayerTurn == true) // 相手のモーションで発動しないように
        {
            BattleManager.instance.turnEndButton.interactable = true;
        }

        if (BattleManager.instance.isPlayerTurn)
        {
            BattleManager.instance.SetCanUsePanelHand(true);// 効果処理の最後に実施
        }
    }


    
    
}
