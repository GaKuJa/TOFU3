using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(�U����񖳌�) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private Collision _col = null;

    private bool _endFlag = false;

    private void Start()
    {
        //�_���[�W�{���A���͔{����������
        _damageMagni = 0.0f;
        _pressForceMagni = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _col = collision;
        this.gameObject.SetActive(false);
        GetYUBA_SHIELD();
    }

    private void GetYUBA_SHIELD()
    {
        do
        {
            //�擾�����v���C���[�̎������n�C���C�g

            //if (/*�e���v���C���[�ɓ���������*/)
            //{
            //    //�_���[�W����񂾂��O�ɂ���
            //    SHOYOUGUN.Instance.ShotDamage *= _damageMagni;
            //    //���͂���񂾂��O�ɂ���
            //    SHOYOUGUN.Instance._forcePower *= _pressForceMagni;
            //    _endFlag = true;
            //}


        } while (!_endFlag);
    }
}
