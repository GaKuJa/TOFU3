using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MOMIZI-RED�̃I�u�W�F�N�g�v�[������
/// </summary>

public class MOMIZI_REDGenerator : MonoBehaviour
{
    //MOMIZI-RED�̃v���n�u���i�[
    private GameObject pfMOMIZI_RED = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_MOMIZI_RED = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        pfMOMIZI_RED = ItemList.Instance.Item[5];

        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_MOMIZI;

            //�A�C�e���̐���
            item_MOMIZI = (Instantiate(pfMOMIZI_RED)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_MOMIZI.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_MOMIZI.gameObject.SetActive(false);
            _list_MOMIZI_RED.Add(item_MOMIZI);
        }
    }

    /// <summary>
    /// List�u_list_MOMIZI_RED�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateMOMIZI_RED(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_MOMIZI_RED.Count; i++)
        {
            if (_list_MOMIZI_RED[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_MOMIZI_RED[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetMOMIZI_RED()
    {
        return pfMOMIZI_RED;
    }
}
