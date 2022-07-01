using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
//shotgun
public class SESAMIGUN : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotSpeed;         //�e��
    public float Interval;          //�A�ˑ��x�i��ς�����悤�ɂ��������j
    public int ShotCountNow = 2;   //���݂̒e��
    public int ShotMax = 2;        //�P�}�K�W���̒e��
    public int ShotBullet = 6;     //�e�̑S�e��
    public float _forcePower;       //������΂�����
    public float ShotDamage = 5;        //�_���[�W
    private float ShotInterval;     //�A�ˑ��x
    private float time = 5.0f;


    private Vector3 randomVec;

    //private List<�^��> �ϐ��� = new List<�^��>();
    List<Vector3> Bullet = new List<Vector3>();

    private void ListBullet()
    {

        Bullet.Add(new Vector3(0.0f, 5.0f, 100.0f));
        Bullet.Add(new Vector3(5.0f, 5.0f, 100.0f));
        Bullet.Add(new Vector3(-5.0f, 5.0f, 100.0f));
        Bullet.Add(new Vector3(5.0f, 0.0f, 100.0f));
        Bullet.Add(new Vector3(-5.0f, 0.0f, 100.0f));
        Bullet.Add(new Vector3(0.0f, -5.0f, 100.0f));
        Bullet.Add(new Vector3(5.0f, -5.0f, 100.0f));
        Bullet.Add(new Vector3(-5.0f, -5.0f, 100.0f));

    }


    private void ShotPrefab()//�e�̔���
    {
        

        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            ShotCountNow -= 1;
            

            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * ShotSpeed);

            //Debug.Log(RandomBullet());

            //3�b��ɏo�����e������
            Destroy(bullet, 3.0f);
        }
    }

    /*private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //���ˊp�x
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(0, 0, 0);

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
    */

    private void ShotBulletDamage()
    {

    }

    private void ShotNothing()//�����[�h
    {
        time -= Time.deltaTime;
        if (time <= 0)
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