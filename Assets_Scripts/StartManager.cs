using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面（Start Scene）の制御クラス
/// </summary>
public class StartManager : MonoBehaviour
{
    
    public IEnumerator StartButtom()//Homeシーンへ移動する
    {
        yield return new WaitForSeconds(1f); // 演出用のウェイト
        
        SceneTransitionManager.instance.Load("Home");
    }
    

    /// <summary>
    /// 画面タップ（スタートボタン）時の処理
    /// </summary>
    public void PushStartButtom()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(StartButtom());
    }
    

}
