using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのデス判定
/// </summary>

public class PlayerDeath : MonoBehaviour
{
    //各プレイヤーの参照
    private TestPlayer1Controler _player1;
    private TestPlayer2Controler _player2;
    //private GameObject _player3;
    //private GameObject _player4;

    private PlayerStatus _cs_palyerStatus = null;

    private bool _fieldOut1 = false;
    private bool _fieldOut2 = false;
    private bool _fieldOut3 = false;
    private bool _fieldOut4 = false;

    public enum playerNumber
    {
        player1,
        player2,
        player3,
        player4            
    }

    private void Start()
    {
        _player1 = GetComponent<TestPlayer1Controler>();
        _player2 = GetComponent<TestPlayer2Controler>();
        _cs_palyerStatus = GetComponent<PlayerStatus>();
    }

    private void OnCollisionEnter(Collision other)
    {
        _cs_palyerStatus.deedorAlive = PlayerStatus.DeadorAlive.Death;
        Debug.Log(_cs_palyerStatus.deedorAlive);
    }

    public PlayerStatus.DeadorAlive GetPlayerDeath()
    {
        return _cs_palyerStatus.deedorAlive;
    }
}
