using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
    public float Hp { get; set; }   // HP
    public int remain { get; set; } // 残機


    public enum DeadorAlive
    {
        Alive,
        Death
    }

    public DeadorAlive deedorAlive { get; set; }
}