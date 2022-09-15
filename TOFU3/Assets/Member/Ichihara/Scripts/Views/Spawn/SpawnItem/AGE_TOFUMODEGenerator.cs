using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AGE-TOFUMODO�̃I�u�W�F�N�g�v�[������
/// </summary>

public class AGE_TOFUMODEGenerator : MonoBehaviour
{
    //AGE-TOFUMODO�̃v���n�u���i�[
    private GameObject pfAGE_TOFUMODE;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_AGE_TOFUMODE = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;

    // Start is called before the first frame update
    void Start()
    {
        pfAGE_TOFUMODE = ItemList.Instance.Item[4];

        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_TOFUMODE;

            //�A�C�e���̐���
            item_TOFUMODE = (Instantiate(pfAGE_TOFUMODE)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_TOFUMODE.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_TOFUMODE.gameObject.SetActive(false);
            _list_AGE_TOFUMODE.Add(item_TOFUMODE);
        }
    }

    /// <summary>
    /// List�u_list_AGE_TOFUMODE�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateAGE_TOFUMODE(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_AGE_TOFUMODE.Count; i++)
        {
            if (_list_AGE_TOFUMODE[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_AGE_TOFUMODE[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetAGE_TOFUMODE()
    {
        return pfAGE_TOFUMODE;
    }

}
