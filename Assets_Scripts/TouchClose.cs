using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// クリック（タップ）された時に、開いている詳細パネルを閉じるクラス。
/// パネル外の背景などにアタッチして使用する。
/// </summary>
public class TouchClose : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) // クリックされた時に実行される
    {
        // カード詳細パネルを取得する
        CardDetailPanel cardDetailPanel = GameObject.Find("CardDetailPanel(Clone)").GetComponent<CardDetailPanel>();

        // カード詳細パネルを削除する
        cardDetailPanel.DestoyCardDetailPanel();
    }
}