using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//????????
public class KATSUO : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotSpeed;         //�e��
    public float Interval;          //�A�ˑ��x�i��ς�����悤�ɂ��������j
    public int ShotCountNow = 5;   //���݂̒e��
    public int ShotMax = 5;        //�P�}�K�W���̒e��
    public int ShotBullet = 5;     //�e�̑S�e��
    public float _forcePower;       //������΂�����
    public float ShotDamage = 100;        //�_���[�W


    private float ShotInterval;     //�A�ˑ��x

    //Physics.Raycast(Vector3 origin(ray�̊J�n�n�_), Vector3 direction(ray�̌���),RaycastHit hitInfo(���������I�u�W�F�N�g�̏����i�[), float distance(ray�̔��ˋ���), int layerMask(���C���}�X�N�̐ݒ�));

    //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

    float rndx;
    float rndy;
    float rndz;

    //Vector3 origin = new Vector3(0, 0, 0); // ���_
    //Vector3 direction = new Vector3(1, 0, 0); // X��������\���x�N�g��
    //Ray ray = new Ray(origin, direction); // Ray�𐶐�

    private Vector3 RandomBullet()
    {
        float rndx = Random.Range(-20.0f, 20.0f);
        float rndy = Random.Range(-20.0f, 20.0f);
        float rndz = Random.Range(100.0f, 101.0f);

        return randomVec = new Vector3(rndx, rndy, rndz);
    }

    private Vector3 randomVec;

    private void Start()
    {
        randomVec = new Vector3(rndx, rndy, rndz * ShotSpeed);
    }


    private void ShotPrefab()//�e�̔���
    {


        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
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
        Vector3 toVec = new Vector3(rndx, rndy, rndz);

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