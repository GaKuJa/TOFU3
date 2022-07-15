using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus = null;

    private bool _endFlag = false;

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        GetDASHI_STIM();
    }

    private void GetDASHI_STIM()
    {
        //���ʎ���(15�b)
        _effectTime = 15.0f;

        do
        {
            _effectTime -= Time.deltaTime;

            //�ړ����x���グ��
            //�X�v�����g���̑��x���グ��
            //�X���C�f�B���O���̑��x���グ��

        } while (!_endFlag);
    }
}
