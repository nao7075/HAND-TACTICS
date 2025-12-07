# File: CardView.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/CardView.cs`

<a id='CardView'></a>
## Class CardView
**Namespace:** `(Global)`<br>
**Signature:** `CardView : MonoBehaviour`

> カードの見た目（View）を制御するクラス。  
> CardModelのデータを元に、イラスト、テキスト、枠色などをUIに反映させる。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | costText | `TextMeshProUGUI` | コスト表示 |  |
| `private` | nameText | `TextMeshProUGUI` | 名前表示 |  |
| `private` | powerText | `TextMeshProUGUI` | パワー表示 |  |
| `private` | jankenText | `TextMeshProUGUI` | じゃんけん属性値 |  |
| `private` | iconImage | `Image` | カードイラスト |  |
| `private` | janiconImage | `Image` | じゃんけん属性アイコン |  |
| `private` | costImage | `Image` | コスト背景 |  |
| `private` | canAttackPanel | `GameObject` | 攻撃可能時の強調枠 |  |
| `private` | canUsePanel | `GameObject` | 使用可能時の強調枠 |  |
| `private` | abilityText | `TextMeshProUGUI` | 効果テキスト |  |
| `private` | cardPanel1 | `GameObject` | 属性に応じた背景パネル（1:赤） |  |
| `private` | cardPanel2 | `GameObject` | 属性に応じた背景パネル（2:緑） |  |
| `private` | cardPanel3 | `GameObject` | 属性に応じた背景パネル（3:青） |  |
| `private` | powerPanel | `GameObject` | パワー表示部 |  |
| `private` | jankenPanel | `GameObject` | じゃんけん属性表示部 |  |
| `private` | countPanel | `GameObject` | デッキ編成時の所持枚数表示パネル |  |
| `private` | countText | `TextMeshProUGUI` | 所持枚数テキスト |  |
| `private` | DestoroyPanel | `GameObject` | 破壊時のエフェクトパネル |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | Show | CardModel cardModel | `Void` | CardModelのデータをUIに反映して表示を更新する |
| `public` | ShowCountPanel |  | `Void` | デッキ編成画面用に、所持カード枚数を表示するパネルを有効化する |
| `public` | SetCanAttackPanel | Boolean flag | `Void` | 攻撃可能エフェクト（枠）の表示切り替え |
| `public` | SetCanUsePanel | Boolean flag | `Void` | 使用可能エフェクト（枠）の表示切り替え<br>フラグに合わせてCanUsePanelを付けるor消す |
| `public` | SetDestoroyPanel |  | `Void` | 破壊時の演出パネルを表示する<br>フラグに合わせてCanUsePanelを付けるor消す |

---

