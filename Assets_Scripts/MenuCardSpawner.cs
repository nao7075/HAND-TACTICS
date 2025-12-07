using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

/// <summary>
/// ホーム画面の背景演出として、カードをランダムに生成して落下させるクラス。
/// </summary>
public class MenuCardSpawner : MonoBehaviour
{
    [SerializeField] private CardController cardPrefab; // カードのプレハブ
    [SerializeField] private Transform panel; // カードを生成するパネル

    public float spawnInterval = 0.2f; // カードを生成する間隔
    public float minX = -900f; // 生成位置のX座標の最小値
    public float maxX = 900f; // 生成位置のX座標の最大値
    public float spawnY = 700f; // 生成位置のY座標
    public float fallSpeed = 200.0f; // カードが落ちる速度

    private RectTransform panelRectTransform; // パネルの RectTransform
    private float timer;//Updateのカード生成の時間管理
    private List<RectTransform> activeCards = new List<RectTransform>();// 画面内にあるカード
    private List<int> unusedCardIDs = new List<int>();// まだ出していないカードID

    private int CardSum = 48;// カードの総種類数
    void Start()
    {
        // パネルの RectTransform を取得
        panelRectTransform = panel.GetComponent<RectTransform>();

        // 未使用のカードIDを初期化
        for (int i = 0; i < CardSum; i++)
        {
            unusedCardIDs.Add(i);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 一定間隔ごとにカードを生成
        if (timer >= spawnInterval)
        {
            SpawnCard();
            timer = 0;
        }
    }

    /// <summary>
    /// 新しいカードを生成し、重ならない位置に配置する
    /// </summary>
    void SpawnCard()
    {
        if (unusedCardIDs.Count == 0)
        {
            for (int i = 0; i < CardSum; i++)
            {
                unusedCardIDs.Add(i);
            }
        }

        // 未使用のカードIDからランダムに選択
        int randomIndex = Random.Range(0, unusedCardIDs.Count);
        int cardID = unusedCardIDs[randomIndex];
        unusedCardIDs.RemoveAt(randomIndex);
        Debug.Log("cardID: " + cardID);

        // カードが重ならない位置を探す
        Vector3 spawnPosition = GetNonOverlappingPosition();

        // カードを生成し、パネルの子オブジェクトにする
        CardController card = Instantiate(cardPrefab, panel);
        RectTransform cardRectTransform = card.GetComponent<RectTransform>();
        cardRectTransform.localPosition = spawnPosition;

        card.Init(cardID, true);
        Debug.Log("name: " + card.model.name);

        // リストに追加
        activeCards.Add(cardRectTransform);

        // カードを下に移動させるためのコルーチンを開始
        StartCoroutine(Fall(card.gameObject));
    }

    /// <summary>
    /// 既存のカードと重ならない生成位置を計算する
    /// </summary>
    Vector3 GetNonOverlappingPosition()
    {
        const int maxAttempts = 100; // 試行回数の上限
        float cardWidth = cardPrefab.GetComponent<RectTransform>().rect.width;
        float cardHeight = cardPrefab.GetComponent<RectTransform>().rect.height;

        for (int i = 0; i < maxAttempts; i++)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

            if (!IsOverlapping(spawnPosition, cardWidth, cardHeight))
            {
                return spawnPosition;
            }
        }

        // 試行回数が上限に達した場合は、デフォルトの位置を返す
        return new Vector3(Random.Range(minX, maxX), spawnY, 0);
    }

    /// <summary>
    /// 指定位置が既存カードと重なっているか判定する
    /// </summary>
    bool IsOverlapping(Vector3 position, float width, float height)
    {
        foreach (RectTransform card in activeCards)
        {
            if (card != null && RectOverlaps(position, width, height, card.localPosition, card.rect.width, card.rect.height))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 矩形同士の重なり判定
    /// </summary>
    bool RectOverlaps(Vector3 pos1, float width1, float height1, Vector3 pos2, float width2, float height2)
    {
        Rect rect1 = new Rect(pos1.x - width1 / 2, pos1.y - height1 / 2, width1, height1);
        Rect rect2 = new Rect(pos2.x - width2 / 2, pos2.y - height2 / 2, width2, height2);
        return rect1.Overlaps(rect2);
    }

    /// <summary>
    /// カードを落下させ、画面外に出たら削除するコルーチン
    /// </summary>
    IEnumerator Fall(GameObject card)
    {
        RectTransform cardRectTransform = card.GetComponent<RectTransform>();
        while (cardRectTransform.anchoredPosition.y > -600) // カードが画面外に出るまで
        {
            cardRectTransform.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;
            yield return null;
        }

        // カードが画面外に出たら削除
        activeCards.Remove(cardRectTransform);
        Destroy(card);
    }
}


