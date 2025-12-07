using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// カードのデータを保持するクラス。
/// CardEntity（マスターデータ）から値をコピーし、ゲーム中での変動（コストダウンなど）を管理する。
/// </summary>
public class CardModel
{   
    /// <summary> カードID </summary>
    public int cardId;

    /// <summary> カード名 </summary>
    public string name;

    /// <summary> カードコスト</summary>
    public int cost;

    /// <summary> カードパワー</summary>
    public int power;

    /// <summary> じゃんけん属性　1:グー, 2:チョキ, 3:パー　</summary>
    public int janken;
    
    /// <summary> カード画像</summary>
    public Sprite cardImage;///元々あり名前が変わっている
    
    /// <summary> カードじゃんけん属性画像 </summary>
    public Sprite janicon;

    /// <summary> モンスターかスペルか </summary>
    public CardType cardType;

    /// <summary> 効果テキスト </summary>
    public string abilityText;

    /// <summary> デッキのカードかどうか </summary>
    public bool isDeckCard;//

    /// <summary>  コストが下がっているかどうか </summary>
    public bool isCostDown = false;

    /// <summary>  スピードアタッカーかどうか </summary>
    public bool isSpeedAttacker;

    /// <summary>  カードを引く枚数 </summary>
    public int drawCardNum;

    /// <summary>  手札に加えるカードIDのリスト</summary>
    public int[] addCardsList;

    /// <summary>  召喚するカードIDのリスト</summary>
    public int[] summonCardsList;

    /// <summary>  自分リーダーのHPを変化させる値 </summary>
    public int chgMyLeaderHpNum;

    /// <summary>  相手リーダーのHPを変化させる値 </summary>
    public int chgEnemyLeaderHpNum;

    /// <summary>  マナブーストの数 </summary>
    public int manaBoostNum;

    /// <summary>  強制じゃんけん効果かどうか </summary>
    public bool jankenstart;

    /// <summary>  じゃんけんに勝利且つ自分が出した手とじゃんけん属性が一致しているかどうか </summary>
    public bool specificHand;


    //----じゃんけん勝ち効果-----

    /// <summary> じゃんけんの勝でスピードアタッカー </summary>
    public bool janwinspeed;

    /// <summary> じゃんけんの勝ちでパワーが増減する効果 </summary>
    public int janwinpower;

    /// <summary> じゃんけん勝ってればドロー </summary>
    public int janwindraw;

    /// <summary> じゃんけん勝ってれば自分のライフ増減 </summary>
    public int janwinPHp;

    /// <summary> じゃんけん勝ってれば相手のライフ増減 </summary>
    public int janwinEHp;

    /// <summary> じゃんけんの勝でサーチ </summary>
    public int[] janwinaddCardsList;

    /// <summary> じゃんけんの勝で召喚 </summary>
    public int[] janwinsummonCardsList;
    //public int janwinhandlife;//特定の手で且つ勝っていれば


    //-----じゃんけん負け効果-----

    /// <summary> じゃんけん負けでスピードアタッカー </summary>
    public bool janlosespeed;

    /// <summary> じゃんけん負けでパワーが増減する効果 </summary>
    public int janlosepower;

    /// <summary> じゃんけん負けてればればドロー </summary>
    public int janlosedraw;

    /// <summary> じゃんけん負けてれば自分のライフ増減 </summary>
    public int janlosePHp;

    /// <summary> じゃんけん負けてれば相手のライフ増減 </summary>
    public int janloseEHp;

    /// <summary> じゃんけんの負けでサーチ </summary>
    public int[] janloseaddCardsList;

    /// <summary> じゃんけんの負けてれば召喚 </summary>
    public int[] janlosesummonCardsList;
    //public int janlosehandlife;//特定の手で且つ負けてれば


    //-----じゃんけんの手次第効果-----

    /// <summary> じゃんけんの手とカードの手が一致していればスピードアタッカー </summary>
    public bool janhandspeed;

    /// <summary> じゃんけんの手とカードの手が一致していればパワーが増減する効果 </summary>
    public int janhandpower;

    /// <summary> じゃんけんの手とカードの手が一致していればドロー </summary>
    public int janhanddraw;

    /// <summary> じゃんけんの手とカードの手が一致していれば自分のライフ変化 </summary>
    public int janhandPHp;

    /// <summary> じゃんけんの手とカードの手が一致していれば相手のライフ変化 </summary>
    public int janhandEHp;

    /// <summary> じゃんけんの手とカードの手が一致していればサーチ </summary>
    public int[] janhandaddCardsList;

    /// <summary> じゃんけんの手とカードの手が一致していれば召喚 </summary>
    public int[] janhandsummonCardsList;
    

    //-----破壊効果-----

    /// <summary> 相手の特定のじゃんけんを一体破壊 </summary>
    public int destroyjan;

