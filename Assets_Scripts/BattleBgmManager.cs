using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルシーン専用のBGM管理クラス。
/// バトル用のBGM音量などを制御する。
/// </summary>
public class BattleBgmManager : MonoBehaviour
{
    public static BattleBgmManager instance;// シングルトン化：どこからでもアクセスできるようにするためのインスタンス
    [SerializeField] AudioSource BattleBgmAudioSource;// BGMを再生するためのAudioSource（インスペクターで設定）

    // インスタンスの初期化処理
    private void Awake()
    {
        // インスタンスが存在しない場合、自分自身をインスタンスとして設定
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// バトルBGMの音量を設定する
    /// </summary>
    public void SetBattleBGMVolume(float volume)
    {
        BattleBgmAudioSource.volume = volume;
    }

    public AudioSource audioSourceSE;// SEを再生するためのAudioSource（インスペクターで設定、publicなので外部から参照可能）
    public AudioClip[] audioClipsSE;// 再生するSEのクリップリスト（インスペクターで設定、publicなので外部から参照可能）

    /// <summary>
    /// 指定されたインデックスのSEを再生するメソッド
    ///</summary>
    /// <param name="index"> 再生したいSEのインデックス(audioClipsSE配列の要素番号) </param>
    public void PlaySE(int index)
    {
        // PlayOneShotを使って、SEを一度だけ再生（BGMのようにループしない）
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}
