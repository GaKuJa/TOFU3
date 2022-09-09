using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGE_TOFUMODE : BaseItemStatus
{
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
            //金色のオーラ(エフェクト)

            //効果時間(10秒)
            _effectTime -= Time.deltaTime;

            //受けるダメージを0にする
            //SHOYOUGUN.Instance.ShotDamage = 0;

            if(_effectTime <= 0.0f)
            {
                _endFlag = true;
            }




        } while (!_endFlag);
    }
}
