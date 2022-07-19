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
        bool buffSpeedUpFlag = false;

        do
        {
            _effectTime -= Time.deltaTime;

            //�ړ����x���グ��
            //�X�v�����g���̑��x���グ��
            //�X���C�f�B���O���̑��x���グ��

            if(buffSpeedUpFlag == false)
            {
                _cs_playerStatus.buffSpeed *= _movePlayerMagni;

            }



            //���ʎ���(15�b)
            if (_effectTime <= 15.0f)
            {
                _endFlag = true;
            }

        } while (!_endFlag);
    }
}
