using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SHOYU-GUNのオブジェクトプール生成
/// </summary>

public class SHOYU_GUNGenerator : MonoBehaviour
{
    //SHOYOU-GUNのプレハブを格納
    private GameObject pfSHOYU_GUN = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_SHOYU_GUN = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int maxGuns = 5;

    // Start is called before the first frame update
    void Start()
    {
        pfSHOYU_GUN = GunList.Instance.Gun[0];

        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SHOYU;

            //アイテムの生成
            gun_SHOYU = (Instantiate(pfSHOYU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「SHOYOU_GUNGenerator」オブジェクトの子にしておく
            gun_SHOYU.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_SHOYU.gameObject.SetActive(false);
            _list_SHOYU_GUN.Add(gun_SHOYU);
        }
    }

    /// <summary>
    /// List「_list_SHOYOU_GUN」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateSHOYU_GUN(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_SHOYU_GUN.Count; i++)
        {
            if (_list_SHOYU_GUN[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_SHOYU_GUN[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
