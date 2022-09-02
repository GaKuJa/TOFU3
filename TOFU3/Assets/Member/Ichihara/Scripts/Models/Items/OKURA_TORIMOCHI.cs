using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHI : BaseItemStatus
{
    //�ύX����X�e�[�^�X�̎Q�ƌ�
    public GameObject _player;
    public GameObject MovementManager;
    private MovementManager _cs_movementManager;

    //�ŏ��̈�x�������s���邽�߂̃t���O
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

    /// <summary> �ړ��ȂǁA�v���C���[�̓������x���Ȃ� </summary>
    private void DelayPlayerMovement()
    {
        _cs_movementManager.x *= _moveSpeedMagni;
        _cs_movementManager.z *= _moveSpeedMagni;
    }

    /// <summary> �����[�h�ȂǁA�e�̋������x���Ȃ� </summary>
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

    //�ڐG�����I�u�W�F�N�g�̏���n��
    private void AssignPlayerComponent(GameObject obj)
    {
        MovementManager = GameObject.Find("MovementManager");
        _cs_movementManager = obj.GetComponent<MovementManager>();

    }
}
