using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnGun : MonoBehaviour
{
    //�A�C�e���̏����i�[
    [SerializeField]
    private GameObject[] gunPrefabs;
    //�������ꂽ�������i�[
    private List<int> randNum = new List<int>();
    //�����TOFU���i�[
    [SerializeField]
    private GameObject[] fieldTOFU;

    //��������
    [SerializeField]
    float totalTime = 0.0f;
    //�o�ߎ���
    float timeCountDown = 0.0f;
    //�A�C�e�����X�|�[������Ԋu
    [SerializeField]
    float interval = 0.0f;
    [SerializeField]
    float ifInterval = 0.0f;
    //interval���J�E���g�_�E��
    [SerializeField]
    float intervalCount = 0;
    //�X�|�[������A�C�e����
    int gun = 0;
    //�X�e�[�W�ɂ��鑍�A�C�e����
    int totalGun = 0;
    //���Ԍo�߂̃t���O
    bool timerFlag = false;
    //�A�C�e���̃t���O
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
        //�Q�[���J�n����̌o�ߎ���
        totalTime -= Time.deltaTime;
        timeCountDown = (totalTime);
        //Debug.Log (timeCountDown = (totalTime));

        //�������Ԃ����Ȃ��Ȃ�����
        //interval��Z�����Agun,totalgun�𑝂₷
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

    //�A�C�e�������Ԋu���Ƀt�B�[���h�ɃX�|�[������
    void SpawnGun()
    {
        //interval�̌o�ߎ���
        float Spawn = intervalCount;

        if (Spawn <= 0.0f)
        {
            RandomNum();
            SetGun();
        }

    }

    //�����𐶐����ArandNum�Ɋi�[
    void RandomNum()
    {
        //�J�E���^
        int i;

        //���s�񐔏��
        int maxTri = 2;
        if (timerFlag == true)
            maxTri = 3;

        gun = maxTri;

        for (i = 0; i < gun; i++)
        {
            //randNum�ɗv�f��ǉ� & ���̗v�f�ɗ����Ŏ擾�����l����
            randNum.Add(i);
            randNum[i] = Random.Range(0, 100);
        }

    }

    //RandNum�̒l�����ƂɃA�C�e���𐶐�
    void SetGun()
    {
        //�J�E���^
        int i;
        //�������i�[
        int j;
        //�A�C�e�����X�|�[����������W
        Vector3 pos;

        //randNum�̒l���Q�Ƃ���gunPrefab�̃A�C�e���𐶐�����
        for (i = 0; i < gun; i++)
        {
            j = Random.Range(0, 17);
            Debug.Log(fieldTOFU[j]);
            float x = Random.Range(0.0f, 5.0f);
            float z = Random.Range(0.0f, 5.0f);

            pos = new Vector3(x, 2.0f, z);

            if (timerFlag == true)
            {
                //SHOYOU-GUN���X�|�[������m��
                if (randNum[i] < 25)
                {
                    gunInstant0();
                }
                //KOYADOFU-GUN���X�|�[������m��
                else if (randNum[i] >= 25 && randNum[i] < 35)
                {
                    gunInstant1();
                }
                //Long NEGI-Rifle���X�|�[������m��
                else if (randNum[i] >= 35 && randNum[i] < 55)
                {
                    gunInstant2();
                }
                //SESAMI-Shoooter���X�|�[������m��
                else if (randNum[i] >= 55 && randNum[i] < 80)
                {
                    gunInstant3();
                }
                //KATUO-���m���X�|�[������m��
                else if (randNum[i] >= 80 && randNum[i] < 90)
                {
                    gunInstant4();
                }
                //B.F.T���X�|�[������m��
                else if (randNum[i] >= 90 && randNum[i] < 100)
                {
                    gunInstant5();
                }

            }

            else if (timerFlag == false && gunFlag == true)
            {
                //SHOYOU-GUN���X�|�[������m��
                if (randNum[i] < 25)
                {
                    gunInstant0();
                }
                //KOYADOFU-GUN���X�|�[������m��
                else if (randNum[i] >= 25 && randNum[i] < 50)
                {
                    gunInstant1();
                }
                //Long NEGI-Rifle���X�|�[������m��
                else if (randNum[i] >= 50 && randNum[i] < 65)
                {
                    gunInstant2();
                }
                //SESAMI-Shoooter���X�|�[������m��
                else if (randNum[i] >= 65 && randNum[i] < 90)
                {
                    gunInstant3();
                }
                //KATUO-���m���X�|�[������m��
                else if (randNum[i] >= 90 && randNum[i] < 95)
                {
                    gunInstant4();
                }
                //B.F.T���X�|�[������m��
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    gunInstant5();
                }

            }

            else if (timerFlag == false && gunFlag == false)
            {
                //SHOYOU-GUN���X�|�[������m��
                if (randNum[i] < 25)
                {
                    gunInstant0();
                }
                //KOYADOFU-GUN���X�|�[������m��
                else if (randNum[i] >= 25 && randNum[i] < 55)
                {
                    gunInstant1();
                }
                //Long NEGI-Rifle���X�|�[������m��
                else if (randNum[i] >= 55 && randNum[i] < 70)
                {
                    gunInstant2();
                }
                //SESAMI-Shoooter���X�|�[������m��
                else if (randNum[i] >= 70 && randNum[i] < 90)
                {
                    gunInstant3();
                }
                //KATUO-���m���X�|�[������m��
                else if (randNum[i] >= 90 && randNum[i] < 95)
                {
                    gunInstant4();
                }
                //B.F.T���X�|�[������m��
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
