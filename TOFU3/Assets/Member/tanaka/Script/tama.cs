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
        //���ˊp�x
        //Vector3 fromVec = new Vector3(StartObject.transform.position.x, StartObject.transform.position.y, StartObject.transform.position.z);
        //Vector3 toVec = new Vector3(EndObject.transform.position.x, EndObject.transform.position.y, EndObject.transform.position.z);

        return this.transform.forward;
    }

    private void OnTriggerEnter(Collider _collider)
    {
        //�Ԃ��������肩��RigitBody�����o��
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();//tag ����
        if (!otherRigitbody)
        {
            return;
        }

        //������ԕ��������߂�(�e�e�̕���)
        Vector3 toVec = GetAngleVec();

        //�������
        otherRigitbody.AddForce(GetAngleVec() * _forcePower, ForceMode.Impulse);

        Debug.Log(GetAngleVec());
        //Player.SetHp(BulletDamege());
    }


}
