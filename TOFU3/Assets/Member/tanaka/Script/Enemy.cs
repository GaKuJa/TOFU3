using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GunSt gunst;

    public int hitPoint = 100;  //HP

    // Update is called once per frame
    void Update()
    {
        //HP��0�ɂȂ����Ƃ��ɓG��j�󂷂�
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }

    }

    //�_���[�W���󂯎����HP�����炷�֐�
    public void Damage(int damage)
    {
        //�󂯎�����_���[�W��HP�����炷
        hitPoint -= damage;
    }
}
