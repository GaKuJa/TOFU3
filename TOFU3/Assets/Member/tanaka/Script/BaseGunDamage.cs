using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunDamage : MonoBehaviour
{
    public void Damage(int damage,int playerhp)
    {
        //�󂯎�����_���[�W��HP�����炷
        playerhp -= damage;

    }

}
