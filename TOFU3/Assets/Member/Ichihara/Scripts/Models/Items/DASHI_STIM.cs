using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    //ステータスの参照元
    public GameObject _player = null;
    public Player _cs_player = null;
    private TestPlayer1Controler _movement1 = null;
    private TestPlayer2Controler _movement2 = null;
    private ItemPickUp _pickUp = null;


    private bool _speedUpFlag = false;

    private void Update()
    {
        EndItemEffect();

        //効果時間の加算
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _effectTime) { _endFlag = true; }
        if (_speedUpFlag == false)
        {
            ItemEffect();
            _speedUpFlag = true;
        }

        Debug.Log(_movement2.x);
    }

    private void ItemEffect()
    {
        MoveSpeedUp();
    }

    /// <summary>
    /// スピードアップ処理
    /// </summary>
    private void MoveSpeedUp()
    {
        switch(_cs_player.playerNum)
        {
            case 1:
                _movement1.x *= _moveSpeedMagni;
                break;
            case 2:
                _movement2.x *= _moveSpeedMagni;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InitializeElapsedTime();
            _player = other.gameObject;
            _cs_player = _player.GetComponentInParent<Player>();
            _pickUp = _player.GetComponentInParent<ItemPickUp>();
            AssignPlayerComponent(_player);
            ItemEffect();
        }
    }

    /// <summary>
    /// 接触したオブジェクトの情報を渡す
    /// </summary>
    /// <param name="obj"></param>
    private void AssignPlayerComponent(GameObject obj)
    {
        //プレイヤーの数が増えたら追記
        switch (_cs_player.playerNum)
        {
            case 1:
                _movement1 = obj.GetComponentInParent<TestPlayer1Controler>();
                break;
            case 2:
                _movement2 = obj.GetComponentInParent<TestPlayer2Controler>();
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }

    }
}
