using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// B�EF�ET�̃I�u�W�F�N�g�v�[������
/// </summary>

public class B_F_TGenerator : MonoBehaviour
{
    //YUBA-SHILD�̃v���n�u���i�[
    private GameObject pfB_F_T = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_B_F_T = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        pfB_F_T = GunList.Instance.Gun[5];

        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_BFT;

            //�A�C�e���̐���
            gun_BFT = (Instantiate(pfB_F_T)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uB_F_TGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_BFT.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_BFT.gameObject.SetActive(false);
            _list_B_F_T.Add(gun_BFT);
        }
    }

    /// <summary>
    /// List�u_list_B_F_T�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateB_F_T(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_B_F_T.Count; i++)
        {
            if (_list_B_F_T[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_B_F_T[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
