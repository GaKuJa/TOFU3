using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// YUBA-SHIELDのオブジェクトプール生成
/// </summary>

public class YUBA_SHIELDGenerator : MonoBehaviour
{
    //YUBA-SHILDのプレハブを格納
    private GameObject pfYUBA_SHIELD = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_YUBA_Shield = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int _maxItems = 5;

    // Start is called before the first frame update
    void Start()
    {
        pfYUBA_SHIELD = ItemList.Instance.Item[0];

        for(int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_YUBA;

            //アイテムの生成
            item_YUBA = (Instantiate(pfYUBA_SHIELD)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spawnPos"></param>
    public void GenerateYUBA_SHIELD(Vector3 spawnPos)
    {
        for(int i = 0; i < _list_YUBA_Shield.Count; i++)
        {
            if(_list_YUBA_Shield[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_YUBA_Shield[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetYUBA_SHIELD()
    {
        return pfYUBA_SHIELD;
    }
}
