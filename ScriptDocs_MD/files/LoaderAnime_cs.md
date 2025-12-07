# File: LoaderAnime.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts/LoaderAnime.cs`

<a id='LoaderAnime'></a>
## Class LoaderAnime
**Namespace:** `Photon.Pun.Demo.PunBasics`<br>
**Signature:** `LoaderAnime : MonoBehaviour`

> Simple behaviour to animate particles around to create a typical "Ajax Loader". this is actually very important to visual inform the user that something is happening  
> or better say that the application is not frozen, so a animation of some sort helps reassuring the user that the system is idle and well.  
> TODO: hide when connection failed.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | speed | `Single` |  |  |
| `public` | radius | `Single` |  |  |
| `public` | particles | `GameObject` |  |  |
| `private` | _offset | `Vector3` |  |  |
| `private` | _transform | `Transform` |  |  |
| `private` | _particleTransform | `Transform` |  |  |
| `private` | _isAnimating | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Awake |  | `Void` | MonoBehaviour method called on GameObject by Unity during early initialization phase. |
| `private` | ⚡ Update |  | `Void` | MonoBehaviour method called on GameObject by Unity on every frame. |
| `public` | StartLoaderAnimation |  | `Void` | Starts the loader animation. Becomes visible |
| `public` | StopLoaderAnimation |  | `Void` | Stops the loader animation. Becomes invisible |

---

