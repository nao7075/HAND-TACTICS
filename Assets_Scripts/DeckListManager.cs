using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが作成した複数のデッキデータを保持・管理し、永続化（保存・読み込み）を行うクラス。
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


    private void Start()// ゲーム開始時に保存されたデータを読み込む
    {
        LoadDeckData();
    }

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

    // --- 保存・読み込み機能 ---

    /// <summary>
    /// 現在のデッキリストの状態をPlayerPrefsに保存する
    /// </summary>
    public static void SaveDeckData()
    {
        // List<int> を JSON文字列に変換
        string json1 = JsonUtility.ToJson(new Serialization<int>(deckList1));
        string json2 = JsonUtility.ToJson(new Serialization<int>(deckList2));
        string json3 = JsonUtility.ToJson(new Serialization<int>(deckList3));

        // PlayerPrefsに書き込み
        PlayerPrefs.SetString("Deck1", json1);
        PlayerPrefs.SetString("Deck2", json2);
        PlayerPrefs.SetString("Deck3", json3);
        
        // 保存を確定
        PlayerPrefs.Save();
        Debug.Log("Deck Data Saved.");
    }

    /// <summary>
    /// PlayerPrefsからデッキデータを読み込む
    /// </summary>
    public void LoadDeckData()
    {
        // 保存データが存在する場合のみ読み込む
        if (PlayerPrefs.HasKey("Deck1"))
        {
            string json1 = PlayerPrefs.GetString("Deck1");
            deckList1 = JsonUtility.FromJson<Serialization<int>>(json1).ToList();
        }
        
        if (PlayerPrefs.HasKey("Deck2"))
        {
            string json2 = PlayerPrefs.GetString("Deck2");
            deckList2 = JsonUtility.FromJson<Serialization<int>>(json2).ToList();
        }

        if (PlayerPrefs.HasKey("Deck3"))
        {
            string json3 = PlayerPrefs.GetString("Deck3");
            deckList3 = JsonUtility.FromJson<Serialization<int>>(json3).ToList();
        }
        
        Debug.Log("Deck Data Loaded.");
    }
}

// List<T> を JsonUtility でシリアライズ可能にするためのラッパークラス
[System.Serializable]
public class Serialization<T>
{
    [SerializeField]
    List<T> target;
    public List<T> ToList() { return target; }

    public Serialization(List<T> target)
    {
        this.target = target;
    }
}
