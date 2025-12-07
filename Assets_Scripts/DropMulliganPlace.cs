using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// フィールドにアタッチするクラス
/// <summary>
/// バトル開始時のマリガン画面で、カード交換用エリアへのドロップを受け付けるクラス
/// </summary>
public class DropMulliganPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) // ドロップされた時に行う処理
    {
        //CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); // ドラッグしてきた情報からCardMovementを取得
        CardController card = eventData.pointerDrag.GetComponent<CardController>(); // 今回の書き換え部分

        if (card != null) // もしカードがあれば、
        {
            if (card.model.canUse == true)  // 使用可能なカードなら(マリガン可能な状態なら)
            {
                card.Battlemovement.cardParent = this.transform; // カードの親要素を自分（アタッチされてるオブジェクト）にする 今回の書き換え部分
                card.DropMulliganField();// マリガンフィールドへの移動処理
            }
        }
    }
}
