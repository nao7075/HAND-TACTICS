using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// メニュー画面などのBGM再生を管理するクラス。
/// DontDestroyOnLoadによりシーンを跨いでBGMを流し続ける。
/// </summary>
public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;//シングルストン化
    [SerializeField] AudioSource BGMAudioSource;// BGMを再生するためのAudioSource（インスペクターで設定）

    // インスタンスの初期化処理
    private void Awake()
    {
        // インスタンスが存在しない場合
        if (instance == null)
        {
            // 自分自身をインスタンスとして設定
            instance = this;
            DontDestroyOnLoad(gameObject);// シーン遷移しても破壊されない
        }
        // すでにインスタンスが存在する場合（重複して生成された場合など）
        else if (instance != this)
        {
            Destroy(gameObject);// 重複したら自分を消す
            return;
        }
    }

    /// <summary>
    /// BGMの音量を設定する
    /// volume: 設定したい音量（0.0〜1.0）
    /// </summary>
    public void SetBGMVolume(float volume)
    {
        BGMAudioSource.volume = volume;
    }

    public AudioSource audioSourceSE;// SEを再生するためのAudioSource（インスペクターで設定、publicなので外部から参照可能）
    public AudioClip[] audioClipsSE;// index: 再生したいSEのインデックス（audioClipsSE配列の要素番号）

    /// <summary>
    /// 指定されたインデックスのSEを再生するメソッド
    ///</summary>
    /// <param name="index"> 再生したいSEのインデックス(audioClipsSE配列の要素番号) </param>
    public void PlaySE(int index)
    {
        // PlayOneShotを使って、SEを一度だけ再生
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}

