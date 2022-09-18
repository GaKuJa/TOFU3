using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHI : BaseItemStatus
{
    //�ύX����X�e�[�^�X�̎Q�ƌ�
    public GameObject _player = null;
    public Player _cs_player = null;
    private TestPlayer1Controler _movement1 = null;
    private TestPlayer2Controler _movement2 = null;
    private ItemPickUp _pickUp = null;

    //�ŏ��̈�x�������s���邽�߂̃t���O
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

    /// <summary> �ړ��ȂǁA�v���C���[�̓������x���Ȃ� </summary>
    private void DelayPlayerMovement()
    {
        //�v���C���[����������ǋL
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

    /// <summary> �����[�h�ȂǁA�e�̋������x���Ȃ� </summary>
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
    /// �ڐG�����I�u�W�F�N�g�̏���n��
    /// </summary>
    /// <param name="obj"></param>
    private void AssignPlayerComponent(GameObject obj)
    {
        //�v���C���[�̐�����������ǋL
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
