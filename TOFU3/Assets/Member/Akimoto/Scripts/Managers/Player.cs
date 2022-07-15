using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        GameManager.Instance.SetPlayerNum(playerNum);
    }
}
