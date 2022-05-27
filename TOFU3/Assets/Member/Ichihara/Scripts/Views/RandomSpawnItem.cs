using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItem : MonoBehaviour
{
    //�A�C�e���̏����i�[
    [SerializeField]
    private GameObject[] itemPrefabs;
    //�X�e�[�W�̏���TOFU���i�[
    [SerializeField]
    private GameObject[] fieldTOFU;
    //�������ꂽ�������i�[
    private List<int> randNum = new List<int>();

    //���ԊǗ�
    [SerializeField]
    float time = 0.0f;
    //���Ԍo�߂̃`�F�b�N
    bool timerFlagFirst = false;
    bool timerFlagSecond = false;
    //�A�C�e�����X�|�[������Ԋu���i�[
    [SerializeField]
    float interval = 0.0f;
    [SerializeField]
    float ifInterval = 0.0f;
    //interval�̒l���i�[
    //interval�����Z���Ď��Ԃ��v��ׁA
    //�J�E���^�Ƃ͕ʂ�interval�̒l���m�ہA�������interval�����Z�b�g����K�v������
    [SerializeField]
    float setInterval = 0.0f;
    //�X�|�[������A�C�e����
    int item = 0;
    //interval,item��؂�ւ���t���O
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
        //�Q�[���J�n����̌o�ߎ���
        time -= Time.deltaTime;

        //�������Ԃ����Ȃ��Ȃ�����
        //interval��Z�����Aitem�𑝂₷
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

        //interval��������
        if (interval <= 0.0f)
            interval = setInterval;

    }

    //�A�C�e�������Ԋu���Ƀt�B�[���h�ɃX�|�[������
    void SpawnItem()
    {
        //interval�̌o�ߎ���
        float Spawn = interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            SetItem();
        }

    }

    //�����𐶐����ArandNum�Ɋi�[
    void RandomNum()
    {
        //�J�E���^
        int i;

        for(i = 0; i < item; i++ )
        {
            //randNum�ɗv�f��ǉ� & ���̗v�f�ɗ����Ŏ擾�����l����
            randNum.Add(i);
            randNum[i] = Random.Range(0, 100);
        }

    }
    
    //RandNum�̒l�����ƂɃA�C�e���𐶐�
    void SetItem()
    {
        //�J�E���^
        int i;
        //�������i�[
        int j;
        //�A�C�e�����X�|�[����������W
        Vector3 pos;

        //randNum�̒l���Q�Ƃ���itemPrefab�̊e�v�f�𐶐�����              
        for (i = 0; i < item; i++)
        {
            //��������v���n�u�A�v���n�u�𐶐�������W���擾
            j = Random.Range(0, 17);
            //Debug.Log (fieldTOFU[j].transform.position);

            float x = Random.Range(0.0f, 5.0f);
            float z = Random.Range(0.0f, 5.0f);

            pos = new Vector3(x, 1.0f, z);
            //Debug.Log(pos);

            if (timerFlagFirst && timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (randNum[i] < 15)
                {
                    ItemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (randNum[i] >= 15 && randNum[i] < 35)
                {
                    ItemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (randNum[i] >= 35 && randNum[i] < 50)
                {
                    ItemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (randNum[i] >= 50 && randNum[i] < 55)
                {
                    ItemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (randNum[i] >= 55 && randNum[i] < 75)
                {
                    ItemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (randNum[i] >= 75 && randNum[i] < 95)
                {
                    ItemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    ItemInstant6();
                }

            }

            else if (timerFlagFirst && !timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (randNum[i] < 15)
                {
                    ItemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (randNum[i] >= 15 && randNum[i] < 35)
                {
                    ItemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (randNum[i] >= 35 && randNum[i] < 50)
                {
                    ItemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (randNum[i] >= 50 && randNum[i] < 65)
                {
                    ItemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (randNum[i] >= 65 && randNum[i] < 80)
                {
                    ItemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (randNum[i] >= 80 && randNum[i] < 95)
                {
                    ItemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (randNum[i] >= 95 && randNum[i] < 100)
                {
                    ItemInstant6();
                }

            }

            else if (!timerFlagFirst && !timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (randNum[i] < 20)
                {
                    ItemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (randNum[i] >= 20 && randNum[i] < 40)
                {
                    ItemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (randNum[i] >= 40 && randNum[i] < 55)
                {
                    ItemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (randNum[i] >= 55 && randNum[i] < 75)
                {
                    ItemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (randNum[i] >= 75 && randNum[i] < 85)
                {
                    ItemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (randNum[i] >= 85 && randNum[i] < 95)
                {
                    ItemInstant5();
                }
                //���̖�����X�|�[������m��
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
