using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// デッキ編成画面で「デッキエリア」にカードがドロップされた時の処理
/// </summary>
public class DropDeckCardPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) // ドロップされた時に行う処理
    {
        CardController card = eventData.pointerDrag.GetComponent<CardController>(); // ドラッグしてきた情報からCardMovementを取得

        if (card.movement != null) // もしカードがあれば、
        {
            if (!card.movement.canMove) return;
            Debug.Log(card.model.cardId);
            DeckEditManager deckEditManager = GameObject.Find("DeckEditManager").GetComponent<DeckEditManager>();
            /*if (deckEditManager.deckCardsList.Count == 16) deckEditManager.AddStockCard(card.model.cardId); // デッキが16枚なら、所持カードに追加する
            if (deckEditManager.deckCardsList.Count < 16) deckEditManager.AddDeckCard(card.model.cardId); // デッキが15枚以下なら、デッキに追加する*/
            //deckEditManager.SetDeckCards(card.model.cardId);
            //deckEditManager.AddDeckCard(card.model.cardId); //ドロップしたカードをデッキに追加する

            // 現在のページやカード数に応じて、デッキに追加するかストックに戻すかを判定
            if(deckEditManager.deckpage == 1 && deckEditManager.deckCardsList.Count == 16)
            {
                deckEditManager.AddStockCard(card.model.cardId); // デッキが16枚なら、所持カードに追加する
                deckEditManager.SetDeckCards1(); // 所持カードを再表示させる
            }
            else if(deckEditManager.deckpage == 1 && deckEditManager.deckCardsList.Count < 16)
            {
                deckEditManager.AddDeckCard(card.model.cardId); // デッキが15枚以下なら、デッキに追加する
                deckEditManager.SetDeckCards1(); // 所持カードを再表示させる
            }
            else if(deckEditManager.deckpage == 2 && deckEditManager.deckCardsList.Count == 32)
            {
                deckEditManager.AddStockCard(card.model.cardId); // デッキが32枚なら、所持カードに追加する
                deckEditManager.SetDeckCards2(); // 所持カードを再表示させる
            }
            else if(deckEditManager.deckpage == 2 && deckEditManager.deckCardsList.Count < 32)
            {
                deckEditManager.AddDeckCard(card.model.cardId); // デッキが32枚未満なら、デッキに追加する
                deckEditManager.SetDeckCards2(); // 所持カードを再表示させる
            }
            
            deckEditManager.SetStockCards(); // 所持カードを再表示させる
        }
    }
}
