using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// B・F・Tのオブジェクトプール生成
/// </summary>


public class B_F_TGenerator : MonoBehaviour
{
    //YUBA-SHILDのプレハブを格納
    public GameObject _pfB_F_T;
    //アイテムを備蓄しておくList 
    List<PoolingObjectPrefabs> _list_B_F_T = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_BFT;

            //アイテムの生成
            gun_BFT = (Instantiate(_pfB_F_T)).GetComponent<PoolingObjectPrefabs>();
            //アイテムをこの「B_F_TGenerator」オブジェクトの子にしておく
            gun_BFT.transform.parent = this.transform;
            //フィールドにスポーンする前は非アクティブにしておく
            gun_BFT.gameObject.SetActive(false);
            _list_B_F_T.Add(gun_BFT);
        }
    }

    /// <summary>
    /// List「_list_B_F_T」の中身を最初から確認していき、
    /// 非アクティブのオブジェクトを探す関数
    /// </summary>
    /// <param name="spwanPos"></param>
    public void GenerateB_F_T(Vector3 spwanPos)
    {
        for (int i = 0; i < _list_B_F_T.Count; i++)
        {
            if (_list_B_F_T[i].gameObject.activeSelf == false && GameObject.FindGameObjectsWithTag("Gun").Length < maxGuns)
            {
                //非アクティブのアイテムを生成する
                _list_B_F_T[i].InitItem(spwanPos);
                break;
            }
        }

        return;
    }

}
