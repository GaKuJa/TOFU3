using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunList : MonoBehaviour
{
    public static GunList Instance { get => _instance; }
    static GunList _instance;

    public List<GameObject> Gun = new List<GameObject>();

    private void Awake()
    {
        if(_instance == null) { _instance = this; }
    }
}
