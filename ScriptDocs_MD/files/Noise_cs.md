# File: Noise.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Demos_DemoProcedural_Scripts.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/DemoProcedural/Scripts/Noise.cs`

<a id='Noise'></a>
## Class Noise
**Namespace:** `Simplex`<br>
**Signature:** `Noise`

> Implementation of the Perlin simplex noise, an improved Perlin noise algorithm.  
> Based loosely on SimplexNoise1234 by Stefan Gustavson

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | seed | `Int32` |  |  |
| `private` | perm | `Byte[]` |  |  |
| `private` | permOriginal | `Byte[]` |  |  |

### プロパティ (Properties)
| アクセス | 名前 | 型 | 説明 |
| :---: | :--- | :---: | :--- |
| `public` | Seed <br><small>{ get; set; }</small> | `Int32` |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S Calc1D | Int32 width, Single scale | `Single[]` |  |
| `public` | S Calc2D | Int32 width, Int32 height, Single scale | `Single[,]` |  |
| `public` | S Calc3D | Int32 width, Int32 height, Int32 length, Single scale | `Single[,,]` |  |
| `public` | S CalcPixel1D | Int32 x, Single scale | `Single` |  |
| `public` | S CalcPixel2D | Int32 x, Int32 y, Single scale | `Single` |  |
| `public` | S CalcPixel3D | Int32 x, Int32 y, Int32 z, Single scale | `Single` |  |
| `internal` | S Generate | Single x | `Single` | 1D simplex noise<br>2D simplex noise |
| `internal` | S Generate | Single x, Single y | `Single` | 1D simplex noise<br>2D simplex noise |
| `internal` | S Generate | Single x, Single y, Single z | `Single` | 1D simplex noise<br>2D simplex noise |
| `private` | S FastFloor | Single x | `Int32` |  |
| `private` | S Mod | Int32 x, Int32 m | `Int32` |  |
| `private` | S grad | Int32 hash, Single x | `Single` | Gradient value 1.0, 2.0, ..., 8.0 |
| `private` | S grad | Int32 hash, Single x, Single y | `Single` | Gradient value 1.0, 2.0, ..., 8.0 |
| `private` | S grad | Int32 hash, Single x, Single y, Single z | `Single` | Gradient value 1.0, 2.0, ..., 8.0 |
| `private` | S grad | Int32 hash, Single x, Single y, Single z, Single t | `Single` | Gradient value 1.0, 2.0, ..., 8.0 |

---

