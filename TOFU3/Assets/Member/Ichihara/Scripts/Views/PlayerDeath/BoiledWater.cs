using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃f�X����
/// </summary>

public class BoiledWater : MonoBehaviour
{
    private bool _flag = false;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerDeathStatus.Instance.playerstatus = PlayerDeathStatus.Playerstatus.death;
        Debug.Log(PlayerDeathStatus.Instance.playerstatus);
    }

    public PlayerDeathStatus.Playerstatus SetPlayerDeath()
    {
        return PlayerDeathStatus.Instance.playerstatus;
    }
}
