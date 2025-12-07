using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アタッチされたオブジェクトを一定速度で回転させる演出用スクリプト。
/// タイトルロゴの回転などに使用。
/// </summary>
public class RotatePanel : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度を設定するための変数

    void Update()//じゃんけんロゴの回転
    {
        // Y軸を中心に回転させる（2Dの場合はZ軸回転の意図かもしれないが、コード通りY軸回転）
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

