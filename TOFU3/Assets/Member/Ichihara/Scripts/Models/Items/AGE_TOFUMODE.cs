using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
{
    //必要なステータスの参照元
    public GameObject Player;
    public GameObject GunSt;
    public GameObject Enemy;
    private GunSt _cs_gunSt;
    private Enemy _cs_enemy;

    private void ItemEffect()
    {
        do
        {
            //効果時間の加算
            _elapsedTime += Time.deltaTime;

            //ダメージ無効化
            float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
            _cs_enemy.Damage((int)Damage);

            if (_elapsedTime >= _effectTime)
            {
                _endFlag = true;
            }

            //金色のオーラ(エフェクト)

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

    //接触したオブジェクトの情報を渡す
    private void AssignPlayerComponent()
    {
        GunSt = GameObject.Find("GunSt");
        Enemy = GameObject.Find("Enemy");
        _cs_gunSt = GetComponent<GunSt>();
        _cs_enemy = GetComponent<Enemy>();
    }
}
