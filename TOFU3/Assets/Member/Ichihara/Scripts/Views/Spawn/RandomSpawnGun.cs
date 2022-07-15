using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 銃をランダムな位置に生成するスクリプト
/// </summary>

public class RandomSpawnGun : BaseSpawmStatus
{
    //フィールドに存在している銃の総数
    public List<GameObject> Guns = new List<GameObject>();

    //スポーンする銃の総数
    private int _gun = 0;

    //Inspectorから「Generator」スクリプトを設定
    [SerializeField]
    private SHOYOU_GUNGenerator _cs_SHOYOU_GUN = null;
    [SerializeField]
    private KOYADOFU_GUNGenerator _cs_KOYADOFU_GUN = null;
    [SerializeField]
    private Long_NEGI_RifleGenerator _cs_Long_NEGI_Rifle = null;
    [SerializeField]
    private SESAMI_ShooterGenerator _cs_SESAMI_Shooter = null;
    [SerializeField]
    private KATSUO_BUSHIGenerator _cs_KATSUO_BUSHI = null;
    [SerializeField]
    private B_F_TGenerator _cs_B_F_T = null;

    // Start is called before the first frame update
    void Start()
    {
        _gun = 2;
        _setInterval = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム開始からの経過時間
        _time -= Time.deltaTime;

        //制限時間が少なくなったら
        //_intervalを短くし、_gunを増やす
        if (_time <= 360.0f)
            _timerFlagFirst = true;
        if (_time <= 180.0f)
            _timerFlagSecond = true;

        if (_timerFlagFirst && !_timerFlagSecond)
        {
            _gun = 3;
        }
        else if (_timerFlagFirst && _timerFlagSecond)
        {
            _setInterval = _afterThreeMinutesInterval;
            _gun = 5;
        }

        _interval -= Time.deltaTime;

        SpawnGun();
        if (Guns.Count > 1)
        {
            RemoveElements();
        }

        //_intervalをリセット
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> 銃を一定間隔毎にフィールドにスポーンする関数 </summary>
    void SpawnGun()
    {
        //_intervalの経過時間
        float Spawn = _interval;

        if (Spawn <= 0.0f)
        {
            RandomNum();
            SetGun();
        }

    }

    /// <summary> Gunsに格納されているオブジェクトがfalseの場合、
    /// そのオブジェクトが格納されている要素を除去する関数 </summary>
    void RemoveElements()
    {
        foreach(GameObject gun in Guns)
        {
            if (gun.activeSelf == false)
            {
                Guns.Remove(gameObject);
            }
        }
    }

    /// <summary> 乱数を生成し、_randNumに格納する関数 </summary>
    void RandomNum()
    {
        for (int i = 0; i < _gun; i++)
        {
            //_randNumに要素を追加
            //その要素に乱数で取得した値を代入
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }

    /// <summary> _randNumの値を参照して銃を生成する関数 </summary>
    void SetGun()
    {
        //乱数を格納
        int j;
        // 地面の数だけランダムを取得するList
        List<int> _fieldRandomTOFU = new List<int>();

        //_fieldTOFUの要素を_fieldRandomTOFUに代入
        for (int i = 0; i < _fieldTOFU.Count; i++)
        {
            _fieldRandomTOFU.Add(i);
        }

        //_randNumの値を参照して_itemPrefabの各要素を生成する              
        for (int i = 0; i < _gun; i++)
        {
            //Itemsにスポーンしたオブジェクトの情報を格納
            if (Guns.Count < _gun)
            {
                Guns.Add(gameObject);
            }
            else if (Guns.Count >= _gun)
            {
                break;
            }

            //プレハブを生成する座標を取得
            j = Random.Range(0, _fieldRandomTOFU.Count);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //SHOYOU-GUNをスポーンする確率
                if (_randNum[i] < 25)
                {
                    SpawnSHOYOU_GUN();
                }
                //KOYADOFU-GUNをスポーンする確率
                else if (_randNum[i] >= 25 && _randNum[i] < 35)
                {
                    SpawnKOYADOFU_GUN();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 35 && _randNum[i] < 55)
                {
                    SpawnLong_NEGI_Rifle();
                }
                //SESAMI-Shooterをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 80)
                {
                    SpawnSESAMI_Shooter();
                }
                //KATSUO武士をスポーンする確率
                else if (_randNum[i] >= 80 && _randNum[i] < 90)
                {
                    SpawnKATSUO_BUSHI();
                }
                //B・F・Tをスポーンする確率
                else if (_randNum[i] >= 90 && _randNum[i] < 100)
                {
                    SpawnB_F_T();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //SHOYOU-GUNをスポーンする確率
                if (_randNum[i] < 25)
                {
                    SpawnSHOYOU_GUN();
                }
                //KOYADOFU-GUNをスポーンする確率
                else if (_randNum[i] >= 25 && _randNum[i] < 50)
                {
                    SpawnKOYADOFU_GUN();
                }
                //OKAKA-CHAFをスポーンする確率
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    SpawnLong_NEGI_Rifle();
                }
                //SESAMI-Shooterをスポーンする確率
                else if (_randNum[i] >= 65 && _randNum[i] < 90)
                {
                    SpawnSESAMI_Shooter();
                }
                //KATSUO武士をスポーンする確率
                else if (_randNum[i] >= 90 && _randNum[i] < 95)
                {
                    SpawnKATSUO_BUSHI();
                }
                //B・F・Tをスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnB_F_T();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //SHOYOU-GUNをスポーンする確率
                if (_randNum[i] < 25)
                {
                    SpawnSHOYOU_GUN();
                }
                //KOYADOFU-GUNをスポーンする確率
                else if (_randNum[i] >= 25 && _randNum[i] < 55)
                {
                    SpawnKOYADOFU_GUN();
                }
                //Long-NEGI-Rifleをスポーンする確率
                else if (_randNum[i] >= 55 && _randNum[i] < 70)
                {
                    SpawnLong_NEGI_Rifle();
                }
                //SESAMI-Shooterをスポーンする確率
                else if (_randNum[i] >= 70 && _randNum[i] < 90)
                {
                    SpawnSESAMI_Shooter();
                }
                //KATSUO武士をスポーンする確率
                else if (_randNum[i] >= 90 && _randNum[i] < 95)
                {
                    SpawnKATSUO_BUSHI();
                }
                //B・F・Tをスポーンする確率
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnB_F_T();
                }

            }

        }

        //SHOYOU-GUNをスポーンする
        void SpawnSHOYOU_GUN()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_SHOYOU_GUN.GenerateSHOYOU_GUN(spawnPos);
            transform.SetParent(transform.root);

        }

