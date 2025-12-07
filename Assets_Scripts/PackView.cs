using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 不使用
/// </summary>
public class PackView : MonoBehaviour
{
    [SerializeField] Image packageImage;

    public void Show(int packId) // PackEntityのデータ取得と反映
    {
        PackEntity pack = Resources.Load<PackEntity>("PackEntityList/Pack" + packId);
        packageImage.sprite = pack.packageImage;
    }
}