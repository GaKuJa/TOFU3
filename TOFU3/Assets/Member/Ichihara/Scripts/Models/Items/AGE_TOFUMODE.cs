using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus = null;

    private bool _endFlag = false;

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        GetAGE_TOFUMODE();
    }

    private void GetAGE_TOFUMODE()
    {
        do
        {
            //効果時間(10秒)
            //受けるダメージを0にする
            //金色のオーラ(エフェクト)

        } while (!_endFlag);
    }
}
