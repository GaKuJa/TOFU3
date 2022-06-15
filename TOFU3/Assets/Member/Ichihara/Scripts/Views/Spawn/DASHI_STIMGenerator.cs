using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIMGenerator : MonoBehaviour
{
    //YUBA-SHILD�̃v���n�u���i�[
    public GameObject _pfDASHI_STIM;
    //�A�C�e������~���Ă���List 
    List<PoolingItemPrefabs> _list_DASHI_STIM = new List<PoolingItemPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_DASHI;

            //�A�C�e���̐���
            item_DASHI = (Instantiate(_pfDASHI_STIM)).GetComponent<PoolingItemPrefabs>();
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
    /// <param name="spwanPos"></param>
    public void SpawnDASHI_STIM(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_DASHI_STIM.Count; i++)
        {
            if (_list_DASHI_STIM[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_DASHI_STIM[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
