using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�v�[���ɕK�v�ȋ@�\
/// </summary>

public class PoolingObjectPrefabs : MonoBehaviour
{
    Transform _transfItem;

    public void InitItem(Vector3 spwanPos)
    {
        _transfItem = GetComponent<Transform>();
        //�A�C�e���̐����ʒu���w��
        _transfItem.position = spwanPos;
        //�A�C�e�����A�N�e�B�u�ɂ���
        this.gameObject.SetActive(true);

    }
}
