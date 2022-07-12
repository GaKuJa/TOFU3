using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Player : BasePlayer
{
    public enum PlayerStatus
    {
        alive,
        dead,
    }
    [SerializeField]
    public PlayerStatus playerStatus;

    [SerializeField]
    private GameObject RespawnPoint;

    // private Subject<PlayerStatus>          subject           = new Subject<PlayerStatus>();
    

    public void PlayerReSpawn(GameObject playerGameObject)
    {
        Debug.Log("ReSpown");
        playerGameObject.transform.position = RespawnPoint.transform.position;
    }
    
    
    public PlayerStatus GetPlayerStatus()
    {
        
        return playerStatus;
    }
    
    public void SetPlayerStatus(PlayerStatus setPlayerSt)
    {
        playerStatus = setPlayerSt;
    }
}
