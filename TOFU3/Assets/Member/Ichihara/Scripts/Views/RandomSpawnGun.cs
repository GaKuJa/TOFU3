using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnGun : MonoBehaviour
{
    //アイテムの情報を格納
    [SerializeField]
    private GameObject[] gunPrefabs;
    //生成された乱数を格納
    private List<int> randNum = new List<int>();
    //足場のTOFUを格納
    [SerializeField]
    private GameObject[] fieldTOFU;

    //制限時間
    [SerializeField]
    float totalTime = 0.0f;
    //経過時間
    float timeCountDown = 0.0f;
    //アイテムがスポーンする間隔
    [SerializeField]
    float interval = 0.0f;
    [SerializeField]
    float ifInterval = 0.0f;
    //intervalをカウントダウン
    [SerializeField]
    float intervalCount = 0;
    //スポーンするアイテム数
    int gun = 0;
    //ステージにある総アイテム数
    int totalGun = 0;
    //時間経過のフラグ
    bool timerFlag = false;
    //アイテムのフラグ
    bool gunFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        totalGun = gun;
        intervalCount = interval;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム開始からの経過時間
        totalTime -= Time.deltaTime;
        timeCountDown = (totalTime);
        //Debug.Log (timeCountDown = (totalTime));

        //制限時間が少なくなったら
        //intervalを短くし、gun,totalgunを増やす
        if (timeCountDown <= 180.0f)
            timerFlag = true;
        if (timeCountDown <= 300.0f)
            gunFlag = true;

        if (timerFlag == true)
        {
            interval = ifInterval;
            gun = 3;
            //totalgun = gun;
        }
        intervalCount = (intervalCount -= Time.deltaTime);
        //Debug.Log (intervalCount = (intervalCount -= Time.deltaTime));

        SpawnGun();

        if (intervalCount <= 0.0f)
            intervalCount = interval;

    }

    //アイテムを一定間隔毎にフィールドにスポーンする
    void SpawnGun()
    {
        //intervalの経過時間
        float Spawn = intervalCount;

        if (Spawn <= 0.0f)
        {
            RandomNum();
            SetGun();
        }

    }

    //乱数を生成し、randNumに格納
    void RandomNum()
    {
        //カウンタ
        int i;

        //試行回数上限
        int maxTri = 2;
        if (timerFlag == true)
            maxTri = 3;

        gun = maxTri;

        for (i = 0; i < gun; i++)
        {
            //randNumに要素を追加 & その要素に乱数で取得した値を代入
            randNum.Add(i);
            randNum[i] = Random.Range(0, 100);
        }

    }

    //RandNumの値をもとにアイテムを生成
    void SetGun()
    {
        //カウンタ
        int i;
        //乱数を格納
        int j;
        //アイテムをスポーンさせる座標
        Vector3 pos;

        //randNumの値を参照してgunPrefabのアイテムを生成する
        for (i = 0; i < gun; i++)
        {
            j = Random.Range(0, 17);
            Debug.Log(fieldTOFU[j]);
            float x = Random.Range(0.0f, 5.0f);
            float z = Random.Range(0.0f, 5.0f);

            pos = new Vector3(x, 2.0f, z);

            if (timerFlag == true)
            {
                //SHOYOU-GUNをスポーンする確率
                if (randNum[i] < 25)
                {
                    gunInstant0();
                }
                //KOYADOFU-GUNをスポーンする確率
                else if (randNum[i] >= 25 && randNum[i] < 35)
                {
                    gunInstant1();
                }
                //Long NEGI-Rifleをスポーンする確率
                else if (randNum[i] >= 35 && randNum[i] < 55)
                {
                    gunInstant2();
                }
                //SESAMI-Shoooterをスポーンする確率
                else if (randNum[i] >= 55 && randNum[i] < 80)
                {
                    gunInstant3();
                }
                //KATUO-武士をスポーンする確率
                else if (randNum[i] >= 80 && randNum[i] < 90)
                {
                    gunInstant4();
                }
                //B.F.Tをスポーンする確率
                else if (randNum[i] >= 90 && randNum[i] < 100)
                {
                    gunInstant5();
                }

            }

            else if (timerFlag == false && gunFlag == true)
            {
                //SHOYOU-GUNをスポーンする確率
                if (randNum[i] < 25)
                {
                    gunInstant0();
                }
                //KOYADOFU-GUNをスポーンする確率
                else if (randNum[i] >= 25 && randNum[i] < 50)
                {
                    gunInstant1();
                }
                //Long NEGI-Rifleをスポーンする確率
                else if (randNum[i] >= 50 && randNum[i] < 65)
                {
                    gunInstant2();
                }
                //SESAMI-Shoooterをスポーンする確率
                else if (randNum[i] >= 65 && randNum[i] < 90)
                {
                    gunInstant3();
                }
                //KATUO-武士をスポーンする確率
                else if (randNum[i] >= 90 && randNum[i] < 95)
                {
                    gunInstant4();
                }
                //B.F.Tをスポーンする確率
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    gunInstant5();
                }

            }

            else if (timerFlag == false && gunFlag == false)
            {
                //SHOYOU-GUNをスポーンする確率
                if (randNum[i] < 25)
                {
                    gunInstant0();
                }
                //KOYADOFU-GUNをスポーンする確率
                else if (randNum[i] >= 25 && randNum[i] < 55)
                {
                    gunInstant1();
                }
                //Long NEGI-Rifleをスポーンする確率
                else if (randNum[i] >= 55 && randNum[i] < 70)
                {
                    gunInstant2();
                }
                //SESAMI-Shoooterをスポーンする確率
                else if (randNum[i] >= 70 && randNum[i] < 90)
                {
                    gunInstant3();
                }
                //KATUO-武士をスポーンする確率
                else if (randNum[i] >= 90 && randNum[i] < 95)
                {
                    gunInstant4();
                }
                //B.F.Tをスポーンする確率
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    gunInstant5();
                }

            }

        }

        void gunInstant0()
        {
            var obj = Instantiate(gunPrefabs[0], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void gunInstant1()
        {
            var obj = Instantiate(gunPrefabs[1], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void gunInstant2()
        {
            var obj = Instantiate(gunPrefabs[2], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void gunInstant3()
        {
            var obj = Instantiate(gunPrefabs[3], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void gunInstant4()
        {
            var obj = Instantiate(gunPrefabs[4], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }

        void gunInstant5()
        {
            var obj = Instantiate(gunPrefabs[5], fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            obj.transform.SetParent(fieldTOFU[j].transform);
            obj.transform.SetParent(transform.root);
            obj.transform.localPosition = pos;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }


    }

}
