using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ShotGunScript : BaseGunStatus,IBaseBun
{
    [SerializeField]
    private int pelletNum = 0;
    // 弾ゲームオブジェクト
    [SerializeField]
    private GameObject bulletGameObject;

    [SerializeField]
    private GameObject gunGameObject,parentGameObject;
    // 弾が飛ぶ方向のリスト
    [SerializeField]
    private List<Vector3> shotVecList = new List<Vector3>();

    private List<Rigidbody> bulletList = new List<Rigidbody>();
    private int             shotCount  = 0;

    private void Start()
    {
        bulletList = CreatBulletList();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotCount++;
            BulletShot(bulletList[shotCount],BulletShotCalculation(shotVecList[shotCount]));
        }
    }

    public List<Rigidbody> CreatBulletList()
    {
        List<Rigidbody> bulletList = new List<Rigidbody>();
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(bulletGameObject,gunGameObject.transform.forward,Quaternion.identity, parentGameObject.transform);
            bullet.SetActive(false);
            bulletList.Add(bullet.GetComponent<Rigidbody>());
            
        }
        return bulletList;
    }

    public Vector3         BulletShotCalculation(Vector3 shotVec)
    {
        return parentGameObject.transform.forward;
    }

    public void            BulletShot(Rigidbody bullet, Vector3 shotVec)
    {
        bullet.gameObject.SetActive(true);
        bullet.AddForce(shotVec,ForceMode.Impulse);
        //StartCoroutine(BulletDestry(bullet));
    }

    IEnumerable BulletDestry(Rigidbody bullet)
    {
        yield return new WaitForSeconds(3.0f);
        bullet.gameObject.SetActive(false);
        bullet.transform.position = gunGameObject.transform.forward;
    }
}
