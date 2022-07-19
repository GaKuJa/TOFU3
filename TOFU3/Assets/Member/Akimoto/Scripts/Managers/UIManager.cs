using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Player> playerList = new List<Player>();
    [SerializeField]
    private List<Text> textList = new List<Text>();
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
                break;
            case BattleSceneManager.SceneMode.End:
                break;
            default:
                break;
        }
        textList[0].text = playerList[0].GetHp().ToString();
        textList[1].text = playerList[1].GetHp().ToString();
    }
}
