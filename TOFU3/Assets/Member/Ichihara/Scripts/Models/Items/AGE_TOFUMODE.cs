using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
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
        if (_elapsedTime > _effectTime || _pickUp.AgeTofu == false) { return; }

        //���ʎ��Ԃ̉��Z
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _effectTime) { _endFlag = true; }
        EndItemEffect();
    }

    /// <summary>
    /// �_���[�W�ƈ��͂𖳌���
    /// </summary>
    private void ItemEffect()
    {
        //�_���[�W�𖳌���
        float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
        _cs_enemy.Damage((int)Damage);
        //���͂𖳌���
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.InitializeElapsedTime();
            _player = other.gameObject;
            _pickUp = _player.GetComponentInParent<ItemPickUp>();
            AssignPlayerComponent();
        }

        if (other.CompareTag("Shell") && _endFlag == false) { ItemEffect(); }
    }

    private void ReducedDamage()
    {
        //�_���[�W������

    }

    /// <summary>
    /// �ڐG�����I�u�W�F�N�g�̏���n��
    /// </summary>
    private void AssignPlayerComponent()
    {
        _cs_gunSt = _gunSt.GetComponent<GunSt>();
        _cs_enemy = _gunSt.GetComponent<Enemy>();
    }
}
