# File: DeckEditManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/DeckEditManager.cs`

<a id='DeckEditManager'></a>
## Class DeckEditManager
**Namespace:** `(Global)`<br>
**Signature:** `DeckEditManager : MonoBehaviour`

> デッキ編成画面（Deck Scene）の管理クラス。  
> デッキと所持カード（ストック）の表示、ページ切り替え、データの保存・リセットを行う。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | cardPrefab | `CardController` | カードプレハブ |  |
| `private` | deckCardTrans1page | `Transform` | デッキカードの生成場所1ページ目 |  |
| `private` | deckCardTrans2page | `Transform` | デッキカードの生成場所2ページ目 |  |
| `private` | DeckPanel1 | `GameObject` | デッキページ1のパネル |  |
| `private` | DeckPanel2 | `GameObject` | デッキページ2のパネル |  |
| `private` | page1Button | `GameObject` | ページ切り替えボタン左 |  |
| `private` | page2Button | `GameObject` | ページ切り替えボタン右 |  |
| `private` | deckCardTrans1 | `Transform` | デッキカードスロット1 |  |
| `private` | deckCardTrans2 | `Transform` | デッキカードスロット2 |  |
| `private` | deckCardTrans3 | `Transform` | デッキカードスロット3 |  |
| `private` | deckCardTrans4 | `Transform` | デッキカードスロット4 |  |
| `private` | deckCardTrans5 | `Transform` | デッキカードスロット5 |  |
| `private` | deckCardTrans6 | `Transform` | デッキカードスロット6 |  |
| `private` | deckCardTrans7 | `Transform` | デッキカードスロット7 |  |
| `private` | deckCardTrans8 | `Transform` | デッキカードスロット8 |  |
| `private` | deckCardTrans9 | `Transform` | デッキカードスロット9 |  |
| `private` | deckCardTrans10 | `Transform` | デッキカードスロット10 |  |
| `private` | deckCardTrans11 | `Transform` | デッキカードスロット11 |  |
| `private` | deckCardTrans12 | `Transform` | デッキカードスロット12 |  |
| `private` | deckCardTrans13 | `Transform` | デッキカードスロット13 |  |
| `private` | deckCardTrans14 | `Transform` | デッキカードスロット14 |  |
| `private` | deckCardTrans15 | `Transform` | デッキカードスロット15 |  |
| `private` | deckCardTrans16 | `Transform` | デッキカードスロット16 |  |
| `private` | deckCardTrans17 | `Transform` | デッキカードスロット17 |  |
| `private` | deckCardTrans18 | `Transform` | デッキカードスロット18 |  |
| `private` | deckCardTrans19 | `Transform` | デッキカードスロット19 |  |
| `private` | deckCardTrans20 | `Transform` | デッキカードスロット20 |  |
| `private` | deckCardTrans21 | `Transform` | デッキカードスロット21 |  |
| `private` | deckCardTrans22 | `Transform` | デッキカードスロット22 |  |
| `private` | deckCardTrans23 | `Transform` | デッキカードスロット23 |  |
| `private` | deckCardTrans24 | `Transform` | デッキカードスロット24 |  |
| `private` | deckCardTrans25 | `Transform` | デッキカードスロット25 |  |
| `private` | deckCardTrans26 | `Transform` | デッキカードスロット26 |  |
| `private` | deckCardTrans27 | `Transform` | デッキカードスロット27 |  |
| `private` | deckCardTrans28 | `Transform` | デッキカードスロット28 |  |
| `private` | deckCardTrans29 | `Transform` | デッキカードスロット29 |  |
| `private` | deckCardTrans30 | `Transform` | デッキカードスロット30 |  |
| `private` | deckCardTrans31 | `Transform` | デッキカードスロット31 |  |
| `private` | deckCardTrans32 | `Transform` | デッキカードスロット32 |  |
| `private` | stockCardTrans | `Transform` | 所持カード生成場所 |  |
| `private` | stockCardTrans1 | `Transform` | 所持カードスロット1 |  |
| `private` | stockCardTrans2 | `Transform` | 所持カードスロット2 |  |
| `private` | stockCardTrans3 | `Transform` | 所持カードスロット3 |  |
| `private` | stockCardTrans4 | `Transform` | 所持カードスロット4 |  |
| `private` | stockCardTrans5 | `Transform` | 所持カードスロット5 |  |
| `private` | stockCardTrans6 | `Transform` | 所持カードスロット6 |  |
| `private` | DropPanels | `GameObject` | ドロップ判定用のパネル |  |
| `public` | deckCardsList | `List`1` | 現在編集中のデッキリスト |  |
| `public` | stockCardsList | `List`1` | 所持してるのカードリスト（各カードIDごとの所持枚数を格納)、unity側で制御 |  |
| `public` | page | `Int32` | 所持カードのページ数、初期値0 |  |
| `public` | deckpage | `Int32` | デッキの現在のページ数 (1 or 2)、初期値0 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | SaveButton |  | `Void` | 保存ボタン処理。編集内容を確定してデッキ一覧に戻る。 |
| `public` | SaveBackButtom |  | `IEnumerator` |  |
| `private` | SetDeckEditPanel |  | `Void` | デッキ編集画面の表示内容を更新する（初期化用）<br>デッキカードと所持カードのセットアップを再度行う |
| `public` | SetDeckCards1 |  | `Void` | デッキの1ページ目（1～16枚目）を表示する<br>引数を削除 |
| `public` | SetDeckCards2 |  | `Void` | デッキの2ページ目（17～32枚目）を表示する<br>引数を削除 |
| `public` | SetStockCards |  | `Void` | 所持カード（ストック）一覧を表示する。<br>ページ送り（page変数）に対応して表示するカードIDを切り替える。 |
| `public` | changeStockCardPage | Int32 changePage | `Void` | 所持カードの表示を切り替えるボタンの処理 |
| `public` | changeDeckCardPage | Int32 changePage | `Void` | デッキ表示エリアのページ切り替え処理（1ページ目  2ページ目） |
| `public` | AddDeckCard | Int32 cardId | `Void` | デッキリストにカードIDを追加し、ID順にソートする |
| `public` | RemoveDeckCard | Int32 cardId | `Void` | デッキリストからカードIDを削除し、ソートする |
| `public` | AddStockCard | Int32 cardId | `Void` | 所持カードの枚数を増やす（デッキから戻した時など） |
| `public` | RemoveStockCard | Int32 cardId | `Void` | 所持カードの枚数を減らす（デッキに入れた時など） |
| `public` | ShowDropPanels | Boolean flag | `Void` | ドラッグ中のみドロップ用パネルを表示する |
| `private` | RemoveDeckCardsFromStockCards |  | `Void` | デッキに含まれているカード分、所持数を減算して初期化する<br>再計算（実質0） |
| `public` | ResetButton |  | `Void` | リセットボタン処理。デッキを全解除し、全て所持カードに戻す。 |
| `private` | AddDeckCardsFromStockCards |  | `Void` | 所持数を戻す |

---

