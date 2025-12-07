using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アタッチされたオブジェクトを拡大・縮小（パルス）させる演出用スクリプト。
/// スタートボタンの強調などに使用。
/// </summary>
public class ScalePanel : MonoBehaviour
{
    // 拡大と縮小のターゲットスケール
    public Vector3 minScale = new Vector3(1f, 1f, 1f); //スタートボタンの最小サイズ
    public Vector3 maxScale = new Vector3(2f, 2f, 1f); //スタートボタンの最大サイズ

    public float speed = 1f;// 拡大縮小のスピード

    private bool scalingUp = true;// 内部状態の追跡

    void Update()
    {
        // 現在のスケールを取得
        Vector3 currentScale = transform.localScale;

        // ターゲットスケールを計算
        Vector3 targetScale = scalingUp ? maxScale : minScale;

        // スケールを補間
        transform.localScale = Vector3.Lerp(currentScale, targetScale, speed * Time.deltaTime);

        // ターゲットスケールに近づいたら、方向を反転
        if (Vector3.Distance(currentScale, targetScale) < 0.01f)
        {
            scalingUp = !scalingUp;
        }
    }
}
