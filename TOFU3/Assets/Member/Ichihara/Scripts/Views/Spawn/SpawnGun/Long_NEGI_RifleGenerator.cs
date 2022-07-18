using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Long-NEGI-Rifle�̃I�u�W�F�N�g�v�[������
/// </summary>

public class Long_NEGI_RifleGenerator : MonoBehaviour
{
    //Long-NEGI-Rifle�̃v���n�u���i�[
    public GameObject PfLong_NEGI_Rifle = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_Long_NEGI_Rifle = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_NEGI;

            //�A�C�e���̐���
            gun_NEGI = (Instantiate(PfLong_NEGI_Rifle)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uLong_NEGI_RifleGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_NEGI.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_NEGI.gameObject.SetActive(false);
            _list_Long_NEGI_Rifle.Add(gun_NEGI);
        }
    }

    /// <summary>
    /// List�u_list_Long_NEGI_Rifle�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateLong_NEGI_Rifle(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_Long_NEGI_Rifle.Count; i++)
        {
            if (_list_Long_NEGI_Rifle[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_Long_NEGI_Rifle[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
