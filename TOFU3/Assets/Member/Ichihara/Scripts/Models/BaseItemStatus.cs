using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> アイテムの基礎ステータス </summary>

public class BaseItemStatus : MonoBehaviour
{
    [Header("ItemStatus")]
    //効果時間
    [SerializeField]
    protected float _effectTime = 0.0f;
    //経過時間
    protected float _elapsedTime = 0.0f;
    //ダメージ倍率
    [SerializeField]
    protected float _damageMagni = 0.0f;
    //圧力倍率
    [SerializeField]
    protected float _pressForceMagni = 0.0f;
    //プレイヤー移動速度倍率
    [SerializeField]
    protected float _moveSpeedMagni = 0.0f;
    //終了フラグ
    protected bool _endFlag = false;

    protected void InitializeElapsedTime()
    {
        _elapsedTime = 0.0f;
    }

    /// <summary> アイテムの効果の終了処理 </summary>
    protected void EndItemEffect()
    {
        if (_endFlag == true) { Destroy(this); }
    }

}
