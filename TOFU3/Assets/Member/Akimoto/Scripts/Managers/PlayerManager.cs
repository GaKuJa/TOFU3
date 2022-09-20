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
    [SerializeField]
    public PlayerGameStatus playerGameStatus = PlayerGameStatus.GamePlay;
    private void Update()
    {
        if (GameManager.Instance.sceneList == GameManager.SceneList.BattuleScene)
        {
            // ���񂾂烊�X�|�[��
            _reactiveProperty.Where(pSt => player.playerStatus == Player.PlayerStatus.Dead).
                              Subscribe(playerRes => cameraControl.CameraFadeOut(player.PlayerReSpawn, player.PlayerReset));
            
            // ���X�|�[����ɃJ�������t�F�[�h�C��
            _reactiveProperty.Where(_ => player.playerStatus == Player.PlayerStatus.Alive).Subscribe(_ => cameraControl.ActionFadeIn());
            
            // �c�@���S���Ȃ�����Q�[������ޏo
            _reactiveProperty.Where(_ => player.remainingLives <= 0 && playerGameStatus != PlayerGameStatus.GameOver)
                             .Subscribe(_ => PlayerGameOver());
        }
    }
    private void PlayerGameOver()
    {
        playerGameStatus = PlayerGameStatus.GameOver;
        BattleSceneManager.Instance.SetGameStatus(player.playerNum - 1, playerGameStatus);
    }

}
