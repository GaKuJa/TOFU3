using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// YUZU-RADAR�̃I�u�W�F�N�g�v�[������
/// </summary>

public class YUZU_RADARGenerator : MonoBehaviour
{
    //YUZU-RADAR�̃v���n�u���i�[
    public GameObject pfYUZU_RADAR;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_YUZU_RADAR = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_YUZU;

            //�A�C�e���̐���
            item_YUZU = (Instantiate(pfYUZU_RADAR)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_YUZU.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_YUZU.gameObject.SetActive(false);
            _list_YUZU_RADAR.Add(item_YUZU);
        }
    }

    /// <summary>
    /// List�u_list_YUZU_RADAR�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateYUZU_RADAR(Vector3 spawnPos)
    {

        for (int i = 0; i < _list_YUZU_RADAR.Count; i++)
        {
            if (_list_YUZU_RADAR[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_YUZU_RADAR[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
