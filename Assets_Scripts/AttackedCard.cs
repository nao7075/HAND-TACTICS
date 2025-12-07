using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// カードにアタッチし、攻撃ドロップを受け付けるクラス,
/// 攻撃されるためのクラス
/// </summary>
public class AttackedCard : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// 他のオブジェクト（攻撃カード）がこのカードにドロップされた時の処理
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
        /// 攻撃
        // attackerを選択　マウスポインターに重なったカードをアタッカーにする
        // ドラッグされてきたカード（Attacker）を取得
        CardController attackCard = eventData.pointerDrag.GetComponent<CardController>();

        // 自分自身（Defender）を取得　
        CardController defenceCard = GetComponent<CardController>();

        // 攻撃カードが自分のカードで、かつ相手のカードに対してドロップされた場合
        if (attackCard.model.PlayerCard && defenceCard.model.PlayerCard == false)//attackCard.model.PlayerCard==true
        {
            // バトル処理を開始
            StartCoroutine(BattleManager.instance.CardBattle(attackCard, defenceCard));
        }
        
    }
}
