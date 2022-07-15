using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのデス判定
/// </summary>

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerDeathStatus.instance.playerstatus = PlayerDeathStatus.Playerstatus.death;
        Debug.Log(PlayerDeathStatus.instance.playerstatus);
    }

    public PlayerDeathStatus.Playerstatus SetPlayerDeath()
    {
        return PlayerDeathStatus.instance.playerstatus;
    }
}
