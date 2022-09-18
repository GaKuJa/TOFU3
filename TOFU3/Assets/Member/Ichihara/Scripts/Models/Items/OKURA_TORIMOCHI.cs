using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHI : BaseItemStatus
{
    //変更するステータスの参照元
    public GameObject _player = null;
    public Player _cs_player = null;
    private TestPlayer1Controler _movement1 = null;
    private TestPlayer2Controler _movement2 = null;
    private ItemPickUp _pickUp = null;

    //最初の一度だけ実行するためのフラグ
    private bool _isSpeedUp = false;

    private void Update()
    {
        if (_elapsedTime > _effectTime || _pickUp.OkuraTorimoti == false) { return; }

        EndItemEffect();

        if (_elapsedTime >= _effectTime) { _endFlag = true; }
        if (_isSpeedUp == false)
        {
            ItemEffect();
            _isSpeedUp = true;
        }
    }

    private void ItemEffect()
    {
        DelayPlayerMovement();
    }

    /// <summary> 移動など、プレイヤーの動きが遅くなる </summary>
    private void DelayPlayerMovement()
    {
        //プレイヤーが増えたら追記
        switch (_cs_player.playerNum)
        {
            case 1:
                _movement1.x *= _moveSpeedMagni;
                break;
            case 2:
                _movement2.x *= _moveSpeedMagni;
                Debug.Log(_movement2.x);
                break;
            default:
                break;
        }

    }

    /// <summary> リロードなど、銃の挙動が遅くなる </summary>
    private void DelayGunMovement()
    {

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