        //KOYADOFU-GUNをスポーンする
        void SpawnKOYADOFU_GUN()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_KOYADOFU_GUN.GenerateKOYADOFU_GUN(spawnPos);
            transform.SetParent(transform.root);

        }

        //Long-NEGI-Rifleをスポーンする
        void SpawnLong_NEGI_Rifle()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_Long_NEGI_Rifle.GenerateLong_NEGI_Rifle(spawnPos);
            transform.SetParent(transform.root);

        }

        //SESAMI-Shooterをスポーンする
        void SpawnSESAMI_Shooter()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_SESAMI_Shooter.GenerateSESAMI_Shoot(spawnPos);
            transform.SetParent(transform.root);

        }

        //KATSUO武士をスポーンする
        void SpawnKATSUO_BUSHI()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_KATSUO_BUSHI.GenerateKATSUO_BUSHI(spawnPos);
            transform.SetParent(transform.root);

        }

        //B・F・Tをスポーンする
        void SpawnB_F_T()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_B_F_T.GenerateB_F_T(spawnPos);
            transform.SetParent(transform.root);

        }

        
        // 地面のランダムな座標を取得する　
        Vector3 GetRandomPos(int randomList)
        {
            //返り値の宣言
            Vector3 setSpawnPos = Vector3.zero;

            bool checkFlag = false;

            //オブジェクトのx座標系、z座標系の半分の大きさ
            Vector3 halfExtents = new Vector3(0.5f, 0.0f, 0.5f);

            Debug.Log("fieldTOFU :" + randomList + " Item");

            //ステージオブジェクト同士が重ならないように調整する
            do
            {
                //スポーンする座標の最大値、最小値を設定
                var spawnPosX = Mathf.Clamp(Random.Range(-_fieldTOFU[randomList].transform.localScale.x / 2 + halfExtents.x, _fieldTOFU[randomList].transform.localScale.x / 2 - halfExtents.x),
                                            -_fieldTOFU[randomList].transform.localScale.x / 2,
                                            _fieldTOFU[randomList].transform.localScale.x / 2);

                var spawnPosZ = Mathf.Clamp(Random.Range(-_fieldTOFU[randomList].transform.localScale.z / 2 + halfExtents.z, _fieldTOFU[randomList].transform.localScale.z / 2 - halfExtents.z),
                                            -_fieldTOFU[randomList].transform.localScale.z / 2,
                                            _fieldTOFU[randomList].transform.localScale.z / 2);

                //オブジェクトがスポーンする座標
                Vector3 prxSetSpawnPos = _fieldTOFU[randomList].transform.position +
                    new Vector3(spawnPosX, _fieldTOFU[randomList].transform.localScale.y / 2, spawnPosZ);

                if (!Physics.CheckBox(prxSetSpawnPos, halfExtents, Quaternion.identity))
                {
                    Debug.Log(prxSetSpawnPos);
                    setSpawnPos = prxSetSpawnPos;
                    checkFlag = true;
                }

            } while (!checkFlag);

            return setSpawnPos;

        }
    }

}
