using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(�U����񖳌�) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    public GameObject Player;
    public GameObject GunSt;
    public GameObject Enemy;
    private GunSt _cs_gunSt;
    private Enemy _cs_enemy;

    [SerializeField]
    private PlayerStatus _cs_playerStatus;

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
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            AssignPlayerComponent();
            Update();
        }

        if (other.CompareTag("Shell"))
        {
            //�_���[�W������
            float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
            _cs_enemy.Damage((int)Damage);

            //���͖�����

            _endFlag = true;
        }

    }

    //�ڐG�����I�u�W�F�N�g�̏���n��
    private void AssignPlayerComponent()
    {
        GunSt = GameObject.Find("GunSt");
        Enemy = GameObject.Find("Enemy");
        _cs_gunSt = GetComponent<GunSt>();
        _cs_enemy = GetComponent<Enemy>();

    }
}
