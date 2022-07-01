using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// �A�C�e���������_���Ȉʒu�ɐ�������X�N���v�g
/// </summary>


public class RandomSpawnItem : SpawnManager
{
    //�X�|�[������A�C�e���̑���
    int _item = 0;

    //Inspector����uGenerator�v�X�N���v�g��ݒ�
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
        //�Q�[���J�n����̌o�ߎ���
        _time -= Time.deltaTime;

        //�������Ԃ����Ȃ��Ȃ�����
        //_interval��Z�����A_item�𑝂₷
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

        //_interval�����Z�b�g
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> �A�C�e�������Ԋu���Ƀt�B�[���h�ɃX�|�[������֐� </summary>
    void SpawnItem()
    {
        //_interval�̌o�ߎ���
        float Spawn = _interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            SetItem();
        }

    }

    /// <summary> �����𐶐����A_randNum�Ɋi�[����֐� </summary>
    void RandomNum()
    {
        for(int i = 0; i < _item; i++ )
        {
            //_randNum�ɗv�f��ǉ�
            //���̗v�f�ɗ����Ŏ擾�����l����
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }

    /// <summary> _randNum�̒l���Q�Ƃ��ăA�C�e���𐶐�����֐� </summary>
    void SetItem()
    {
        //�������i�[
        int j;
        // �n�ʂ̐����������_�����擾����List
        List<int> _fieldRandomTOFU = new List<int>();

        //_fieldTOFU�̗v�f��_fieldRandomTOFU�ɑ��
        for(int i = 0; i < _fieldTOFU.Count; i++)
        {
            _fieldRandomTOFU.Add(i);

        }

        //_randNum�̒l���Q�Ƃ���_itemPrefab�̊e�v�f�𐶐�����              
        for (int i = 0; i < _item; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Item").Length == _item)
                break;

            //�v���n�u�𐶐�������W���擾
            j = Random.Range(0, _fieldRandomTOFU.Count);
            //Debug.Log (_fieldTOFU[j].transform.position);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    SpawnYUBA_SHIELD();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    SpawnDASHI_STIM();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    SpawnOKAKA_CHAF();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    SpawnYUZU_RADAR();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    SpawnAGE_TOFUMODE();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                }
                //OKURA-TORIMOCHI���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    SpawnYUBA_SHIELD();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    SpawnDASHI_STIM();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    SpawnOKAKA_CHAF();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    SpawnYUZU_RADAR();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    SpawnAGE_TOFUMODE();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                }
                //OKURA-TORIMOCHI���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 20)
                {
                    SpawnYUBA_SHIELD();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    SpawnDASHI_STIM();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    SpawnOKAKA_CHAF();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    SpawnYUZU_RADAR();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    SpawnAGE_TOFUMODE();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                }
                //OKURA-TORIMOCHI���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                }

            }

        }

        //YUBA-SHIELD���X�|�[������
        void SpawnYUBA_SHIELD()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_YUBA_SHIELD.GenerateYUBA_SHIELD(spawnPos);
            transform.SetParent(transform.root);

        }

        //DASHI-STIMD���X�|�[������
        void SpawnDASHI_STIM()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_DASHI_STIM.GenerateDASHI_STIM(spawnPos);
            transform.SetParent(transform.root);

        }

        //OKAKA-CHAF���X�|�[������
        void SpawnOKAKA_CHAF()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_OKAKA_CHAF.GenerateOKAKA_CHAF(spawnPos);
            transform.SetParent(transform.root);

        }

        //YUZA-RADAR���X�|�[������
        void SpawnYUZU_RADAR()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_YUZU_RADAR.GenerateYUZU_RADAR(spawnPos);
            transform.SetParent(transform.root);

        }

        //AGE-TOFUMODO���X�|�[������
        void SpawnAGE_TOFUMODE()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_AGETOFUMODE.GenerateAGE_TOFUMODE(spawnPos);
            transform.SetParent(transform.root);

        }

        //MOMIZI-RED���X�|�[������
        void SpawnMOMIZI_RED()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_MOMIZI_RED.GenerateMOMIZI_RED(spawnPos);
            transform.SetParent(transform.root);

        }

        //OKURA-TORIMOCHI���X�|�[������
        void SpawnOKURA_TORIMOCHI()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_OKURA_TORIMOCHI.GenerateOKURA_TORIMOCHI(spawnPos);
            transform.SetParent(transform.root);

        }


        // �n�ʂ̃����_���ȍ��W���擾����@
        Vector3 GetRandomPos(int randomList)
        {
            //�Ԃ�l�̐錾
            Vector3 setSpawnPos = Vector3.zero;

            bool spawnFlag = false;

            //�I�u�W�F�N�g�̊e���W�n�̔����̑傫��
            Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

            //�X�e�[�W�I�u�W�F�N�g���m���d�Ȃ�Ȃ��悤�ɒ�������
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

