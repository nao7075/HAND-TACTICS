using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体を通して存在するシングルトンマネージャー。
/// カードの生成や、オンライン対戦フラグなどの全体情報を管理する。
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] CardController cardPrefab; // カードプレハブ
    [SerializeField] CardDetailPanel cardDetailsPanelPrefab; // カード詳細パネルのプレハブ

    public bool IsOnlineBattle {get; set;}// オンライン対戦中かどうかのフラグ
    
    public static List<int> PossessionCardsList = new List<int>() {};// 所持カードリスト
    
    // カードの種類数
    int cardKindNum = 42;//カードの種類の初期値、unityのインスペクターで設定した枚数になる

    public static GameManager instance;// シングルトン化

    private void Awake()
    {
        // シングルトンパターンの実装
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);// シーン遷移しても破壊されない
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        // カードの種類分、リストに要素を入れ込む
        for (int i = 0; i < cardKindNum; i++) PossessionCardsList.Add(0);
        Debug.Log(PossessionCardsList);
    }

 
    
    /// <summary>
    /// 指定したIDのカードを、指定した場所に生成するファクトリーメソッド
    /// カードを作るメソッド（生成したいカードのID、生成したいカードの場所）
    /// </summary>
    public CardController CreateCard(int cardId, Transform trans)
    {
        // cardPrefabをopenedCardTransに生成する
        CardController card = Instantiate(cardPrefab, trans);
        card.Init(cardId, true);
        return card;
    }

    /// <summary>
    /// 指定したカードの詳細パネルをUI上に生成して表示する
    /// </summary>
    public void CreateCardDetailsPanel(CardController card)
    {
        // Canvasの場所を取得
        Transform canvas = GameObject.Find("Canvas").GetComponent<Transform>();
 
        // カード詳細パネルを生成する
        CardDetailPanel cardDetailsPanel = Instantiate(cardDetailsPanelPrefab);
 
        // カード詳細パネルの親要素と内容をセットする
        cardDetailsPanel.transform.SetParent(canvas,false);
        cardDetailsPanel.SetCardDetailsPanel(card);
    }
}
