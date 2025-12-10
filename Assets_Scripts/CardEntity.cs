using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// カードのマスターデータを定義するScriptableObject。
/// Unityエディタ上でカードのステータスや効果を設定するために使用する。
/// </summary>
[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]
public class CardEntity : ScriptableObject
{
    [Header("■ 基本情報")]/// ヘッダー

    public int cardID; //カードID
    public new string name; //カード名
    public int cost; //カードコスト
    public int power; //カードパワー
    public int janken; //じゃんけん属性　1:グー, 2:チョキ, 3:パー
    public Sprite cardImage; //カード画像
    public Sprite janicon; //カードじゃんけん属性画像

    public CardType cardType; // カードタイプの選択
    [Multiline] public string abilityText; // 効果テキストの入力箇所
    public bool isCostDown;//コストが下がっているかどうか
    [Space(15)] // スペースを空ける
    [Header("■ 効果設定")]
    [Space(15)] // スペースを空ける
    [Header("■ 通常効果")]
    public bool isSpeedAttacker; // スピードアタッカー(疾走、召喚酔いしない)かどうか
    public int drawCardNum; // カードを引く枚数
    public int[] addCardsList; // 手札に加えるカードのリスト
    public int[] summonCardsList; // 召喚するカードのリスト
    public int chgMyLeaderHpNum; // 自分リーダーのHPを変化させる値
    public int chgEnemyLeaderHpNum; // 相手リーダーのHPを変化させる値
    public int manaBoostNum; // マナポイント(PP)の上昇値
    public bool jankenstart;//じゃんけんをする
    [Header("■ じゃんけんに勝利且つ、手が一致の効果かどうか")]
    public bool specificHand;//特定の手で
    [Header("■ じゃんけんに勝っている時の効果")]
    public bool janwinspeed;//じゃんけん勝でスピードアタッカー
    public int janwinpower;//じゃんけん勝ちでパワーが増減する効果
    public int janwindraw;//じゃんけん勝ってればドロー
    public int janwinPHp;//じゃんけん勝ってれば自分のライフ変化
    public int janwinEHp;//じゃんけん勝ってれば相手のライフ変化
    public int[] janwinaddCardsList;//じゃんけん勝ちでサーチ
    public int[] janwinsummonCardsList;//じゃんけんの勝で召喚
    //public int janwinhandlife;//特定の手で且つ勝っていれば
    [Header("■ じゃんけんに負けている時の効果")]
    public bool janlosespeed;//じゃんけん負けでスピードアタッカー
    public int janlosepower;//じゃんけん負けでパワーが増減する効果
    public int janlosedraw;//じゃんけん負けてればればドロー
    public int janlosePHp;//じゃんけん負けてれば自分のライフ変化
    public int janloseEHp;//じゃんけん負けてれば相手のライフ変化
    public int[] janloseaddCardsList;//じゃんけん負けででサーチ
    public int[] janlosesummonCardsList;//じゃんけんの負けてれば召喚
    //public int janlosehandlife;//特定の手で且つ負けてれば
    [Header("■ じゃんけんとカードの手が一致している時の効果")]
    public bool janhandspeed;//じゃんけんの手とカードの手が一致していればスピードアタッカー
    public int janhandpower;//じゃんけんの手とカードの手が一致していればパワーが増減する効果
    public int janhanddraw;//じゃんけんの手とカードの手が一致していればドロー
    public int janhandPHp;//じゃんけんの手とカードの手が一致していれば自分のライフ変化
    public int janhandEHp;//じゃんけんの手とカードの手が一致していれば相手のライフ変化
    public int[] janhandaddCardsList;//じゃんけんの手とカードの手が一致していればサーチ
    public int[] janhandsummonCardsList;//じゃんけんの手とカードの手が一致していれば召喚
    
    [Header("■ 破壊効果")]
    [Space(15)] // スペースを空ける
    [Header("破壊したいじゃんけん番号を選ぶ")]
    public int destroyjan;//相手の特定のじゃんけんを一体破壊
    [Header("自分のじゃんけんを選ぶ")]
    public int destroyjan2;//２種類のじゃんけんをすべて破壊
    [Header("全破壊")]
    public bool alldestroy;//全破壊

    //public int janwinhand

}
public enum CardType // カードタイプの種類の定義
{
    Monster,
    Spell
}
