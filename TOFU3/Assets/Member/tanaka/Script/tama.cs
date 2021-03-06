using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class tama : MonoBehaviour
{
    //[SerializeField]
    //private GameObject Player;
    [SerializeField]
    private float _forcePower;

    private Vector3 GetAngleVec()
    {
        //発射角度
        //Vector3 fromVec = new Vector3(StartObject.transform.position.x, StartObject.transform.position.y, StartObject.transform.position.z);
        //Vector3 toVec = new Vector3(EndObject.transform.position.x, EndObject.transform.position.y, EndObject.transform.position.z);

        return this.transform.forward;
    }

    private void OnTriggerEnter(Collider _collider)
    {
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
    }


}
