using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが作成した複数のデッキデータを保持・管理するクラス。
/// どのデッキを編集するか、どのデッキで対戦するかを中継する役割を持つ。
/// </summary>
public class DeckListManager : MonoBehaviour
{
    /// <summary> 現在選択されているデッキリスト </summary>
    public static List<int> deckList = new List<int>() { };
    
    public static int editDeckNum = 0; // 編集するデッキ番号を記録する変数

    /// <summary> 保存されているデッキデータ1 </summary>
    public static List<int> deckList1 = new List<int>() {3,4,5,9,9,10,11,10,11,12,13,14,15,15,15,18,19,20,21,22,23,27,28,29,30,31,32,39,40,41,42,47};
    
    /// <summary> 保存されているデッキデータ2  </summary>
    public static List<int> deckList2 = new List<int>() { };
    
    /// <summary> 保存されているデッキデータ3  </summary>
    public static List<int> deckList3 = new List<int>() { };


    /// <summary>
    /// デッキ選択ボタンが押された時の処理。
    /// 選択された番号のデッキデータをアクティブにする。
    /// </summary>
    public void PushDeckListButton(int deckListNum)
    {
        if (deckListNum == 1) deckList = deckList1;
        if (deckListNum == 2) deckList = deckList2;
        if (deckListNum == 3) deckList = deckList3;

        // 編集番号を記録
        editDeckNum = deckListNum;

        SoundManager.instance.PlaySE(0);
        StartCoroutine(DeckListButtom());
    }

    
    public void BackHomeButtom()// ホーム画面に移動するボタン
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(BackButtom());
    }

    public IEnumerator BackButtom()//BackHomeButtomで実行
    {
        yield return new WaitForSeconds(0.075f);
        
        SceneTransitionManager.instance.Load("Home");
    }

    
    public IEnumerator DeckListButtom()// デッキ編集画面へ遷移
    {
        yield return new WaitForSeconds(0.075f);
        
        SceneTransitionManager.instance.Load("Deck");
    }
}