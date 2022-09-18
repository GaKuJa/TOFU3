using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(�U����񖳌�) </summary>

public class YUBA_SHIELD : BaseItemStatus, IBaseBulletDamege
{
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    [SerializeField]
    private GameObject _gunSt = null;
    [SerializeField]
    private GameObject _enemy = null;

    private GunSt _cs_gunSt = null;
    private Enemy _cs_enemy = null;
    private ItemPickUp _pickUp = null;

    private void Update()
    {
        if (_pickUp.YubaShield == false) { return; }
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
            _pickUp = other.GetComponentInParent<ItemPickUp>();
            AssignCsComponent();
        }
        if (other.CompareTag("Shell"))
        {
            ReducedDamageAndPressed();
            _pickUp.YubaShield = false;
            _endFlag = true;
        }
    }

    /// <summary>
    /// �_���[�W�ƈ��͂𖳌���
    /// </summary>
    private void ReducedDamageAndPressed()
    {
        //�_���[�W������
        float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
        _cs_enemy.Damage((int)Damage);

        //���͖�����
    }

    private void AssignCsComponent()
    {
        _cs_gunSt = _gunSt.GetComponent<GunSt>();
        _cs_enemy = _enemy.GetComponent<Enemy>();
    }

    public int BulletDamege(int playerHp, int bulletDamege)
    {
        float Damage = bulletDamege *_damageMagni;
        return playerHp -= (int)Damage;
    }

}
