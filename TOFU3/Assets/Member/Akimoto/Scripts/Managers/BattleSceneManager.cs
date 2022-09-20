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
    public float GameTimeMinutes { get; private set; } = 4;
    public float GameTimeSeconds { get; private set; } = 60;
    // プレイヤーのステータスリスト
    public List<Player> playersStatList { get; private set; } = new List<Player>();
    [SerializeField]
    private List<PlayerManager.PlayerGameStatus> playerManagerList = new List<PlayerManager.PlayerGameStatus>();
    public SceneMode sceneMode = SceneMode.Standby;
    public Action ActionGameStart = new Action(() => { });
    // 当たった側のプレイヤー番号
    private int          hitPlayerNum       = 0;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GameManager.Instance.sceneList = GameManager.SceneList.BattuleScene;
        ActionGameStart = ChangeSceneModeStart;
        for (int i = 0; i < playersList.Count; i++)
            playersStatList.Add(playersList[i].GetComponent<Player>());
        for (int i = 0; i < managerList.Count; i++)
            playerManagerList.Add(managerList[i].playerGameStatus);
    }
    private void Update()
    { 
        switch(sceneMode)
        {
            case SceneMode.Standby:
                WaitTimeStart();
                break;
            case SceneMode.Start:
                GamePlaying();
                break;
            case SceneMode.End:
                ChangeResultScene();
                break;
            default:
                break;
        }
    }
    private void WaitTimeStart()
    {
        GameStartWaitTime -= Time.deltaTime;
        if(GameStartWaitTime < 1)
        {
            ChangeSceneModeStart();
        }
    }
    private void GamePlaying()
    {
        GameTimeSeconds -= Time.deltaTime;
        if (GameTimeSeconds <= 1)
        {
            GameTimeMinutes--;
            GameTimeSeconds = 60;
        }
        if (testHotWaterScript.PlayerFieldOutFlag)
        {
            playersStatList[testHotWaterScript.playerNum - 1].PlayerIsDead();
            testHotWaterScript.PlayerFieldOutFlag = false;
        }
        // プレイヤーが亡くなったらリストから外す
        if (playerManagerList.Contains(PlayerManager.PlayerGameStatus.GameOver))
        {
            playerManagerList.Remove(PlayerManager.PlayerGameStatus.GameOver);
        }
        // バトル終了条件
        if (playerManagerList.Count <= 1 || GameTimeMinutes < 0)
            ChangeSceneModeEnd();
    }
    private void ChangeSceneModeStart()
    {
        sceneMode = SceneMode.Start;
    }
    private void ChangeSceneModeEnd()
    {
        sceneMode = SceneMode.End;
    }
    public void SetPlayerNum(int player)
    {
        hitPlayerNum = player - 1;
        playersStatList[hitPlayerNum].SetHp(util.OnDamage(playersStatList[hitPlayerNum].GetHp(), 30));
    }
    private void ChangeResultScene()
    {
        
        SceneManager.LoadScene(GameManager.SceneList.ResulutScene.ToString());
    }
    public void SetGameStatus(int listNum,PlayerManager.PlayerGameStatus pStat)
    {
        playerManagerList[listNum] = pStat;
    }
}