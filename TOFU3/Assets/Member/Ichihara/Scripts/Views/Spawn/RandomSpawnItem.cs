using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// �A�C�e���������_���Ȉʒu�ɐ�������X�N���v�g
/// </summary>


public class RandomSpawnItem : BaseSpawmStatus
{
    //�t�B�[���h�ɑ��݂��Ă���A�C�e���̑���
    public List<GameObject> Items = new List<GameObject>();
    //�A�C�e�����A�N�e�B�u���𔻒�
    private List<bool> _checkItems = new List<bool>();

    //�X�|�[������A�C�e���̑���
    private int _item = 0;

    //�n�ʂ̐����������_�����擾����List
    List<int> _fieldRandomTOFU = new List<int>();

    //Inspector����uGenerator�v�X�N���v�g��ݒ�
    [Header("ItemGenerator")]
    [SerializeField]
    private YUBA_SHIELDGenerator _cs_YUBA_SHIELD = null;
    [SerializeField]
    private DASHI_STIMGenerator _cs_DASHI_STIM = null;
    [SerializeField]
    private OKAKA_CHAFGenerator _cs_OKAKA_CHAF = null;
    [SerializeField]
    private YUZU_RADARGenerator _cs_YUZU_RADAR = null;
    [SerializeField]
    private AGE_TOFUMODEGenerator _cs_AGETOFUMODE = null;
    [SerializeField]
    private MOMIZI_REDGenerator _cs_MOMIZI_RED = null;
    [SerializeField]
    private OKURA_TORIMOCHIGenerator _cs_OKURA_TORIMOCHI = null;

    // Start is called before the first frame update
    void Start()
    {
        _item = 4;
        _setInterval = _interval;

        //_fieldTOFU�̗v�f��_fieldRandomTOFU�ɑ��
        for (int i = 0; i < _fieldTOFU.Count; i++)
        {
            _fieldRandomTOFU.Add(i);
        }
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

        _interval -= Time.deltaTime;

        SpawnItem();
        if(Items.Count > 1)
        {
            RemoveElements();
        }

        //_interval�����Z�b�g
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> �A�C�e�������Ԋu���Ƀt�B�[���h�ɃX�|�[������֐� </summary>
    private void SpawnItem()
    {
        //_interval�̌o�ߎ���
        float Spawn = _interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            SetItem();
        }

    }

    /// <summary> Items�Ɋi�[����Ă���I�u�W�F�N�g����A�N�e�B�u�̏ꍇ�A
    /// ���̃I�u�W�F�N�g���i�[����Ă���index���������� </summary>
    private void RemoveElements()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].activeSelf == false)
            {
                _checkItems[i] = true;
            }

