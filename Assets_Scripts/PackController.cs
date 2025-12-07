using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 不使用
/// </summary>
public class PackController : MonoBehaviour, IPointerClickHandler
{
    // クリックしたときに実行される処理
    public void OnPointerClick(PointerEventData eventData)
    {
        OpenThisPack();
    }

    // カードを生成して、パックを破壊する
    void OpenThisPack()
    {
        // OpenPackManagerを取得
        OpenPackManager openPackManager = GameObject.Find("OpenPackManager").GetComponent<OpenPackManager>();

        // Cardを生成する
        openPackManager.OpenPack();

        // Packオブジェクトを破壊する
        DestroyPack();
    }

    // Packオブジェクトを破壊する
    void DestroyPack()
    {
        Destroy(this.gameObject);
    }
}
