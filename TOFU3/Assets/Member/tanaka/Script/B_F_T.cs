using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���P����
public class B_F_T : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotSpeed;         //�e��
    public float Interval;          //�A�ˑ��x�i��ς�����悤�ɂ��������j
    public int ShotCountNow = 20;   //���݂̒e��
    public int ShotMax = 20;        //�P�}�K�W���̒e��
    public int ShotBullet = 40;     //�e�̑S�e��
    public float _forcePower;       //������΂�����
    public float ShotDamage = 100;  //�_���[�W


    private float ShotInterval;     //�A�ˑ��x

    // �����̗�
    private float power = 10f;

    // �������y�Ԕ͈́i���a�j
    private float radius = 10f;

    //Vector3 origin = new Vector3(0, 0, 0); // ���_
    //Vector3 direction = new Vector3(1, 0, 0); // X��������\���x�N�g��
    //Ray ray = new Ray(origin, direction); // Ray�𐶐�

    private void Start()
    {
       
    }


    private void ShotPrefab()//�e�̔���
    {


        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            ShotCountNow -= 1;
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //Vector3 force = new Vector3(rndx, rndy, zzz);
            bulletRb.AddForce(transform.forward * ShotSpeed);

            //3�b��ɏo�����e������

            Destroy(bullet, 3.0f);
        }
    }

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //���ˊp�x
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(0,0,0);

        return Vector3.Normalize(toVec);
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

    private void OnCollisionEnter(Collision collision)
    {
        // ���e�_�𔚐S�n�ɂ���
        Vector3 explosionPos = collision.transform.position;

        // ���S�n����w�w�肵�����a���x�ɂ���I�u�W�F�N�g��collider���擾����B
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb)
            {
                // �����̔���
                rb.AddExplosionForce(power, collision.transform.position, radius, 1.0f, ForceMode.VelocityChange);
            }
        }

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
