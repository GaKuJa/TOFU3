using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentTest : MonoBehaviour
{
    [SerializeField, Tooltip("親")]
    Transform parent = null;

    void Start()
    {
        // child の生成
        var child = new GameObject("Child").transform;
        // parent を child の親に設定
        child.SetParent(parent);
    }
}
