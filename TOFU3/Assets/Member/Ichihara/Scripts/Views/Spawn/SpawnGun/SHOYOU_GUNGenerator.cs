using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// SHOYOU-GUNのオブジェクトプール生成
/// </summary>



public class SHOYOU_GUNGenerator : MonoBehaviour
{
    //SHOYOU-GUNのプレハブを格納
    public GameObject _pfSHOYOU_GUN;
    //アイテムを備蓄しておくList 
    List<PoolingObjectPrefabs> _list_SHOYOU_GUN = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_SHOYOU;

            //アイテムの生成
            gun_SHOYOU = (Instantiate(_pfSHOYOU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「SHOYOU_GUNGenerator」オブジェクトの子にしておく
            gun_SHOYOU.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_SHOYOU.gameObject.SetActive(false);
            _list_SHOYOU_GUN.Add(gun_SHOYOU);
        }
    }

    /// <summary>
    /// List「_list_SHOYOU_GUN」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateSHOYOU_GUN(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_SHOYOU_GUN.Count; i++)
        {
            if (_list_SHOYOU_GUN[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < maxGuns)
            {
                //非アクティブのアイテムを生成する
                _list_SHOYOU_GUN[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
