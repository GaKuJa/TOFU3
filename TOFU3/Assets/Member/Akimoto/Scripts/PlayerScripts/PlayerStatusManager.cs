using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerStatusManager : MonoBehaviour
{
    public enum PlayerMoveStatus
    {
        Defalt,
        Walk,
        Dath,
        Jump,
        WallRun,
        Crounch,
        CrounchWalk,
        Sliding,
    }

    public ReactiveProperty<PlayerMoveStatus> moveSatus { get; set; } = new ReactiveProperty<PlayerMoveStatus>();

    [SerializeField]
    private AnimationControler animationControler = null;

    private void Start()
    {
        moveSatus.ObserveEveryValueChanged(_ => moveSatus).Subscribe(_ => PlayerMove(_));
    }

    private void PlayerMove(ReactiveProperty<PlayerMoveStatus> plaeyrMoveStatus)
    {
        switch (plaeyrMoveStatus.Value)
        {
            case PlayerMoveStatus.Walk:
                animationControler.WalkAnimation(true);
                break;
            case PlayerMoveStatus.Dath:
                animationControler.DathAnimation(true);
                break;
            case PlayerMoveStatus.Jump:
                animationControler.JumpAnimation(true);
                break;
            case PlayerMoveStatus.WallRun:
                break;
            case PlayerMoveStatus.Crounch:
                animationControler.CrounchAnimation(true);
                break;
            case PlayerMoveStatus.CrounchWalk:
                animationControler.CrounchingWalkAnimation(true);
                break;
            case PlayerMoveStatus.Sliding:
                animationControler.SlidingAnimation(true);
                break;
        }
    }
}
