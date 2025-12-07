using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デッキ編成画面（Deck Scene）の管理クラス。
/// デッキと所持カード（ストック）の表示、ページ切り替え、データの保存・リセットを行う。
/// </summary>
public class DeckEditManager : MonoBehaviour
{
    // CardController型に変更
    [SerializeField] CardController cardPrefab; // カードプレハブ
    
    // デッキカードの生成場所（ページごと）
    [SerializeField] Transform deckCardTrans1page;// デッキカードの生成場所1ページ目
    [SerializeField] Transform deckCardTrans2page;// デッキカードの生成場所2ページ目

    [SerializeField] GameObject DeckPanel1; // デッキページ1のパネル
    [SerializeField] GameObject DeckPanel2; // デッキページ2のパネル

    // ページ切り替えボタン
    [SerializeField] GameObject page1Button;// ページ切り替えボタン左
    [SerializeField] GameObject page2Button;// ページ切り替えボタン右

    // 各デッキカードスロットの位置（1～32）
    [SerializeField] Transform deckCardTrans1;//デッキカードスロット1
    [SerializeField] Transform deckCardTrans2;//デッキカードスロット2
    [SerializeField] Transform deckCardTrans3;//デッキカードスロット3
    [SerializeField] Transform deckCardTrans4;//デッキカードスロット4
    [SerializeField] Transform deckCardTrans5;//デッキカードスロット5
    [SerializeField] Transform deckCardTrans6;//デッキカードスロット6
    [SerializeField] Transform deckCardTrans7;//デッキカードスロット7
    [SerializeField] Transform deckCardTrans8;//デッキカードスロット8
    [SerializeField] Transform deckCardTrans9;//デッキカードスロット9
    [SerializeField] Transform deckCardTrans10;//デッキカードスロット10
    [SerializeField] Transform deckCardTrans11;//デッキカードスロット11
    [SerializeField] Transform deckCardTrans12;//デッキカードスロット12
    [SerializeField] Transform deckCardTrans13;//デッキカードスロット13
    [SerializeField] Transform deckCardTrans14;//デッキカードスロット14
    [SerializeField] Transform deckCardTrans15;//デッキカードスロット15
    [SerializeField] Transform deckCardTrans16;//デッキカードスロット16
    [SerializeField] Transform deckCardTrans17;//デッキカードスロット17
    [SerializeField] Transform deckCardTrans18;//デッキカードスロット18
    [SerializeField] Transform deckCardTrans19;//デッキカードスロット19
    [SerializeField] Transform deckCardTrans20;//デッキカードスロット20
    [SerializeField] Transform deckCardTrans21;//デッキカードスロット21
    [SerializeField] Transform deckCardTrans22;//デッキカードスロット22
    [SerializeField] Transform deckCardTrans23;//デッキカードスロット23
    [SerializeField] Transform deckCardTrans24;//デッキカードスロット24
    [SerializeField] Transform deckCardTrans25;//デッキカードスロット25
    [SerializeField] Transform deckCardTrans26;//デッキカードスロット26
    [SerializeField] Transform deckCardTrans27;//デッキカードスロット27
    [SerializeField] Transform deckCardTrans28;//デッキカードスロット28
    [SerializeField] Transform deckCardTrans29;//デッキカードスロット29
    [SerializeField] Transform deckCardTrans30;//デッキカードスロット30
    [SerializeField] Transform deckCardTrans31;//デッキカードスロット31
    [SerializeField] Transform deckCardTrans32;//デッキカードスロット32

    // 所持カード（ストック）の生成場所
    [SerializeField] Transform stockCardTrans; //所持カード生成場所
    [SerializeField] Transform stockCardTrans1; // 所持カードスロット1
    [SerializeField] Transform stockCardTrans2; // 所持カードスロット2
    [SerializeField] Transform stockCardTrans3; // 所持カードスロット3
    [SerializeField] Transform stockCardTrans4; // 所持カードスロット4
    [SerializeField] Transform stockCardTrans5; // 所持カードスロット5
    [SerializeField] Transform stockCardTrans6; // 所持カードスロット6

