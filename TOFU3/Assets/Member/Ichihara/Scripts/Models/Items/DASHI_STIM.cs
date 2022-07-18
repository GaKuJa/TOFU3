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
        bool buffSpeedUpFlag = false;

        do
        {
            _effectTime -= Time.deltaTime;

            //移動速度を上げる
            //スプリント時の速度を上げる
            //スライディング時の速度を上げる

            if(buffSpeedUpFlag == false)
            {
                _cs_playerStatus.buffSpeed *= _movePlayerMagni;

            }



            //効果時間(15秒)
            if (_effectTime <= 15.0f)
            {
                _endFlag = true;
            }

        } while (!_endFlag);
    }
}
