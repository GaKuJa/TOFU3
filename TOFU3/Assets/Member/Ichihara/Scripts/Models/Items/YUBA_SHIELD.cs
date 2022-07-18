using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(攻撃一回無効) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private Collision _col = null;

    private bool _endFlag = false;

    private void Start()
    {
        //ダメージ倍率、圧力倍率を初期化
        _damageMagni = 0.0f;
        _pressForceMagni = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _col = collision;
        this.gameObject.SetActive(false);
        GetYUBA_SHIELD();
    }

    private void GetYUBA_SHIELD()
    {
        do
        {
            //取得したプレイヤーの周りを青くハイライト

            //if (/*弾がプレイヤーに当たったら*/)
            //{
            //    //ダメージを一回だけ０にする
            //    SHOYOUGUN.Instance.ShotDamage *= _damageMagni;
            //    //圧力を一回だけ０にする
            //    SHOYOUGUN.Instance._forcePower *= _pressForceMagni;
            //    _endFlag = true;
            //}


        } while (!_endFlag);
    }
}
