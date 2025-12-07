using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内のSE（効果音）再生を一元管理するクラス。
/// シングルトンとして動作する（各シーンに配置されているパターンもある）。
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; //シングルストン化
    [SerializeField] AudioSource seAudioSource;// SEを再生するためのAudioSource（インスペクターで設定）

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// SEの音量を設定する
    /// </summary>
    public void SetSEVolume(float volume)
    {
        seAudioSource.volume = volume;
    }


    public AudioSource audioSourceSE;// SEを再生するためのAudioSource（インスペクターで設定、publicなので外部から参照可能）
    public AudioClip[] audioClipsSE;// index: 再生したいSEのインデックス（audioClipsSE配列の要素番号）

    /// <summary>
    /// 指定されたインデックスのSEを再生する
    /// </summary>
    public void PlaySE(int index)
    {
        // PlayOneShotを使って、SEを一度だけ再生
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}
