using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SHOYU-GUN�̃I�u�W�F�N�g�v�[������
/// </summary>

public class SHOYU_GUNGenerator : MonoBehaviour
{
    //SHOYOU-GUN�̃v���n�u���i�[
    private GameObject pfSHOYU_GUN = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_SHOYU_GUN = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int maxGuns = 5;

    // Start is called before the first frame update
    void Start()
    {
        pfSHOYU_GUN = GunList.Instance.Gun[0];

        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SHOYU;

            //�A�C�e���̐���
            gun_SHOYU = (Instantiate(pfSHOYU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uSHOYOU_GUNGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_SHOYU.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_SHOYU.gameObject.SetActive(false);
            _list_SHOYU_GUN.Add(gun_SHOYU);
        }
    }

    /// <summary>
    /// List�u_list_SHOYOU_GUN�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateSHOYU_GUN(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_SHOYU_GUN.Count; i++)
        {
            if (_list_SHOYU_GUN[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_SHOYU_GUN[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
