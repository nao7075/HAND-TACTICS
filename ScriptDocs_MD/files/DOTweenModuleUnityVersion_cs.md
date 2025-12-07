# File: DOTweenModuleUnityVersion.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Plugins_Demigiant_DOTween_Modules.md)

> **Path:** `Assets/Plugins/Demigiant/DOTween/Modules/DOTweenModuleUnityVersion.cs`

<a id='DOTweenModuleUnityVersion'></a>
## Class DOTweenModuleUnityVersion
**Namespace:** `DG.Tweening`<br>
**Signature:** `DOTweenModuleUnityVersion`

> Shortcuts/functions that are not strictly related to specific Modules  
> but are available only on some Unity versions

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S DOGradientColor | Material target, Gradient gradient, Single duration | `Sequence` | Tweens a Material's color using the given gradient<br>(NOTE 1: only uses the colors of the gradient, not the alphas - NOTE 2: creates a Sequence, not a Tweener).<br>Also stores the image as the tween's target so it can be used for filtered operations<br>Tweens a Material's named color property using the given gradient<br>(NOTE 1: only uses the colors of the gradient, not the alphas - NOTE 2: creates a Sequence, not a Tweener).<br>Also stores the image as the tween's target so it can be used for filtered operations |
| `public` | S DOGradientColor | Material target, Gradient gradient, String property, Single duration | `Sequence` | Tweens a Material's color using the given gradient<br>(NOTE 1: only uses the colors of the gradient, not the alphas - NOTE 2: creates a Sequence, not a Tweener).<br>Also stores the image as the tween's target so it can be used for filtered operations<br>Tweens a Material's named color property using the given gradient<br>(NOTE 1: only uses the colors of the gradient, not the alphas - NOTE 2: creates a Sequence, not a Tweener).<br>Also stores the image as the tween's target so it can be used for filtered operations |
| `public` | S WaitForCompletion | Tween t, Boolean returnCustomYieldInstruction | `CustomYieldInstruction` | Returns a  that waits until the tween is killed or complete.<br>It can be used inside a coroutine as a yield.<br>Example usage:yield return myTween.WaitForCompletion(true); |
| `public` | S WaitForRewind | Tween t, Boolean returnCustomYieldInstruction | `CustomYieldInstruction` | Returns a  that waits until the tween is killed or rewinded.<br>It can be used inside a coroutine as a yield.<br>Example usage:yield return myTween.WaitForRewind(); |
| `public` | S WaitForKill | Tween t, Boolean returnCustomYieldInstruction | `CustomYieldInstruction` | Returns a  that waits until the tween is killed.<br>It can be used inside a coroutine as a yield.<br>Example usage:yield return myTween.WaitForKill(); |
| `public` | S WaitForElapsedLoops | Tween t, Int32 elapsedLoops, Boolean returnCustomYieldInstruction | `CustomYieldInstruction` | Returns a  that waits until the tween is killed or has gone through the given amount of loops.<br>It can be used inside a coroutine as a yield.<br>Example usage:yield return myTween.WaitForElapsedLoops(2); |
| `public` | S WaitForPosition | Tween t, Single position, Boolean returnCustomYieldInstruction | `CustomYieldInstruction` | Returns a  that waits until the tween is killed<br>or has reached the given time position (loops included, delays excluded).<br>It can be used inside a coroutine as a yield.<br>Example usage:yield return myTween.WaitForPosition(2.5f); |
| `public` | S WaitForStart | Tween t, Boolean returnCustomYieldInstruction | `CustomYieldInstruction` | Returns a  that waits until the tween is killed or started<br>(meaning when the tween is set in a playing state the first time, after any eventual delay).<br>It can be used inside a coroutine as a yield.<br>Example usage:yield return myTween.WaitForStart(); |
| `public` | S DOOffset | Material target, Vector2 endValue, Int32 propertyID, Single duration | `TweenerCore`3` | Tweens a Material's named texture offset property with the given ID to the given value.<br>Also stores the material as the tween's target so it can be used for filtered operations |
| `public` | S DOTiling | Material target, Vector2 endValue, Int32 propertyID, Single duration | `TweenerCore`3` | Tweens a Material's named texture scale property with the given ID to the given value.<br>Also stores the material as the tween's target so it can be used for filtered operations |
| `public` | S AsyncWaitForCompletion | Tween t | `Task` | Returns an async  that waits until the tween is killed or complete.<br>It can be used inside an async operation.<br>Example usage:await myTween.WaitForCompletion(); |
| `public` | S AsyncWaitForRewind | Tween t | `Task` | Returns an async  that waits until the tween is killed or rewinded.<br>It can be used inside an async operation.<br>Example usage:await myTween.AsyncWaitForRewind(); |
| `public` | S AsyncWaitForKill | Tween t | `Task` | Returns an async  that waits until the tween is killed.<br>It can be used inside an async operation.<br>Example usage:await myTween.AsyncWaitForKill(); |
| `public` | S AsyncWaitForElapsedLoops | Tween t, Int32 elapsedLoops | `Task` | Returns an async  that waits until the tween is killed or has gone through the given amount of loops.<br>It can be used inside an async operation.<br>Example usage:await myTween.AsyncWaitForElapsedLoops(); |
| `public` | S AsyncWaitForPosition | Tween t, Single position | `Task` | Returns an async  that waits until the tween is killed or started<br>(meaning when the tween is set in a playing state the first time, after any eventual delay).<br>It can be used inside an async operation.<br>Example usage:await myTween.AsyncWaitForPosition(); |
| `public` | S AsyncWaitForStart | Tween t | `Task` | Returns an async  that waits until the tween is killed.<br>It can be used inside an async operation.<br>Example usage:await myTween.AsyncWaitForKill(); |

---

