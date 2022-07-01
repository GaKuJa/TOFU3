using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItem : MonoBehaviour
{
    //アイテムのプレハブを格納
    [SerializeField]
    private GameObject[] _itemPrefabs;
    //ステージの床のTOFUプレハブを格納
    [SerializeField]
    private GameObject[] _fieldTOFU;
    //生成された乱数を格納
    private List<int> _randNum = new List<int>();
    //現在マップに配置されているアイテムプレハブの個数を格納
    private List<int> _items = new List<int>();

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
    float _ifinterval = 0.0f;
    //_intervalの値を格納
    //_intervalを減算して時間を計る為、
    //カウンタとは別に_intervalの値を確保、代入して_intervalをリセットする必要がある
    [SerializeField]
    float _setinterval = 0.0f;
    //スポーンするアイテム数
    int _item = 0;
    //_interval,_itemを切り替えるフラグ
    bool _switchFlag = false;
    

    // Start is called before the first frame update
    void Start()
    {
        _item = 4;
        _setinterval = _interval;
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

        if (!_switchFlag && _timerFlagSecond)
        {
            _switchFlag = true;
            _interval = _ifinterval;
            _item = 5;
        }

        //Debug.Log(_item);

        _interval -= Time.deltaTime;
        //Debug.Log (set_interval = (set_interval -= Time.deltatime));

        Spawnitem();

        //_intervalを初期化
        if (_interval <= 0.0f)
            _interval = _setinterval;

    }

    //アイテムを一定間隔毎にフィールドにスポーンする
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

    //乱数を生成し、_randNumに格納
    void RandomNum()
    {
        //カウンタ
        int i;

        for(i = 0; i < _item; i++ )
        {
            //_randNumに要素を追加 & その要素に乱数で取得した値を代入
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }
    
    //_randNumの値をもとにアイテムを生成
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
            //_randNumの要素数を取得し、アイテム生成の回数を制御する


            //プレハブを生成する座標を取得
            j = Random.Range(0, 17);
            //Debug.Log (_fieldTOFU[j].transform.position);

            float x = Random.Range(0.0f, 5.0f);
            float z = Random.Range(0.0f, 5.0f);

            pos = new Vector3(x, 1.5f, z);
            //Debug.Log(pos);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 15)
                {
                    _itemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    _itemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    _itemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    _itemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    _itemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    _itemInstant5();
                }
                //名称未定をスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    _itemInstant6();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 15)
                {
                    _itemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    _itemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    _itemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    _itemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    _itemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    _itemInstant5();
                }
                //名称未定をスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    _itemInstant6();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 20)
                {
                    _itemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    _itemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    _itemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    _itemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    _itemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    _itemInstant5();
                }
                //名称未定をスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    _itemInstant6();
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

        void _itemInstant0()
        {
            var obj = Instantiate(_itemPrefabs[0], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[0];
        }

        void _itemInstant1()
        {
            var obj = Instantiate(_itemPrefabs[1], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[1];
        }

        void _itemInstant2()
        {
            var obj = Instantiate(_itemPrefabs[2], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[2];
        }

        void _itemInstant3()
        {
            var obj = Instantiate(_itemPrefabs[3], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[3];
        }

        void _itemInstant4()
        {
            var obj = Instantiate(_itemPrefabs[4], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[4];
        }

        void _itemInstant5()
        {
            var obj = Instantiate(_itemPrefabs[5], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[5];
        }

        void _itemInstant6()
        {
            var obj = Instantiate(_itemPrefabs[6], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(_fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[6];
        }

    }

}
