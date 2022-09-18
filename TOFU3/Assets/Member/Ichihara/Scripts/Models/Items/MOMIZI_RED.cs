using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMIZI_RED : BaseItemStatus
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
        if (_elapsedTime > _effectTime || _pickUp.MomijiRed == false) { return; }

        //効果時間の加算
        _elapsedTime += Time.deltaTime;

        ItemEffect();

        if (_elapsedTime >= _effectTime) { _endFlag = true; }
        EndItemEffect();
    }

    private void ItemEffect()
    {
        //武器のダメージ上昇
        float Damage = _cs_gunSt.GetGunDamage() * (int)_damageMagni;
        _cs_enemy.Damage((int)Damage);
        //武器の圧力上昇
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            AssignCsComponent();
        }
    }

    //接触したオブジェクトの情報を渡す
    private void AssignCsComponent()
    {
        _cs_gunSt = _gunSt.GetComponent<GunSt>();
        _cs_enemy = _enemy.GetComponent<Enemy>();

    }
}
