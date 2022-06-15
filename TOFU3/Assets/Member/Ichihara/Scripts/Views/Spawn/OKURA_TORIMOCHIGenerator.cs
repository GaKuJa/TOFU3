using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKURA_TORIMOCHIGenerator : MonoBehaviour
{
    //YUBA-SHILDのプレハブを格納
    public GameObject _pfOKURA_TORIMOCHI;
    //アイテムを備蓄しておくList 
    List<PoolingItemPrefabs> _list_OKURA_TORIMOCHI = new List<PoolingItemPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingItemPrefabs item_OKURA;

            //アイテムの生成
            item_OKURA = (Instantiate(_pfOKURA_TORIMOCHI)).GetComponent<PoolingItemPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_OKURA.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_OKURA.gameObject.SetActive(false);
            _list_OKURA_TORIMOCHI.Add(item_OKURA);
        }
    }

    /// <summary>
    /// List「_list_OKURA_TORIMOCHI」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void SpawnOKURA_TORIMOCHI(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_OKURA_TORIMOCHI.Count; i++)
        {
            if (_list_OKURA_TORIMOCHI[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_OKURA_TORIMOCHI[i].InitItem(spwanPos);
                return;
            }
        }
    }

}
