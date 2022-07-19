using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    public static BattleSceneManager Instance { get => _instance; }
    static BattleSceneManager _instance;
    public enum SceneMode
    {
        Standby,
        Start,
        End,
    }
    // プレイヤーのリスト
    [SerializeField]
    private List<GameObject> playersList = new List<GameObject>();
    [SerializeField]
    private List<PlayerManager> managerList = new List<PlayerManager>();
    [SerializeField]
    private TestHotWaterScript testHotWaterScript = null;
    [SerializeField]
    private Util util = null;
    public float GameStartWaitTime { get; private set; } = 4; 
    // プレイヤーのステータスリスト
    private List<Player> playersStatList = new List<Player>();
    private List<PlayerManager.PlayerGameStatus> playerManagerList = new List<PlayerManager.PlayerGameStatus>();
    public SceneMode sceneMode = SceneMode.Standby;
    public Action ActionGameStart = new Action(() => { });
    private int          playerNum       = 0;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        ActionGameStart = GameStart;
        for (int i = 0; i < playersList.Count; i++)
        {
            playersStatList.Add(playersList[i].GetComponent<Player>());
        }
        for (int i = 0; i < managerList.Count; i++)
            playerManagerList.Add(managerList[i].playerGameStatus);
    }
    private void Update()
    { 
        switch(sceneMode)
        {
            case SceneMode.Standby:
                GameStartWaitTime -= Time.deltaTime;
                break;
            case SceneMode.Start:
                GamePlay();
                break;
            case SceneMode.End:
                ChangeResultScene();
                break;
            default:
                break;
        }
    }
    private void GamePlay()
    {
        if (testHotWaterScript.PlayerFieldOutFlag)
        {
            playersStatList[testHotWaterScript.playerNum - 1].PlayerIsDead();
            testHotWaterScript.PlayerFieldOutFlag = false;
        }
        if (playerManagerList.Contains(PlayerManager.PlayerGameStatus.GameOver))
            playerManagerList.Remove(PlayerManager.PlayerGameStatus.GameOver);
        if (playerManagerList.Count <= 1)
            ChangeSceneMode();
    }
    private void GameStart()
    {
        sceneMode = SceneMode.Start;
    }
    private void ChangeSceneMode()
    {
        sceneMode = SceneMode.End;
    }

    public void SetPlayerNum(int player)
    {
        playerNum = player - 1;
        playersStatList[playerNum].SetHp(util.OnDamage(playersStatList[playerNum].GetHp(), 30));
    }
    private void ChangeResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
    public void SetGameStatus(int listNum,PlayerManager.PlayerGameStatus pStat)
    {
        playerManagerList[listNum] = pStat;
    }
}