using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DASHI-STIM�̃I�u�W�F�N�g�v�[������
/// </summary>

public class DASHI_STIMGenerator : MonoBehaviour
{
    //DASHI-STIM�̃v���n�u���i�[
    public GameObject PfDASHI_STIM;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_DASHI_STIM = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_DASHI;

            //�A�C�e���̐���
            item_DASHI = (Instantiate(PfDASHI_STIM)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_DASHI.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_DASHI.gameObject.SetActive(false);
            _list_DASHI_STIM.Add(item_DASHI);
        }
    }

    /// <summary>
    /// List�u_list_DASHI_STIM�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateDASHI_STIM(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_DASHI_STIM.Count; i++)
        {
            if (_list_DASHI_STIM[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_DASHI_STIM[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetDASHI_STIM()
    {
        return PfDASHI_STIM;
    }

}
