using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ホーム画面のボタン操作とシーン遷移を管理するクラス
/// </summary>
public class HomeManager : MonoBehaviour
{
    public IEnumerator DeckButtom()//DeckListへシーン遷移するボタン
    {
        yield return new WaitForSeconds(0.075f);
        
        SceneTransitionManager.instance.Load("DeckList");
    }
    public IEnumerator ShopButtom()//Shop"へシーン遷移するボタン
    {
        yield return new WaitForSeconds(0.075f);
        SceneTransitionManager.instance.Load("Shop");
    }
    public IEnumerator BattleButtom()//DeckSelectへシーン遷移するボタン
    {
        yield return new WaitForSeconds(0.075f);
        SceneTransitionManager.instance.Load("DeckSelect");
    }

    // 各ボタンクリック時の処理（SE再生 -> 遷移コルーチン開始）
    
    public void PushDeckButtom()//PushDeckButtomを押したときのSE再生
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(DeckButtom());
    }
    public void PushShopButtom()//PushShopButtomを押したときのSE再生
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(ShopButtom());
    }
    public void PushBattleButtom()//PushBattleButtomを押したときのSE再生
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(BattleButtom());
    }

}