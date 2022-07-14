using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOYUGUNScript2 : BaseGunStatus
{
    public static SHOYUGUNScript2 Instance { get => _instance; }
    static SHOYUGUNScript2 _instance;
    // ゲームオブジェクトプレハブ
    [SerializeField]
    private GameObject BulletPrefab;
    // 銃ゲームオブジェクト
    [SerializeField]
    private Transform Gun;
    private float plusShootInterval = 0;
    private int shootCount;
    private bool shootingFlag = false;
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

        if (Input.GetAxis("L_R_Trigger2") < 0)
        {
            ShotPrefab();
            shootingFlag = true;
        }
        if (Input.GetKeyDown("joystick 2 button 2") && magazinNum != 0)
            ReloadBullet();
        if (shootingFlag)
            IntervalControl();
    }

    private void ReloadBullet()
    {
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

}
