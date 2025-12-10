using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTweenの機能を使うために記載が必要
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// デッキ編集画面などにおける、カードの一般的な移動制御クラス。
/// ドラッグ＆ドロップによる移動や、クリック時の詳細表示を担当する。
/// </summary>
public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,IPointerClickHandler
{
    
    public bool canMove = false;// カードが移動可能かを示すフラグ（所持数0のカード等はfalseになる）

    /// <summary>
    /// パック開封時にカードが移動する処理(使わない)
    /// </summary>
    public IEnumerator ExpandThisCard(Transform moveTarget)
    {
        transform.SetParent(moveTarget); // 親要素を変更する
        transform.DOMove(moveTarget.position, 0.5f); // 0.5秒かけて指定の場所に移動
        yield return new WaitForSeconds(0.5f); // 0.5秒間処理を止める
    }

    /// <summary>
    /// ドラッグ開始処理
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData) 
    {   
        // 動かせないカードなら、処理を止める
        if (!canMove) return;
        
        // 親をCanvasに変更して最前面に表示
        Transform canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        transform.SetParent(canvas, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false; // blocksRaycastsをオフにする

        // デッキシーンならDropパネルを表示する
        if (SceneManager.GetActiveScene().name == "Deck")
        {
            DeckEditManager deckEditManager = GameObject.Find("DeckEditManager").GetComponent<DeckEditManager>();
            CardController card = GetComponent<CardController>(); // cardを取得
 
            // デッキのカードならデッキのリストから削除する
            if (card.model.isDeckCard) deckEditManager.RemoveDeckCard(card.model.cardId);
            
            // デッキのカードじゃないなら所持カードのリストから削除する
            if (!card.model.isDeckCard)
            {
                // 所持カードリストから削除する
                deckEditManager.RemoveStockCard(card.model.cardId);
 
                deckEditManager.SetStockCards();
            }

            // ドロップ可能なエリア（DropPanels）を表示
            deckEditManager.ShowDropPanels(true);
        }
    }
 
    public void OnDrag(PointerEventData eventData) // ドラッグした時に起こす処理
    {
        // 動かせないカードなら、処理を止める
        if (!canMove) return;
        transform.position = eventData.position;// マウス追従
    }

    /// <summary>
    /// ドラッグ終了処理
    /// </summary>
    public void OnEndDrag(PointerEventData eventData) // カードを離したときに行う処理
    {
        // 動かせないカードなら、処理を止める
        if (!canMove) return;

        // デッキシーンならDropパネルを非表示にする
        if (SceneManager.GetActiveScene().name == "Deck")
        {
            DeckEditManager deckEditManager = GameObject.Find("DeckEditManager").GetComponent<DeckEditManager>();
            deckEditManager.ShowDropPanels(false);
        }
        SoundManager.instance.PlaySE(3);

        // ドロップ処理完了後、この一時的なドラッグ用オブジェクトは破棄される
        // （各DropPlaceスクリプト側で、正規の場所に新しいカードが生成される仕組みになっている）
        Destroy(this.gameObject);
    }

    /// <summary>
    /// カードクリック時の処理。詳細パネルを表示する。
    /// </summary>
    public void OnPointerClick(PointerEventData eventData) 
    {
        CardController thisCard = this.GetComponent<CardController>();
 
        // 相手の手札の場合は詳細パネルを表示しない
        if (thisCard.model.PlayerCard == false && thisCard.model.FieldCard == false)
        {
            return;
        }

        // カード詳細パネルを生成する
        GameManager.instance.CreateCardDetailsPanel(thisCard);
    }
}
