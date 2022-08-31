using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class tama : MonoBehaviour
{
    [SerializeField]
    private float knockBack;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {

            Rigidbody otherRigitbody = other.GetComponentInParent<Rigidbody>();

            // 自分の位置と接触してきたオブジェクトの位置とを計算して、距離と方向を出して正規化
            Vector3 distination = (other.transform.position - transform.position).normalized;
            //Debug.Log(otherRigitbody.transform.position);
            //Debug.Log(transform.position);
            otherRigitbody.AddForce(-distination * knockBack, ForceMode.Impulse); //当たった物体
            //Debug.Log("hukitobi");
            //return;

        }

    }
    
}

/*private Vector3 GetAngleVec()
    {
        発射角度
        Vector3 fromVec = new Vector3(StartObject.transform.position.x, StartObject.transform.position.y, StartObject.transform.position.z);
        Vector3 toVec = new Vector3(EndObject.transform.position.x, EndObject.transform.position.y, EndObject.transform.position.z);

        return this.transform.forward;
    }

    private void OnTriggerEnter(Collider _collider)
    {
        /*
        //ぶつかった相手からRigitBodyを取り出す
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();//tag つける
        if (!otherRigitbody)
        {
            return;
        }

        //吹き飛ぶ方向を求める(銃弾の方向)
        Vector3 toVec = GetAngleVec();

        //吹き飛ぶ
        otherRigitbody.AddForce(GetAngleVec() * _forcePower, ForceMode.Impulse);

        Debug.Log(GetAngleVec());
        //Player.SetHp(BulletDamege());
        
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
    */