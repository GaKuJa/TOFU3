using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(�U����񖳌�) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
<<<<<<< HEAD
    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private bool _endFlag = false;

    private void Start()
    {

        //�_���[�W�{���A���͔{����������
        _damageMagni = 0.0f;
        _pressForceMagni = 0.0f;
=======
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    private GunSt _cs_gunSt = null;
    private Enemy _cs_enemy = null;

    private void Start()
    {
        _cs_gunSt = GetComponent<GunSt>();
        _cs_enemy = GetComponent<Enemy>();
>>>>>>> main
    }

    private void Update()
    {
<<<<<<< HEAD
        //�擾�����v���C���[�̎������n�C���C�g

        //if (/*�e���v���C���[�ɓ���������*/)
        //{
        //    YUBA_SHIELDEffect();
        //    _endFlag = true;
        //}

    }

    private void YUBA_SHIELDEffect()
    {

        //�_���[�W����񂾂��O�ɂ���
        SHOYOUGUN.Instance.ShotDamage *= _damageMagni;
        //���͂���񂾂��O�ɂ���
        SHOYOUGUN.Instance._forcePower *= _pressForceMagni;
=======
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
>>>>>>> main
    }

}
