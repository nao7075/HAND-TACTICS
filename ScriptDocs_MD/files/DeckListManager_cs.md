# File: DeckListManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/DeckListManager.cs`

<a id='DeckListManager'></a>
## Class DeckListManager
**Namespace:** `(Global)`<br>
**Signature:** `DeckListManager : MonoBehaviour`

> プレイヤーが作成した複数のデッキデータを保持・管理するクラス。  
> どのデッキを編集するか、どのデッキで対戦するかを中継する役割を持つ。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | deckList | `List`1` | 現在選択されているデッキリスト |  |
| `public` | editDeckNum | `Int32` | 編集するデッキ番号を記録する変数 |  |
| `public` | deckList1 | `List`1` | 保存されているデッキデータ1 |  |
| `public` | deckList2 | `List`1` | 保存されているデッキデータ2 |  |
| `public` | deckList3 | `List`1` | 保存されているデッキデータ3 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | PushDeckListButton | Int32 deckListNum | `Void` | デッキ選択ボタンが押された時の処理。<br>選択された番号のデッキデータをアクティブにする。 |
| `public` | BackHomeButtom |  | `Void` | ホーム画面に移動するボタン |
| `public` | BackButtom |  | `IEnumerator` | BackHomeButtomで実行 |
| `public` | DeckListButtom |  | `IEnumerator` | デッキ編集画面へ遷移 |

---

