using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移を一元管理するクラス。
/// シングルトンとして常駐し、どのシーンからでもロードを呼び出せる。
/// </summary>
public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager instance; //シングルストン化

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 指定された名前のシーンをロードする
    /// </summary>
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
