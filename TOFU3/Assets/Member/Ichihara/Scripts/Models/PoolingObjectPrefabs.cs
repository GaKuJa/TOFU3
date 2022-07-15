using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトプールに必要な機能
/// </summary>

public class PoolingObjectPrefabs : MonoBehaviour
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
        if(!(collision.gameObject.CompareTag("Ground")))
        {
            this.gameObject.SetActive(false);
        }
    }

}
