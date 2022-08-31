using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    //�X�e�[�^�X�̎Q�ƌ�
    private MovementManager _cs_movementManager;

    private bool _speedUpFlag = false; 

    private void Start()
    {
        _cs_movementManager = GetComponent<MovementManager>();
    }

    void Update()
    {
        EndItemEffect();

        //���ʎ��Ԃ̉��Z
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
    /// �X�s�[�h�A�b�v����
    /// </summary>
    private void MoveSpeedUp()
    {
        _cs_movementManager.x *= _moveSpeedMagni;
    }

}
