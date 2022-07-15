using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIM : BaseItemStatus
{
    [SerializeField]
    private PlayerStatus _cs_playerStatus = null;

    private bool _endFlag = false;

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        GetDASHI_STIM();
    }

    private void GetDASHI_STIM()
    {
        //効果時間(15秒)
        _effectTime = 15.0f;

        do
        {
            _effectTime -= Time.deltaTime;

            //移動速度を上げる
            //スプリント時の速度を上げる
            //スライディング時の速度を上げる

        } while (!_endFlag);
    }
}
