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

    /// <summary>
    /// Player�Ƃ̐ڐG���肪��������A�A�C�e�����A�N�e�B�u�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ObjectActive(this.gameObject));
        }
    }

    private IEnumerator ObjectActive(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Siyuukai_RandomSpawnGun.instance.Guns.Remove(obj);

    }

}
