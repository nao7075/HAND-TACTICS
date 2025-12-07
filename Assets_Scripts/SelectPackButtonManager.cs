using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 不使用
/// </summary>
public class SelectPackButtonManager : MonoBehaviour
{
    [SerializeField] Image packSelectButtonImage;
    [SerializeField] TextMeshProUGUI packNameText;

    int packID;

    public void SetButton(int packId)
    {
        PackEntity packEntity = Resources.Load<PackEntity>("PackEntityList/Pack" + packId);
        packSelectButtonImage.sprite = packEntity.packImage;
        packNameText.text = packEntity.packName;
        packID = packEntity.packId;
    }

    // ボタンが押された時の処理
    public void PushButtom()
    {
        ShopManager shopManager = GameObject.Find("ShopPanel").GetComponent<ShopManager>();
        shopManager.ShowPurchasePackPanel(packID); // パック購入パネルを表示させる
    }
}
