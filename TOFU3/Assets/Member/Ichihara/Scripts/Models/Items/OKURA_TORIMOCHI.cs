using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHI : BaseItemStatus
{
    //変更するステータスの参照元
    public GameObject _player;
    public GameObject MovementManager;
    private MovementManager _cs_movementManager;

    //最初の一度だけ実行するためのフラグ
    private bool _isSpeedUp = false;

    private void ItemEffect()
    {
        do
        {
            EndItemEffect();

            if (_elapsedTime >= _effectTime)
            {
                _endFlag = true;
            }

            if (_isSpeedUp == false)
            {
                _isSpeedUp = true;
                DelayPlayerMovement();

            }

        } while (true);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            AssignPlayerComponent(_player);
            ItemEffect();
        }
    }

    //接触したオブジェクトの情報を渡す
    private void AssignPlayerComponent(GameObject obj)
    {
        MovementManager = GameObject.Find("MovementManager");
        _cs_movementManager = obj.GetComponent<MovementManager>();

    }
}
