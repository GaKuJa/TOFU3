using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class MatchingSceneManager : MonoBehaviour
{
    public static MatchingSceneManager Instance { get => _instance; }
    static MatchingSceneManager _instance;

    [SerializeField]
    private List<Player> playerList = new List<Player>();

    [SerializeField]
    private UIControl uiControl = null;

    public List<bool> matchingList = new List<bool>();

    public float time = 30;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GameManager.Instance.sceneList = GameManager.SceneList.MatchingScene;
        for (int i = 0; i < playerList.Count; i++)
        {
            matchingList.Add(playerList[i].matchingFlag);
        }
    }

    private void Update()
    {
        time -= Time.deltaTime;
        uiControl.TimeDisplay((int)time);
        if (time < 1)
        {
            // マッチングしたプレイヤーのみのListを生成
            var matchingPlayers = playerList.Where(_ => _);
            // BattuleSceneのディスプレイの数をListの配列数から表示
            GameManager.Instance.SetMatchingNum(matchingPlayers.Count());
            // シーンをGameManagerのEnumから参照
            SceneManager.LoadScene(GameManager.SceneList.BattuleScene.ToString());
        }
    }

    public void SetMatchingFlag(int playerNum, bool setFlag)
    {
        matchingList[playerNum - 1] = setFlag;
    }
}
