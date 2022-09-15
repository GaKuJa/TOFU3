using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// B・F・Tのオブジェクトプール生成
/// </summary>

public class B_F_TGenerator : MonoBehaviour
{
    //YUBA-SHILDのプレハブを格納
    private GameObject pfB_F_T = null;

    //アイテムを備蓄しておくList 
    private List<PoolingObjectPrefabs> _list_B_F_T = new List<PoolingObjectPrefabs>();
    //備蓄しておくアイテムの数
    private const int maxGuns = 5;


    // Start is called before the first frame update
    void Start()
    {
        pfB_F_T = GunList.Instance.Gun[5];

        for (int i = 0; i < maxGuns; i++)
        {
            PoolingObjectPrefabs gun_BFT;

            //アイテムの生成
            gun_BFT = (Instantiate(pfB_F_T)).GetComponent<PoolingObjectPrefabs>();
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
    /// <param name="spawnPos"></param>
    public void GenerateB_F_T(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_B_F_T.Count; i++)
        {
            if (_list_B_F_T[i].gameObject.activeSelf == false)
            {
                //非アクティブのアイテムを生成する
                _list_B_F_T[i].InitItem(spawnPos);
                break;
            }
        }

        return;
    }

}
