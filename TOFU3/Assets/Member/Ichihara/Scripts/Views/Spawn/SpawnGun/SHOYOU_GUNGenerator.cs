using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// SHOYOU-GUN�̃I�u�W�F�N�g�v�[������
/// </summary>



public class SHOYOU_GUNGenerator : MonoBehaviour
{
    //SHOYOU-GUN�̃v���n�u���i�[
    public GameObject _pfSHOYOU_GUN;
    //�A�C�e������~���Ă���List 
    List<PoolingObjectPrefabs> _list_SHOYOU_GUN = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SHOYOU;

            //�A�C�e���̐���
            gun_SHOYOU = (Instantiate(_pfSHOYOU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uSHOYOU_GUNGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_SHOYOU.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_SHOYOU.gameObject.SetActive(false);
            _list_SHOYOU_GUN.Add(gun_SHOYOU);
        }
    }

    /// <summary>
    /// List�u_list_SHOYOU_GUN�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateSHOYOU_GUN(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_SHOYOU_GUN.Count; i++)
        {
            if (_list_SHOYOU_GUN[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < maxGuns)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_SHOYOU_GUN[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
