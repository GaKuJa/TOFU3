using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMIZI_RED : BaseItemStatus
{
    //必要なステータスの参照元
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

        //効果時間の加算
        _elapsedTime += Time.deltaTime;

        //武器のダメージ上昇
        float Damage = _cs_gunSt.GetGunDamage() * (int)_damageMagni;
        _cs_enemy.Damage((int)Damage);

        //武器の圧力上昇

        if(_elapsedTime >= _effectTime)
        {
            _endFlag = true;
        }

        //装備している武器に燃えるエフェクト
    }
}
