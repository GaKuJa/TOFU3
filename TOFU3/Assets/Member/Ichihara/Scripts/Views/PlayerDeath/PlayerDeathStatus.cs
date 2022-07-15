using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathStatus : MonoBehaviour
{
    public static PlayerDeathStatus instance;

    public enum Playerstatus
    {
        alive,
        death
    }

    public Playerstatus playerstatus { set; get; }

    private void Awake()
    {
        if(instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