    [SerializeField] GameObject DropPanels;// ドロップ判定用のパネル
    
    
    // List<int> deckCardsList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    public List<int> deckCardsList = new List<int>() { }; // 現在編集中のデッキリスト

    /// <summary>
    /// 所持してるのカードリスト（各カードIDごとの所持枚数を格納)、unity側で制御
    /// </summary>
    public List<int> stockCardsList = new List<int>() { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3};

    
    public int page = 0;// 所持カードのページ数、初期値0
    
    public int deckpage = 0;// デッキの現在のページ数 (1 or 2)、初期値0

    private void Start()
    {
        // 所持カードリストを読み込む
        //stockCardsList = new List<int>(GameManager.PossessionCardsList);

        // デッキリストマネージャーから編集対象のデッキをコピーして読み込む,（参照渡し）
        deckCardsList = DeckListManager.deckList;
        // デッキ編成の画面を初期化する
        SetDeckEditPanel();

        // 初期ページ設定
        page1Button.SetActive(false);
        page2Button.SetActive(true);
    }

    /// <summary>
    /// 保存ボタン処理。編集内容を確定してデッキ一覧に戻る。
    /// </summary>
    public void SaveButton()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(SaveBackButtom());
    }

    public IEnumerator SaveBackButtom()
    {
        yield return new WaitForSeconds(0.075f);
        
        SceneTransitionManager.instance.Load("DeckList");
    }

    /// <summary>
    /// デッキ編集画面の表示内容を更新する（初期化用）
    /// </summary>
    void SetDeckEditPanel()
    {

        // デッキ内のカードを表示
        SetDeckCards1();
    
        // デッキのカードを所持カードから削除する
        RemoveDeckCardsFromStockCards();

        // 所持カード一覧を表示
        SetStockCards();
    }
    
    /// <summary>
    /// デッキの1ページ目（1～16枚目）を表示する
    /// </summary>
    public void SetDeckCards1() // 引数を削除
    {
        deckpage=1;
        Debug.Log("deckpage"+deckpage);

        // 既存のカードオブジェクトをクリア
        foreach (Transform eachDeckCardTrans in deckCardTrans1page)
        {
            foreach (Transform cardTrasns in eachDeckCardTrans)
            {
                Destroy(cardTrasns.gameObject);
            }
        }
        foreach (Transform eachDeckCardTrans in deckCardTrans2page)
        {
            foreach (Transform cardTrasns in eachDeckCardTrans)
            {
                Destroy(cardTrasns.gameObject);
            }
        }

        // デッキのカードリストを参照して、デッキにカードを生成する、リストの先頭から順にカードを生成
        for (int i = 0; i < deckCardsList.Count; i++)
        {

            if (i == 0) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans1);
            if (i == 1) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans2);
            if (i == 2) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans3);
            if (i == 3) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans4);
            if (i == 4) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans5);
            if (i == 5) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans6);
            if (i == 6) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans7);
            if (i == 7) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans8);
            if (i == 8) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans9);
            if (i == 9) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans10);
            if (i == 10) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans11);
            if (i == 11) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans12);
            if (i == 12) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans13);
            if (i == 13) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans14);
            if (i == 14) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans15);
            if (i == 15) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans16);
        }

        // 生成したカードに「デッキ内のカード」であるフラグを立てる
        foreach (Transform eachDeckCardTrans in deckCardTrans1page)
        {
            foreach (Transform cardTrasns in eachDeckCardTrans)
            {
                CardController card = cardTrasns.gameObject.GetComponent<CardController>();
                card.model.isDeckCard = true;
                card.movement.canMove = true;
            }
        }
    }

    /// <summary>
    /// デッキの2ページ目（17～32枚目）を表示する
    /// </summary>
    public void SetDeckCards2() // 引数を削除
    {
        deckpage=2;
        Debug.Log("deckpage"+deckpage);

        // 既存カードのクリア
        foreach (Transform eachDeckCardTrans in deckCardTrans1page)
        {
            foreach (Transform cardTrasns in eachDeckCardTrans)
            {
                Destroy(cardTrasns.gameObject);
            }
        }
        foreach (Transform eachDeckCardTrans in deckCardTrans2page)
        {
            foreach (Transform cardTrasns in eachDeckCardTrans)
            {
                Destroy(cardTrasns.gameObject);
            }
        }

        // デッキのカードリストを参照して、デッキにカードを生成する、後半部分
        for (int i = 16; i < deckCardsList.Count; i++)
        {

            if (i == 16) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans17);
            if (i == 17) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans18);
            if (i == 18) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans19);
            if (i == 19) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans20);
            if (i == 20) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans21);
            if (i == 21) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans22);
            if (i == 22) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans23);
            if (i == 23) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans24);
            if (i == 24) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans25);
            if (i == 25) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans26);
            if (i == 26) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans27);
            if (i == 27) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans28);
            if (i == 28) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans29);
            if (i == 29) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans30);
            if (i == 30) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans31);
            if (i == 31) GameManager.instance.CreateCard(deckCardsList[i], deckCardTrans32);
           /*if (i == 0) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans17);
            if (i == 1) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans18);
            if (i == 2) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans19);
            if (i == 3) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans20);
            if (i == 4) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans21);
            if (i == 5) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans22);
            if (i == 6) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans23);
            if (i == 7) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans24);
            if (i == 8) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans25);
            if (i == 9) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans26);
            if (i == 10) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans27);
            if (i == 11) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans28);
            if (i == 12) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans29);
            if (i == 13) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans30);
            if (i == 14) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans31);
            if (i == 15) GameManager.instance.CreateCard(deckCardsList[i+16], deckCardTrans31);*/
        }

        // 生成したカードに「デッキ内のカード」であるフラグを立てる
        foreach (Transform eachDeckCardTrans in deckCardTrans2page)
        {
            foreach (Transform cardTrasns in eachDeckCardTrans)
            {
                CardController card = cardTrasns.gameObject.GetComponent<CardController>();
                card.model.isDeckCard = true;
                card.movement.canMove = true;
            }
        }
    }

    /// <summary>
    /// 所持カード（ストック）一覧を表示する。
    /// ページ送り（page変数）に対応して表示するカードIDを切り替える。
    /// </summary>
    public void SetStockCards()
    {
        // 既存カードのクリア
        foreach (Transform eachStockCardTrans in stockCardTrans)
        {
            foreach (Transform cardTrasns in eachStockCardTrans)
            {
                Destroy(cardTrasns.gameObject);
            }
        }
        
        // 現在のページに対応するカードID（6枚ずつ）を生成
        for (int i = 0; i < 6; i++)
        {
            int stockInitCardOrder = page * 6; // 所持カードのページの最初に生成されるカードの値(開始ID)を取得
            if (stockInitCardOrder + i >= stockCardsList.Count) break; // 対象のIDのカードが存在しなければ、処理を止める
            Transform creatCardTransTarget = null;
 
            // カードを生成する場所の割り当て
            if (i == 0) creatCardTransTarget = stockCardTrans1;
            if (i == 1) creatCardTransTarget = stockCardTrans2;
            if (i == 2) creatCardTransTarget = stockCardTrans3;
            if (i == 3) creatCardTransTarget = stockCardTrans4;
            if (i == 4) creatCardTransTarget = stockCardTrans5;
            if (i == 5) creatCardTransTarget = stockCardTrans6;
 
            CardController card = GameManager.instance.CreateCard(stockInitCardOrder + i, creatCardTransTarget); // CardController型で取得
            card.view.ShowCountPanel(); // 枚数パネルを表示させる
            card.movement.canMove = true;

            // カード枚数が0枚ならドラッグ不可にする
            if (stockCardsList[card.model.cardId] == 0)
            {
                card.movement.canMove = false;
            }
        }
    }
    /// <summary>
    /// 所持カードの表示を切り替えるボタンの処理
    /// </summary>
    public void changeStockCardPage(int changePage)
    {
        // ページ数が負の数になるなら、処理を止める.ページ範囲外チェック
        if (changePage == -1)
        {
            int tmpPage = page + changePage;
            if (tmpPage < 0) return;
        }

        // ページが所持カードの種類を上回る場合、処理を止める.ページ範囲外チェック
        if (changePage == 1)
        {
            int stockInitCardOrder = (page + changePage) * 6;
            if (stockInitCardOrder >= stockCardsList.Count) return;
        }

        // ページを引数分変更
        page += changePage;
        SoundManager.instance.PlaySE(1);
        // 改めて所持カードを再描画
        SetStockCards();
    }

    /// <summary>
    /// デッキ表示エリアのページ切り替え処理（1ページ目 <-> 2ページ目）
    /// </summary>
    public void changeDeckCardPage(int changePage)
    {
        // 1ページ目へ戻る
        if (changePage == -1)
        {
            SoundManager.instance.PlaySE(1);
            DeckPanel2.SetActive(false);
            DeckPanel1.SetActive(true);
            SetDeckCards1();
            page1Button.SetActive(false);
            page2Button.SetActive(true);
            
        }

        // 2ページ目へ進む（カードが16枚以上ある場合のみ）
        if (changePage == 1 && deckCardsList.Count >= 16)
        {
            SoundManager.instance.PlaySE(1);
            DeckPanel1.SetActive(false);
            DeckPanel2.SetActive(true);
            SetDeckCards2();
            page2Button.SetActive(false);
            page1Button.SetActive(true);
        }

        

        // 改めてデッキカードを設定する
        //SetDeckCards();
    }
    

    /// <summary>
    /// デッキリストにカードIDを追加し、ID順にソートする
    /// </summary>
    public void AddDeckCard(int cardId)
    {
        deckCardsList.Add(cardId);
        deckCardsList.Sort();
    }

    /// <summary>
    /// デッキリストからカードIDを削除し、ソートする
    /// </summary>
    public void RemoveDeckCard(int cardId)
    {
        deckCardsList.Remove(cardId);
        deckCardsList.Sort();
    }

    /// <summary>
    /// 所持カードの枚数を増やす（デッキから戻した時など）
    /// </summary>
    public void AddStockCard(int cardId)
    {
        stockCardsList[cardId] += 1;
    }
    
    /// <summary>
    /// 所持カードの枚数を減らす（デッキに入れた時など）
    /// </summary>
    public void RemoveStockCard(int cardId)
    {
        stockCardsList[cardId] -= 1;
    }

    /// <summary>
    /// ドラッグ中のみドロップ用パネルを表示する
    /// </summary>
    public void ShowDropPanels(bool flag)
    {
        DropPanels.SetActive(flag);
    }

    /// <summary>
    /// デッキに含まれているカード分、所持数を減算して初期化する
    /// </summary>
    void RemoveDeckCardsFromStockCards()
    {
        for (int i = 0; i < deckCardsList.Count; i++)
        {
            stockCardsList[deckCardsList[i]] -= 1;
        }
    }

    /// <summary>
    /// リセットボタン処理。デッキを全解除し、全て所持カードに戻す。
    /// </summary>
    public void ResetButton()
    {
        SoundManager.instance.PlaySE(2);
        if (deckpage == 2)
        {
            
            DeckPanel2.SetActive(false);// 改めてデッキカードを設定する
            DeckPanel1.SetActive(true);
            
            page1Button.SetActive(false);
            page2Button.SetActive(true);
            
        }
        AddDeckCardsFromStockCards();// 所持数を戻す
        deckCardsList.Clear();// デッキリストを空に
        RemoveDeckCardsFromStockCards();// 再計算（実質0）
        
        SetDeckEditPanel(); // デッキカードと所持カードのセットアップを再度行う
    }

    // リセットボタン押下時に、デッキのカードを所持カードに追加する
    void AddDeckCardsFromStockCards()
    {
        for (int i = 0; i < deckCardsList.Count; i++)
        {
            stockCardsList[deckCardsList[i]] += 1;
        }
    }

}