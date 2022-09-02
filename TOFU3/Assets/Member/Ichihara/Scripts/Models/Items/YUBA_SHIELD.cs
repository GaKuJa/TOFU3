using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(攻撃一回無効) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    //必要なステータスの参照元
    public GameObject Player;
    public GameObject GunSt;
    public GameObject Enemy;
    private GunSt _cs_gunSt;
    private Enemy _cs_enemy;

    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private void Update()
    {
        EndItemEffect();

        //取得したプレイヤーの周りを青くハイライト

    }

    /// <summary>
    /// 弾が当たった時、一度だけダメージ、圧力を一回無効化
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            AssignPlayerComponent();
            Update();
        }

        if (other.CompareTag("Shell"))
        {
            //ダメージ無効化
            float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
            _cs_enemy.Damage((int)Damage);

            //圧力無効化

            _endFlag = true;
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
