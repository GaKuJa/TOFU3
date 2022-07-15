using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OKAKA-CHAF�̃I�u�W�F�N�g�v�[������
/// </summary>

public class OKAKA_CHAFGenerator : MonoBehaviour
{
    //PKAKA-CHAF�̃v���n�u���i�[
    public GameObject PfOKAKA_CHAF;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_OKAKA_CHAF = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_OKAKA;

            //�A�C�e���̐���
            item_OKAKA = (Instantiate(PfOKAKA_CHAF)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spawnPos"></param>
    public void GenerateOKAKA_CHAF(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_OKAKA_CHAF.Count; i++)
        {
            if (_list_OKAKA_CHAF[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_OKAKA_CHAF[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
