using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //YUBA-SHILD�̃v���n�u���i�[
    [SerializeField]
    public GameObject[] _itemListYUBA;
    //�A�C�e������~���Ă���List 
    List<ItemPool> _LIst_itemPool = new List<ItemPool>();
    //���~���Ă����A�C�e���̐�
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
