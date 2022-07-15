using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 銃、アイテムのスポーン機能の共通要素
/// </summary>

public class BaseSpawmStatus : MonoBehaviour
{
    //ステージの床のTOFUプレハブを格納
    [SerializeField]
    protected List<GameObject> _fieldTOFU = new List<GameObject>();

    //生成された乱数を格納
    protected List<int> _randNum = new List<int>();

    //時間管理
    [SerializeField]
    protected float _time = 0.0f;

    //時間経過のチェック
    protected bool _timerFlagFirst = false;
    protected bool _timerFlagSecond = false;

    //オブジェクトがスポーンする間隔を格納
    [SerializeField]
    protected float _interval = 0.0f;
    [SerializeField]
    protected float _afterThreeMinutesInterval = 0.0f;

    //_intervalの値を格納
    //_intervalを減算して時間を計る為、
    //カウンタとは別に_intervalの値を確保、代入して_intervalをリセットする必要がある
    [SerializeField]
    protected float _setInterval = 0.0f;

}
