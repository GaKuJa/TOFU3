using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃f�X����
/// </summary>

public class BoiledWater : MonoBehaviour
{
    //�K�v�ȋ@�\�̎Q�ƌ�
    private Player _cs_player;
    //�擾�����v���C���[�̔ԍ����i�[
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
    /// ���������I�u�W�F�N�g���擾���APlayer �̔ԍ���Ԃ�
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        // Player �^�O���擾
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

        //�f�o�b�O�p
        //Debug.Log(_playerNum);
        //Debug.Log(_cs_player.playerStatus);
    }

    public Player.PlayerStatus GetPlayerDeath()
    {
        return _cs_player.playerStatus;
    }
}
