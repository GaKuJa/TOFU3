using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OKURA-TORIMOCHIのオブジェクトプール生成
/// </summary>

public class OKURA_TORIMOCHIGenerator : MonoBehaviour
{
    //OKURA-TORIMOCHIのプレハブを格納
    public GameObject PfOKURA_TORIMOCHI;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_OKURA_TORIMOCHI = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int _maxItems = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            PoolingObjectPrefabs item_OKURA;

            //アイテムの生成
            item_OKURA = (Instantiate(PfOKURA_TORIMOCHI)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spawnPos"></param>
    public void GenerateOKURA_TORIMOCHI(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_OKURA_TORIMOCHI.Count; i++)
        {
            if (_list_OKURA_TORIMOCHI[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_OKURA_TORIMOCHI[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

    public GameObject GetOKURA_TORIMOCHI()
    {
        return PfOKURA_TORIMOCHI;
    }
}
