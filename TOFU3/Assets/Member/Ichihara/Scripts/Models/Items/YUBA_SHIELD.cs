using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(攻撃一回無効) </summary>

public class YUBA_SHIELD : BaseItemStatus, IBaseBulletDamege
{
    //必要なステータスの参照元
    [SerializeField]
    private GameObject _gunSt = null;
    [SerializeField]
    private GameObject _enemy = null;

    private GunSt _cs_gunSt = null;
    private Enemy _cs_enemy = null;
    private ItemPickUp _pickUp = null;

    private void Update()
    {
        if (_pickUp.YubaShield == false) { return; }
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
            _pickUp = other.GetComponentInParent<ItemPickUp>();
            AssignCsComponent();
        }
        if (other.CompareTag("Shell"))
        {
            ReducedDamageAndPressed();
            _pickUp.YubaShield = false;
            _endFlag = true;
        }
    }

    /// <summary>
    /// ダメージと圧力を無効化
    /// </summary>
    private void ReducedDamageAndPressed()
    {
        //ダメージ無効化
        float Damage = _cs_gunSt.GetGunDamage() * _damageMagni;
        _cs_enemy.Damage((int)Damage);

        //圧力無効化
    }

    private void AssignCsComponent()
    {
        _cs_gunSt = _gunSt.GetComponent<GunSt>();
        _cs_enemy = _enemy.GetComponent<Enemy>();
    }

    public int BulletDamege(int playerHp, int bulletDamege)
    {
        float Damage = bulletDamege *_damageMagni;
        return playerHp -= (int)Damage;
    }

}
