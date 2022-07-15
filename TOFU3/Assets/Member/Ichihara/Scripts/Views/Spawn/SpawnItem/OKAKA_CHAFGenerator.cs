using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OKAKA-CHAFのオブジェクトプール生成
/// </summary>

public class OKAKA_CHAFGenerator : MonoBehaviour
{
    //PKAKA-CHAFのプレハブを格納
    public GameObject PfOKAKA_CHAF;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_OKAKA_CHAF = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_OKAKA;

            //アイテムの生成
            item_OKAKA = (Instantiate(PfOKAKA_CHAF)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「YUBA_SHIELDGenerator」オブジェクトの子にしておく
            item_OKAKA.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            item_OKAKA.gameObject.SetActive(false);
            _list_OKAKA_CHAF.Add(item_OKAKA);
        }
    }

    /// <summary>
    /// List「_list_OKAKA_CHAF」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateOKAKA_CHAF(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_OKAKA_CHAF.Count; i++)
        {
            if (_list_OKAKA_CHAF[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_OKAKA_CHAF[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
