# File: BattleCardMovement.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/BattleCardMovement.cs`

<a id='BattleCardMovement'></a>
## Class BattleCardMovement
**Namespace:** `(Global)`<br>
**Signature:** `BattleCardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler`

> バトルシーンにおけるカードの移動制御（ドラッグ＆ドロップ、攻撃モーション）を行うクラス  
> マウス操作のクラス名

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | cardParent | `Transform` | カードが本来所属している親オブジェクト（フィールドや手札エリアなど） |  |
| `private` | canDrag | `Boolean` | カードをドラッグ操作できるかどうかのフラグ |  |
| `private` | oriCardParent | `Transform` | ドラッグ開始前の親オブジェクトを一時保存する変数 |  |
| `private` | cardIndex | `Int32` | ドラッグ開始前の兄弟順（描画順）を保存する変数 |  |
| `private` | playercardposition | `Vector3` | プレイヤーカードの初期位置（攻撃モーション時の戻り位置として使用） |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | OnBeginDrag | PointerEventData eventData | `Void` | ドラッグ開始時の処理<br>ドラッグを始めるときに行う処理 |
| `public` | OnDrag | PointerEventData eventData | `Void` | ドラッグ操作中に毎フレーム呼ばれるメソッド。<br>カードの位置をマウスカーソル（タッチ位置）に追従させる。<br>ドラッグした時に起こす処理 |
| `public` | OnEndDrag | PointerEventData eventData | `Void` | ドラッグ操作が終了した（指を離した）瞬間に呼ばれるメソッド。<br>ドロップ処理が成功しなかった場合などに、カードを元の位置に戻す処理を行う。<br>カードを離したときに行う処理 |
| `public` | AttackMotion | Transform target | `IEnumerator` | 敵カードが攻撃を行う際のアニメーション処理。<br>ターゲットに向かって移動し、攻撃後に元の位置に戻る動きを演出する。<br>敵カード側 |
| `public` | PlayerAttackMotion | Transform target | `IEnumerator` | プレイヤー側のカードが攻撃を行う際のアニメーション処理。<br>ドラッグ操作後の位置ズレを防ぐための補正が含まれているバージョン。<br>バグ修正のためのプレイヤー側の |
| `public` | SummonMotion |  | `IEnumerator` | カードがフィールドに召喚された時の登場アニメーション。<br>一瞬拡大してから元のサイズに戻ることで「ポンッ」と出たような演出を行う。 |
| `public` | UseSpellMotion |  | `IEnumerator` | スペルカードを使用した際のアニメーション。<br>大きく拡大して強調表示した後、消滅する演出を行う。 |

---

