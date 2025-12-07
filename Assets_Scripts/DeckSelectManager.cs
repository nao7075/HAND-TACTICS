using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// 対戦前に使用するデッキを選択する画面の管理クラス。
/// デッキ枚数が規定（32枚）に満たない場合は選択できないように制御する。
/// </summary>
public class DeckSelectManager : MonoBehaviour
{
    [SerializeField] Button Deck1Button; //対戦デッキ1ボタン
    [SerializeField] Button Deck2Button; //対戦デッキ2ボタン
    [SerializeField] Button Deck3Button; //対戦デッキ3ボタン
    [SerializeField] GameObject Deck1Error; //枚数不足時のエラー表示
    [SerializeField] GameObject Deck2Error; //枚数不足時のエラー表示
    [SerializeField] GameObject Deck3Error; //枚数不足時のエラー表示
    public static List<int> deckList = new List<int>() { };//対戦デッキデータを格納するリスト

    /// <summary>
    /// デッキ選択ボタン押下時の処理。
    /// 選択されたデッキをバトル用デッキとして設定する。
    /// </summary>
    public void PushDeckSelectButton(int deckListNum)
    {
        if (deckListNum == 1) deckList = DeckListManager.deckList1;
        if (deckListNum == 2) deckList = DeckListManager.deckList2;
        if (deckListNum == 3) deckList = DeckListManager.deckList3;


        SoundManager.instance.PlaySE(0);
        StartCoroutine(DeckSelectButtom());
    }

    
    public void BackHomeButtom()// ホーム画面に移動するボタン
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(BackButtom());
    }

    public IEnumerator BackButtom()//BackHomeButtomで実行する
    {
        yield return new WaitForSeconds(0.075f);
        
        SceneTransitionManager.instance.Load("Home");
    }

    
    public IEnumerator DeckSelectButtom()// マッチング画面へ遷移
    {
        yield return new WaitForSeconds(0.075f);
        
        SceneTransitionManager.instance.Load("Matching");
    }
    

    /// <summary>
    /// 画面表示時にデッキ枚数をチェックし、不備があるデッキのボタンを無効化する
    /// </summary>
    void OnEnable()
    {

        Deck1Error.SetActive(false);
        Deck2Error.SetActive(false);
        Deck3Error.SetActive(false);

        // デッキ1の枚数チェック (32枚でなければエラー)
        if(DeckListManager.deckList1.Count != 32)
        {
            Deck1Error.SetActive(true);
            Deck1Button.interactable = false;
        }
        // デッキ2
        if(DeckListManager.deckList2.Count != 32)
        {
            Deck2Error.SetActive(true);
            Deck2Button.interactable = false;
        }
        // デッキ3
        if(DeckListManager.deckList3.Count != 32)
        {
            Deck3Error.SetActive(true);
            Deck3Button.interactable = false;
        }
    }
    
}