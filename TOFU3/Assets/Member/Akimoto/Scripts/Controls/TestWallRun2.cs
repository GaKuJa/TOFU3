using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWallRun2 : MonoBehaviour
{
    private Rigidbody rb;
    private TestPlayer2Controler pm;
    private RaycastHit LeftWallhit;
    private RaycastHit RightWallhit;

    [SerializeField] private float WallrunForce;
    [SerializeField] private float WallRunDistance;
    [SerializeField] private Transform PlayerObj;
    [SerializeField] private float MinHight;
    [SerializeField] private float MaxHight;

    public LayerMask isWall;
    [System.NonSerialized] public bool wallLeft;
    [System.NonSerialized] public bool wallRight;
    [System.NonSerialized] public bool exitingWall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<TestPlayer2Controler>();
    }

    private void Update()
    {
        CheckForWall();
        StateMachine();
    }

    private void FixedUpdate()
    {
        if (pm.wallrunning)
            WallRunningMovement();
    }

    private void CheckForWall()
    {
        wallLeft = Physics.Raycast(transform.position, -PlayerObj.right, out LeftWallhit, WallRunDistance, isWall);
        wallRight = Physics.Raycast(transform.position, PlayerObj.right, out RightWallhit, WallRunDistance, isWall);
    }

    //  ðŒ‚É‰ž‚¶‚½ˆ—‚ð‚·‚éˆ—
    private void StateMachine()
    {
        if ((wallLeft || wallRight) && pm.z > 0 && transform.position.y >= MinHight && transform.position.y <= MaxHight && !exitingWall)
        {
            if (!pm.wallrunning)
                StartWallRun();
        }
        else if (exitingWall)
        {
            if (pm.wallrunning)
                StopWallRun();
        }
        else
        {
            if (pm.wallrunning)
                StopWallRun();
        }
    }

    private void StartWallRun()
    {
        rb.useGravity = false;
        pm.wallrunning = true;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    private void StopWallRun()
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = true;
        pm.wallrunning = false;
        pm.JumpCount = 0;
    }

    private void WallRunningMovement()
    {
        Vector3 wallNormal = wallRight ? RightWallhit.normal : LeftWallhit.normal;  // ¶‰E•Ç”»’è

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);              // ŠOÏ

        if ((PlayerObj.forward - wallForward).magnitude > (PlayerObj.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        rb.AddForce(wallForward * WallrunForce, ForceMode.Impulse);
    }
}
