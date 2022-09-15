using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// KATSUO���m�̃I�u�W�F�N�g�v�[������
/// </summary>

public class KATSUO_BUSHIGenerator : MonoBehaviour
{
    //KATSUO���m�̃v���n�u���i�[
    private GameObject pfKATSUO_BUSHI = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_KATSUO_BUSHI = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int maxGuns = 5;

    // Start is called before the first frame update
    void Start()
    {
        pfKATSUO_BUSHI = GunList.Instance.Gun[4];

        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_KATSUO;

            //�A�C�e���̐���
            gun_KATSUO = (Instantiate(pfKATSUO_BUSHI)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uKATSUO_BUSHIGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_KATSUO.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_KATSUO.gameObject.SetActive(false);
            _list_KATSUO_BUSHI.Add(gun_KATSUO);
        }
    }

    /// <summary>
    /// List�u_list_KATSUO_BUSHI�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateKATSUO_BUSHI(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_KATSUO_BUSHI.Count; i++)
        {
            if (_list_KATSUO_BUSHI[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_KATSUO_BUSHI[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
