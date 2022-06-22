using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// MOMIZI-RED�̃I�u�W�F�N�g�v�[������
/// </summary>



public class MOMIZI_REDGenerator : MonoBehaviour
{
    //MOMIZI-RED�̃v���n�u���i�[
    public GameObject _pfMOMIZI_RED;
    //�A�C�e������~���Ă���List 
    List<PoolingObjectPrefabs> _list_MOMIZI_RED = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_MOMIZI;

            //�A�C�e���̐���
            item_MOMIZI = (Instantiate(_pfMOMIZI_RED)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spwanPos"></param>
    public void GenerateMOMIZI_RED(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_MOMIZI_RED.Count; i++)
        {
            if (_list_MOMIZI_RED[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Item").Length < _maxItems)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_MOMIZI_RED[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
