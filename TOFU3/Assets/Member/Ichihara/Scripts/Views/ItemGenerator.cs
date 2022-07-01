using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //YUBA-SHILDのプレハブを格納
    [SerializeField]
    public GameObject[] _itemListYUBA;
    //アイテムを備蓄しておくList 
    List<ItemPool> _LIst_itemPool = new List<ItemPool>();
    //備蓄しておくアイテムの数
    const int _maxItems = 10;


    // Start is called before the first frame update
    void Start()
    {
        ItemPool item_YUBA;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
