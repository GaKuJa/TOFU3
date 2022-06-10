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
    public float ShotSpeed;         //弾速
    public float Interval;          //連射速度（を変えられるようにしただけ）
    public int ShotCountNow = 20;   //現在の弾薬数
    public int ShotMax = 20;        //１マガジンの弾数
    public int ShotBullet = 40;     //銃の全弾数
    public float _forcePower;       //吹き飛ばす強さ
    public float ShotDamage = 33;   //ダメージ


    private float ShotInterval;     //連射速度

    private Vector3 randomVec;

    //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

    float rndx;
    float rndy;
    float rndz;

    private List<int> shotgun = new List<int>();


    private Vector3 RandomBullet()
    {
        // transformを取得
        //Transform myTransform = this.transform;

        //Vector3 localPos = myTransform.localPosition;
        float rndx = Random.Range(-5.0f, 5.0f);
        float rndy = Random.Range(-5.0f, 5.0f);
        float rndz = Random.Range(10.0f,11.0f);

        //myTransform.localPosition = localPos; // ローカル座標での座標を設定

        randomVec = new Vector3(rndx, rndy, rndz * ShotSpeed);


        //Vector3 localrandomVec = Player.transform.InverseTransformPoint(randomVec);
        //return localrandomVec;

        return randomVec;

    }



    private void ShotPrefab()//弾の発射
    {

        ShotInterval += 1;

        if (ShotInterval % Interval == 0 && ShotCountNow > 0)
        {
            ShotCountNow -= 1;
            Debug.Log(RandomBullet());
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position,transform.rotation);// Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0)
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(RandomBullet());

            
            //3秒後に出した弾を消す
            Destroy(bullet, 3.0f);


        }
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

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //発射角度
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