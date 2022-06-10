using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//shotgun
public class SESAMIGUN : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotSpeed;         //’e‘¬
    public float Interval;          //˜AË‘¬“xi‚ğ•Ï‚¦‚ç‚ê‚é‚æ‚¤‚É‚µ‚½‚¾‚¯j
    public int ShotCountNow = 2;   //Œ»İ‚Ì’e–ò”
    public int ShotMax = 2;        //‚Pƒ}ƒKƒWƒ“‚Ì’e”
    public int ShotBullet = 6;     //e‚Ì‘S’e”
    public float _forcePower;       //‚«”ò‚Î‚·‹­‚³
    public float ShotDamage;        //ƒ_ƒ[ƒW

    private float ShotInterval;     //˜AË‘¬“x

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

    //private List<Œ^–¼> •Ï”–¼ = new List<Œ^–¼>();

    private void Start()
    {
        randomVec = new Vector3(rndx, rndy, rndz * ShotSpeed);
    }


    private void ShotPrefab()//’e‚Ì”­Ë
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

            //3•bŒã‚Éo‚µ‚½’e‚ğÁ‚·
            Destroy(bullet, 3.0f);
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {

        //‚Ô‚Â‚©‚Á‚½‘Šè‚©‚çRigitBody‚ğæ‚èo‚·
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
        if (!otherRigitbody)
        {
            return;
        }

        //‚«”ò‚Î‚·•ûŒü‚ğ‹‚ß‚é(ƒvƒŒƒCƒ„[‚©‚çG‚ê‚½‚à‚Ì‚Ì•ûŒü)
        Vector3 toVec = GetAngleVec(BulletPrefab, _collider.gameObject);

        //‚«”ò‚Ô
        otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);


    }


    private void ShotBulletDamage()
    {

    }

    private void ShotNothing()//ƒŠƒ[ƒh
    {

        int reload = ShotMax - ShotCountNow;

        //’e‚ªc‚Á‚Ä‚é‚Æ‚«
        if (ShotBullet >= reload)
        {
            ShotCountNow += reload;
            ShotBullet -= reload;

        }
        //‚È‚¢‚Æ‚«
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
        //”­ËŠp“x
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