# File: OpenPackManager.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Scripts.md)

> **Path:** `Assets/Scripts/OpenPackManager.cs`

<a id='OpenPackManager'></a>
## Class OpenPackManager
**Namespace:** `(Global)`<br>
**Signature:** `OpenPackManager : MonoBehaviour`

> 不使用

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | cardPackPrefab | `GameObject` | カードパックプレハブ |  |
| `private` | openedCardTrans | `Transform` | 開封したカードの生成場所 |  |
| `private` | cardPackTrans | `Transform` | カードパックの生成場所 |  |
| `private` | expandCardTrans1 | `Transform` |  |  |
| `private` | expandCardTrans2 | `Transform` |  |  |
| `private` | expandCardTrans3 | `Transform` |  |  |
| `private` | expandCardTrans4 | `Transform` |  |  |
| `private` | expandCardTrans5 | `Transform` |  |  |
| `private` | expandCardTrans6 | `Transform` |  |  |
| `private` | expandCardTrans7 | `Transform` |  |  |
| `private` | expandCardTrans8 | `Transform` |  |  |
| `public` | packCardList | `List`1` | パックのカードリスト |  |
| `private` | buyPackCount | `Int32` | 購入するパックの個数 |  |
| `private` | generatedPackCount | `Int32` | 生成したパックの個数 |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `private` | CreatePack | Int32 packId | `Void` |  |
| `public` | OpenPack |  | `Void` |  |
| `private` | decisionCardId |  | `Int32` |  |
| `private` | ExpandPackCards |  | `IEnumerator` | IEnumeratorに変更 |
| `public` | PushOKButtom |  | `Void` |  |
| `private` | NextPack |  | `Void` |  |
| `private` | RemoveExpandCard |  | `Void` |  |
| `private` | EndOpenPack |  | `Void` |  |
| `private` | AddPackCards | Int32 cardId | `Void` |  |

---

