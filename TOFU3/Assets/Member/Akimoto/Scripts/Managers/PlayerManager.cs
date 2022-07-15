using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class PlayerManager : MonoBehaviour
{
    public enum PlayerGameStatus
    {
        GamePlay,
        GameOver,
    }
    [SerializeField]
    private Player player = null;
    [SerializeField]
    private GameObject playerGameObject;
    [SerializeField]
    private CameraControl cameraControl = null;
    public ReactiveProperty<PlayerStatus> _reactiveProperty = new ReactiveProperty<PlayerStatus>();
    public PlayerGameStatus playerGameStatus = PlayerGameStatus.GamePlay;
    private void Update()
    {
        _reactiveProperty.Where(pSt => player.playerStatus == Player.PlayerStatus.Dead).
                          Subscribe(playerRes => cameraControl.CameraFadeOut(player.PlayerReSpawn,player.PlayerReset));
        _reactiveProperty.Where(_ => player.playerStatus == BasePlayer.PlayerStatus.Alive).Subscribe(_ => cameraControl.ActionFadeIn());
        _reactiveProperty.Where(_ => player.remainingLives <= 0 && playerGameStatus != PlayerGameStatus.GameOver)
                         .Subscribe(_ => PlayerGameOver());
    }
    private void PlayerGameOver()
    {
        playerGameStatus = PlayerGameStatus.GameOver;
        GameManager.Instance.SetGameStatus(player.playerNum - 1, playerGameStatus);
    }

}
