using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
{
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    public GameObject Player;
    public GameObject GunSt;
    public GameObject Enemy;
    private GunSt _cs_gunSt;
    private Enemy _cs_enemy;

    private void ItemEffect()
    {
        do
        {
            //���ʎ��Ԃ̉��Z
            _elapsedTime += Time.deltaTime;

            //�_���[�W������
            float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
            _cs_enemy.Damage((int)Damage);

            if (_elapsedTime >= _effectTime)
            {
                _endFlag = true;
            }

            //���F�̃I�[��(�G�t�F�N�g)

        } while (_endFlag == false);

        EndItemEffect();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            AssignPlayerComponent();
            ItemEffect();
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
