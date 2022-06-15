using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �A�C�e���������_���Ȉʒu�ɐ�������X�N���v�g
/// </summary>


public class RandomSpawnItem : MonoBehaviour
{
    //�A�C�e���̃v���n�u���i�[
    [SerializeField]
    private GameObject[] _itemPrefabs;
    //�X�e�[�W�̏���TOFU�v���n�u���i�[
    [SerializeField]
    private GameObject[] _fieldTOFU;
    //���݃}�b�v�ɔz�u����Ă���A�C�e���v���n�u�̌����i�[
    private List<int> _items = new List<int>();

    //�������ꂽ�������i�[
    private List<int> _randNum = new List<int>();

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
    float _afterThreeMinitsInterval = 0.0f;
    //_interval�̒l���i�[
    //_interval�����Z���Ď��Ԃ��v��ׁA
    //�J�E���^�Ƃ͕ʂ�_interval�̒l���m�ہA�������_interval�����Z�b�g����K�v������
    [SerializeField]
    float _setInterval = 0.0f;
    //�X�|�[������A�C�e����
    int _item = 0;

    //Inspector����uGenerator�v�X�N���v�g��ݒ�
    [SerializeField]
    YUBA_SHIELDGenerator _sc_YUBA_SHIELD;
    [SerializeField]
    DASHI_STIMGenerator _sc_DASHI_STIM;
    [SerializeField]
    OKAKA_CHAFGenerator _sc_OKAKA_CHAF;
    [SerializeField]
    YUZU_RADARGenerator _sc_YUZU_RADAR;
    [SerializeField]
    AGE_TOFUMODEGenerator _sc_AGETOFUMODE;
    [SerializeField]
    MOMIZI_REDGenerator _sc_MOMIZI_RED;
    [SerializeField]
    OKURA_TORIMOCHIGenerator _sc_OKURA_TORIMOCHI;


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

        if (_timerFlagSecond )
        {
            _setInterval = _afterThreeMinitsInterval;
            _item = 5;
        }

        //Debug.Log(_item);

        _interval -= Time.deltaTime;

        //Debug.Log (set_interval = (set_interval -= Time.deltatime));

        Spawnitem();
        //for (int i = 0; i < _item - _items.Count; i++)
        //{
        //    if (_items[i] == /*���݂��Ȃ�*/)
        //    {
        //        _items.RemoveAt(i);
        //    }
        //}

        //_interval��������
        if (_interval <= 0.0f)
            _interval = _setInterval;

    }

    /// <summary> �A�C�e�������Ԋu���Ƀt�B�[���h�ɃX�|�[������֐� </summary>
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

    /// <summary> �����𐶐����A_randNum�Ɋi�[����֐� </summary>
    void RandomNum()
    {
        //�J�E���^
        int i;

        for(i = 0; i < _item; i++ )
        {
            //_randNum�ɗv�f��ǉ�
            //���̗v�f�ɗ����Ŏ擾�����l����
            _randNum.Add(i);
            _randNum[i] = Random.Range(0, 100);
        }

    }

    /// <summary> _randNum�̒l���Q�Ƃ��ăA�C�e���𐶐�����֐� </summary>
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
            ////_items�ɗv�f��ǉ����A�A�C�e�������̉񐔂𐧌䂷��
            //if(_items.Count < _item)
            //{
            //    _items.Add(i);
            //}
            //else if(_items.Count == _item)
            //{
            //    break;
            //}

            //�v���n�u�𐶐�������W���擾
            j = Random.Range(0, _fieldTOFU.Length);
            //Debug.Log (_fieldTOFU[j].transform.position);

            float x = Random.Range(-10.0f, 10.0f);
            float z = Random.Range(-10.0f, 10.0f);

            pos = new Vector3(x, 1.5f, z);
            //Debug.Log(pos);

            if (_timerFlagFirst && _timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    itemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    itemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    itemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 55)
                {
                    itemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    itemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 95)
                {
                    itemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    itemInstant6();
                }

            }

            else if (_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 15)
                {
                    itemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 15 && _randNum[i] < 35)
                {
                    itemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 35 && _randNum[i] < 50)
                {
                    itemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 50 && _randNum[i] < 65)
                {
                    itemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 65 && _randNum[i] < 80)
                {
                    itemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 80 && _randNum[i] < 95)
                {
                    itemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    itemInstant6();
                }

            }

            else if (!_timerFlagFirst && !_timerFlagSecond)
            {
                //YUBA-SHILD���X�|�[������m��
                if (_randNum[i] < 20)
                {
                    itemInstant0();
                }
                //DASHI-STIM���X�|�[������m��
                else if (_randNum[i] >= 20 && _randNum[i] < 40)
                {
                    itemInstant1();
                }
                //OKAKA-CHAF���X�|�[������m��
                else if (_randNum[i] >= 40 && _randNum[i] < 55)
                {
                    itemInstant2();
                }
                //YUZU-RADAR���X�|�[������m��
                else if (_randNum[i] >= 55 && _randNum[i] < 75)
                {
                    itemInstant3();
                }
                //AGE-TOFUMODE���X�|�[������m��
                else if (_randNum[i] >= 75 && _randNum[i] < 85)
                {
                    itemInstant4();
                }
                //MOMIZI-RED���X�|�[������m��
                else if (_randNum[i] >= 85 && _randNum[i] < 95)
                {
                    itemInstant5();
                }
                //���̖�����X�|�[������m��
                else if (_randNum[i] >= 95 && _randNum[i] < 100)
                {
                    itemInstant6();
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

        void itemInstant0()
        {
            _sc_YUBA_SHIELD.SpawnYUBA_SHIELD(pos);
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.SetParent(_fieldTOFU[j].transform);
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.SetParent(transform.root);
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.localPosition = pos;
            //_sc_YUBA_SHIELD.SpwanYUBA_SHIELD(pos).transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[0];
        }

        void itemInstant1()
        {
            _sc_DASHI_STIM.SpawnDASHI_STIM(pos);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[1];
        }

        void itemInstant2()
        {
            _sc_OKAKA_CHAF.SpawnOKAKA_CHAF(pos);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[2];
        }

        void itemInstant3()
        {
            _sc_YUZU_RADAR.SpawnYUZU_RADAR(pos);
            //var obj = Instantiate(_itemPrefabs[3], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[3];
        }

        void itemInstant4()
        {
            _sc_AGETOFUMODE.SpwanAGE_TOFUMODE(pos);
            //var obj = Instantiate(_itemPrefabs[4], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[4];
        }

        void itemInstant5()
        {
            _sc_MOMIZI_RED.SpawnMOMIZI_RED(pos);
            //var obj = Instantiate(_itemPrefabs[5], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.SetParent(_fieldTOFU[j].transform);
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[5];
        }

        void itemInstant6()
        {
            _sc_OKURA_TORIMOCHI.SpawnOKURA_TORIMOCHI(pos);
            //var obj = Instantiate(_itemPrefabs[6], _fieldTOFU[j].transform.TransformVector(pos), Quaternion.identity);
            //obj.transform.parent = _fieldTOFU[j].transform;
            //obj.transform.SetParent(transform.root);
            //obj.transform.localPosition = pos;
            //obj.transform.localScale = new Vector3(1, 1, 1);

            //return _itemPrefabs[6];
        }

    }

}
