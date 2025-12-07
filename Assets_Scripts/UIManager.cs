using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ゲーム内のUI（ユーザーインターフェース）を一元管理するクラス。
/// 各種パネルの表示切り替え、テキスト更新、ボタンの挙動制御などを行う。
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject changeTurnPanel;    // ターン切り替え時のカットインパネル
    [SerializeField] GameObject GameEndPanel;       // リザルト（勝敗）パネル
    [SerializeField] GameObject LeftPlayerPanel;    // 相手切断時の通知パネル
    [SerializeField] GameObject GearPanel;          // 設定（歯車）パネル
    [SerializeField] GameObject SoundPanel;         // サウンド設定パネル
    [SerializeField] TextMeshProUGUI changeTurnText;// ターン切り替えテキスト
    [SerializeField] TextMeshProUGUI GameEndText;   // 勝敗テキスト
    [SerializeField] GameObject restartGameButton;  // 再戦ボタン
    [SerializeField] GameObject BackHomeButton;     // ホームへ戻るボタン
    [SerializeField] GameObject BackHomeButton2;    // 切断時のホームへ戻るボタン
    [SerializeField] GameObject GearButton;         // 設定ボタンアイコン
    [SerializeField] GameObject SoundButton;        // サウンドボタンアイコン
    [SerializeField] GameObject BackHomeButton3;    // 設定画面内のホームボタン
    [SerializeField] GameObject CloseButton;        // 設定画面を閉じるボタン
    [SerializeField] GameObject SoundCloseButton;   // サウンド画面を閉じるボタン
    //[SerializeField] TextMeshProUGUI retryMessage;
    [SerializeField] GameObject MulliganPanel;      // マリガン（手札引き直し）画面

    [SerializeField] GameObject JankenPanel;        // じゃんけん選択画面全体
    [SerializeField] GameObject PlayerJankenPanel;  // プレイヤーの選択肢パネル
    [SerializeField] GameObject EnemyJankenPanel;   // 相手の選択肢パネル
    [SerializeField] GameObject PGPanel;            // Player Goo Panel
    [SerializeField] GameObject PCPanel;            // Player Choki Panel
    [SerializeField] GameObject PPPanel;            // Player Pa Panel
    [SerializeField] GameObject EGPanel;            // Enemy Goo Panel
    [SerializeField] GameObject ECPanel;            // Enemy Choki Panel
    [SerializeField] GameObject EPPanel;            // Enemy Pa Panel
    [SerializeField] GameObject PGButton;           // グーボタン
    [SerializeField] GameObject PCButton;           // チョキボタン
    [SerializeField] GameObject PPButton;           // パーボタン
    [SerializeField] GameObject EGButton;           // 敵グー表示（アイコン）
    [SerializeField] GameObject ECButton;           // 敵チョキ表示
    [SerializeField] GameObject EPButton;           // 敵パー表示

    [SerializeField] GameObject EGHidePanel;        // 敵の選択隠し用パネル（グー）
    [SerializeField] GameObject ECHidePanel;        // 敵の選択隠し用パネル（チョキ）
    [SerializeField] GameObject EPHidePanel;        // 敵の選択隠し用パネル（パー）

    [SerializeField] GameObject PGResultPanel;      // 自分のじゃんけん結果表示
    [SerializeField] GameObject PCResultPanel;      // 自分のじゃんけん結果表示
    [SerializeField] GameObject PPResultPanel;      // 自分のじゃんけん結果表示

    [SerializeField] GameObject EGResultPanel;      // 敵のじゃんけん結果表示
    [SerializeField] GameObject ECResultPanel;      // 敵のじゃんけん結果表示
    [SerializeField] GameObject EPResultPanel;      // 敵のじゃんけん結果表示

    [SerializeField] GameObject JankenCountPanel;   // 手札のじゃんけん内訳表示

