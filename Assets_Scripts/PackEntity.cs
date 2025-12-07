using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 不使用
/// </summary>
[CreateAssetMenu(fileName = "PackEntity", menuName = "Create PackEntity")]
public class PackEntity : ScriptableObject
{
    public int packId;
    public string packName;
    public Sprite packImage;
    public Sprite packageImage;

    public List<int> cardList = new List<int>() { };
}
