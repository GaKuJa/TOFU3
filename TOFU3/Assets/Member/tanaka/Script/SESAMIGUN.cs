using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//?A?T???g???C?t??
public class SESAMIGUN : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotSpeed;         //íeë¨
    public float Interval;          //òAéÀë¨ìxÅiÇïœÇ¶ÇÁÇÍÇÈÇÊÇ§Ç…ÇµÇΩÇæÇØÅj
    public int ShotCountNow = 2;   //åªç›ÇÃíeñÚêî
    public int ShotMax = 2;        //ÇPÉ}ÉKÉWÉìÇÃíeêî
    public int ShotBullet = 6;     //èeÇÃëSíeêî
    public float _forcePower;       //êÅÇ´îÚÇŒÇ∑ã≠Ç≥
    public float ShotDamage;        //É_ÉÅÅ[ÉW

    private float ShotInterval;     //òAéÀë¨ìx

    float rndx;
    float rndy;
    float rndz;

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


    private void ShotPrefab()//íeÇÃî≠éÀ
    {


        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            ShotCountNow -= 1;
            
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //Vector3 force = new Vector3(rndx, rndy, zzz);
            bulletRb.AddForce(RandomBullet() * ShotSpeed);

            Debug.Log(RandomBullet());

            //3ïbå„Ç…èoÇµÇΩíeÇè¡Ç∑
            Destroy(bullet, 3.0f);
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {

        //Ç‘Ç¬Ç©Ç¡ÇΩëäéËÇ©ÇÁRigitBodyÇéÊÇËèoÇ∑
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
        if (!otherRigitbody)
        {
            return;
        }

        //êÅÇ´îÚÇŒÇ∑ï˚å¸ÇãÅÇﬂÇÈ(ÉvÉåÉCÉÑÅ[Ç©ÇÁêGÇÍÇΩÇ‡ÇÃÇÃï˚å¸)
        Vector3 toVec = GetAngleVec(BulletPrefab, _collider.gameObject);

        //êÅÇ´îÚÇ‘
        otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);


    }


    private void ShotBulletDamage()
    {

    }

    private void ShotNothing()//ÉäÉçÅ[Éh
    {

        int reload = ShotMax - ShotCountNow;

        //íeÇ™écÇ¡ÇƒÇÈÇ∆Ç´
        if (ShotBullet >= reload)
        {
            ShotCountNow += reload;
            ShotBullet -= reload;

        }
        //Ç»Ç¢Ç∆Ç´
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
        //î≠éÀäpìx
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