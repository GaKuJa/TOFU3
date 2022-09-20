using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    private PlayerStatusManager playerStatusManager = null;
    public void PlayerMove(InputAction.CallbackContext context)
    {
        playerStatusManager.moveSatus.Value = PlayerStatusManager.PlayerMoveStatus.Walk;
        Debug.Log(playerStatusManager.moveSatus.Value);
    }
}
