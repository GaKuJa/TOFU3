using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(�U����񖳌�) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    private GunSt _cs_gunSt = null;
    private Enemy _cs_enemy = null;

    private void Start()
    {
        _cs_gunSt = GetComponent<GunSt>();
        _cs_enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        EndItemEffect();

        //�擾�����v���C���[�̎������n�C���C�g

    }

    /// <summary>
    /// �e�������������A��x�����_���[�W�A���͂���񖳌���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //�_���[�W������
        float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
        _cs_enemy.Damage((int)Damage);

        //���͖�����


        _endFlag = true;
    }

}
