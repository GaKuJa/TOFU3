using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class tama : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float _forcePower;

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //���ˊp�x
        Vector3 fromVec = new Vector3(_from.transform.position.x, _from.transform.position.y, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, _to.transform.position.y, _to.transform.position.z);

        return Vector3.Normalize(toVec);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        //�Ԃ��������肩��RigitBody�����o��
        Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
        if (!otherRigitbody)
        {
            return;
        }

        //������ԕ��������߂�(�e�e�̕���)
        //Vector3 toVec = GetAngleVec(GameObject., _collider.gameObject);

        //�������
        //otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);

        //Player.SetHp(BulletDamege());
    }


}
