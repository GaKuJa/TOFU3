using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのデス判定
/// </summary>

public class BoiledWater : MonoBehaviour
{
<<<<<<< HEAD:TOFU3/Assets/Member/Ichihara/Scripts/Views/PlayerDeath/BoiledWater.cs
    private bool _flag = false;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerDeathStatus.Instance.playerstatus = PlayerDeathStatus.Playerstatus.death;
        Debug.Log(PlayerDeathStatus.Instance.playerstatus);
=======
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
>>>>>>> main:TOFU3/Assets/Member/Ichihara/Scripts/Views/PlayerDeath/PlayerDeath.cs
    }

    private void Start()
    {
<<<<<<< HEAD:TOFU3/Assets/Member/Ichihara/Scripts/Views/PlayerDeath/BoiledWater.cs
        return PlayerDeathStatus.Instance.playerstatus;
=======
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
>>>>>>> main:TOFU3/Assets/Member/Ichihara/Scripts/Views/PlayerDeath/PlayerDeath.cs
    }
}
