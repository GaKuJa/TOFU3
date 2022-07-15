using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> YUBA-SHIELD(攻撃一回無効) </summary>

public class YUBA_SHIELD : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus;

    private bool _endFlag = false;

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        GetYUBA_SHIELD();
    }

    private void GetYUBA_SHIELD()
    {
        do
        {
            //取得したプレイヤーの周りを青くハイライト

            //if (/*弾がこのアイテムを取得したプレイヤーに当たったら*/)
            //{
            //    //ダメージを一回だけ０にする
            //    //圧力を一回だけ０にする
            //}


        } while (!_endFlag);
    }
}
