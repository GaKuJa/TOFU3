using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�A�A�C�e���̃X�|�[���@�\�̋��ʗv�f
/// </summary>

public class BaseSpawmStatus : MonoBehaviour
{
    //�X�e�[�W�̏���TOFU�v���n�u���i�[
    [SerializeField]
    protected List<GameObject> _fieldTOFU = new List<GameObject>();

    //�������ꂽ�������i�[
    protected List<int> _randNum = new List<int>();

    //���ԊǗ�
    [SerializeField]
    protected float _time = 0.0f;

    //���Ԍo�߂̃`�F�b�N
    protected bool _timerFlagFirst = false;
    protected bool _timerFlagSecond = false;

    //�I�u�W�F�N�g���X�|�[������Ԋu���i�[
    [SerializeField]
    protected float _interval = 0.0f;
    [SerializeField]
    protected float _afterThreeMinutesInterval = 0.0f;

    //_interval�̒l���i�[
    //_interval�����Z���Ď��Ԃ��v��ׁA
    //�J�E���^�Ƃ͕ʂ�_interval�̒l���m�ہA�������_interval�����Z�b�g����K�v������
    [SerializeField]
    protected float _setInterval = 0.0f;

}
