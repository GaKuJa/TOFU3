using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUBA_SHIELDGenerator : MonoBehaviour
{

    //YUBA-SHILDのプレハブを格納
    public GameObject _pfYUBA_SHIELD;
    //アイテムを備蓄しておくList 
    List<PoolingItemPrefabs> _list_YUBA_Shield = new List<PoolingItemPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_YUBA;

            //アイテムの生成
            item_YUBA = (Instantiate(_pfYUBA_SHIELD)).GetComponent<PoolingItemPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_YUBA.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_YUBA.gameObject.SetActive(false);
            _list_YUBA_Shield.Add(item_YUBA);
        }
    }

    /// <summary>
    /// List「_list_YUBA_Shield」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void SpawnYUBA_SHIELD(Vector3 spwanPos)
    {
        for(int i = 0; i < _list_YUBA_Shield.Count; i++)
        {
            if(_list_YUBA_Shield[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_YUBA_Shield[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
