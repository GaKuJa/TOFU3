using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    //�X�e�[�^�X�̎Q�ƌ�
    public GameObject Player;
    public GameObject MovementManager;
    private MovementManager _cs_movementManager;

    private bool _speedUpFlag = false; 

    private void ItemEffect()
    {
        do
        {
            EndItemEffect();

            //���ʎ��Ԃ̉��Z
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
    /// �X�s�[�h�A�b�v����
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

    //�ڐG�����I�u�W�F�N�g�̏���n��
    private void AssignPlayerComponent(GameObject obj)
    {
        MovementManager = GameObject.Find("MovementManager");
        _cs_movementManager = obj.GetComponent<MovementManager>();
    }
}
