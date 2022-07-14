using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    protected void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.SetPlayerNum(playerNum);
    }
}
