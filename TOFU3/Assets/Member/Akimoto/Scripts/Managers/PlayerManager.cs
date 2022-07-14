using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player = null;
    
    [SerializeField]
    private GameObject playerGameObject;
    [SerializeField]
    private CameraControl cameraControl = null;
    public ReactiveProperty<PlayerStatus> _reactiveProperty = new ReactiveProperty<PlayerStatus>();
    private void Update()
    {
        _reactiveProperty.Where(pSt => player.playerStatus == Player.PlayerStatus.Dead).
                          Subscribe(playerRes => cameraControl.CameraFadeOut(player.PlayerReSpawn,player.PlayerReset));
        _reactiveProperty.Where(_ => player.playerStatus == BasePlayer.PlayerStatus.Alive).Subscribe(_ => cameraControl.ActionFadeIn());
    }

}
