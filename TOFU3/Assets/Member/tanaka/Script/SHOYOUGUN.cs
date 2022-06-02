using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//
//?A?T???g???C?t??
public class SHOYOUGUN : MonoBehaviour
{
    public static SHOYOUGUN Instance { get => _instance; }
    static        SHOYOUGUN _instance;
    // 弾のプレハブ
    [SerializeField]
    private GameObject BulletPrefab;
    // 弾速
    public float ShotSpeed;
    // 連射速度
    public float Interval;
    // 現在の弾薬数
    public int ShotCountNow = 20;
    // マガジンの最大数
    public int ShotMax = 20;
    // リロードできる数
    public int ShotBullet = 40;
    public float _forcePower;       //������΂�����
    public float ShotDamage = 33;        //�_���[�W


    private float ShotInterval;     //�A�ˑ��x

    //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

    float rndx;
    float rndy;
    float rndz;

    private void Awake()
    {
        _instance = this;
    }

    private Vector3 RandomBullet()
    {
        float rndx = Random.Range(-5.0f, 5.0f);
        float rndy = Random.Range(-5.0f, 5.0f);
        float rndz = Random.Range(100.0f,101.0f);
        return randomVec = new Vector3(rndx, rndy, rndz);
    }

    private Vector3 randomVec;

    private void Start()
    {
        randomVec = new Vector3(rndx,rndy,rndz * ShotSpeed);
    }


    private void ShotPrefab()//�e�̔���
    {


        ShotInterval += 1;
        
        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            Debug.Log("Shootiong!");
            ShotCountNow -= 1;
            Debug.Log(RandomBullet());
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //Vector3 force = new Vector3(rndx, rndy, zzz);
            bulletRb.AddForce(RandomBullet() * ShotSpeed);

            //3�b��ɏo�����e������

            Destroy(bullet, 3.0f);
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {

        //�Ԃ��������肩��RigitBody�����o��
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
        if (!otherRigitbody)
        {
            return;
        }

        //������΂����������߂�(�v���C���[����G�ꂽ���̂̕���)
        Vector3 toVec = GetAngleVec(BulletPrefab, _collider.gameObject);

        //�������
        otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);

        
    }


    private void ShotBulletDamage()
    {
       
    }

    private void ShotNothing()//�����[�h
    {

        int reload = ShotMax - ShotCountNow; 

        //�e���c���Ă�Ƃ�
        if (ShotBullet >= reload)
        {
            ShotCountNow += reload; 
            ShotBullet -= reload; 

        }
        //�Ȃ��Ƃ�
        else
        {
            ShotCountNow += ShotBullet; 
            ShotBullet = 0; 
        }

        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("MousuIn!");
            ShotPrefab();
            //RandomBullet();
            

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ShotNothing();


        }

    }

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //���ˊp�x
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(rndx,rndy,rndz);

        return Vector3.Normalize(toVec);
    }
  

    public int GetShotCountNow()
    {
        return ShotCountNow;
    }

    public int GetShotMax()
    {
        return ShotMax;
    }

    public int GetShotBullet()
    {
        return ShotBullet;
    }
}