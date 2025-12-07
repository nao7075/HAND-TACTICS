using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// フィールドにアタッチするクラス
/// <summary>
/// バトルフィールド（プレイエリア）へのドロップを受け付けるクラス。
/// 手札からフィールドへカードを出す処理を行う。
/// </summary>
public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) // ドロップされた時に行う処理
    {
        //CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); // ドラッグしてきた情報からCardMovementを取得
        CardController card = eventData.pointerDrag.GetComponent<CardController>(); // 今回の書き換え部分

        if (card != null) // もしカードがあれば、
        {
            if (card.model.canUse == true)  // 使用可能なカードなら(コスト条件等を満たしていれば)
            {
                card.Battlemovement.cardParent = this.transform; // カードの親要素を自分（アタッチされてるオブジェクト）にする 今回の書き換え部分
                card.DropField(); // カード使用処理（マナ消費、効果発動など）
            }
        }
    }
}
