using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//?A?T???g???C?t??
public class SHOYOUGUN : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField]
    private GameObject Player;
    private GameObject Shooting;
    public float ShotSpeed;         //�e��
    public float Interval;          //�A�ˑ��x�i��ς�����悤�ɂ��������j
    public int ShotCountNow = 20;   //���݂̒e��
    public int ShotMax = 20;        //�P�}�K�W���̒e��
    public int ShotBullet = 40;     //�e�̑S�e��
    public float _forcePower;       //������΂�����
    public float ShotDamage = 33;   //�_���[�W


    private float ShotInterval;     //�A�ˑ��x

    private Vector3 randomVec;

    //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

    float rndx;
    float rndy;
    float rndz;

    private List<int> shotgun = new List<int>();


    private Vector3 RandomBullet()
    {
        // transform���擾
        //Transform myTransform = this.transform;

        //Vector3 localPos = myTransform.localPosition;
        float rndx = Random.Range(-5.0f, 5.0f);
        float rndy = Random.Range(-5.0f, 5.0f);
        float rndz = Random.Range(10.0f,11.0f);

        //myTransform.localPosition = localPos; // ���[�J�����W�ł̍��W��ݒ�

        randomVec = new Vector3(rndx, rndy, rndz * ShotSpeed);


        //Vector3 localrandomVec = Player.transform.InverseTransformPoint(randomVec);
        //return localrandomVec;

        return randomVec;

    }



    private void ShotPrefab()//�e�̔���
    {

        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            ShotCountNow -= 1;
            Debug.Log(RandomBullet());
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position,transform.rotation);// Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0)
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(RandomBullet());

            
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