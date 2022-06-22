using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// KOYADOFU-GUNのオブジェクトプール生成
/// </summary>



public class KOYADOFU_GUNGenerator : MonoBehaviour
{
    //KOYADOFU-GUNのプレハブを格納
    public GameObject _pfKOYADOFU_GUN;
    //アイテムを備蓄しておくList 
    List<PoolingObjectPrefabs> _list_KOYADOFU_GUN = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_KOYADOFU;

            //アイテムの生成
            gun_KOYADOFU = (Instantiate(_pfKOYADOFU_GUN)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「KOYADOFU_GUNGenerator」オブジェクトの子にしておく
            gun_KOYADOFU.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_KOYADOFU.gameObject.SetActive(false);
            _list_KOYADOFU_GUN.Add(gun_KOYADOFU);
        }
    }

    /// <summary>
    /// List「_list_KOYADOFU_GUN」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateKOYADOFU_GUN(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_KOYADOFU_GUN.Count; i++)
        {
            if (_list_KOYADOFU_GUN[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < maxGuns)
            {
                //非アクティブのアイテムを生成する
                _list_KOYADOFU_GUN[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
