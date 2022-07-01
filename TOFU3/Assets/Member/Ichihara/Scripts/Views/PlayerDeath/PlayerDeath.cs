using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのデス判定
/// </summary>

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    TestPlayerDeath testPlayerDeath;

    private void OnCollisionEnter(Collision collision)
    {
        testPlayerDeath.playerstatus = TestPlayerDeath.Playerstatus.death;
        Debug.Log(testPlayerDeath.playerstatus);
    }
}
