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
            //���F�̃I�[��(�G�t�F�N�g)

            //���ʎ���(10�b)
            _effectTime -= Time.deltaTime;

            //�󂯂�_���[�W��0�ɂ���
            //SHOYOUGUN.Instance.ShotDamage = 0;

            if(_effectTime <= 0.0f)
            {
                _endFlag = true;
            }




        } while (!_endFlag);
    }
}
