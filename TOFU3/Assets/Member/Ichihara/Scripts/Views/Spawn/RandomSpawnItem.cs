using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// アイテムをランダムな位置に生成するスクリプト
/// </summary>


public class RandomSpawnItem : MonoBehaviour
{
    //アイテムのプレハブを格納
    [SerializeField]
    private GameObject[] _itemPrefabs;
    //ステージの床のTOFUプレハブを格納
    [SerializeField]
    private GameObject[] _fieldTOFU;
    //現在マップに配置されているアイテムプレハブの個数を格納
    private List<int> _items = new List<int>();

    //生成された乱数を格納
    private List<int> _randNum = new List<int>();

    //時間管理
    [SerializeField]
    float _time = 0.0f;
    //時間経過のチェック
    bool _timerFlagFirst = false;
    bool _timerFlagSecond = false;
    //アイテムがスポーンする間隔を格納
    [SerializeField]
    float _interval = 0.0f;
    [SerializeField]
    float _afterThreeMinitsInterval = 0.0f;
    //_intervalの値を格納
    //_intervalを減算して時間を計る為、
    //カウンタとは別に_intervalの値を確保、代入して_intervalをリセットする必要がある
    [SerializeField]
    float _setInterval = 0.0f;
    //スポーンするアイテム数
    int _item = 0;

    //Inspectorから「Generator」スクリプトを設定
    [SerializeField]
    YUBA_SHIELDGenerator _sc_YUBA_SHIELD;
    [SerializeField]
    DASHI_STIMGenerator _sc_DASHI_STIM;
    [SerializeField]
    OKAKA_CHAFGenerator _sc_OKAKA_CHAF;
    [SerializeField]
    YUZU_RADARGenerator _sc_YUZU_RADAR;
    [SerializeField]
    AGE_TOFUMODEGenerator _sc_AGETOFUMODE;
    [SerializeField]
    MOMIZI_REDGenerator _sc_MOMIZI_RED;
    [SerializeField]
    OKURA_TORIMOCHIGenerator _sc_OKURA_TORIMOCHI;


    // Start is called before the first frame update
    void Start()
    {
        _item = 4;
        _setInterval = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム開始からの経過時間
        _time -= Time.deltaTime;

        //制限時間が少なくなったら
        //_intervalを短くし、_itemを増やす
        if (_time <= 300.0f)
            _timerFlagFirst = true;
        if (_time <= 180.0f)
            _timerFlagSecond = true;

        if (_timerFlagSecond )
        {
            _setInterval = _afterThreeMinitsInterval;
            _item = 5;
        }

        //Debug.Log(_item);

        _interval -= Time.deltaTime;

        //Debug.Log (set_interval = (set_interval -= Time.deltatime));

        Spawnitem();
        //for (int i = 0; i < _item - _items.Count; i++)
        //{
        //    if (_items[i] == /*存在しない*/)
        //    {
        //        _items.RemoveAt(i);
        //    }
        //}

        //_intervalを初期化
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> アイテムを一定間隔毎にフィールドにスポーンする関数 </summary>
    void Spawnitem()
    {
        //_intervalの経過時間
        float Spawn = _interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            Setitem();
        }

    }

    /// <summary> 乱数を生成し、_randNumに格納する関数 </summary>
    void RandomNum()
    {
        //カウンタ
        int i;

        for(i = 0; i < _item; i++ )
        {
            //_randNumに要素を追加
            //その要素に乱数で取得した値を代入
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }

    /// <summary> _randNumの値を参照してアイテムを生成する関数 </summary>
    void Setitem()
    {
        //カウンタ
        int i;
        //乱数を格納
        int j;
        //アイテムをスポーンさせる座標
        Vector3 pos;

        //_randNumの値を参照して_itemPrefabの各要素を生成する              
        for (i = 0; i < _item; i++)
        {
            ////_itemsに要素を追加し、アイテム生成の回数を制御する
            //if(_items.Count < _item)
            //{
            //    _items.Add(i);
            //}
            //else if(_items.Count == _item)
            //{
            //    break;
            //}

            //プレハブを生成する座標を取得
            j = Random.Range(0, _fieldTOFU.Length);
            //Debug.Log (_fieldTOFU[j].transform.position);

            float x = Random.Range(-10.0f, 10.0f);
            float z = Random.Range(-10.0f, 10.0f);

            pos = new Vector3(x, 1.5f, z);
            //Debug.Log(pos);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 15)
                {
                    itemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    itemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    itemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    itemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    itemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    itemInstant5();
                }
                //名称未定をスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    itemInstant6();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 15)
                {
                    itemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    itemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    itemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    itemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    itemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    itemInstant5();
                }
                //名称未定をスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    itemInstant6();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 20)
                {
                    itemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    itemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    itemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    itemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    itemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    itemInstant5();
                }
                //名称未定をスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    itemInstant6();
                }

                ////返り値を格納
                //var count_itemTags = _itemTags;
                //count_itemTags = GameObject.FindGameObjectsWithTag("_item");

                //Debug.Log(count_itemTags);

                //if (count_itemTags.Length == _item - 1)
                //{
                //    break;
                //}

            }

        }

        void itemInstant0()
        {
            _sc_YUBA_SHIELD.SpawnYUBA_SHIELD(pos);
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.SetParent(_fieldTOFU[j].transform);
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.SetParent(transform.root);
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.localPosition = pos;
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[0];
        }

        void itemInstant1()
        {
            _sc_DASHI_STIM.SpawnDASHI_STIM(pos);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[1];
        }

        void itemInstant2()
        {
            _sc_OKAKA_CHAF.SpawnOKAKA_CHAF(pos);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[2];
        }

        void itemInstant3()
        {
            _sc_YUZU_RADAR.SpawnYUZU_RADAR(pos);
            //var obj = Instantiate(_itemPrefabs[3], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[3];
        }

        void itemInstant4()
        {
            _sc_AGETOFUMODE.SpwanAGE_TOFUMODE(pos);
            //var obj = Instantiate(_itemPrefabs[4], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[4];
        }

        void itemInstant5()
        {
            _sc_MOMIZI_RED.SpawnMOMIZI_RED(pos);
            //var obj = Instantiate(_itemPrefabs[5], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[5];
        }

        void itemInstant6()
        {
            _sc_OKURA_TORIMOCHI.SpawnOKURA_TORIMOCHI(pos);
            //var obj = Instantiate(_itemPrefabs[6], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.parent = _fieldTOFU[j].transform;
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[6];
        }

    }

}
