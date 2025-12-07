using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンのロード完了イベントを監視し、シーンに応じた処理（BGM切り替え等）を行うクラス。
/// </summary>
public class SceneTransitionHandler : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    private void OnEnable()
    {
        // シーンロード完了イベントの登録
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// シーンロード完了時に呼ばれる処理
    /// </summary>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // バトルシーンに入ったらメニューBGMを停止、それ以外なら再生
        if (BGMManager.instance != null)
        {
            if (scene.name == "Battle")
            {
                BGMManager.instance.gameObject.SetActive(false);
            }
            else
            {
                BGMManager.instance.gameObject.SetActive(true);
            }
        }
    }
}

