using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//
//shotgun
public class SESAMIGUN : BaseGunStatus, IBaseBulletDamege
{
    public static SESAMIGUN Instance { get => _instance; }
    static SESAMIGUN _instance;
    // ゲームオブジェクトプレハブ
    [SerializeField]
    private GameObject BulletPrefab;
    // 銃ゲームオブジェクト
    [SerializeField]
    private Transform Gun;
    private float plusShootInterval = 0;
    private int shootCount;
    private bool shootingFlag = false;
    private float _forcePower;
    [SerializeField]
    private float waittime;
    void Awake()
    {
        _instance = this;
    }

    //private List<型名> 変数名 = new List<型名>();
    [SerializeField]
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
    private void Start()
    {
        plusShootInterval = shootIntervalTime;
        for (int i = 0; i < Bullet.Count; i++)
        {
            Debug.Log(Bullet[i]);
        }

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ShotPrefab();
            shootingFlag = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && magazinNum != 0)
            ReloadBullet();
        if (shootingFlag)
            IntervalControl();
    }

    IEnumerator ReloadBullet()
    {
        yield return new WaitForSeconds(waittime);
        magazinNum -= shootCount;
        bulletNum += shootCount;
        shootCount = 0;
    }

    private Vector3 RandomBullet1()
    {
        return Gun.forward * bulletShotSpeed + new Vector3(0.0f, 5.0f, 100f);
    }

    private Vector3 RandomBullet2()
    {
        return Gun.forward * bulletShotSpeed + new Vector3(5.0f, 5.0f, 100f);
    }


    private void ShotPrefab() //�e�̔���
    {
        if (plusShootInterval >= shootIntervalTime && bulletNum > 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(RandomBullet1());
            bulletRigidbody.AddForce(RandomBullet2());
            Destroy(bullet, 3.0f);
            plusShootInterval = 0;
            PullMagazin();
        }
    }
    

    private void PullMagazin()
    {
        shootCount++;
        bulletNum -= 1;
    }

    private void IntervalControl()
    {
        plusShootInterval += Time.deltaTime;
    }

    public int GetMaxMagazinNum()
    {
        return magazinNum;
    }

    public int GetMaxBulletNum()
    {
        return bulletNum;
    }

    public int BulletDamege(int playerHp, int bulletDamege)
    {

        return playerHp -= bulletDamege;

    }
    
}