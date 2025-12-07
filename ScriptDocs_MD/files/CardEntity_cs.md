# File: CardEntity.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Scripts/CardEntity.cs`

<a id='CardEntity'></a>
## Class CardEntity
**Namespace:** `(Global)`<br>
**Signature:** `CardEntity : ScriptableObject`

> カードのマスターデータを定義するScriptableObject。  
> Unityエディタ上でカードのステータスや効果を設定するために使用する。

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | cardID | `Int32` | **[■ 基本情報]**<br>カードID |  |
| `public` | name | `String` | カード名 |  |
| `public` | cost | `Int32` | カードコスト |  |
| `public` | power | `Int32` | カードパワー |  |
| `public` | janken | `Int32` | じゃんけん属性　1:グー, 2:チョキ, 3:パー |  |
| `public` | cardImage | `Sprite` | カード画像 |  |
| `public` | janicon | `Sprite` | カードじゃんけん属性画像 |  |
| `public` | cardType | `CardType` | カードタイプの選択 |  |
| `public` | abilityText | `String` | 効果テキストの入力箇所 |  |
| `public` | isCostDown | `Boolean` | コストが下がっているかどうか |  |
| `public` | isSpeedAttacker | `Boolean` | **[■ 効果設定 / ■ 通常効果]**<br>スピードアタッカー(疾走、召喚酔いしない)かどうか |  |
| `public` | drawCardNum | `Int32` | カードを引く枚数 |  |
| `public` | addCardsList | `Int32[]` | 手札に加えるカードのリスト |  |
| `public` | summonCardsList | `Int32[]` | 召喚するカードのリスト |  |
| `public` | chgMyLeaderHpNum | `Int32` | 自分リーダーのHPを変化させる値 |  |
| `public` | chgEnemyLeaderHpNum | `Int32` | 相手リーダーのHPを変化させる値 |  |
| `public` | manaBoostNum | `Int32` | マナポイント(PP)の上昇値 |  |
| `public` | jankenstart | `Boolean` | じゃんけんをする |  |
| `public` | specificHand | `Boolean` | **[■ じゃんけんに勝利且つ、手が一致の効果かどうか]**<br>特定の手で |  |
| `public` | janwinspeed | `Boolean` | **[■ じゃんけんに勝っている時の効果]**<br>じゃんけん勝でスピードアタッカー |  |
| `public` | janwinpower | `Int32` | じゃんけん勝ちでパワーが増減する効果 |  |
| `public` | janwindraw | `Int32` | じゃんけん勝ってればドロー |  |
| `public` | janwinPHp | `Int32` | じゃんけん勝ってれば自分のライフ変化 |  |
| `public` | janwinEHp | `Int32` | じゃんけん勝ってれば相手のライフ変化 |  |
| `public` | janwinaddCardsList | `Int32[]` | じゃんけん勝ちでサーチ |  |
| `public` | janwinsummonCardsList | `Int32[]` | じゃんけんの勝で召喚 |  |
| `public` | janlosespeed | `Boolean` | **[■ じゃんけんに負けている時の効果]**<br>じゃんけん負けでスピードアタッカー |  |
| `public` | janlosepower | `Int32` | じゃんけん負けでパワーが増減する効果 |  |
| `public` | janlosedraw | `Int32` | じゃんけん負けてればればドロー |  |
| `public` | janlosePHp | `Int32` | じゃんけん負けてれば自分のライフ変化 |  |
| `public` | janloseEHp | `Int32` | じゃんけん負けてれば相手のライフ変化 |  |
| `public` | janloseaddCardsList | `Int32[]` | じゃんけん負けででサーチ |  |
| `public` | janlosesummonCardsList | `Int32[]` | じゃんけんの負けてれば召喚 |  |
| `public` | janhandspeed | `Boolean` | **[■ じゃんけんの手とカードの手が一致している時の効果]**<br>じゃんけんの手とカードの手が一致していればスピードアタッカー |  |
| `public` | janhandpower | `Int32` | じゃんけんの手とカードの手が一致していればパワーが増減する効果 |  |
| `public` | janhanddraw | `Int32` | じゃんけんの手とカードの手が一致していればドロー |  |
| `public` | janhandPHp | `Int32` | じゃんけんの手とカードの手が一致していれば自分のライフ変化 |  |
| `public` | janhandEHp | `Int32` | じゃんけんの手とカードの手が一致していれば相手のライフ変化 |  |
| `public` | janhandaddCardsList | `Int32[]` | じゃんけんの手とカードの手が一致していればサーチ |  |
| `public` | janhandsummonCardsList | `Int32[]` | じゃんけんの手とカードの手が一致していれば召喚 |  |
| `public` | destroyjan | `Int32` | **[■ 破壊効果 / 破壊したいじゃんけん番号を選ぶ]**<br>相手の特定のじゃんけんを一体破壊 |  |
| `public` | destroyjan2 | `Int32` | **[自分のじゃんけんを選ぶ]**<br>２種類のじゃんけんをすべて破壊 |  |
| `public` | alldestroy | `Boolean` | **[全破壊]**<br>全破壊 |  |

---

