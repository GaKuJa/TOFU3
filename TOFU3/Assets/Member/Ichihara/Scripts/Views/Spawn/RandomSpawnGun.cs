using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// �e�������_���Ȉʒu�ɐ�������X�N���v�g
/// </summary>

public class RandomSpawnGun : BaseSpawmStatus
{
    //�t�B�[���h�ɑ��݂��Ă���e�̑���
    public List<GameObject> Guns = new List<GameObject>();

    //�X�|�[������e�̑���
    private int _gun = 0;

    //Inspector����uGenerator�v�X�N���v�g��ݒ�
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
        //�Q�[���J�n����̌o�ߎ���
        _time -= Time.deltaTime;

        //�������Ԃ����Ȃ��Ȃ�����
        //_interval��Z�����A_gun�𑝂₷
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
        if (Guns.Count > 0)
        {
            RemoveElements();
        }

        //_interval�����Z�b�g
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> �e�����Ԋu���Ƀt�B�[���h�ɃX�|�[������֐� </summary>
    void SpawnGun()
    {
        //_interval�̌o�ߎ���
        float Spawn = _interval;

        if (Spawn <= 0.0f)
        {
            RandomNum();
            SetGun();
        }

    }

    /// <summary> Guns�Ɋi�[����Ă���I�u�W�F�N�g��false�̏ꍇ�A
    /// ���̃I�u�W�F�N�g���i�[����Ă���v�f����������֐� </summary>
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

    /// <summary> �����𐶐����A_randNum�Ɋi�[����֐� </summary>
    void RandomNum()
    {
        for (int i = 0; i < _gun; i++)
        {
            //_randNum�ɗv�f��ǉ�
            //���̗v�f�ɗ����Ŏ擾�����l����
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }

    /// <summary> _randNum�̒l���Q�Ƃ��ďe�𐶐�����֐� </summary>
    void SetGun()
    {
        //�������i�[
        int j;
        // �n�ʂ̐����������_�����擾����List
        List<int> _fieldRandomTOFU = new List<int>();

        //_fieldTOFU�̗v�f��_fieldRandomTOFU�ɑ��
        for (int i = 0; i < _fieldTOFU.Count; i++)
        {
            _fieldRandomTOFU.Add(i);
        }

        //_randNum�̒l���Q�Ƃ���_itemPrefab�̊e�v�f�𐶐�����              
        for (int i = 0; i < _gun; i++)
        {
            //Items�ɃX�|�[�������I�u�W�F�N�g�̏����i�[
            if (Guns.Count < _gun)
            {
                Guns.Add(gameObject);
            }
            else if (Guns.Count >= _gun)
            {
                break;
            }

            //�v���n�u�𐶐�������W���擾
            j = Random.Range(0, _fieldRandomTOFU.Count);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //SHOYOU-GUN���X�|�[������m��
                if (_randNum[i] < 25)
                {
                    SpawnSHOYOU_GUN();
                }
                //KOYADOFU-GUN���X�|�[������m��
                else if (_randNum[i] >= 25 && _randNum[i] < 35)
                {
                    SpawnKOYADOFU_GUN();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 55)
                {
                    SpawnLong_NEGI_Rifle();
                }
                //SESAMI-Shooter���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 80)
                {
                    SpawnSESAMI_Shooter();
                }
                //KATSUO���m���X�|�[������m��
                else if (_randNum[i] >= 80 && _randNum[i] < 90)
                {
                    SpawnKATSUO_BUSHI();
                }
                //B�EF�ET���X�|�[������m��
                else if (_randNum[i] >= 90 && _randNum[i] < 100)
                {
                    SpawnB_F_T();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //SHOYOU-GUN���X�|�[������m��
                if (_randNum[i] < 25)
                {
                    SpawnSHOYOU_GUN();
                }
                //KOYADOFU-GUN���X�|�[������m��
                else if (_randNum[i] >= 25 && _randNum[i] < 50)
                {
                    SpawnKOYADOFU_GUN();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    SpawnLong_NEGI_Rifle();
                }
                //SESAMI-Shooter���X�|�[������m��
                else if (_randNum[i] >= 65 && _randNum[i] < 90)
                {
                    SpawnSESAMI_Shooter();
                }
                //KATSUO���m���X�|�[������m��
                else if (_randNum[i] >= 90 && _randNum[i] < 95)
                {
                    SpawnKATSUO_BUSHI();
                }
                //B�EF�ET���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnB_F_T();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //SHOYOU-GUN���X�|�[������m��
                if (_randNum[i] < 25)
                {
                    SpawnSHOYOU_GUN();
                }
                //KOYADOFU-GUN���X�|�[������m��
                else if (_randNum[i] >= 25 && _randNum[i] < 55)
                {
                    SpawnKOYADOFU_GUN();
                }
                //Long-NEGI-Rifle���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 70)
                {
                    SpawnLong_NEGI_Rifle();
                }
                //SESAMI-Shooter���X�|�[������m��
                else if (_randNum[i] >= 70 && _randNum[i] < 90)
                {
                    SpawnSESAMI_Shooter();
                }
                //KATSUO���m���X�|�[������m��
                else if (_randNum[i] >= 90 && _randNum[i] < 95)
                {
                    SpawnKATSUO_BUSHI();
                }
                //B�EF�ET���X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    SpawnB_F_T();
                }

            }

        }

        //SHOYOU-GUN���X�|�[������
        void SpawnSHOYOU_GUN()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_SHOYOU_GUN.GenerateSHOYOU_GUN(spawnPos);
            transform.SetParent(transform.root);

        }

        //KOYADOFU-GUN���X�|�[������
        void SpawnKOYADOFU_GUN()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_KOYADOFU_GUN.GenerateKOYADOFU_GUN(spawnPos);
            transform.SetParent(transform.root);

        }

        //Long-NEGI-Rifle���X�|�[������
        void SpawnLong_NEGI_Rifle()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_Long_NEGI_Rifle.GenerateLong_NEGI_Rifle(spawnPos);
            transform.SetParent(transform.root);

        }

