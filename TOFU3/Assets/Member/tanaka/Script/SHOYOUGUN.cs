using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private float _forcePower;
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

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //発射角度
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(0, 0, 0);

        return Vector3.Normalize(toVec);
    }

    private void OnTriggerEnter(Collider _collider)
    {

        //ぶつかった相手からRigitBodyを取り出す
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
        if (!otherRigitbody)
        {
            return;
        }

        //吹き飛ばす方向を求める(プレイヤーから触れたものの方向)
        Vector3 toVec = GetAngleVec(BulletPrefab, _collider.gameObject);

        //吹き飛ぶ
        otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);

        //Player.SetHp(BulletDamege());
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