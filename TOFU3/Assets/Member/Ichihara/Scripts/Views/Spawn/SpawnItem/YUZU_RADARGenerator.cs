using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// YUZU-RADARのオブジェクトプール生成
/// </summary>

public class YUZU_RADARGenerator : MonoBehaviour
{
    //YUZU-RADARのプレハブを格納
    public GameObject pfYUZU_RADAR;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_YUZU_RADAR = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_YUZU;

            //アイテムの生成
            item_YUZU = (Instantiate(pfYUZU_RADAR)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_YUZU.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_YUZU.gameObject.SetActive(false);
            _list_YUZU_RADAR.Add(item_YUZU);
        }
    }

    /// <summary>
    /// List「_list_YUZU_RADAR」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateYUZU_RADAR(Vector3 spawnPos)
    {

        for (int i = 0; i < _list_YUZU_RADAR.Count; i++)
        {
            if (_list_YUZU_RADAR[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_YUZU_RADAR[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
