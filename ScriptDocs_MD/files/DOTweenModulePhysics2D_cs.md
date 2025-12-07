# File: DOTweenModulePhysics2D.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Plugins/Demigiant/DOTween/Modules/DOTweenModulePhysics2D.cs`

<a id='DOTweenModulePhysics2D'></a>
## Class DOTweenModulePhysics2D
**Namespace:** `DG.Tweening`<br>
**Signature:** `DOTweenModulePhysics2D`

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S DOMove | Rigidbody2D target, Vector2 endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody2D's position to the given value.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations |
| `public` | S DOMoveX | Rigidbody2D target, Single endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody2D's X position to the given value.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations |
| `public` | S DOMoveY | Rigidbody2D target, Single endValue, Single duration, Boolean snapping | `TweenerCore`3` | Tweens a Rigidbody2D's Y position to the given value.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations |
| `public` | S DORotate | Rigidbody2D target, Single endValue, Single duration | `TweenerCore`3` | Tweens a Rigidbody2D's rotation to the given value.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations |
| `public` | S DOJump | Rigidbody2D target, Vector2 endValue, Single jumpPower, Int32 numJumps, Single duration, Boolean snapping | `Sequence` | Tweens a Rigidbody2D's position to the given value, while also applying a jump effect along the Y axis.<br>Returns a Sequence instead of a Tweener.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations.<br>IMPORTANT: a rigidbody2D can't be animated in a jump arc using MovePosition, so the tween will directly set the position |
| `public` | S DOPath | Rigidbody2D target, Vector2[] path, Single duration, PathType pathType, PathMode pathMode, Int32 resolution, Nullable`1 gizmoColor | `TweenerCore`3` | Tweens a Rigidbody2D's position through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations.<br>NOTE: to tween a Rigidbody2D correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOPath. |
| `public` | S DOLocalPath | Rigidbody2D target, Vector2[] path, Single duration, PathType pathType, PathMode pathMode, Int32 resolution, Nullable`1 gizmoColor | `TweenerCore`3` | Tweens a Rigidbody2D's localPosition through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations<br>NOTE: to tween a Rigidbody2D correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOLocalPath. |
| `internal` | S DOPath | Rigidbody2D target, Path path, Single duration, PathMode pathMode | `TweenerCore`3` | Tweens a Rigidbody2D's position through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations.<br>NOTE: to tween a Rigidbody2D correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOPath. |
| `internal` | S DOLocalPath | Rigidbody2D target, Path path, Single duration, PathMode pathMode | `TweenerCore`3` | Tweens a Rigidbody2D's localPosition through the given path waypoints, using the chosen path algorithm.<br>Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations<br>NOTE: to tween a Rigidbody2D correctly it should be set to kinematic at least while being tweened.<br>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).<br>If you plan to publish there you should use a regular transform.DOLocalPath. |

---

