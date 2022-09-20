using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Player playerStatus = null;

    [SerializeField]
    private BaseGunStatus gunStatus = null;

    [SerializeField]
    private BattleSceneManager battleSceneManager = null;

    [SerializeField]
    private UIControl uIControl = null;

    private void Update()
    {
        uIControl.HPDisplay(playerStatus.GetHp());
        uIControl.PlayerCountDisplay(battleSceneManager.playersStatList.Count);
        uIControl.RemamingDisplay(playerStatus.remainingLives);
        uIControl.ShotBulletDisplay(gunStatus.bulletNum);
        uIControl.TimeDisplay(battleSceneManager.GameTimeMinutes);
    }
}