        //SESAMI-Shooter���X�|�[������
        void SpawnSESAMI_Shooter()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_SESAMI_Shooter.GenerateSESAMI_Shoot(spawnPos);
            transform.SetParent(transform.root);

        }

        //KATSUO���m���X�|�[������
        void SpawnKATSUO_BUSHI()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_KATSUO_BUSHI.GenerateKATSUO_BUSHI(spawnPos);
            transform.SetParent(transform.root);

        }

        //B�EF�ET���X�|�[������
        void SpawnB_F_T()
        {
            var spawnPos = GetRandomPos(_fieldRandomTOFU[j]);
            _cs_B_F_T.GenerateB_F_T(spawnPos);
            transform.SetParent(transform.root);

        }

        
        // �n�ʂ̃����_���ȍ��W���擾����@
        Vector3 GetRandomPos(int randomList)
        {
            //�Ԃ�l�̐錾
            Vector3 setSpawnPos = Vector3.zero;

            bool checkFlag = false;

            //�I�u�W�F�N�g��x���W�n�Az���W�n�̔����̑傫��
            Vector3 halfExtents = new Vector3(this.gameObject.transform.localScale.x / 2,
                                              0.0f,
                                              this.gameObject.transform.localScale.z / 2);

            Debug.Log("fieldTOFU :" + randomList + " Item");

            //�X�e�[�W�I�u�W�F�N�g���m���d�Ȃ�Ȃ��悤�ɂȂ�܂Ŏ��s����
            do
            {
                //�X�|�[��������W�̍ő�l�A�ŏ��l��ݒ�
                var spawnPosX = Mathf.Clamp(Random.Range(-_fieldTOFU[randomList].transform.localScale.x / 2
                                                + halfExtents.x, _fieldTOFU[randomList].transform.localScale.x / 2 - halfExtents.x),
                                            -_fieldTOFU[randomList].transform.localScale.x / 2,
                                            _fieldTOFU[randomList].transform.localScale.x / 2);

                var spawnPosZ = Mathf.Clamp(Random.Range(-_fieldTOFU[randomList].transform.localScale.z / 2
                                                + halfExtents.z, _fieldTOFU[randomList].transform.localScale.z / 2 - halfExtents.z),
                                            -_fieldTOFU[randomList].transform.localScale.z / 2,
                                            _fieldTOFU[randomList].transform.localScale.z / 2);

                //�I�u�W�F�N�g���X�|�[��������W���擾
                Vector3 prxSetSpawnPos = _fieldTOFU[randomList].transform.position +
                    new Vector3(spawnPosX, _fieldTOFU[randomList].transform.localScale.y / 2, spawnPosZ);

                //���[�v�I��
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
