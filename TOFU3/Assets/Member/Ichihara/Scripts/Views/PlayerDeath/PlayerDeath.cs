using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃f�X����
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
