using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKAKA_CHAFGenerator : MonoBehaviour
{
    //YUBA-SHILD�̃v���n�u���i�[
    public GameObject _pfOKAKA_CHAF;
    //�A�C�e������~���Ă���List 
    List<PoolingItemPrefabs> _list_OKAKA_CHAF = new List<PoolingItemPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_OKAKA;

            //�A�C�e���̐���
            item_OKAKA = (Instantiate(_pfOKAKA_CHAF)).GetComponent<PoolingItemPrefabs>();
            //�A�C�e�������́uYUBA_SHIELDGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            item_OKAKA.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            item_OKAKA.gameObject.SetActive(false);
            _list_OKAKA_CHAF.Add(item_OKAKA);
        }
    }

    /// <summary>
    /// List�u_list_OKAKA_CHAF�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spwanPos"></param>
    public void SpawnOKAKA_CHAF(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_OKAKA_CHAF.Count; i++)
        {
            if (_list_OKAKA_CHAF[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_OKAKA_CHAF[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
