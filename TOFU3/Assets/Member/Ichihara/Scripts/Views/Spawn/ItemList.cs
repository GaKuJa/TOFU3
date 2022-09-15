using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public static ItemList Instance { get => _instance; }
    static ItemList _instance;

    public List<GameObject> Item = new List<GameObject>();

    private void Awake()
    {
        if(_instance == null) { _instance = this; }
    }


}
