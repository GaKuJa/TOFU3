using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentTest : MonoBehaviour
{
    [SerializeField, Tooltip("�e")]
    Transform parent = null;

    void Start()
    {
        // child �̐���
        var child = new GameObject("Child").transform;
        // parent �� child �̐e�ɐݒ�
        child.SetParent(parent);
    }
}
