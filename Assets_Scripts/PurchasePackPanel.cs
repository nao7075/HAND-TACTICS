using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 不使用
/// </summary>
public class PurchasePackPanel : MonoBehaviour
{
    [SerializeField] Transform packImageTrans;
    [SerializeField] TextMeshProUGUI purchasePackCountText; // パック購入数のテキスト

    public static int purchasePackCount = 0; // パック購入数 staticに変更
    public static int purchasePackID = 0; // 購入するパックのID
    // パネルをセットする
    public void SetPanel(int packId)
    {
        // パックのイメージ画像を破壊する
        foreach (Transform packImage in packImageTrans)
        {
            Destroy(packImage.gameObject);
        }

        // パックのイメージ画像を出す
        ShopManager shopManager = GameObject.Find("ShopPanel").GetComponent<ShopManager>();
        shopManager.CreateSelectPackButton(packId, packImageTrans);

        // 変数の初期化後、購入するパックの数を表示させる
        purchasePackCount = 0;
        SetPurchasePackCountText();

        // 購入するパックのIDを代入する
        purchasePackID = packId;
    }

    // パック購入数のテキストに購入数を反映させる
    void SetPurchasePackCountText()
    {
        purchasePackCountText.text = purchasePackCount.ToString();
    }

        // パック購入数の変更ボタンを押した時の処理
    public void PushChangePurchasePackCountButton(int changeCount)
    {
        purchasePackCount += changeCount;

        if (purchasePackCount < 0) purchasePackCount = 0;
        if (purchasePackCount >= 10) purchasePackCount = 10;

        SetPurchasePackCountText();
    }

    public void PushOKButtom()
    {
        if (purchasePackCount == 0) return;

        // Packシーンに切り替える
        SceneTransitionManager.instance.Load("Pack");
    }
}