using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHotWaterScript : MonoBehaviour
{
    public bool PlayerFieldOutFlag { get; set; } = false;
    public int playerNum { get; private set; } = 0;
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            PlayerFieldOutFlag = true;
            GameObject player = collision.gameObject;
            Player playerStatus = player.GetComponent<Player>();
            playerNum = playerStatus.playerNum;
        }
    }
}
