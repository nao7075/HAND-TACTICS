using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不使用
/// </summary>
public class ShopManager : MonoBehaviour
{
    [SerializeField] SelectPackButtonManager selectPackButtonPrefab; // パック選択ボタンのプレハブ
    [SerializeField] Transform selectPackButtonTrans; // パック選択ボタンを生成する場所
    [SerializeField] GameObject purchasePackPanel; // パック購入パネル
    public List<int> packList = new List<int>() { 1, 2, 3, 4 }; // パックのIDリスト

    private void Start()
    {
        SetSelectPackButton();
    }

    // ショップ画面にパック選択ボタンをセットする
    void SetSelectPackButton()
    {
        for (int i = 0; i < packList.Count; i++)
        {
            CreateSelectPackButton(packList[i],selectPackButtonTrans);
        }
    }

    // パック選択ボタンを生成する
    public void CreateSelectPackButton(int packId,Transform transform)
    {
        SelectPackButtonManager button = Instantiate(selectPackButtonPrefab, transform);
        button.SetButton(packId);
    }

    // パック購入パネルを表示させる
    public void ShowPurchasePackPanel(int packId)
    {
        purchasePackPanel.SetActive(true);
        purchasePackPanel.GetComponent<PurchasePackPanel>().SetPanel(packId);
    }

        // ホーム画面に移動するボタン
    public void BackHomeButtom()
    {
        SceneTransitionManager.instance.Load("Home");
    }
    
}