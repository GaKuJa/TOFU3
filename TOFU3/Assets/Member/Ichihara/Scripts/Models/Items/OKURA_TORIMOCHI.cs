using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHI : BaseItemStatus
{
    //変更するステータスの参照元
    private MovementManager _cs_movementManager = null;

    //最初の一度だけ実行するためのフラグ
    private bool _isSpeedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        _cs_movementManager = GetComponent<MovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EndItemEffect();

        if(_elapsedTime >= _effectTime)
        {
            _endFlag = true;
        }

        if(_isSpeedUp == false)
        {
            _isSpeedUp = true;
            DelayPlayerMovement();
            
        }

    }

    /// <summary> 移動など、プレイヤーの動きが遅くなる </summary>
    private void DelayPlayerMovement()
    {
        _cs_movementManager.x *= _moveSpeedMagni;
        _cs_movementManager.z *= _moveSpeedMagni;
    }

    /// <summary> リロードなど、銃の挙動が遅くなる </summary>
    private void DelayGunMovement()
    {

    }
}
