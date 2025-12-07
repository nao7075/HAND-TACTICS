
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移時のフェードイン・フェードアウト演出を管理するクラス。
/// DontDestroyOnLoadによりシーンを跨いで存在し続ける。
/// </summary>
public class SceneFadeManager : MonoBehaviour
{
    
    private bool isFadeOut = false; //フェードアウト処理の開始、完了を管理するフラグ
    
    private bool isFadeIn = true; //フェードイン処理の開始、完了を管理するフラグ
    
    float fadeSpeed = 0.75f; //透明度が変わるスピード
    
    public Image fadeImage; //画面をフェードさせるための画像をパブリックで取得

    float red, green, blue, alfa; //フェードアウト開始時の画像のRGBA値
    
    string afterScene; //シーン遷移のための型

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SetRGBA(0, 0, 0, 1);
        //シーン遷移が完了した際にフェードインを開始するように設定
        SceneManager.sceneLoaded += fadeInStart;
    }
    
    void fadeInStart(Scene scene,LoadSceneMode mode)//シーン遷移が完了した際にフェードインを開始するように設定
    {
        isFadeIn = true;
    }
    /// <summary>
    /// フェードアウト開始時の画像のRGBA値と次のシーン名を指定
    /// </summary>
    /// <param name="red">画像の赤成分</param>
    /// <param name="green">画像の緑成分</param>
    /// <param name="blue">画像の青成分</param>
    /// <param name="alfa">画像の透明度</param>
    /// <param name="nextScene">遷移先のシーン名</param>
    public void fadeOutStart(int red,int green,int blue,int alfa,string nextScene)
    {
        SetRGBA(red, green, blue, alfa);
        SetColor();
        isFadeOut = true;
        afterScene = nextScene;
    }
    // Update is called once per frame
    void Update()
    {
        if (isFadeIn == true)
        {
            //不透明度を徐々に下げる
            alfa -= fadeSpeed * Time.deltaTime;
            //変更した透明度を画像に反映させる関数を呼ぶ
            SetColor();
            if (alfa <= 0)
                isFadeIn = false;
        }
        if (isFadeOut == true)
        {
            //不透明度を徐々に上げる
            alfa += fadeSpeed * Time.deltaTime;
            //変更した透明度を画像に反映させる関数を呼ぶ
            SetColor();
            if (alfa >= 1)
            {
                isFadeOut = false;
                SceneManager.LoadScene(afterScene);
            }
        }
    }
    
    void SetColor()//画像に色を代入する関数
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    
    public void SetRGBA(int r, int g, int b, int a)//色の値を設定するための関数
    {
        red = r;
        green = g;
        blue = b;
        alfa = a;
    }
}


