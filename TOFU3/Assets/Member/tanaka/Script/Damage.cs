using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private GunSt gunst;

    public int damage;          //当たった部位毎のダメージ量
    private GameObject enemy;   //敵オブジェクト
    private Enemy hp;              //HPクラス
 
    void Start()
    {
        enemy = GameObject.Find("Enemy");   //敵情報を取得
        hp = enemy.GetComponent<Enemy>();      //HP情報を取得
    }
 
    void OnTriggerEnter(Collider other){
 
        //ぶつかったオブジェクトのTagにShellという名前が書いてあったならば（条件）.
        if (other.CompareTag("Shell")){
 
            //HPクラスのDamage関数を呼び出す
            hp.Damage(gunst.GetGunDamage());
 
            //ぶつかってきたオブジェクトを破壊する.
            Destroy(other.gameObject);
        }
    }
}
