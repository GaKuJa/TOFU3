using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingItemPrefabs : MonoBehaviour
{
    Transform _transfItem;

    public void InitItem(Vector3 spwanPos)
    {
        _transfItem = GetComponent<Transform>();
        //�A�C�e���̐����ʒu���w��
        _transfItem.position = spwanPos;
        //�A�C�e�����A�N�e�B�u�ɂ���
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Player�Ƃ̐ڐG���肪��������A�A�C�e�����A�N�e�B�u�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

}
