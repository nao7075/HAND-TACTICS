using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UIのスライダー操作を受け取り、各サウンドマネージャーに音量変更を伝えるクラス。
/// </summary>
public class VolumeSlider : MonoBehaviour
{
  
  // volume: スライダーの値（通常は0.0〜1.0）
  // スライダーの「On Value Changed」イベントに登録して使用する
  
  public void SetBattleBGMVolume(float volume)// バトルBGMの音量を変更するメソッド
  {
    // シングルトンであるBattleBgmManagerにアクセスして音量を設定
    BattleBgmManager.instance.SetBattleBGMVolume(volume);
  }

  public void SetBGMVolume(float volume)// メニューBGMの音量を変更するメソッド
  {
    // シングルトンであるBGMManagerにアクセスして音量を設定
    BGMManager.instance.SetBGMVolume(volume);
  }

  public void SetSEVolume(float volume)// SE（効果音）の音量を変更するメソッド
  {
    // シングルトンであるSoundManagerにアクセスして音量を設定
    SoundManager.instance.SetSEVolume(volume);
  }
}
