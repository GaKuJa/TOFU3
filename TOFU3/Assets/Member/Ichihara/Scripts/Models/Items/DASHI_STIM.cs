using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    //ステータスの参照元
    private MovementManager _cs_movementManager;

    private bool _speedUpFlag = false; 

    private void Start()
    {
        _cs_movementManager = GetComponent<MovementManager>();
    }

    void Update()
    {
        EndItemEffect();

        //効果時間の加算
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _effectTime)
        {
            _endFlag = true;
        }

        if(_speedUpFlag == false)
        {
            MoveSpeedUp();
            _speedUpFlag = true;
        }
    }

    /// <summary>
    /// スピードアップ処理
    /// </summary>
    private void MoveSpeedUp()
    {
        _cs_movementManager.x *= _moveSpeedMagni;
    }

}
