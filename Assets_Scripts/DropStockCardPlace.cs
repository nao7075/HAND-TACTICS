using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// デッキ編成画面で「所持カード（ストック）エリア」にカードがドロップされた時の処理。
/// つまり、デッキからカードを外す操作に対応する。
/// </summary>
public class DropStockCardPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) // ドロップされた時に行う処理
    {
        CardController card = eventData.pointerDrag.GetComponent<CardController>(); // ドラッグしてきた情報からCardMovementを取得

        if (card.movement != null) // もしカードがあれば、
        {
            if (!card.movement.canMove) return;

            Debug.Log(card.model.cardId);
            DeckEditManager deckEditManager = GameObject.Find("DeckEditManager").GetComponent<DeckEditManager>();
            
            // 所持カードとして戻す（枚数を増やす）
            deckEditManager.AddStockCard(card.model.cardId);
            
            // デッキ表示を更新（カードが減った状態を描画）
            if(deckEditManager.deckpage == 1)
            {
                deckEditManager.SetDeckCards1(); // 所持カードを再表示させる
            }
            
            else if(deckEditManager.deckpage == 2)
            {
                deckEditManager.SetDeckCards2(); // 所持カードを再表示させる
            }
            
            //deckEditManager.SetDeckCards();
            deckEditManager.SetStockCards();// 所持カード表示を更新
        }
    }
}
