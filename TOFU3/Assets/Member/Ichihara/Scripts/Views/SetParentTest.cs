using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentTest : MonoBehaviour
{
    [SerializeField, Tooltip("e")]
    Transform parent = null;

    void Start()
    {
        // child ‚Ì¶¬
        var child = new GameObject("Child").transform;
        // parent ‚ğ child ‚Ìe‚Éİ’è
        child.SetParent(parent);
    }
}
