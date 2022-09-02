using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OKURA-TORIMOCHI�̃I�u�W�F�N�g�v�[������
/// </summary>

public class OKURA_TORIMOCHIGenerator : MonoBehaviour
{
    //OKURA-TORIMOCHI�̃v���n�u���i�[
    public GameObject PfOKURA_TORIMOCHI;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_OKURA_TORIMOCHI = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_OKURA;

            //�A�C�e���̐���
            item_OKURA = (Instantiate(PfOKURA_TORIMOCHI)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_OKURA.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_OKURA.gameObject.SetActive(false);
            _list_OKURA_TORIMOCHI.Add(item_OKURA);
        }
    }

    /// <summary>
    /// List�u_list_OKURA_TORIMOCHI�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateOKURA_TORIMOCHI(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_OKURA_TORIMOCHI.Count; i++)
        {
            if (_list_OKURA_TORIMOCHI[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_OKURA_TORIMOCHI[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetOKURA_TORIMOCHI()
    {
        return PfOKURA_TORIMOCHI;
    }
}
