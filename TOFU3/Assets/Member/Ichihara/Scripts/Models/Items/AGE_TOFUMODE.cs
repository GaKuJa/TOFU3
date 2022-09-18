using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
{
    //必要なステータスの参照元
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

        //効果時間の加算
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _effectTime) { _endFlag = true; }
        EndItemEffect();
    }

    /// <summary>
    /// ダメージと圧力を無効化
    /// </summary>
    private void ItemEffect()
    {
        //ダメージを無効化
        float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
        _cs_enemy.Damage((int)Damage);
        //圧力を無効化
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
        //ダメージ無効化

    }

    /// <summary>
    /// 接触したオブジェクトの情報を渡す
    /// </summary>
    private void AssignPlayerComponent()
    {
        _cs_gunSt = _gunSt.GetComponent<GunSt>();
        _cs_enemy = _gunSt.GetComponent<Enemy>();
    }
}
