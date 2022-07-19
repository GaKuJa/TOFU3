using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Long-NEGI-Rifleのオブジェクトプール生成
/// </summary>

public class Long_NEGI_RifleGenerator : MonoBehaviour
{
    //Long-NEGI-Rifleのプレハブを格納
    public GameObject PfLong_NEGI_Rifle = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_Long_NEGI_Rifle = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_NEGI;

            //アイテムの生成
            gun_NEGI = (Instantiate(PfLong_NEGI_Rifle)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「Long_NEGI_RifleGenerator」オブジェクトの子にしておく
            gun_NEGI.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_NEGI.gameObject.SetActive(false);
            _list_Long_NEGI_Rifle.Add(gun_NEGI);
        }
    }

    /// <summary>
    /// List「_list_Long_NEGI_Rifle」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateLong_NEGI_Rifle(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_Long_NEGI_Rifle.Count; i++)
        {
            if (_list_Long_NEGI_Rifle[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_Long_NEGI_Rifle[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
