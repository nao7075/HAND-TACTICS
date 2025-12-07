# File: DOTweenModuleSprite.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Plugins/Demigiant/DOTween/Modules/DOTweenModuleSprite.cs`

<a id='DOTweenModuleSprite'></a>
## Class DOTweenModuleSprite
**Namespace:** `DG.Tweening`<br>
**Signature:** `DOTweenModuleSprite`

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S DOColor | SpriteRenderer target, Color endValue, Single duration | `TweenerCore`3` | Tweens a SpriteRenderer's color to the given value.<br>Also stores the spriteRenderer as the tween's target so it can be used for filtered operations |
| `public` | S DOFade | SpriteRenderer target, Single endValue, Single duration | `TweenerCore`3` | Tweens a Material's alpha color to the given value.<br>Also stores the spriteRenderer as the tween's target so it can be used for filtered operations |
| `public` | S DOGradientColor | SpriteRenderer target, Gradient gradient, Single duration | `Sequence` | Tweens a SpriteRenderer's color using the given gradient<br>(NOTE 1: only uses the colors of the gradient, not the alphas - NOTE 2: creates a Sequence, not a Tweener).<br>Also stores the image as the tween's target so it can be used for filtered operations |
| `public` | S DOBlendableColor | SpriteRenderer target, Color endValue, Single duration | `Tweener` | Tweens a SpriteRenderer's color to the given value,<br>in a way that allows other DOBlendableColor tweens to work together on the same target,<br>instead than fight each other as multiple DOColor would do.<br>Also stores the SpriteRenderer as the tween's target so it can be used for filtered operations |

---

