using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathStatus : MonoBehaviour
{
    public static PlayerDeathStatus Instance { get => _instance; }
    static PlayerDeathStatus _instance;

    public enum Playerstatus
    {
        alive,
        death
    }

    public Playerstatus playerstatus { set; get; }

    private void Awake()
    {
        _instance = this;
    }
}
