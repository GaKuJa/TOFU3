using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// YUBA-SHIELD�̃I�u�W�F�N�g�v�[������
/// </summary>

public class YUBA_SHIELDGenerator : MonoBehaviour
{
    //YUBA-SHILD�̃v���n�u���i�[
    public GameObject pfYUBA_SHIELD;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_YUBA_Shield = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_YUBA;

            //�A�C�e���̐���
            item_YUBA = (Instantiate(pfYUBA_SHIELD)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_YUBA.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_YUBA.gameObject.SetActive(false);
            _list_YUBA_Shield.Add(item_YUBA);
        }
    }

    /// <summary>
    /// List�u_list_YUBA_Shield�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateYUBA_SHIELD(Vector3 spawnPos)
    {
        for(int i = 0; i < _list_YUBA_Shield.Count; i++)
        {
            if(_list_YUBA_Shield[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_YUBA_Shield[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}