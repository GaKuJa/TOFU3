using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


//main
public class SHOYUGUN : BaseGunStatus, IBaseBulletDamege
{
    public static SHOYUGUN Instance { get => _instance; }
    static SHOYUGUN _instance;
    // ゲームオブジェクトプレハブ
    [SerializeField]
    private GameObject BulletPrefab;
    // 銃ゲームオブジェクト
    [SerializeField]
    private Transform Gun;
    private float plusShootInterval = 0;
    private int shootCount;
    private bool shootingFlag = false;
    [SerializeField]
    private float _forcePower;
    [SerializeField]
    private float waittime;

    void Awake()
    {
        _instance = this;
    }
    void Start()
    {

        plusShootInterval = shootIntervalTime;

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ShotPrefab();
            shootingFlag = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && magazinNum != 0)
            StartCoroutine("ReloadBullet");
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

    private void ShotPrefab() //�e�̔���
    {
        if (plusShootInterval >= shootIntervalTime && bulletNum > 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(RandomBullet());
            Destroy(bullet, 3.0f);
            plusShootInterval = 0;
            PullMagazin();
        }
    }

    private Vector3 RandomBullet()
    {
        float randomX = Random.Range(reticleSize, -reticleSize);
        float randomY = Random.Range(reticleSize, -reticleSize);
        return Gun.forward * bulletShotSpeed + new Vector3(randomX, randomY, 0);
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
