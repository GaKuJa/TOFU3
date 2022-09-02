using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(攻撃一回無効) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
<<<<<<< HEAD
    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private bool _endFlag = false;

    private void Start()
    {

        //ダメージ倍率、圧力倍率を初期化
        _damageMagni = 0.0f;
        _pressForceMagni = 0.0f;
=======
    //必要なステータスの参照元
    private GunSt _cs_gunSt = null;
    private Enemy _cs_enemy = null;

    private void Start()
    {
        _cs_gunSt = GetComponent<GunSt>();
        _cs_enemy = GetComponent<Enemy>();
>>>>>>> main
    }

    private void Update()
    {
<<<<<<< HEAD
        //取得したプレイヤーの周りを青くハイライト

        //if (/*弾がプレイヤーに当たったら*/)
        //{
        //    YUBA_SHIELDEffect();
        //    _endFlag = true;
        //}

    }

    private void YUBA_SHIELDEffect()
    {

        //ダメージを一回だけ０にする
        SHOYOUGUN.Instance.ShotDamage *= _damageMagni;
        //圧力を一回だけ０にする
        SHOYOUGUN.Instance._forcePower *= _pressForceMagni;
=======
        EndItemEffect();

        //取得したプレイヤーの周りを青くハイライト

    }

    /// <summary>
    /// 弾が当たった時、一度だけダメージ、圧力を一回無効化
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //ダメージ無効化
        float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
        _cs_enemy.Damage((int)Damage);

        //圧力無効化


        _endFlag = true;
>>>>>>> main
    }

}
