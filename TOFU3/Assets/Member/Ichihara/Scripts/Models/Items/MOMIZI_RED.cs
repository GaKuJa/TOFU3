using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMIZI_RED : BaseItemStatus
{
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    GunSt _cs_gunSt = null;
    Enemy _cs_enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        _cs_gunSt = GetComponent<GunSt>();
        _cs_enemy = GetComponent<Enemy>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(_endFlag == true)
        {
            Destroy(this);
        }

        //���ʎ��Ԃ̉��Z
        _elapsedTime += Time.deltaTime;

        //����̃_���[�W�㏸
        float Damage = _cs_gunSt.GetGunDamage() * (int)_damageMagni;
        _cs_enemy.Damage((int)Damage);

        //����̈��͏㏸

        if(_elapsedTime >= _effectTime)
        {
            _endFlag = true;
        }

        //�������Ă��镐��ɔR����G�t�F�N�g
    }
}
