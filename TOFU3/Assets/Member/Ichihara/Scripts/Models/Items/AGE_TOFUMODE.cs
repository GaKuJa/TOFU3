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
            //���ʎ���(10�b)
            //�󂯂�_���[�W��0�ɂ���
            //���F�̃I�[��(�G�t�F�N�g)

        } while (!_endFlag);
    }
}
