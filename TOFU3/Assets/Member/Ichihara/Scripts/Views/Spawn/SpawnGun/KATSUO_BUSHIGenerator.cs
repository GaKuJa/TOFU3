using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// KATSUO武士のオブジェクトプール生成
/// </summary>

public class KATSUO_BUSHIGenerator : MonoBehaviour
{
    //KATSUO武士のプレハブを格納
    private GameObject pfKATSUO_BUSHI = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_KATSUO_BUSHI = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int maxGuns = 5;

    // Start is called before the first frame update
    void Start()
    {
        pfKATSUO_BUSHI = GunList.Instance.Gun[4];

        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_KATSUO;

            //アイテムの生成
            gun_KATSUO = (Instantiate(pfKATSUO_BUSHI)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「KATSUO_BUSHIGenerator」オブジェクトの子にしておく
            gun_KATSUO.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_KATSUO.gameObject.SetActive(false);
            _list_KATSUO_BUSHI.Add(gun_KATSUO);
        }
    }

    /// <summary>
    /// List「_list_KATSUO_BUSHI」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GenerateKATSUO_BUSHI(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_KATSUO_BUSHI.Count; i++)
        {
            if (_list_KATSUO_BUSHI[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_KATSUO_BUSHI[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