    /// <summary> ２種類のじゃんけんをすべて破壊 </summary>
    public int destroyjan2;

    /// <summary> 全破壊 </summary>
    public bool alldestroy;


    //----その他管理----

    /// <summary>  使用可能か </summary>
    public bool canUse = false;

    /// <summary> プレイヤーのカードか </summary>
    public bool PlayerCard = false;

    /// <summary> フィールドに出ているか </summary>
    public bool FieldCard = false;

    /// <summary> 攻撃可能か </summary>
    public bool canAttack = false;

    /// <summary> プレイヤーのカードの管理番号、試合中に生成されると0から順につけられる </summary>
    public  int playerNumberth;

    /// <summary> 敵プレイヤーのカードの管理番号、試合中に同期されると0から順につけられる </summary>
    public  int enemyNumberth;//出来れば PlayerCard = falseならつけるにしたい
    
    
    /// <summary>
    /// コンストラクタ。CardEntityからデータをロードする。
    /// </summary>
    public CardModel(int cardID, bool playerCard) // データを受け取り、その処理
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);

        cardId = cardEntity.cardID;
        name = cardEntity.name;
        cost = cardEntity.cost;
        power = cardEntity.power;
        janken = cardEntity.janken;
        cardImage = cardEntity.cardImage;
        
        janicon = cardEntity.janicon;

        cardType = cardEntity.cardType;
        abilityText= cardEntity.abilityText;
        isCostDown = cardEntity.isCostDown;

        isSpeedAttacker = cardEntity.isSpeedAttacker;
        drawCardNum = cardEntity.drawCardNum;
        addCardsList = cardEntity.addCardsList;
        summonCardsList = cardEntity.summonCardsList;
        chgMyLeaderHpNum = cardEntity.chgMyLeaderHpNum;
        chgEnemyLeaderHpNum = cardEntity.chgEnemyLeaderHpNum;
        manaBoostNum = cardEntity.manaBoostNum;
        jankenstart = cardEntity.jankenstart;

        specificHand = cardEntity.specificHand;
        //勝
        janwinspeed = cardEntity.janwinspeed;//じゃんけんの勝でスピードアタッカー
        janwinpower = cardEntity.janwinpower;//じゃんけん勝ちでパワーアップ
        janwindraw = cardEntity.janwindraw;//じゃんけん勝ってればドロー
        janwinPHp = cardEntity.janwinPHp;//じゃんけん勝ってれば自分のライフ変化
        janwinEHp = cardEntity.janwinEHp;//じゃんけん勝ってれば相手のライフ変化
        janwinaddCardsList = cardEntity.janwinaddCardsList;//じゃんけんの勝でサーチ
        janwinsummonCardsList = cardEntity.janwinsummonCardsList;//じゃんけんの勝で召喚
        //janwinhandlife = cardEntity.janwinhandlife;//特定の手で且つ勝っていれば
        //負け
        janlosespeed = cardEntity.janlosespeed;//じゃんけん負けでスピードアタッカー
        janlosepower = cardEntity.janlosepower;//じゃんけん負けでパワーアップ
        janlosedraw = cardEntity.janlosedraw;//じゃんけん負ければドロー
        janlosePHp = cardEntity.janlosePHp;//じゃんけん負けてれば自分のライフ変化
        janloseEHp = cardEntity.janloseEHp;//じゃんけん負けてれば相手のライフ変化
        janloseaddCardsList = cardEntity.janloseaddCardsList;//じゃんけんの負けでサーチ
        janlosesummonCardsList = cardEntity.janlosesummonCardsList;//じゃんけんの負けで召喚
        //janlosehandlife = cardEntity.janlosehandlife;//特定の手で且つ負けていれば
        // じゃんけんの手
        janhandspeed = cardEntity.janhandspeed;//自分の手とカードの手が一致してればスピードアタッカー
        janhandpower = cardEntity.janhandpower;//自分の手とカードの手が一致してればパワーアップ
        janhanddraw = cardEntity.janhanddraw;//自分の手とカードの手が一致してればドロー
        janhandPHp = cardEntity.janhandPHp;//自分の手とカードの手が一致しててれば自分のライフ変化
        janhandEHp = cardEntity.janhandEHp;//自分の手とカードの手が一致しててれば相手のライフ変化
        janhandaddCardsList = cardEntity.janhandaddCardsList;//自分の手とカードの手が一致しててればサーチ
        janhandsummonCardsList = cardEntity.janhandsummonCardsList;//自分の手とカードの手が一致しててれば召喚
        //破壊効果
        destroyjan = cardEntity.destroyjan;//相手の特定のじゃんけんを一体破壊
        destroyjan2 = cardEntity.destroyjan2;//二種類のじゃんけんすべて破壊
        alldestroy = cardEntity.alldestroy;//全破壊

        PlayerCard = playerCard;
        
    }
    
}
