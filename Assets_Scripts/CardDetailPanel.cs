using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// カードをクリックした際に表示される詳細画面（ポップアップ）を制御するクラス。
/// </summary>
public class CardDetailPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cardNameText;// カード名
    [SerializeField] TextMeshProUGUI cardAbilityText;// 能力テキスト
    [SerializeField] Transform cardTrans;// 拡大カードを表示する位置

    /// <summary>
    /// 詳細パネルの内容を設定し、カードの拡大モデルを生成する
    /// </summary>
    /// <param name="card">表示対象のカードコントローラー</param>
    public void SetCardDetailsPanel(CardController card)
    {
        cardNameText.text = card.model.name;
        cardAbilityText.text = card.model.abilityText;
        Debug.Log(card.model.cardId);

        // 詳細パネル内にカードの実体を生成して表示
        CardController targetCard = GameManager.instance.CreateCard(card.model.cardId, cardTrans);
        targetCard.ScaleCard(3f);// 3倍に拡大
    }
    
    /// <summary>
    /// 詳細パネルを閉じる（破棄する）
    /// </summary>
    public void DestoyCardDetailPanel()
    {
        Destroy(this.gameObject);
    }
}
