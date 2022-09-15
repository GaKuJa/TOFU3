using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MOMIZI-REDのオブジェクトプール生成
/// </summary>

public class MOMIZI_REDGenerator : MonoBehaviour
{
    //MOMIZI-REDのプレハブを格納
    private GameObject pfMOMIZI_RED = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_MOMIZI_RED = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        pfMOMIZI_RED = ItemList.Instance.Item[5];

        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_MOMIZI;

            //アイテムの生成
            item_MOMIZI = (Instantiate(pfMOMIZI_RED)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_MOMIZI.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_MOMIZI.gameObject.SetActive(false);
            _list_MOMIZI_RED.Add(item_MOMIZI);
        }
    }

    /// <summary>
    /// List「_list_MOMIZI_RED」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateMOMIZI_RED(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_MOMIZI_RED.Count; i++)
        {
            if (_list_MOMIZI_RED[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_MOMIZI_RED[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetMOMIZI_RED()
    {
        return pfMOMIZI_RED;
    }
}
