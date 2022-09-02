using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathStatus : MonoBehaviour
{
    public static PlayerDeathStatus Instance { get => _instance; }
    static PlayerDeathStatus _instance;

    public enum PlayerDeath
    {
        alive,
        death
    }

    public PlayerDeath playerstatus { set; get; }

    private void Awake()
    {
        _instance = this;
        if(_instance = null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
