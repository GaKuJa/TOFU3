using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMIZI_RED : BaseItemStatus
{
    //�K�v�ȃX�e�[�^�X�̎Q�ƌ�
    [SerializeField]
    private GameObject _gunSt = null;
    [SerializeField]
    private GameObject _enemy = null;

    private GameObject _player = null;
    private GunSt _cs_gunSt = null;
    private Enemy _cs_enemy = null;
    private ItemPickUp _pickUp = null;

    private void Update()
    {
        if (_elapsedTime > _effectTime || _pickUp.MomijiRed == false) { return; }

        //���ʎ��Ԃ̉��Z
        _elapsedTime += Time.deltaTime;

        ItemEffect();

        if (_elapsedTime >= _effectTime) { _endFlag = true; }
        EndItemEffect();
    }

    private void ItemEffect()
    {
        //����̃_���[�W�㏸
        float Damage = _cs_gunSt.GetGunDamage() * (int)_damageMagni;
        _cs_enemy.Damage((int)Damage);
        //����̈��͏㏸
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            AssignCsComponent();
        }
    }

    //�ڐG�����I�u�W�F�N�g�̏���n��
    private void AssignCsComponent()
    {
        _cs_gunSt = _gunSt.GetComponent<GunSt>();
        _cs_enemy = _enemy.GetComponent<Enemy>();

    }
}
