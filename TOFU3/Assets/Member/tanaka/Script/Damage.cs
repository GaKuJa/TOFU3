using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private GunSt gunst;

    public int damage;          //�����������ʖ��̃_���[�W��
    private GameObject enemy;   //�G�I�u�W�F�N�g
    private Enemy hp;              //HP�N���X
 
    void Start()
    {
        enemy = GameObject.Find("Enemy");   //�G�����擾
        hp = enemy.GetComponent<Enemy>();      //HP�����擾
    }
 
    void OnTriggerEnter(Collider other){
 
        //�Ԃ������I�u�W�F�N�g��Tag��Shell�Ƃ������O�������Ă������Ȃ�΁i�����j.
        if (other.CompareTag("Shell")){
 
            //HP�N���X��Damage�֐����Ăяo��
            hp.Damage(gunst.GetGunDamage());
 
            //�Ԃ����Ă����I�u�W�F�N�g��j�󂷂�.
            Destroy(other.gameObject);
        }
    }
}
