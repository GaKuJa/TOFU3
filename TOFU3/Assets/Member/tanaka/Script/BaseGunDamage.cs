using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunDamage : MonoBehaviour
{
    public void Damage(int damage,int playerhp)
    {
        //ó‚¯æ‚Á‚½ƒ_ƒ[ƒW•ªHP‚ğŒ¸‚ç‚·
        playerhp -= damage;

    }

}
