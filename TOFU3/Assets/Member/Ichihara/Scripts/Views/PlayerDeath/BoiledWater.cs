using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのデス判定
/// </summary>

public class BoiledWater : MonoBehaviour
{
    //必要な機能の参照元
    private Player _cs_player;
    //取得したプレイヤーの番号を格納
    private int _playerNum = default(int);

    [System.NonSerialized] public bool _fleldOutPlayer1 = false;
    [System.NonSerialized] public bool _fleldOutPlayer2 = false;
    [System.NonSerialized] public bool _fleldOutPlayer3 = false;
    [System.NonSerialized] public bool _fleldOutPlayer4 = false;

    public enum PlayerNumber : int
    {
        player1 = 1,
        player2,
        player3,
        player4
    }

    /// <summary>
    /// 当たったオブジェクトを取得し、Player の番号を返す
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        // Player タグを取得
        if (other.gameObject.CompareTag("Player"))
        {
            _cs_player = other.gameObject.GetComponent<Player>();
            _playerNum = other.gameObject.GetComponent<Player>().playerNum;

            switch (_playerNum)
            {
                case (int)PlayerNumber.player1:
                    _fleldOutPlayer1 = true;
                    _cs_player.playerStatus = Player.PlayerStatus.Dead;
                    GetPlayerDeath();
                    break;
                case (int)PlayerNumber.player2:
                    _fleldOutPlayer2 = true;
                    _cs_player.playerStatus = Player.PlayerStatus.Dead;
                    GetPlayerDeath();
                    break;
                case (int)PlayerNumber.player3:
                    _fleldOutPlayer3 = true;
                    _cs_player.playerStatus = Player.PlayerStatus.Dead;
                    GetPlayerDeath();
                    break;
                case (int)PlayerNumber.player4:
                    _fleldOutPlayer4 = true;
                    _cs_player.playerStatus = Player.PlayerStatus.Dead;
                    GetPlayerDeath();
                    break;
                default:
                    break;
            }
        }
        else { return; }

        //デバッグ用
        //Debug.Log(_playerNum);
        //Debug.Log(_cs_player.playerStatus);
    }

    public Player.PlayerStatus GetPlayerDeath()
    {
        return _cs_player.playerStatus;
    }
}
