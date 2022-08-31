using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
{
    //必要なステータスの参照元
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
    }

}
