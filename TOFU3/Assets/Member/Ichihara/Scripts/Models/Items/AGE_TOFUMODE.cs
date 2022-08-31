using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
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
    }

}
