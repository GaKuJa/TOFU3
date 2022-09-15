using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    //ステータスの参照元
    public GameObject Player;
    public GameObject MovementManager;
    private MovementManager _cs_movementManager;

    private bool _speedUpFlag = false; 

    private void ItemEffect()
    {
        do
        {
            EndItemEffect();

            //効果時間の加算
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _effectTime) { _endFlag = true; }

            if (_speedUpFlag == false)
            {
                MoveSpeedUp();
                _speedUpFlag = true;
            }

        } while (true);
    }

    /// <summary>
    /// スピードアップ処理
    /// </summary>
    private void MoveSpeedUp()
    {
        _cs_movementManager.x *= _moveSpeedMagni;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            AssignPlayerComponent(Player);
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
