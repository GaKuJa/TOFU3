using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerDeath : MonoBehaviour
{
    public enum Playerstatus
    {
        alive,
        death
    }

    [SerializeField]

    public Playerstatus playerstatus { set; get; }
}