//0,160,255,128(青系)
//255,0,0,128  (赤系)

    /// <summary>
    /// ターン切り替え時のカットイン演出を表示するコルーチン
    /// </summary>
    public IEnumerator ShowChangeTurnPanel()
    {
        //yield return null; 
        changeTurnPanel.SetActive(true);
        changeTurnText.color = Color.white;
        changeTurnText.fontSize = 200;

        // どちらのターンかに応じてテキストと背景色を変更
        if (BattleManager.instance.isPlayerTurn == true)
        {
            changeTurnPanel.GetComponent<Image>().color = new Color32(0,160,255,170);
            changeTurnText.text = "Your Turn";
        }
        else
        {
            changeTurnPanel.GetComponent<Image>().color = new Color32(255,0,0,140);
            changeTurnText.text = "Enemy Turn";
        }
        
        yield return new WaitForSeconds(2);// 2秒間表示

        changeTurnPanel.SetActive(false);
    }


    /// <summary>
    /// ゲーム終了時（勝敗決定時）のパネルを表示する
    /// </summary>
    public void ShowGameEndPanel(bool isPlayerWinnig)
    {
        GameEndPanel.SetActive(true);
        restartGameButton.SetActive(true);
        BackHomeButton.SetActive(true);
        GameEndText.fontSize = 150;
        if (isPlayerWinnig == true)
        {
            GameEndText.color = Color.yellow;
            GameEndText.text = "You Win!";
            SoundManager.instance.PlaySE(14);// 勝利音
        }
        else
        {
            GameEndText.color = Color.red;
            GameEndText.text = "You Lose...";
            SoundManager.instance.PlaySE(15);// 敗北音
        }
    }

    /// <summary>
    /// 再戦待機中のメッセージを表示する
    /// </summary>
    public void ShowRetryMessage()
    {
        GameEndText.color = Color.white;
        GameEndText.fontSize = 70;
        GameEndText.text = "相手が再戦を希望しました";
    }

    /// <summary>
    /// 相手の選択待ちメッセージを表示する
    /// </summary>
    public void WaitMessage()
    {
        GameEndText.color = Color.white;
        GameEndText.fontSize = 70;
        GameEndText.text = "相手の選択を待っています";
    }

    /// <summary>
    /// 相手が切断（退出）した際のパネルを表示する
    /// </summary>
    public void ShowLeftPlayerPanel()
    {
        LeftPlayerPanel.SetActive(true);
        BackHomeButton2.SetActive(true);
    }

    /// <summary>
    /// リザルトパネルを非表示にする（再戦時など）
    /// </summary>
    public void HideGameEndPanel()
    {
        BackHomeButton.SetActive(false);
        restartGameButton.SetActive(false);
        GameEndPanel.SetActive(false);
    }

    /// <summary>
    /// 退出通知パネルを非表示にする（再戦時など）
    /// </summary>
    public void HideLeftPlayerPanel()
    {
        LeftPlayerPanel.SetActive(false);
        BackHomeButton.SetActive(false);

    }
    
    /// <summary>
    /// じゃんけんフェイズのUI一式を表示する
    /// </summary>
    public void ShowJankenPanel()
    {
        JankenPanel.SetActive(true);
        PlayerJankenPanel.SetActive(true);
        EnemyJankenPanel.SetActive(true);
        // 全ての手のパネルとボタンをアクティブ化
        PGPanel.SetActive(true);
        PCPanel.SetActive(true);
        PPPanel.SetActive(true);
        EGPanel.SetActive(true);
        ECPanel.SetActive(true);
        EPPanel.SetActive(true);
        PGButton.SetActive(true);
        PCButton.SetActive(true);
        PPButton.SetActive(true);
        EGButton.SetActive(true);
        ECButton.SetActive(true);
        EPButton.SetActive(true);
    }

    /// <summary>
    /// じゃんけんUIを全て非表示にする
    /// </summary>
    public void HideAllJankenPanel()
    {
        JankenPanel.SetActive(false);
        PlayerJankenPanel.SetActive(false);
        EnemyJankenPanel.SetActive(false);
        PGPanel.SetActive(false);
        PCPanel.SetActive(false);
        PPPanel.SetActive(false);
        EGPanel.SetActive(false);
        ECPanel.SetActive(false);
        EPPanel.SetActive(false);
        PGButton.SetActive(false);
        PCButton.SetActive(false);
        PPButton.SetActive(false);
        EGButton.SetActive(false);
        ECButton.SetActive(false);
        EPButton.SetActive(false);
    }

    /// <summary>
    /// プレイヤーが手を選んだ後、選ばなかった手を非表示にする
    /// </summary>
    /// <param name="PHand">選んだ手（1:グー, 2:チョキ, 3:パー）</param>
    public void HideP2JankenPanel(int PHand)//プレイヤーの押したボタン以外をオフにする
    {
        if(PHand==1)//gu
        {
            // グー以外を非表示
            //PGButton.SetActive(false);
            PCButton.SetActive(false);
            PPButton.SetActive(false);
            PCPanel.SetActive(false);
            PPPanel.SetActive(false);
            
        }
        else if(PHand==2)//choki
        {
            PGButton.SetActive(false);
            //PCButton.SetActive(false);
            PPButton.SetActive(false);
            PGPanel.SetActive(false);
            PPPanel.SetActive(false);
            
        }
        else if(PHand==3)//pa
        {
            PGButton.SetActive(false);
            PCButton.SetActive(false);
            //PPButton.SetActive(false);
            PGPanel.SetActive(false);
            PCPanel.SetActive(false);
            
        }
        
    }

    /// <summary>
    /// 相手が手を選んだ後（同期後）、選ばなかった手を非表示にする
    /// </summary>
    public void HideE2JankenPanel(int EHand)//敵の押したボタン以外をオフにする
    {

        if(EHand==1)//egu
        {
            EGHidePanel.SetActive(true);

            //EGButton.SetActive(false);
            ECButton.SetActive(false);
            EPButton.SetActive(false);
            ECPanel.SetActive(false);
            EPPanel.SetActive(false);
            
        }
        else if(EHand==2)//echoki
        {
            ECHidePanel.SetActive(true);

            EGButton.SetActive(false);
            //ECButton.SetActive(false);
            EPButton.SetActive(false);
            EGPanel.SetActive(false);
            EPPanel.SetActive(false);
            
        }
        else if(EHand==3)//epa
        {
            EPHidePanel.SetActive(true);

            EGButton.SetActive(false);
            ECButton.SetActive(false);
            //EPButton.SetActive(false);
            EGPanel.SetActive(false);
            ECPanel.SetActive(false);
            
        }
        
    }

    /// <summary>
    /// プレイヤーのじゃんけん結果（リーダー横のアイコン）を表示する
    /// </summary>
    public void PlayerResultPanel(int result)
    {   
        PGResultPanel.SetActive(false);
        PCResultPanel.SetActive(false);
        PPResultPanel.SetActive(false);
        if(result==1)
        {
            PGResultPanel.SetActive(true);
        }
        else if(result==2)
        {
            PCResultPanel.SetActive(true);
        }
        else if(result==3)
        {
            PPResultPanel.SetActive(true);
        }
    }

    /// <summary>
    /// 相手のじゃんけん結果を表示する
    /// </summary>
    public void EnemyResultPanel(int result)
    {   
        EGResultPanel.SetActive(false);
        ECResultPanel.SetActive(false);
        EPResultPanel.SetActive(false);
        if(result==1)
        {
            EGResultPanel.SetActive(true);
        }
        else if(result==2)
        {
            ECResultPanel.SetActive(true);
        }
        else if(result==3)
        {
            EPResultPanel.SetActive(true);
        }
    }

    /// <summary>
    /// じゃんけん結果表示をリセットする
    /// </summary>
    public void HideResultPanel()
    {   
        EGResultPanel.SetActive(false);
        ECResultPanel.SetActive(false);
        EPResultPanel.SetActive(false);
        PGResultPanel.SetActive(false);
        PCResultPanel.SetActive(false);
        PPResultPanel.SetActive(false);
    }

    /// <summary>
    /// 相手の手の隠しパネル（？マーク）を外して正解を表示する
    /// </summary>
    public void EHidePanel(int EHand)
    {
        if(EHand==1)//egu
        {
            EGHidePanel.SetActive(false);
        }
        else if(EHand==2)//echoki
        {
            ECHidePanel.SetActive(false);
        }
        else if(EHand==3)//epa
        {
            EPHidePanel.SetActive(false);
        }
    }

    /// <summary>
    /// 設定（ギア）パネルを開く
    /// </summary>
    public void OpenGearPanel()//ギアボタンに着ける処理
    {
        SoundManager.instance.PlaySE(16);
        GearButton.SetActive(false);
        GearPanel.SetActive(true);
        BackHomeButton3.SetActive(true);
        CloseButton.SetActive(true);
    }

    /// <summary>
    /// 設定（ギア）パネルを閉じる
    /// </summary>
    public void CloseGearPanel()
    {
        SoundManager.instance.PlaySE(17);
        GearPanel.SetActive(false);
        BackHomeButton3.SetActive(false);
        CloseButton.SetActive(false);
        GearButton.SetActive(true);
    }

    /// <summary>
    /// サウンド設定パネルを開く
    /// </summary>
    public void OpenSoundPanel()//サウンドボタンに着ける処理
    {
        SoundManager.instance.PlaySE(16);
        SoundButton.SetActive(false);
        SoundPanel.SetActive(true);
        
        SoundCloseButton.SetActive(true);
    }

    /// <summary>
    /// サウンド設定パネルを閉じる
    /// </summary>
    public void CloseSoundPanel()
    {
        SoundManager.instance.PlaySE(17);
        SoundPanel.SetActive(false);
        
        SoundCloseButton.SetActive(false);
        SoundButton.SetActive(true);
    }

    /// <summary>
    /// マリガンパネルを開く
    /// </summary>
    public void OpenMulliganPanel()
    {
        MulliganPanel.SetActive(true);
    }

    /// <summary>
    /// マリガンパネルを閉じる
    /// </summary>
    public void CloseMulliganPanel()
    {
        MulliganPanel.SetActive(false);
    }

    /// <summary>
    /// じゃんけんカウントパネルを開く
    /// </summary>
    public void OpenJankenCountPanel()
    {
        JankenCountPanel.SetActive(true);
    }

    /// <summary>
    /// じゃんけんカウントパネルを閉じる
    /// </summary>
    public void CloseJankenCountPanel()
    {
        JankenCountPanel.SetActive(false);
    }
    
    
}