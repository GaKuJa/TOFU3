using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public int OnDamage(int playerHp, int damage)
    {
        return playerHp - damage;
    }
}
