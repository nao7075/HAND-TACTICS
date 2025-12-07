# File: DOTweenModulePhysics.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Plugins/Demigiant/DOTween/Modules/DOTweenModulePhysics.cs`

<a id='DOTweenModulePhysics'></a>
## Class DOTweenModulePhysics
**Namespace:** `DG.Tweening`<br>
**Signature:** `DOTweenModulePhysics`

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S DOMove | Rigidbody target, Vector3 endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody's position to the given value.<br>Also stores the rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DOMoveX | Rigidbody target, Single endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody's X position to the given value.<br>Also stores the rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DOMoveY | Rigidbody target, Single endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody's Y position to the given value.<br>Also stores the rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DOMoveZ | Rigidbody target, Single endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody's Z position to the given value.<br>Also stores the rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DORotate | Rigidbody target, Vector3 endValue, Single duration, RotateMode mode | `TweenerCore`3` | Tweens a Rigidbody's rotation to the given value.<br>Also stores the rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DOLookAt | Rigidbody target, Vector3 towards, Single duration, AxisConstraint axisConstraint, Nullable`1 up | `TweenerCore`3` | Tweens a Rigidbody's rotation so that it will look towards the given position.<br>Also stores the rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DOJump | Rigidbody target, Vector3 endValue, Single jumpPower, Int32 numJumps, Single duration, Boolean snapping | `Sequence` | Tweens a Rigidbody's position to the given value, while also applying a jump effect along the Y axis.<br>Returns a Sequence instead of a Tweener.<br>Also stores the Rigidbody as the tween's target so it can be used for filtered operations |
| `public` | S DOPath | Rigidbody target, Vector3[] path, Single duration, PathType pathType, PathMode pathMode, Int32 resolution, Nullable`1 gizmoColor | `TweenerCore`3` | Tweens a Rigidbody's position through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody as the tween's target so it can be used for filtered operations.<br>NOTE: to tween a rigidbody correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOPath. |
| `public` | S DOLocalPath | Rigidbody target, Vector3[] path, Single duration, PathType pathType, PathMode pathMode, Int32 resolution, Nullable`1 gizmoColor | `TweenerCore`3` | Tweens a Rigidbody's localPosition through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody as the tween's target so it can be used for filtered operations<br>NOTE: to tween a rigidbody correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOLocalPath. |
| `internal` | S DOPath | Rigidbody target, Path path, Single duration, PathMode pathMode | `TweenerCore`3` | Tweens a Rigidbody's position through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody as the tween's target so it can be used for filtered operations.<br>NOTE: to tween a rigidbody correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOPath. |
| `internal` | S DOLocalPath | Rigidbody target, Path path, Single duration, PathMode pathMode | `TweenerCore`3` | Tweens a Rigidbody's localPosition through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody as the tween's target so it can be used for filtered operations<br>NOTE: to tween a rigidbody correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOLocalPath. |

---

