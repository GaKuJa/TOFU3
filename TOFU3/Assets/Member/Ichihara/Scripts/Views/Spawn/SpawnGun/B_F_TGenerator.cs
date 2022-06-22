using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// B�EF�ET�̃I�u�W�F�N�g�v�[������
/// </summary>


public class B_F_TGenerator : MonoBehaviour
{
    //YUBA-SHILD�̃v���n�u���i�[
    public GameObject _pfB_F_T;
    //�A�C�e������~���Ă���List 
    List<PoolingObjectPrefabs> _list_B_F_T = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_BFT;

            //�A�C�e���̐���
            gun_BFT = (Instantiate(_pfB_F_T)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spwanPos"></param>
    public void GenerateB_F_T(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_B_F_T.Count; i++)
        {
            if (_list_B_F_T[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < maxGuns)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_B_F_T[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
