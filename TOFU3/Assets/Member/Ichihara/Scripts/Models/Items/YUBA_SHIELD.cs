using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(�U����񖳌�) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private bool _endFlag = false;

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        GetYUBA_SHIELD();
    }

    private void GetYUBA_SHIELD()
    {
        do
        {
            //�擾�����v���C���[�̎������n�C���C�g

            //if (/*�e�����̃A�C�e�����擾�����v���C���[�ɓ���������*/)
            //{
            //    //�_���[�W����񂾂��O�ɂ���
            //    //���͂���񂾂��O�ɂ���
            //}


        } while (!_endFlag);
    }
}
