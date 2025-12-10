using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// カードの見た目（View）を制御するクラス。
/// CardModelのデータを元に、イラスト、テキスト、枠色などをUIに反映させる。
/// </summary>
public class CardView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;//コスト表示
    [SerializeField] TextMeshProUGUI nameText;//名前表示
    [SerializeField] TextMeshProUGUI powerText;//パワー表示
    [SerializeField] TextMeshProUGUI jankenText;//じゃんけん属性値
    [SerializeField] Image iconImage;//カードイラスト
    [SerializeField] Image janiconImage;//じゃんけん属性アイコン
    [SerializeField] Image costImage;//コスト背景
    [SerializeField] GameObject canAttackPanel;//攻撃可能時の強調枠
    [SerializeField] GameObject canUsePanel;//使用可能時の強調枠
    [SerializeField] TextMeshProUGUI abilityText;//効果テキスト

    // 属性に応じた背景パネル（1:赤, 2:緑, 3:青）
    [SerializeField] GameObject cardPanel1;// 属性に応じた背景パネル（1:赤）
    [SerializeField] GameObject cardPanel2;// 属性に応じた背景パネル（2:緑）
    [SerializeField] GameObject cardPanel3;// 属性に応じた背景パネル（3:青）

    [SerializeField] GameObject powerPanel;//パワー表示部
    [SerializeField] GameObject jankenPanel;//じゃんけん属性表示部

    [SerializeField] GameObject countPanel; // デッキ編成時の所持枚数表示パネル
    [SerializeField] TextMeshProUGUI countText; // 所持枚数テキスト

    [SerializeField] GameObject DestoroyPanel;//破壊時のエフェクトパネル
    [SerializeField] GameObject EnemyHandPanel;//CPUの手札用のパネル

//g 68,21,9,255(赤系)
//c 58,106,38,255(緑系)
//p 26,45,100,255(青系)
    
    /// <summary>
    /// CardModelのデータをUIに反映して表示を更新する
    /// </summary>
    public void Show(CardModel cardModel) 
    {
        nameText.text = cardModel.name;//
        iconImage.sprite = cardModel.cardImage;//
        janiconImage.sprite = cardModel.janicon;
        abilityText.text = cardModel.abilityText;
        powerText.text = cardModel.power.ToString();
        jankenText.text = cardModel.janken.ToString();
        costText.text = cardModel.cost.ToString();//
        
        // スペルカードの場合はパワーや属性アイコンの一部を非表示にする
        if (cardModel.cardType == CardType.Spell)
        {
            //cardPanel.GetComponent<Image>().color = new Color32(36, 195, 144, 200 );
            //powerText.enabled = false;
            powerPanel.SetActive(false);
            jankenPanel.SetActive(false);
        }

        // じゃんけん属性に応じて背景パネルと色を切り替える
        if (cardModel.janken == 1)// グー
        {   
            cardPanel1.SetActive(true);
            cardPanel2.SetActive(false);
            cardPanel3.SetActive(false);
            costImage.color = new Color32(68,21,9,255);
        }
        else if(cardModel.janken == 2)// チョキ
        {   
            cardPanel1.SetActive(false);
            cardPanel2.SetActive(true);
            cardPanel3.SetActive(false);
            costImage.color = new Color32(58,106,38,255);
        }
        else if(cardModel.janken == 3)// パー
        {   
            cardPanel1.SetActive(false);
            cardPanel2.SetActive(false);
            cardPanel3.SetActive(true);
            costImage.color = new Color32(26,45,100,255);
        }
    }

    /// <summary>
    /// デッキ編成画面用に、所持カード枚数を表示するパネルを有効化する
    /// </summary>
    public void ShowCountPanel()
    {
        countPanel.SetActive(true);
 
        DeckEditManager deckEditManager = GameObject.Find("DeckEditManager").GetComponent<DeckEditManager>();
        CardController card = GetComponent<CardController>();
        // 所持数リストから枚数を取得して表示
        countText.text = deckEditManager.stockCardsList[card.model.cardId].ToString();
    }

    /// <summary>
    /// 攻撃可能エフェクト（枠）の表示切り替え
    /// </summary>
    public void SetCanAttackPanel(bool flag)
    {
        canAttackPanel.SetActive(flag);
    }
    /// <summary>
    /// 使用可能エフェクト（枠）の表示切り替え
    /// </summary>
    public void SetCanUsePanel(bool flag) // フラグに合わせてCanUsePanelを付けるor消す
    {
        canUsePanel.SetActive(flag);
    }

    /// <summary>
    /// 破壊時の演出パネルを表示する
    /// </summary>
    public void SetDestoroyPanel() // フラグに合わせてCanUsePanelを付けるor消す
    {
        DestoroyPanel.SetActive(true);
    }

    public void SetEnemyHandPanel(bool flag)
    {
        EnemyHandPanel.SetActive(flag);
    }

}
