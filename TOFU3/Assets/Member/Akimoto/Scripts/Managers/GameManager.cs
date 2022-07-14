using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }

    static GameManager _instance;
    // プレイヤーのリスト
    [SerializeField]
    private List<GameObject> playersList = new List<GameObject>();

    [SerializeField]
    private Util util = null;
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
    }
    

    public void SetPlayerNum(int player)
    {
        playerNum = player - 1;
        playersStatList[playerNum].SetHp(util.OnDamage(playersStatList[playerNum].GetHp(), 30));
    }
}
