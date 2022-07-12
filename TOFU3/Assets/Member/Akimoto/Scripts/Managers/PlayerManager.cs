using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player = null;

    [SerializeField]
    private CameraControl _cameraControl;

    [SerializeField]
    private GameObject playerGameObject;
    public ReactiveProperty<PlayerStatus> _reactiveProperty = new ReactiveProperty<PlayerStatus>();
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            player.SetPlayerStatus(Player.PlayerStatus.dead);
        _reactiveProperty.Where(pSt => player.playerStatus == Player.PlayerStatus.dead).Subscribe(playerRes => player.PlayerReSpawn(playerGameObject));
    }

}
