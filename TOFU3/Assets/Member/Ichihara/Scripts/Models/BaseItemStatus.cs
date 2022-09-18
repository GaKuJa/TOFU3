using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �A�C�e���̊�b�X�e�[�^�X </summary>

public class BaseItemStatus : MonoBehaviour
{
    [Header("ItemStatus")]
    //���ʎ���
    [SerializeField]
    protected float _effectTime = 0.0f;
    //�o�ߎ���
    protected float _elapsedTime = 0.0f;
    //�_���[�W�{��
    [SerializeField]
    protected float _damageMagni = 0.0f;
    //���͔{��
    [SerializeField]
    protected float _pressForceMagni = 0.0f;
    //�v���C���[�ړ����x�{��
    [SerializeField]
    protected float _moveSpeedMagni = 0.0f;
    //�I���t���O
    protected bool _endFlag = false;

    protected void InitializeElapsedTime()
    {
        _elapsedTime = 0.0f;
    }

    /// <summary> �A�C�e���̌��ʂ̏I������ </summary>
    protected void EndItemEffect()
    {
        if (_endFlag == true) { Destroy(this); }
    }

}
