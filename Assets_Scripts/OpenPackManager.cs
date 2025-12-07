using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 不使用
/// </summary>
public class OpenPackManager : MonoBehaviour
{
    [SerializeField] GameObject cardPackPrefab; // カードパックプレハブ
    [SerializeField] Transform openedCardTrans; // 開封したカードの生成場所
    [SerializeField] Transform cardPackTrans; // カードパックの生成場所

    // カードの展開先の場所
    [SerializeField] Transform expandCardTrans1;
    [SerializeField] Transform expandCardTrans2;
    [SerializeField] Transform expandCardTrans3;
    [SerializeField] Transform expandCardTrans4;
    [SerializeField] Transform expandCardTrans5;
    [SerializeField] Transform expandCardTrans6;
    [SerializeField] Transform expandCardTrans7;
    [SerializeField] Transform expandCardTrans8;

    public List<int> packCardList = new List<int>() { 0, 1, 2, 3 }; // パックのカードリスト

    int buyPackCount = 0; // 購入するパックの個数
    int generatedPackCount; // 生成したパックの個数

    private void Start()
    {
        buyPackCount = PurchasePackPanel.purchasePackCount;
        CreatePack(PurchasePackPanel.purchasePackID);
    }

    // パックを開封するメソッド
    void CreatePack(int packId)
    {
        // 開封したパックの数を増やす
        generatedPackCount += 1;

        // PackPrefabを作成する
        GameObject pack = Instantiate(cardPackPrefab, cardPackTrans);
        pack.GetComponent<PackView>().Show(packId);
    }

    public void OpenPack()
    {
        // パックのカードリストを取得して、packCardListに入れる
        PackEntity packEntity = Resources.Load<PackEntity>("PackEntityList/Pack" + PurchasePackPanel.purchasePackID);
        packCardList = packEntity.cardList;

        // 8枚カードを生成する
        for (int i = 0; i < 8; i++)
        {
            int cardId = decisionCardId();
            Debug.Log(cardId);
            GameManager.instance.CreateCard(cardId, openedCardTrans);
            // パック開封で出てきたカードを所持カードリストに追加する
            AddPackCards(cardId);
        }

        // カードを展開させる
        StartCoroutine(ExpandPackCards()); // StartCoroutineに変更
    }

    // カードのIDをランダムに決めるメソッド
    int decisionCardId()
    {
        int randomCardId = packCardList[Random.Range(0, packCardList.Count)];
        return randomCardId;
    }

    // パックのカードを展開するメソッド
    IEnumerator ExpandPackCards()// IEnumeratorに変更
    {
        int cardNum = 0;
        Transform moveTarget = null;
        CardController[] cardList = openedCardTrans.GetComponentsInChildren<CardController>();

        yield return new WaitForSeconds(0.25f);

        foreach (CardController card in cardList)
        {
            cardNum += 1;
 
            switch (cardNum)
            {
                case 1:
                    moveTarget = expandCardTrans1;
                    break;
                case 2:
                    moveTarget = expandCardTrans2;
                    break;
                case 3:
                    moveTarget = expandCardTrans3;
                    break;
                case 4:
                    moveTarget = expandCardTrans4;
                    break;
                case 5:
                    moveTarget = expandCardTrans5;
                    break;
                case 6:
                    moveTarget = expandCardTrans6;
                    break;
                case 7:
                    moveTarget = expandCardTrans7;
                    break;
                case 8:
                    moveTarget = expandCardTrans8;
                    break;
            }
 
            StartCoroutine(card.movement.ExpandThisCard(moveTarget));
            yield return new WaitForSeconds(0.025f);
        }
    }

    // OKボタンを押した時の処理
    public void PushOKButtom()
    {
        // パック購入数とパック生成数で分岐させる
        if (buyPackCount == generatedPackCount)
        {
            // パック開封を終える
            EndOpenPack();
        }
        else
        {
            // 次のパックを用意する
            NextPack();
        }
    }

    // カードを移動して、次のパックを用意する
    void NextPack()
    {
        RemoveExpandCard();
        CreatePack(PurchasePackPanel.purchasePackID);
    }

    // 展開されたパックのカードを破壊する
    void RemoveExpandCard()
    {
        Destroy(expandCardTrans1.GetChild(0).gameObject);
        Destroy(expandCardTrans2.GetChild(0).gameObject);
        Destroy(expandCardTrans3.GetChild(0).gameObject);
        Destroy(expandCardTrans4.GetChild(0).gameObject);
        Destroy(expandCardTrans5.GetChild(0).gameObject);
        Destroy(expandCardTrans6.GetChild(0).gameObject);
        Destroy(expandCardTrans7.GetChild(0).gameObject);
        Destroy(expandCardTrans8.GetChild(0).gameObject);
    }

    // シーンを切り替える
    void EndOpenPack()
    {
        SceneTransitionManager.instance.Load("Shop");
    }

    // パック開封したカードを所持カードリストに追加する
    void AddPackCards(int cardId)
    {   
        GameManager.PossessionCardsList[cardId] += 1;
    }
}
