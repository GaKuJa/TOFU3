using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SHOYOU-GUN�̃I�u�W�F�N�g�v�[������
/// </summary>

public class SHOYOU_GUNGenerator : MonoBehaviour
{
    //SHOYOU-GUN�̃v���n�u���i�[
    public GameObject PfSHOYOU_GUN = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_SHOYOU_GUN = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SHOYOU;

            //�A�C�e���̐���
            gun_SHOYOU = (Instantiate(PfSHOYOU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uSHOYOU_GUNGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_SHOYOU.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_SHOYOU.gameObject.SetActive(false);
            _list_SHOYOU_GUN.Add(gun_SHOYOU);
        }
    }

    /// <summary>
    /// List�u_list_SHOYOU_GUN�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateSHOYOU_GUN(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_SHOYOU_GUN.Count; i++)
        {
            if (_list_SHOYOU_GUN[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_SHOYOU_GUN[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}