using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// SESAMI-Shooterのオブジェクトプール生成
/// </summary>



public class SESAMI_ShooterGenerator : MonoBehaviour
{

    //SESAMI-Shooterのプレハブを格納
    public GameObject _pfSESAMI_Shoot;
    //アイテムを備蓄しておくList 
    List<PoolingObjectPrefabs> _list_SESAMI_Shoot = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SESAMI;

            //アイテムの生成
            gun_SESAMI = (Instantiate(_pfSESAMI_Shoot)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「SESAMI_ShootGenerator」オブジェクトの子にしておく
            gun_SESAMI.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_SESAMI.gameObject.SetActive(false);
            _list_SESAMI_Shoot.Add(gun_SESAMI);
        }
    }

    /// <summary>
    /// List「_list_SESAMI_Shoot」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateSESAMI_Shoot(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_SESAMI_Shoot.Count; i++)
        {
            if (_list_SESAMI_Shoot[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < _maxGuns)
            {
                //非アクティブのアイテムを生成する
                _list_SESAMI_Shoot[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
