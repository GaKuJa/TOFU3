using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ItemSpontScript : MonoBehaviour
{
    [SerializeField]
    private GameObject itemGameObject;
    [SerializeField]
    private List<GameObject> groundList = new List<GameObject>();

    [SerializeField]
    private List<GameObject> objList = new List<GameObject>();

    [SerializeField]
    private float randomNum = 0;
    private  int hoge = 0;

    private void Start()
    {
        ItemCreat();
        hoge = GetRandomSum();
        Debug.Log(hoge);
        Debug.Log(objList[2]);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            ItemCreat();
    }

    // アイテム作成関数
    private void ItemCreat()
    {
        /*
        List<Vector3> objPosList = new List<Vector3>();
        for (int i = 0; i < objList.Count; i++)
        {
            objList.Add(objList[i]);
        }
        */
        // 地面の数だけランダムを取得するList
        List<int> randomGetList = new List<int>();
        // 地面をランダムにアイテム数分取得（重複なし）
        for (int i = randomGetList.Count; i < groundList.Count-2; i++)
        {
            // ランダムをListに挿入
            randomGetList.Add(GetRandomSum());
            // 重複があったら削除vvvvcs
            randomGetList = (List<int>)randomGetList.Distinct();
        }
        
        // ランダムの数だけアイテム生成
        for (int i = 0; i < randomGetList.Count; i++)
        {
            GameObject item = Instantiate(itemGameObject, 
                                          GetRandomPos(randomGetList[i]), 
                                          Quaternion.identity);
            Destroy(item,1.0f);
        }
    }
    // 地面のランダムな座標を取得　
    private Vector3 GetRandomPos(int randomList)
    {
        return groundList[randomList].transform.position + new Vector3(Random.Range(-groundList[randomList].transform.localScale.x/2+randomNum, groundList[randomList].transform.localScale.x/2-randomNum),
                                                                       groundList[randomList].transform.localScale.y/2 + 0.5f, 
                                                                       Random.Range(-groundList[randomList].transform.localScale.z/2+randomNum, groundList[randomList].transform.localScale.z/2-randomNum));
        
    }
    // ランダム関数
    private int GetRandomSum()
    {
        return Random.Range(0, groundList.Count);
    }
}
