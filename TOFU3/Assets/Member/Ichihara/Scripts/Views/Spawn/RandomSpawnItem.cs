using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// アイテムをランダムな位置に生成するスクリプト
/// </summary>


public class RandomSpawnItem : SpawnManager
{
    //スポーンするアイテムの総数
    int _item = 0;

    //Inspectorから「Generator」スクリプトを設定
    [SerializeField]
    YUBA_SHIELDGenerator _cs_YUBA_SHIELD;
    [SerializeField]
    DASHI_STIMGenerator _cs_DASHI_STIM;
    [SerializeField]
    OKAKA_CHAFGenerator _cs_OKAKA_CHAF;
    [SerializeField]
    YUZU_RADARGenerator _cs_YUZU_RADAR;
    [SerializeField]
    AGE_TOFUMODEGenerator _cs_AGETOFUMODE;
    [SerializeField]
    MOMIZI_REDGenerator _cs_MOMIZI_RED;
    [SerializeField]
    OKURA_TORIMOCHIGenerator _cs_OKURA_TORIMOCHI;


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

        if (_timerFlagFirst && _timerFlagSecond )
        {
            _setInterval = _afterThreeMinutesInterval;
            _item = 5;
        }

        //Debug.Log(_gun);

        _interval -= Time.deltaTime;

        //Debug.Log (set_interval = (set_interval -= Time.deltatime));

        SpawnItem();

        //_intervalをリセット
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> アイテムを一定間隔毎にフィールドにスポーンする関数 </summary>
    void SpawnItem()
    {
        //_intervalの経過時間
        float Spawn = _interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            SetItem();
        }

    }

    /// <summary> 乱数を生成し、_randNumに格納する関数 </summary>
    void RandomNum()
    {
        for(int i = 0; i < _item; i++ )
        {
            //_randNumに要素を追加
            //その要素に乱数で取得した値を代入
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }

    /// <summary> _randNumの値を参照してアイテムを生成する関数 </summary>
    void SetItem()
    {
        //乱数を格納
        int j;
        // 地面の数だけランダムを取得するList
        List<int> _fieldRandomTOFU = new List<int>();

        //_fieldTOFUの要素を_fieldRandomTOFUに代入
        for(int i = 0; i < _fieldTOFU.Count; i++)
        {
            _fieldRandomTOFU.Add(i);

        }

        //_randNumの値を参照して_itemPrefabの各要素を生成する              
        for (int i = 0; i < _item; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Item").Length == _item)
                break;

            //プレハブを生成する座標を取得
            j = Random.Range(0, _fieldRandomTOFU.Count);
            //Debug.Log (_fieldTOFU[j].transform.position);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 15)
                {
                    SpawnYUBA_SHIELD();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    SpawnDASHI_STIM();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    SpawnOKAKA_CHAF();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    SpawnYUZU_RADAR();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    SpawnAGE_TOFUMODE();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                }
                //OKURA-TORIMOCHIをスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 15)
                {
                    SpawnYUBA_SHIELD();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    SpawnDASHI_STIM();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    SpawnOKAKA_CHAF();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    SpawnYUZU_RADAR();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    SpawnAGE_TOFUMODE();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                }
                //OKURA-TORIMOCHIをスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (_randNum[i] < 20)
                {
                    SpawnYUBA_SHIELD();
                }
                //DASHI-STIMをスポーンする確率
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    SpawnDASHI_STIM();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    SpawnOKAKA_CHAF();
                }
                //YUZU-RADARをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    SpawnYUZU_RADAR();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    SpawnAGE_TOFUMODE();
                }
                //MOMIZI-REDをスポーンする確率
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                }
                //OKURA-TORIMOCHIをスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                }

            }

        }

        //YUBA-SHIELDをスポーンする
        void SpawnYUBA_SHIELD()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_YUBA_SHIELD.GenerateYUBA_SHIELD(spawnPos);
            transform.SetParent(transform.root);

        }

        //DASHI-STIMDをスポーンする
        void SpawnDASHI_STIM()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_DASHI_STIM.GenerateDASHI_STIM(spawnPos);
            transform.SetParent(transform.root);

        }

        //OKAKA-CHAFをスポーンする
        void SpawnOKAKA_CHAF()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_OKAKA_CHAF.GenerateOKAKA_CHAF(spawnPos);
            transform.SetParent(transform.root);

        }

        //YUZA-RADARをスポーンする
        void SpawnYUZU_RADAR()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_YUZU_RADAR.GenerateYUZU_RADAR(spawnPos);
            transform.SetParent(transform.root);

        }

        //AGE-TOFUMODOをスポーンする
        void SpawnAGE_TOFUMODE()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_AGETOFUMODE.GenerateAGE_TOFUMODE(spawnPos);
            transform.SetParent(transform.root);

        }

        //MOMIZI-REDをスポーンする
        void SpawnMOMIZI_RED()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_MOMIZI_RED.GenerateMOMIZI_RED(spawnPos);
            transform.SetParent(transform.root);

        }

        //OKURA-TORIMOCHIをスポーンする
        void SpawnOKURA_TORIMOCHI()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_OKURA_TORIMOCHI.GenerateOKURA_TORIMOCHI(spawnPos);
            transform.SetParent(transform.root);

        }


        // 地面のランダムな座標を取得する　
        Vector3 GetRandomPos(int randomList)
        {
            //返り値の宣言
            Vector3 setSpawnPos = Vector3.zero;

            bool spawnFlag = false;

            //オブジェクトの各座標系の半分の大きさ
            Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

            //ステージオブジェクト同士が重ならないように調整する
            while (!spawnFlag)
            {
                Debug.Log("ItemCheck");

                var posX = Random.Range(-_fieldTOFU[randomList].transform.localScale.x / 2, _fieldTOFU[randomList].transform.localScale.x / 2);
                var posY = _fieldTOFU[randomList].transform.localScale.y / 2;
                var posZ = Random.Range(-_fieldTOFU[randomList].transform.localScale.z / 2, _fieldTOFU[randomList].transform.localScale.z / 2);

                var rotY = Random.Range(-_fieldTOFU[randomList].transform.rotation.y, _fieldTOFU[randomList].transform.rotation.y);

                Vector3 prxSetSpawnPos = _fieldTOFU[randomList].transform.localPosition +
                                        new Vector3(posX * rotY, posY, posZ * rotY);

                if (!Physics.CheckBox(prxSetSpawnPos, halfExtents, Quaternion.identity))
                {
                    Debug.Log("ItemCheck");

                    setSpawnPos = prxSetSpawnPos;
                    spawnFlag = true;
                    continue;
                }

            }

            return setSpawnPos;

        }
    }
}

