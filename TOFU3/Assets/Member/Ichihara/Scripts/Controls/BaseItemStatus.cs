using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> アイテムの基礎ステータス </summary>

public class BaseItemStatus : MonoBehaviour
{
    //効果時間
    [SerializeField]
    protected float _effectTime = 0;
    //ダメージ倍率
    [SerializeField]
    protected float _DamageMagni = 0;
    //圧力倍率
    protected float _pressMagni = 0;
    //プレイヤー移動速度倍率
    protected float _movePlayerMagni = 0;

}
