using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunDamage : MonoBehaviour
{
    public void Damage(int damage,int playerhp)
    {
        //受け取ったダメージ分HPを減らす
        playerhp -= damage;

    }

}
