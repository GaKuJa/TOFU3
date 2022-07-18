using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }
    static GameManager _instance;
    // プレイヤーのリスト
    [SerializeField]
    private List<GameObject> playersList = new List<GameObject>();
    [SerializeField]
    private Util util = null;
    [SerializeField]
    private List<PlayerManager> managerList = new List<PlayerManager>();
    [SerializeField]
    private  List<PlayerManager.PlayerGameStatus> playerManagerList = new List<PlayerManager.PlayerGameStatus>();
    [SerializeField]
    private TestHotWaterScript testHotWaterScript = null;
    // プレイヤーのステータスリスト
    private List<Player> playersStatList = new List<Player>();
    private int          playerNum       = 0;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < playersList.Count; i++)
        {
            playersStatList.Add(playersList[i].GetComponent<Player>());
        }
        for (int i = 0; i < managerList.Count; i++)
            playerManagerList.Add(managerList[i].playerGameStatus);
    }
    private void Update()
    {
        if (playerManagerList.Contains(PlayerManager.PlayerGameStatus.GameOver))
            playerManagerList.Remove(PlayerManager.PlayerGameStatus.GameOver);
        if (playerManagerList.Count <= 1)
            ChangeResultScene();
        if(testHotWaterScript.PlayerFieldOutFlag)
        {
            playersStatList[testHotWaterScript.playerNum-1].PlayerIsDead();
            testHotWaterScript.PlayerFieldOutFlag = false;
        }
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
