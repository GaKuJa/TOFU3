using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Player> playerList = new List<Player>();
    [SerializeField]
    private FadeControl fadeControl = null;
    [SerializeField]
    private BattleSceneManager battleSceneManager = null;
    [SerializeField]
    private TextControl textControl = null;
    void Update()
    {
        switch(battleSceneManager.sceneMode)
        {
            case BattleSceneManager.SceneMode.Standby:
                fadeControl.GameStartFadeIn(battleSceneManager.ActionGameStart,battleSceneManager.GameStartWaitTime);
                textControl.FadeTimeToString((int)battleSceneManager.GameStartWaitTime);
                break;
            case BattleSceneManager.SceneMode.Start:
                textControl.FadeTimeTextOut();
                textControl.GameTimerDisplay((int)battleSceneManager.GameTimeMinutes, (int)battleSceneManager.GameTimeSeconds);
                textControl.PlayerStockDisplay(battleSceneManager.playersStatList[0].remainingLives, battleSceneManager.playersStatList[1].remainingLives);
                textControl.HpDisPlay(battleSceneManager.playersStatList[0].GetHp(), battleSceneManager.playersStatList[1].GetHp());
                break;
            case BattleSceneManager.SceneMode.End:
                break;
            default:
                break;
        }
    }
}
