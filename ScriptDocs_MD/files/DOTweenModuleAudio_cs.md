# File: DOTweenModuleAudio.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Plugins/Demigiant/DOTween/Modules/DOTweenModuleAudio.cs`

<a id='DOTweenModuleAudio'></a>
## Class DOTweenModuleAudio
**Namespace:** `DG.Tweening`<br>
**Signature:** `DOTweenModuleAudio`

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S DOFade | AudioSource target, Single endValue, Single duration | `TweenerCore`3` | Tweens an AudioSource's volume to the given value.<br>Also stores the AudioSource as the tween's target so it can be used for filtered operations |
| `public` | S DOPitch | AudioSource target, Single endValue, Single duration | `TweenerCore`3` | Tweens an AudioSource's pitch to the given value.<br>Also stores the AudioSource as the tween's target so it can be used for filtered operations |
| `public` | S DOSetFloat | AudioMixer target, String floatName, Single endValue, Single duration | `TweenerCore`3` | Tweens an AudioMixer's exposed float to the given value.<br>Also stores the AudioMixer as the tween's target so it can be used for filtered operations.<br>Note that you need to manually expose a float in an AudioMixerGroup in order to be able to tween it from an AudioMixer. |
| `public` | S DOComplete | AudioMixer target, Boolean withCallbacks | `Int32` | Completes all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens completed<br>(meaning the tweens that don't have infinite loops and were not already complete) |
| `public` | S DOKill | AudioMixer target, Boolean complete | `Int32` | Kills all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens killed. |
| `public` | S DOFlip | AudioMixer target | `Int32` | Flips the direction (backwards if it was going forward or viceversa) of all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens flipped. |
| `public` | S DOGoto | AudioMixer target, Single to, Boolean andPlay | `Int32` | Sends to the given position all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens involved. |
| `public` | S DOPause | AudioMixer target | `Int32` | Pauses all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens paused. |
| `public` | S DOPlay | AudioMixer target | `Int32` | Plays all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens played. |
| `public` | S DOPlayBackwards | AudioMixer target | `Int32` | Plays backwards all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens played. |
| `public` | S DOPlayForward | AudioMixer target | `Int32` | Plays forward all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens played. |
| `public` | S DORestart | AudioMixer target | `Int32` | Restarts all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens restarted. |
| `public` | S DORewind | AudioMixer target | `Int32` | Rewinds all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens rewinded. |
| `public` | S DOSmoothRewind | AudioMixer target | `Int32` | Smoothly rewinds all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens rewinded. |
| `public` | S DOTogglePause | AudioMixer target | `Int32` | Toggles the paused state (plays if it was paused, pauses if it was playing) of all tweens that have this target as a reference<br>(meaning tweens that were started from this target, or that had this target added as an Id)<br>and returns the total number of tweens involved. |

---

