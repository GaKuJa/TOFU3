using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItem : MonoBehaviour
{
    //�A�C�e���̃v���n�u���i�[
    [SerializeField]
    private GameObject[] _itemPrefabs;
    //�X�e�[�W�̏���TOFU�v���n�u���i�[
    [SerializeField]
    private GameObject[] _fieldTOFU;
    //�������ꂽ�������i�[
    private List<int> _randNum = new List<int>();
    //���݃}�b�v�ɔz�u����Ă���A�C�e���v���n�u�̌����i�[
    private List<int> _items = new List<int>();

    //���ԊǗ�
    [SerializeField]
    float _time = 0.0f;
    //���Ԍo�߂̃`�F�b�N
    bool _timerFlagFirst = false;
    bool _timerFlagSecond = false;
    //�A�C�e�����X�|�[������Ԋu���i�[
    [SerializeField]
    float _interval = 0.0f;
    [SerializeField]
    float _ifinterval = 0.0f;
    //_interval�̒l���i�[
    //_interval�����Z���Ď��Ԃ��v��ׁA
    //�J�E���^�Ƃ͕ʂ�_interval�̒l���m�ہA�������_interval�����Z�b�g����K�v������
    [SerializeField]
    float _setinterval = 0.0f;
    //�X�|�[������A�C�e����
    int _item = 0;
    //_interval,_item��؂�ւ���t���O
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
        //�Q�[���J�n����̌o�ߎ���
        _time -= Time.deltaTime;

        //�������Ԃ����Ȃ��Ȃ�����
        //_interval��Z�����A_item�𑝂₷
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

        //_interval��������
        if (_interval <= 0.0f)
            _interval = _setinterval;

    }

    //�A�C�e�������Ԋu���Ƀt�B�[���h�ɃX�|�[������
    void Spawnitem()
    {
        //_interval�̌o�ߎ���
        float Spawn = _interval;

        if(Spawn <= 0.0f)
        {
            RandomNum();
            Setitem();
        }

    }

    //�����𐶐����A_randNum�Ɋi�[
    void RandomNum()
    {
        //�J�E���^
        int i;

        for(i = 0; i < _item; i++ )
        {
            //_randNum�ɗv�f��ǉ� & ���̗v�f�ɗ����Ŏ擾�����l����
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }
    
    //_randNum�̒l�����ƂɃA�C�e���𐶐�
    void Setitem()
    {
        //�J�E���^
        int i;
        //�������i�[
        int j;
        //�A�C�e�����X�|�[����������W
        Vector3 pos;

        //_randNum�̒l���Q�Ƃ���_itemPrefab�̊e�v�f�𐶐�����              
        for (i = 0; i < _item; i++)
        {
            //_randNum�̗v�f�����擾���A�A�C�e�������̉񐔂𐧌䂷��


            //�v���n�u�𐶐�������W���擾
            j = Random.Range(0, 17);
            //Debug.Log (_fieldTOFU[j].transform.position);

            float x = Random.Range(0.0f, 5.0f);
            float z = Random.Range(0.0f, 5.0f);

            pos = new Vector3(x, 1.5f, z);
            //Debug.Log(pos);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    _itemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    _itemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    _itemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    _itemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    _itemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    _itemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    _itemInstant6();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    _itemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    _itemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    _itemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    _itemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    _itemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    _itemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    _itemInstant6();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 20)
                {
                    _itemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    _itemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    _itemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    _itemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    _itemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    _itemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    _itemInstant6();
                }

                ////�Ԃ�l���i�[
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
