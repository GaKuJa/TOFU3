using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ロケラン
public class B_F_T : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotSpeed;         //弾速
    public float Interval;          //連射速度（を変えられるようにしただけ）
    public int ShotCountNow = 20;   //現在の弾薬数
    public int ShotMax = 20;        //１マガジンの弾数
    public int ShotBullet = 40;     //銃の全弾数
    public float _forcePower;       //吹き飛ばす強さ
    public float ShotDamage = 100;  //ダメージ


    private float ShotInterval;     //連射速度

    // 爆風の力
    private float power = 10f;

    // 爆風が及ぶ範囲（半径）
    private float radius = 10f;

    //Vector3 origin = new Vector3(0, 0, 0); // 原点
    //Vector3 direction = new Vector3(1, 0, 0); // X軸方向を表すベクトル
    //Ray ray = new Ray(origin, direction); // Rayを生成

    private void Start()
    {
       
    }


    private void ShotPrefab()//弾の発射
    {


        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            ShotCountNow -= 1;
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //Vector3 force = new Vector3(rndx, rndy, zzz);
            bulletRb.AddForce(transform.forward * ShotSpeed);

            //3秒後に出した弾を消す

            Destroy(bullet, 3.0f);
        }
    }

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //発射角度
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(0,0,0);

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

    }

    private void OnCollisionEnter(Collision collision)
    {
        // 着弾点を爆心地にする
        Vector3 explosionPos = collision.transform.position;

        // 爆心地から『指定した半径内』にあるオブジェクトのcolliderを取得する。
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb)
            {
                // 爆風の発生
                rb.AddExplosionForce(power, collision.transform.position, radius, 1.0f, ForceMode.VelocityChange);
            }
        }

    }

    private void ShotBulletDamage()
    {

    }

    private void ShotNothing()//リロード
    {

        int reload = ShotMax - ShotCountNow;

        //弾が残ってるとき
        if (ShotBullet >= reload)
        {
            ShotCountNow += reload;
            ShotBullet -= reload;

        }
        //ないとき
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
