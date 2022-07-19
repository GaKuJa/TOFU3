using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SHOYOU-GUNのオブジェクトプール生成
/// </summary>

public class SHOYOU_GUNGenerator : MonoBehaviour
{
    //SHOYOU-GUNのプレハブを格納
    public GameObject PfSHOYOU_GUN = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_SHOYOU_GUN = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SHOYOU;

            //アイテムの生成
            gun_SHOYOU = (Instantiate(PfSHOYOU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「SHOYOU_GUNGenerator」オブジェクトの子にしておく
            gun_SHOYOU.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_SHOYOU.gameObject.SetActive(false);
            _list_SHOYOU_GUN.Add(gun_SHOYOU);
        }
    }

    /// <summary>
    /// List「_list_SHOYOU_GUN」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateSHOYOU_GUN(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_SHOYOU_GUN.Count; i++)
        {
            if (_list_SHOYOU_GUN[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_SHOYOU_GUN[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
