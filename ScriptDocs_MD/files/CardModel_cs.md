# File: CardModel.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/CardModel.cs`

<a id='CardModel'></a>
## Class CardModel
**Namespace:** `(Global)`<br>
**Signature:** `CardModel`

> カードのデータを保持するクラス。  
> CardEntity（マスターデータ）から値をコピーし、ゲーム中での変動（コストダウンなど）を管理する。  
> コンストラクタ。CardEntityからデータをロードする。  
> データを受け取り、その処理

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | cardId | `Int32` | カードID |  |
| `public` | name | `String` | カード名 |  |
| `public` | cost | `Int32` | カードコスト |  |
| `public` | power | `Int32` | カードパワー |  |
| `public` | janken | `Int32` | じゃんけん属性　1:グー, 2:チョキ, 3:パー |  |
| `public` | cardImage | `Sprite` | カード画像<br>/元々あり名前が変わっている |  |
| `public` | janicon | `Sprite` | カードじゃんけん属性画像 |  |
| `public` | cardType | `CardType` | モンスターかスペルか |  |
| `public` | abilityText | `String` | 効果テキスト |  |
| `public` | isDeckCard | `Boolean` | デッキのカードかどうか |  |
| `public` | isCostDown | `Boolean` | コストが下がっているかどうか |  |
| `public` | isSpeedAttacker | `Boolean` | スピードアタッカーかどうか |  |
| `public` | drawCardNum | `Int32` | カードを引く枚数 |  |
| `public` | addCardsList | `Int32[]` | 手札に加えるカードIDのリスト |  |
| `public` | summonCardsList | `Int32[]` | 召喚するカードIDのリスト |  |
| `public` | chgMyLeaderHpNum | `Int32` | 自分リーダーのHPを変化させる値 |  |
| `public` | chgEnemyLeaderHpNum | `Int32` | 相手リーダーのHPを変化させる値 |  |
| `public` | manaBoostNum | `Int32` | マナブーストの数 |  |
| `public` | jankenstart | `Boolean` | 強制じゃんけん効果かどうか |  |
| `public` | specificHand | `Boolean` | じゃんけんに勝利且つ自分が出した手とじゃんけん属性が一致しているかどうか |  |
| `public` | janwinspeed | `Boolean` | じゃんけんの勝でスピードアタッカー |  |
| `public` | janwinpower | `Int32` | じゃんけんの勝ちでパワーが増減する効果<br>じゃんけん勝ちでパワーアップ |  |
| `public` | janwindraw | `Int32` | じゃんけん勝ってればドロー |  |
| `public` | janwinPHp | `Int32` | じゃんけん勝ってれば自分のライフ増減<br>じゃんけん勝ってれば自分のライフ変化 |  |
| `public` | janwinEHp | `Int32` | じゃんけん勝ってれば相手のライフ増減<br>じゃんけん勝ってれば相手のライフ変化 |  |
| `public` | janwinaddCardsList | `Int32[]` | じゃんけんの勝でサーチ |  |
| `public` | janwinsummonCardsList | `Int32[]` | じゃんけんの勝で召喚 |  |
| `public` | janlosespeed | `Boolean` | じゃんけん負けでスピードアタッカー |  |
| `public` | janlosepower | `Int32` | じゃんけん負けでパワーが増減する効果<br>じゃんけん負けでパワーアップ |  |
| `public` | janlosedraw | `Int32` | じゃんけん負けてればればドロー<br>じゃんけん負ければドロー |  |
| `public` | janlosePHp | `Int32` | じゃんけん負けてれば自分のライフ増減<br>じゃんけん負けてれば自分のライフ変化 |  |
| `public` | janloseEHp | `Int32` | じゃんけん負けてれば相手のライフ増減<br>じゃんけん負けてれば相手のライフ変化 |  |
| `public` | janloseaddCardsList | `Int32[]` | じゃんけんの負けでサーチ |  |
| `public` | janlosesummonCardsList | `Int32[]` | じゃんけんの負けてれば召喚<br>じゃんけんの負けで召喚 |  |
| `public` | janhandspeed | `Boolean` | じゃんけんの手とカードの手が一致していればスピードアタッカー<br>自分の手とカードの手が一致してればスピードアタッカー |  |
| `public` | janhandpower | `Int32` | じゃんけんの手とカードの手が一致していればパワーが増減する効果<br>自分の手とカードの手が一致してればパワーアップ |  |
| `public` | janhanddraw | `Int32` | じゃんけんの手とカードの手が一致していればドロー<br>自分の手とカードの手が一致してればドロー |  |
| `public` | janhandPHp | `Int32` | じゃんけんの手とカードの手が一致していれば自分のライフ変化<br>自分の手とカードの手が一致しててれば自分のライフ変化 |  |
| `public` | janhandEHp | `Int32` | じゃんけんの手とカードの手が一致していれば相手のライフ変化<br>自分の手とカードの手が一致しててれば相手のライフ変化 |  |
| `public` | janhandaddCardsList | `Int32[]` | じゃんけんの手とカードの手が一致していればサーチ<br>自分の手とカードの手が一致しててればサーチ |  |
| `public` | janhandsummonCardsList | `Int32[]` | じゃんけんの手とカードの手が一致していれば召喚<br>自分の手とカードの手が一致しててれば召喚 |  |
| `public` | destroyjan | `Int32` | 相手の特定のじゃんけんを一体破壊 |  |
| `public` | destroyjan2 | `Int32` | ２種類のじゃんけんをすべて破壊<br>二種類のじゃんけんすべて破壊 |  |
| `public` | alldestroy | `Boolean` | 全破壊 |  |
| `public` | canUse | `Boolean` | 使用可能か |  |
| `public` | PlayerCard | `Boolean` | プレイヤーのカードか |  |
| `public` | FieldCard | `Boolean` | フィールドに出ているか |  |
| `public` | canAttack | `Boolean` | 攻撃可能か |  |
| `public` | playerNumberth | `Int32` | プレイヤーのカードの管理番号、試合中に生成されると0から順につけられる |  |
| `public` | enemyNumberth | `Int32` | 敵プレイヤーのカードの管理番号、試合中に同期されると0から順につけられる<br>出来れば PlayerCard = falseならつけるにしたい |  |

### コンストラクタ (Constructors)
| アクセス | 名前 | 引数 | 説明 |
| :---: | :--- | :--- | :--- |
| `public` | CardModel | Int32 cardID, Boolean playerCard | Constructor |

---

