using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }
    static GameManager _instance;

    // シーンのリスト
    public enum SceneList
    {
        TitleScene = 1,
        MatchingScene = 2,
        BattuleScene = 3,
        ResulutScene = 4,
    }

    public SceneList sceneList { get; set; } = SceneList.MatchingScene;

    public static int matchingPlayerNum = 0;

    public static int winPlayerNum = 0;

    private void Awake()
    {
        _instance = this;
    }

    public int GetMatchingNum()
    {
        return matchingPlayerNum;
    }

    public void SetMatchingNum(int matchingNum)
    {
        matchingPlayerNum = matchingNum;
    }

    public int GetWinPlayerNum()
    {
        return winPlayerNum;
    }

    public void SetWinPlayerNum(int winPlayer)
    {
        winPlayerNum = winPlayer;
    }
}
