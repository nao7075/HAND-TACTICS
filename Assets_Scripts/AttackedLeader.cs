using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// リーダーオブジェクトにアタッチし、リーダーへの攻撃ドロップを受け付けるクラス
/// </summary>
public class AttackedLeader : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// マウスポインターに重なったカードをアタックカードにして、リーダーへの攻撃の処理をする。
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
        /// 攻撃
        // attackerを選択　マウスポインターに重なったカードをアタッカーにする
        // ドラッグされてきた攻撃カードを取得
        CardController attackCard = eventData.pointerDrag.GetComponent<CardController>();

        // リーダーへの攻撃処理を開始
        StartCoroutine(BattleManager.instance.AttackToLeader(attackCard, true));
    }
}
