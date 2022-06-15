using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingItemPrefabs : MonoBehaviour
{
    Transform _transfItem;

    public void InitItem(Vector3 spwanPos)
    {
        _transfItem = GetComponent<Transform>();
        //アイテムの生成位置を指定
        _transfItem.position = spwanPos;
        //アイテムをアクティブにする
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Playerとの接触判定があったら、アイテムを非アクティブにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

}
