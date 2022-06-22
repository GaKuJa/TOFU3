using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// AGE-TOFUMODOのオブジェクトプール生成
/// </summary>



public class AGE_TOFUMODEGenerator : MonoBehaviour
{
    //AGE-TOFUMODOのプレハブを格納
    public GameObject _pfAGE_TOFUMODE;
    //アイテムを備蓄しておくList 
    List<PoolingObjectPrefabs> _list_AGE_TOFUMODE = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_TOFUMODE;

            //アイテムの生成
            item_TOFUMODE = (Instantiate(_pfAGE_TOFUMODE)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_TOFUMODE.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_TOFUMODE.gameObject.SetActive(false);
            _list_AGE_TOFUMODE.Add(item_TOFUMODE);
        }
    }

    /// <summary>
    /// List「_list_AGE_TOFUMODE」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateAGE_TOFUMODE(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_AGE_TOFUMODE.Count; i++)
        {
            if (_list_AGE_TOFUMODE[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Item").Length < _maxItems)
            {
                //非アクティブのアイテムを生成する
                _list_AGE_TOFUMODE[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
