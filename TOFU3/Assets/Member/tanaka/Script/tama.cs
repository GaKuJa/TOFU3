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

            // �����̈ʒu�ƐڐG���Ă����I�u�W�F�N�g�̈ʒu�Ƃ��v�Z���āA�����ƕ������o���Đ��K��
            Vector3 distination = (other.transform.position - transform.position).normalized;
            //Debug.Log(otherRigitbody.transform.position);
            //Debug.Log(transform.position);
            otherRigitbody.AddForce(-distination * knockBack, ForceMode.Impulse); //������������
            //Debug.Log("hukitobi");
            //return;

        }

    }
    
}

/*private Vector3 GetAngleVec()
    {
        ���ˊp�x
        Vector3 fromVec = new Vector3(StartObject.transform.position.x, StartObject.transform.position.y, StartObject.transform.position.z);
        Vector3 toVec = new Vector3(EndObject.transform.position.x, EndObject.transform.position.y, EndObject.transform.position.z);

        return this.transform.forward;
    }

    private void OnTriggerEnter(Collider _collider)
    {
        /*
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
        
        //�Ԃ��������肩��RigitBody�����o��
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
        if (!otherRigitbody)
        {
            return;
        }

        //������΂����������߂�(�v���C���[����G�ꂽ���̂̕���)
        Vector3 toVec = GetAngleVec(BulletPrefab, _collider.gameObject);

        //�������
        otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);
    }
    */