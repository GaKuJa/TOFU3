using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// KOYADOFU-GUN�̃I�u�W�F�N�g�v�[������
/// </summary>



public class KOYADOFU_GUNGenerator : MonoBehaviour
{
    //KOYADOFU-GUN�̃v���n�u���i�[
    public GameObject _pfKOYADOFU_GUN;
    //�A�C�e������~���Ă���List 
    List<PoolingObjectPrefabs> _list_KOYADOFU_GUN = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_KOYADOFU;

            //�A�C�e���̐���
            gun_KOYADOFU = (Instantiate(_pfKOYADOFU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uKOYADOFU_GUNGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_KOYADOFU.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_KOYADOFU.gameObject.SetActive(false);
            _list_KOYADOFU_GUN.Add(gun_KOYADOFU);
        }
    }

    /// <summary>
    /// List�u_list_KOYADOFU_GUN�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateKOYADOFU_GUN(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_KOYADOFU_GUN.Count; i++)
        {
            if (_list_KOYADOFU_GUN[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < maxGuns)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_KOYADOFU_GUN[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
