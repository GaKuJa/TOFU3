using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// MOMIZI-REDのオブジェクトプール生成
/// </summary>



public class MOMIZI_REDGenerator : MonoBehaviour
{
    //MOMIZI-REDのプレハブを格納
    public GameObject _pfMOMIZI_RED;
    //アイテムを備蓄しておくList 
    List<PoolingObjectPrefabs> _list_MOMIZI_RED = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_MOMIZI;

            //アイテムの生成
            item_MOMIZI = (Instantiate(_pfMOMIZI_RED)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spwanPos"></param>
    public void GenerateMOMIZI_RED(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_MOMIZI_RED.Count; i++)
        {
            if (_list_MOMIZI_RED[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Item").Length < _maxItems)
            {
                //非アクティブのアイテムを生成する
                _list_MOMIZI_RED[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
