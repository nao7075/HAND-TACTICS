using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// バトルシーンにおけるカードの移動制御（ドラッグ＆ドロップ、攻撃モーション）を行うクラス
/// </summary>
public class BattleCardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler//マウス操作のクラス名
{
    /// <summary> カードが本来所属している親オブジェクト（フィールドや手札エリアなど）</summary>
    public Transform cardParent;

    /// <summary> カードをドラッグ操作できるかどうかのフラグ </summary>
    bool canDrag = true;

    /// <summary> ドラッグ開始前の親オブジェクトを一時保存する変数 </summary>
    Transform oriCardParent;// 

    /// <summary> ドラッグ開始前の兄弟順（描画順）を保存する変数 </summary>
    int cardIndex; 

    /// <summary> プレイヤーカードの初期位置（攻撃モーション時の戻り位置として使用） </summary>
    Vector3 playercardposition; 

    /// <summary>
    /// ドラッグ開始時の処理
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData) // ドラッグを始めるときに行う処理
    {
        CardController card = GetComponent<CardController>();
        canDrag = true;

        
        // 相手のカードは操作できない
        if (!card.model.PlayerCard)
        {
            canDrag = false;
        }

        if (card.model.FieldCard == false) // 手札のカードなら
        {
            if (card.model.canUse == false) // マナコストより少ないカードは動かせない
            {
                canDrag = false;
            }
        }
        else// 既にフィールドに出ている場合
        {
            if (card.model.canAttack == false) // 攻撃不可能なカードは動かせない
            {
                canDrag = false;
                
            }
        }

        if (canDrag == false)// 操作不可と判定されたら処理を中断
        {
            return;
        }
        // 現在の位置情報を保存（攻撃モーションの戻り先などで使用するため）
        playercardposition = transform.position;
        cardParent = transform.parent;
        oriCardParent = transform.parent;
        cardIndex = this.transform.GetSiblingIndex();

        // ドラッグ中は他のUIより手前に表示させるため、親を一時的にCanvas直下（または上位の親）に変更する
        transform.SetParent(cardParent.parent, false);

        // ドロップ先のオブジェクト（DropPlaceなど）がRaycastを検知できるように、自身のRaycastブロックを無効化する
        GetComponent<CanvasGroup>().blocksRaycasts = false; 
    }


    /// <summary>
    /// ドラッグ操作中に毎フレーム呼ばれるメソッド。
    /// カードの位置をマウスカーソル（タッチ位置）に追従させる。
    /// </summary>
    public void OnDrag(PointerEventData eventData) // ドラッグした時に起こす処理
    {
        if (canDrag == false)
        {
            return;
        }
        
        // カードの位置を現在のポインター位置に更新
        transform.position = eventData.position;
    }

    /// <summary>
    /// ドラッグ操作が終了した（指を離した）瞬間に呼ばれるメソッド。
    /// ドロップ処理が成功しなかった場合などに、カードを元の位置に戻す処理を行う。
    /// </summary>
    public void OnEndDrag(PointerEventData eventData) // カードを離したときに行う処理
    {
        if (canDrag == false)
        {
            return;
        }
        
        // 親オブジェクトを元の親（またはドロップ処理で更新された新しい親）に戻す
        transform.SetParent(cardParent, false);

        // 親が変わっていない（ドロップ失敗で元の場所に戻る）場合、並び順も元に戻す
        if (oriCardParent == cardParent)
        {
            transform.SetSiblingIndex(cardIndex);
        }

        // 次の操作のためにRaycastブロックを再度有効化する
        GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycastsをオンにする   
    }


    /// <summary>
    /// 敵カードが攻撃を行う際のアニメーション処理。
    /// ターゲットに向かって移動し、攻撃後に元の位置に戻る動きを演出する。
    /// </summary>
    /// <param name="target">攻撃対象（相手カードやリーダー）のTransform</param>
    public IEnumerator AttackMotion(Transform target)//敵カード側
    {
        // 現在位置を記憶（戻るため）
        Vector3 currentPosition = transform.position;//Dragを終えた地点がtransformParentになってしまい元の位置に戻らない
        cardParent = transform.parent;
        Debug.Log("transform.position:"+transform.position);
        Debug.Log("transform.parent:"+transform.parent);
        
        // 元の並び順を記憶
        int attackCardIndex = transform.GetSiblingIndex(); // 子要素の順

        // アニメーション中に隠れないよう、一時的に親を変更して最前面に表示,cardの親を一時的にCanvasにする
        transform.SetParent(cardParent.parent); 

        // DOTweenを使ってターゲット位置へ移動（InElasticで勢いをつける演出）
        transform.DOMove(target.position, 0.75f).SetEase(Ease.InElastic);
        yield return new WaitForSeconds(0.75f);

        // 元の位置に戻る
        transform.DOMove(currentPosition, 0.25f);
        yield return new WaitForSeconds(0.25f);

        // 攻撃ヒット音を再生
        SoundManager.instance.PlaySE(1); 

        transform.SetParent(cardParent); // cardの親を元に戻す
        transform.SetSiblingIndex(attackCardIndex); // 元の子要素の順番にセットする
    
    }
    

    /// <summary>
    /// プレイヤー側のカードが攻撃を行う際のアニメーション処理。
    /// ドラッグ操作後の位置ズレを防ぐための補正が含まれているバージョン。
    /// </summary>
    /// <param name="target">攻撃対象のTransform</param>
    public IEnumerator PlayerAttackMotion(Transform target)//バグ修正のためのプレイヤー側の
    {
        //cardParent = BattleManager.instance.playerField;
        cardParent = transform.parent;
        //int attackCardIndex = transform.GetSiblingIndex(); // 子要素の順
        //transform.SetSiblingIndex(attackCardIndex);

        // ドラッグ終了位置ではなく、ドラッグ開始時の正規の位置（playercardposition）を基準にする
        Vector3 currentPosition = playercardposition;//Dragを終えた地点がtransformParentになってしまい元の位置に戻らないのを防ぐ
        
        Debug.Log("transform.position:"+transform.position);
        Debug.Log("transform.parent:"+transform.parent);
        
        //transform.SetParent(cardParent.parent); // cardの親を一時的にCanvasにする

        // 念のため一瞬で元の位置に戻してからアニメーションを開始
        transform.DOMove(currentPosition,0.001f);
        yield return new WaitForSeconds(0.001f);

        // ターゲットへ突撃
        transform.DOMove(target.position, 0.75f).SetEase(Ease.InElastic);
        yield return new WaitForSeconds(0.75f);

        // 元の位置へ戻る
        transform.DOMove(currentPosition, 0.25f);
        yield return new WaitForSeconds(0.25f);

        SoundManager.instance.PlaySE(1); // 攻撃時の音を鳴らす
        cardParent = BattleManager.instance.playerField;
        transform.SetParent(cardParent); // cardの親を元に戻す
        transform.SetSiblingIndex(cardIndex); // 元の子要素の順番にセットする
    
    }

    
    /// <summary>
    /// カードがフィールドに召喚された時の登場アニメーション。
    /// 一瞬拡大してから元のサイズに戻ることで「ポンッ」と出たような演出を行う。
    /// </summary>
    public IEnumerator SummonMotion()
    {
        SoundManager.instance.PlaySE(2); // 召喚時の音を出す
        transform.DOScale(1.2f, 0.5f); // 0.5秒かけて1.2倍の大きさにする
        yield return new WaitForSeconds(0.5f); // 0.5秒待つ
        transform.DOScale(1.0f, 0.3f); // 0.5秒かけて元の大きさにする
        yield return new WaitForSeconds(0.5f); // 0.5秒待つ
    }

    /// <summary>
    /// スペルカードを使用した際のアニメーション。
    /// 大きく拡大して強調表示した後、消滅する演出を行う。
    /// </summary>
    public IEnumerator UseSpellMotion()
    {
        SoundManager.instance.PlaySE(3);

        yield return new WaitForSeconds(0.1f);
        transform.SetParent(transform.root);

        transform.DOScale(3.0f, 0.5f);
        yield return new WaitForSeconds(0.7f);
        transform.DOScale(5.0f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOScale(0.0f, 0.0f);
        yield return new WaitForSeconds(0.0f);
    }
}


/*
graph TD
    A[ドラッグ開始 (OnBeginDrag)] --> B{操作可能？};
    B -- No --> C[中断];
    B -- Yes --> D[描画順を最前面へ & Raycast無効化];
    D --> E[ドラッグ中 (OnDrag): 位置追従];
    E --> F[ドロップ (OnEndDrag)];
    F --> G{ドロップ成功？};
    G -- Yes --> H[ドロップ先の処理へ (DropPlaceなど)];
    G -- No --> I[元の位置に戻る & Raycast有効化];

    J[攻撃命令] --> K(PlayerAttackMotion);
    K --> L[ターゲットへ移動 (DOTween)];
    L --> M[ヒット音再生];
    M --> N[元の位置へ戻る];

*/