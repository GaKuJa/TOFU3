using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUZU_RADARGenerator : MonoBehaviour
{
    //YUBA-SHILDのプレハブを格納
    public GameObject _pfYUZU_RADAR;
    //アイテムを備蓄しておくList 
    List<PoolingItemPrefabs> _list_YUZU_RADAR = new List<PoolingItemPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_YUZU;

            //アイテムの生成
            item_YUZU = (Instantiate(_pfYUZU_RADAR)).GetComponent<PoolingItemPrefabs>();
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
    /// <param name="spwanPos"></param>
    public void SpawnYUZU_RADAR(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_YUZU_RADAR.Count; i++)
        {
            if (_list_YUZU_RADAR[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_YUZU_RADAR[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