            if (_checkItems[i] == true)
            {
                Items.Remove(Items[i]);
            }
        }


    }

    /// <summary> �����𐶐����A_randNum�Ɋi�[����֐� </summary>
    private void RandomNum()
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
    private void SetItem()
    {
        //�������i�[
        int random;

        //_randNum�̒l���Q�Ƃ���_itemPrefab�̊e�v�f�𐶐�����              
        for (int i = 0; i < _item; i++)
        {
            //Items�ɃX�|�[�������I�u�W�F�N�g�̏����i�[
            if (Items.Count < _item)
            {
                _checkItems.Add(false);
            }
            else if (Items.Count >= _item)
            {
                break;
            }

            //�v���n�u�𐶐�������W���擾
            random = Random.Range(0, _fieldRandomTOFU.Count);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    SpawnYUBA_SHIELD();
                    Items.Add(_cs_YUBA_SHIELD.GetYUBA_SHIELD());
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    SpawnDASHI_STIM();
                    Items.Add(_cs_DASHI_STIM.GetDASHI_STIM());
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    SpawnOKAKA_CHAF();
                    Items.Add(_cs_OKAKA_CHAF.GetOKAKA_CHAF());
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    SpawnYUZU_RADAR();
                    Items.Add(_cs_YUZU_RADAR.GetYUZU_RADAR());
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    SpawnAGE_TOFUMODE();
                    Items.Add(_cs_AGETOFUMODE.GetAGE_TOFUMODE());
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                    Items.Add(_cs_MOMIZI_RED.GetMOMIZI_RED());
                }
                //OKURA-TORIMOCHI���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                    Items.Add(_cs_OKURA_TORIMOCHI.GetOKURA_TORIMOCHI());
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    SpawnYUBA_SHIELD();
                    Items.Add(_cs_YUBA_SHIELD.GetYUBA_SHIELD());
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    SpawnDASHI_STIM();
                    Items.Add(_cs_DASHI_STIM.GetDASHI_STIM());
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    SpawnOKAKA_CHAF();
                    Items.Add(_cs_OKAKA_CHAF.GetOKAKA_CHAF());
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    SpawnYUZU_RADAR();
                    Items.Add(_cs_YUZU_RADAR.GetYUZU_RADAR());
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    SpawnAGE_TOFUMODE();
                    Items.Add(_cs_AGETOFUMODE.GetAGE_TOFUMODE());
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                    Items.Add(_cs_MOMIZI_RED.GetMOMIZI_RED());
                }
                //OKURA-TORIMOCHI���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                    Items.Add(_cs_OKURA_TORIMOCHI.GetOKURA_TORIMOCHI());
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 20)
                {
                    SpawnYUBA_SHIELD();
                    Items.Add(_cs_YUBA_SHIELD.GetYUBA_SHIELD());
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    SpawnDASHI_STIM();
                    Items.Add(_cs_DASHI_STIM.GetDASHI_STIM());
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    SpawnOKAKA_CHAF();
                    Items.Add(_cs_OKAKA_CHAF.GetOKAKA_CHAF());
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    SpawnYUZU_RADAR();
                    Items.Add(_cs_YUZU_RADAR.GetYUZU_RADAR());
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    SpawnAGE_TOFUMODE();
                    Items.Add(_cs_AGETOFUMODE.GetAGE_TOFUMODE());
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    SpawnMOMIZI_RED();
                    Items.Add(_cs_MOMIZI_RED.GetMOMIZI_RED());
                }
                //OKURA-TORIMOCHI���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnOKURA_TORIMOCHI();
                    Items.Add(_cs_OKURA_TORIMOCHI.GetOKURA_TORIMOCHI());
                }

            }

        }

        //YUBA-SHIELD���X�|�[������
        void SpawnYUBA_SHIELD()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_YUBA_SHIELD.GenerateYUBA_SHIELD(spawnPos);
            transform.SetParent(transform.root);
        }

        //DASHI-STIM���X�|�[������
        void SpawnDASHI_STIM()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_DASHI_STIM.GenerateDASHI_STIM(spawnPos);
            transform.SetParent(transform.root);
        }

        //OKAKA-CHAF���X�|�[������
        void SpawnOKAKA_CHAF()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_OKAKA_CHAF.GenerateOKAKA_CHAF(spawnPos);
            transform.SetParent(transform.root);
        }

        //YUZA-RADAR���X�|�[������
        void SpawnYUZU_RADAR()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_YUZU_RADAR.GenerateYUZU_RADAR(spawnPos);
            transform.SetParent(transform.root);
        }

        //AGE-TOFUMODO���X�|�[������
        void SpawnAGE_TOFUMODE()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_AGETOFUMODE.GenerateAGE_TOFUMODE(spawnPos);
            transform.SetParent(transform.root);
        }

        //MOMIZI-RED���X�|�[������
        void SpawnMOMIZI_RED()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_MOMIZI_RED.GenerateMOMIZI_RED(spawnPos);
            transform.SetParent(transform.root);
        }

        //OKURA-TORIMOCHI���X�|�[������
        void SpawnOKURA_TORIMOCHI()
        {
            var spawnPos = RandomPos(_fieldRandomTOFU[random]);
            _cs_OKURA_TORIMOCHI.GenerateOKURA_TORIMOCHI(spawnPos);
            transform.SetParent(transform.root);
        }      
        
    }

    /// <summary> �A�C�e���̃X�|�[�����W���擾����֐� </summary>
    /// <param name="Index"></param>
    /// <returns></returns>
    private Vector3 RandomPos(int Index)
    {
        //�Ԃ�l�̐錾
        Vector3 setSpawnPos = Vector3.zero;

        bool checkFlag = false;

        //�I�u�W�F�N�g��x���W�n�Az���W�n�̔����̑傫��
        Vector3 halfExtents = new Vector3(0.5f, 0.0f, 0.5f);

        //�X�e�[�W�I�u�W�F�N�g���m���d�Ȃ�Ȃ��悤�ɒ�������
        do
        {
            //�X�|�[��������W�̍ő�l�A�ŏ��l��ݒ�
            var spawnPosX = Mathf.Clamp(Random.Range(-_fieldTOFU[Index].transform.localScale.x / 2 + halfExtents.x,
                                                     _fieldTOFU[Index].transform.localScale.x / 2 - halfExtents.x),
                                        -_fieldTOFU[Index].transform.localScale.x / 2,
                                        _fieldTOFU[Index].transform.localScale.x / 2);

            var spawnPosZ = Mathf.Clamp(Random.Range(-_fieldTOFU[Index].transform.localScale.z / 2 + halfExtents.z, 
                                                     _fieldTOFU[Index].transform.localScale.z / 2 - halfExtents.z),
                                        -_fieldTOFU[Index].transform.localScale.z / 2,
                                        _fieldTOFU[Index].transform.localScale.z / 2);

            //�I�u�W�F�N�g���X�|�[��������W
            Vector3 prxSetSpawnPos = _fieldTOFU[Index].transform.position +
                new Vector3(spawnPosX, _fieldTOFU[Index].transform.localScale.y / 2 + 0.1f, spawnPosZ);

            //�I�u�W�F�N�g���m�̏d�Ȃ�̔���
            //if (Physics.CheckBox(prxSetSpawnPos, halfExtents, Quaternion.identity) == false)
            //{
            //    Debug.Log(prxSetSpawnPos);
            //}

            setSpawnPos = prxSetSpawnPos;
            checkFlag = true;

        } while (!checkFlag);

        return setSpawnPos;

    }
}

