using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHI : BaseItemStatus
{
    //�ύX����X�e�[�^�X�̎Q�ƌ�
    private MovementManager _cs_movementManager = null;

    //�ŏ��̈�x�������s���邽�߂̃t���O
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
}
