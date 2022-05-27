using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItem : MonoBehaviour
{
    //アイテムの情報を格納
    [SerializeField]
    private GameObject[] itemPrefabs;
    //ステージの床のTOFUを格納
    [SerializeField]
    private GameObject[] fieldTOFU;
    //生成された乱数を格納
    private List<int> randNum = new List<int>();

    //時間管理
    [SerializeField]
    float time = 0.0f;
    //時間経過のチェック
    bool timerFlagFirst = false;
    bool timerFlagSecond = false;
    //アイテムがスポーンする間隔を格納
    [SerializeField]
    float interval = 0.0f;
    [SerializeField]
    float ifInterval = 0.0f;
    //intervalの値を格納
    //intervalを減算して時間を計る為、
    //カウンタとは別にintervalの値を確保、代入してintervalをリセットする必要がある
    [SerializeField]
    float setInterval = 0.0f;
    //スポーンするアイテム数
    int item = 0;
    //interval,itemを切り替えるフラグ
    bool switchFlag = false;
    

    // Start is called before the first frame update
    void Start()
    {
        item = 4;
        setInterval = interval;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム開始からの経過時間
        time -= Time.deltaTime;

        //制限時間が少なくなったら
        //intervalを短くし、itemを増やす
        if (time <= 300.0f)
            timerFlagFirst = true;
        if (time <= 180.0f)
            timerFlagSecond = true;

        if (!switchFlag && timerFlagSecond)
        {
            switchFlag = true;
            interval = ifInterval;
            item = 5;
        }

        Debug.Log(item);

        interval -= Time.deltaTime;
        //Debug.Log (setInterval = (setInterval -= Time.deltatime));

        SpawnItem();

        //intervalを初期化
        if (interval <= 0.0f)
            interval = setInterval;

    }

    //アイテムを一定間隔毎にフィールドにスポーンする
    void SpawnItem()
    {
        //intervalの経過時間
        float Spawn = interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            SetItem();
        }

    }

    //乱数を生成し、randNumに格納
    void RandomNum()
    {
        //カウンタ
        int i;

        for(i = 0; i < item; i++ )
        {
            //randNumに要素を追加 & その要素に乱数で取得した値を代入
            randNum.Add(i);
            randNum[i] = Random.Range(0, 100);
        }

    }
    
    //RandNumの値をもとにアイテムを生成
    void SetItem()
    {
        //カウンタ
        int i;
        //乱数を格納
        int j;
        //アイテムをスポーンさせる座標
        Vector3 pos;

        //randNumの値を参照してitemPrefabの各要素を生成する              
        for (i = 0; i < item; i++)
        {
            //生成するプレハブ、プレハブを生成する座標を取得
            j = Random.Range(0, 17);
            //Debug.Log (fieldTOFU[j].transform.position);

            float x = Random.Range(0.0f, 5.0f);
            float z = Random.Range(0.0f, 5.0f);

            pos = new Vector3(x, 1.0f, z);
            //Debug.Log(pos);

            if (timerFlagFirst && timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (randNum[i] < 15)
                {
                    ItemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (randNum[i] >= 15 && randNum[i] < 35)
                {
                    ItemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (randNum[i] >= 35 && randNum[i] < 50)
                {
                    ItemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (randNum[i] >= 50 && randNum[i] < 55)
                {
                    ItemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (randNum[i] >= 55 && randNum[i] < 75)
                {
                    ItemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (randNum[i] >= 75 && randNum[i] < 95)
                {
                    ItemInstant5();
                }
                //名称未定をスポーンする確率
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    ItemInstant6();
                }

            }

            else if (timerFlagFirst && !timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (randNum[i] < 15)
                {
                    ItemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (randNum[i] >= 15 && randNum[i] < 35)
                {
                    ItemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (randNum[i] >= 35 && randNum[i] < 50)
                {
                    ItemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (randNum[i] >= 50 && randNum[i] < 65)
                {
                    ItemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (randNum[i] >= 65 && randNum[i] < 80)
                {
                    ItemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (randNum[i] >= 80 && randNum[i] < 95)
                {
                    ItemInstant5();
                }
                //名称未定をスポーンする確率
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    ItemInstant6();
                }

            }

            else if (!timerFlagFirst && !timerFlagSecond)
            {
                //YUBA-SHILDをスポーンする確率
                if (randNum[i] < 20)
                {
                    ItemInstant0();
                }
                //DASHI-STIMをスポーンする確率
                else if (randNum[i] >= 20 && randNum[i] < 40)
                {
                    ItemInstant1();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (randNum[i] >= 40 && randNum[i] < 55)
                {
                    ItemInstant2();
                }
                //YUZU-RADARをスポーンする確率
                else if (randNum[i] >= 55 && randNum[i] < 75)
                {
                    ItemInstant3();
                }
                //AGE-TOFUMODEをスポーンする確率
                else if (randNum[i] >= 75 && randNum[i] < 85)
                {
                    ItemInstant4();
                }
                //MOMIZI-REDをスポーンする確率
                else if (randNum[i] >= 85 && randNum[i] < 95)
                {
                    ItemInstant5();
                }
                //名称未定をスポーンする確率
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    ItemInstant6();
                }

                GameObject[] countItemTags = GameObject.FindGameObjectsWithTag("Item");
                if (countItemTags.Length == item - 1)
                {
                    break;
                }

            }

        }

        void ItemInstant0()
        {
            var obj = Instantiate(itemPrefabs[0], fieldTOFU[j].transform.position, Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void ItemInstant1()
        {
            var obj = Instantiate(itemPrefabs[1], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void ItemInstant2()
        {
            var obj = Instantiate(itemPrefabs[2], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void ItemInstant3()
        {
            var obj = Instantiate(itemPrefabs[3], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void ItemInstant4()
        {
            var obj = Instantiate(itemPrefabs[4], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void ItemInstant5()
        {
            var obj = Instantiate(itemPrefabs[5], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void ItemInstant6()
        {
            var obj = Instantiate(itemPrefabs[6], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

    }

}
