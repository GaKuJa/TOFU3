using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASHI_STIMGenerator : MonoBehaviour
{
    //YUBA-SHILDのプレハブを格納
    public GameObject _pfDASHI_STIM;
    //アイテムを備蓄しておくList 
    List<PoolingItemPrefabs> _list_DASHI_STIM = new List<PoolingItemPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_DASHI;

            //アイテムの生成
            item_DASHI = (Instantiate(_pfDASHI_STIM)).GetComponent<PoolingItemPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_DASHI.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_DASHI.gameObject.SetActive(false);
            _list_DASHI_STIM.Add(item_DASHI);
        }
    }

    /// <summary>
    /// List「_list_DASHI_STIM」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void SpawnDASHI_STIM(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_DASHI_STIM.Count; i++)
        {
            if (_list_DASHI_STIM[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_DASHI_STIM[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
