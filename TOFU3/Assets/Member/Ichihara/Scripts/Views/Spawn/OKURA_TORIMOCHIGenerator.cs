using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHIGenerator : MonoBehaviour
{
    //YUBA-SHILD�̃v���n�u���i�[
    public GameObject _pfOKURA_TORIMOCHI;
    //�A�C�e������~���Ă���List 
    List<PoolingItemPrefabs> _list_OKURA_TORIMOCHI = new List<PoolingItemPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_OKURA;

            //�A�C�e���̐���
            item_OKURA = (Instantiate(_pfOKURA_TORIMOCHI)).GetComponent<PoolingItemPrefabs>();
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
    /// <param name="spwanPos"></param>
    public void SpawnOKURA_TORIMOCHI(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_OKURA_TORIMOCHI.Count; i++)
        {
            if (_list_OKURA_TORIMOCHI[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_OKURA_TORIMOCHI[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
