# File: MenuCardSpawner.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/MenuCardSpawner.cs`

<a id='MenuCardSpawner'></a>
## Class MenuCardSpawner
**Namespace:** `(Global)`<br>
**Signature:** `MenuCardSpawner : MonoBehaviour`

> ホーム画面の背景演出として、カードをランダムに生成して落下させるクラス。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | cardPrefab | `CardController` | カードのプレハブ |  |
| `private` | panel | `Transform` | カードを生成するパネル |  |
| `public` | spawnInterval | `Single` | カードを生成する間隔 |  |
| `public` | minX | `Single` | 生成位置のX座標の最小値 |  |
| `public` | maxX | `Single` | 生成位置のX座標の最大値 |  |
| `public` | spawnY | `Single` | 生成位置のY座標 |  |
| `public` | fallSpeed | `Single` | カードが落ちる速度 |  |
| `private` | panelRectTransform | `RectTransform` | パネルの RectTransform |  |
| `private` | timer | `Single` | Updateのカード生成の時間管理 |  |
| `private` | activeCards | `List`1` | 画面内にあるカード |  |
| `private` | unusedCardIDs | `List`1` | まだ出していないカードID |  |
| `private` | CardSum | `Int32` | カードの総種類数 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | ⚡ Update |  | `Void` | Unity Event Function |
| `private` | SpawnCard |  | `Void` | 新しいカードを生成し、重ならない位置に配置する |
| `private` | GetNonOverlappingPosition |  | `Vector3` | 既存のカードと重ならない生成位置を計算する |
| `private` | IsOverlapping | Vector3 position, Single width, Single height | `Boolean` | 指定位置が既存カードと重なっているか判定する |
| `private` | RectOverlaps | Vector3 pos1, Single width1, Single height1, Vector3 pos2, Single width2, Single height2 | `Boolean` | 矩形同士の重なり判定 |
| `private` | Fall | GameObject card | `IEnumerator` | カードを落下させ、画面外に出たら削除するコルーチン |

---

