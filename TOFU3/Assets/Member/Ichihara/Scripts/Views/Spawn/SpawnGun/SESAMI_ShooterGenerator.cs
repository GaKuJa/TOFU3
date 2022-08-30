using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SESAMI-Shooter�̃I�u�W�F�N�g�v�[������
/// </summary>

public class SESAMI_ShooterGenerator : MonoBehaviour
{
    //SESAMI-Shooter�̃v���n�u���i�[
    public GameObject PfSESAMI_Shoot = null;

    //�A�C�e������~���Ă���List 
    private List<PoolingObjectPrefabs> _list_SESAMI_Shoot = new List<PoolingObjectPrefabs>();
    //���~���Ă����A�C�e���̐�
    private const int _maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SESAMI;

            //�A�C�e���̐���
            gun_SESAMI = (Instantiate(PfSESAMI_Shoot)).GetComponent<PoolingObjectPrefabs>();
            //�A�C�e�������́uSESAMI_ShootGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            gun_SESAMI.transform.parent = this.transform;
            //�t�B�[���h�ɃX�|�[������O�͔�A�N�e�B�u�ɂ��Ă���
            gun_SESAMI.gameObject.SetActive(false);
            _list_SESAMI_Shoot.Add(gun_SESAMI);
        }
    }

    /// <summary>
    /// List�u_list_SESAMI_Shoot�v�̒��g���ŏ�����m�F���Ă����A
    /// ��A�N�e�B�u�̃I�u�W�F�N�g��T���֐�
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateSESAMI_Shoot(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_SESAMI_Shoot.Count; i++)
        {
            if (_list_SESAMI_Shoot[i].gameObject.activeSelf == false)
            {
                //��A�N�e�B�u�̃A�C�e���𐶐�����
                _list_SESAMI_Shoot[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}