using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    private Rigidbody rb;               // 物理
    private MovementManager pm;         // MovementManagerを取得
    private RaycastHit LeftWallhit;     // 右壁判定
    private RaycastHit RightWallhit;    // 左壁判定

    [SerializeField] private float WallrunForce;    // 壁走りの推進力
    [SerializeField] private float WallRunDistance; // 壁走りするための壁とObjの距離
    [SerializeField] private Transform PlayerObj;   // Obj取得

    // リーダーが見やすいようにInspector上では非表示にしています
    [System.NonSerialized] public bool wallLeft;    // 左壁か
    [System.NonSerialized] public bool wallRight;   // 右壁か
    [System.NonSerialized] public bool exitingWall; // 壁から離れたか
    public LayerMask isWall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<MovementManager>();   // MovementManagerを取得
    }

    private void Update()
    {
        CheckForWall();
        StateMachine();
    }

    private void FixedUpdate()
    {
        // ステータスと一致したら壁走り処理
        if (pm.wallrunning)
            WallRunningMovement();
    }

    // 壁の左右チェック処理
    private void CheckForWall()
    {
        wallLeft = Physics.Raycast(transform.position, -PlayerObj.right, out LeftWallhit, WallRunDistance, isWall);     // 左壁判定
        wallRight = Physics.Raycast(transform.position, PlayerObj.right, out RightWallhit, WallRunDistance, isWall);    // 右壁判定
    }

    //  条件に応じた処理をする処理
    private void StateMachine()
    {
        // 左右壁かつ左右キーを押していなくて、壁から離れていなかったら
        if ((wallLeft || wallRight) && pm.z > 0 && !exitingWall)
        {
            // 壁走り始める(壁走りの重複防止)
            if(!pm.wallrunning)
                StartWallRun();
        }
        // 壁から離れたら止める
        else if (exitingWall)
        {
            if(pm.wallrunning)
                StopWallRun();
        }
        // それ以外の処理をしたら止める
        else
        {
            if (pm.wallrunning)
                StopWallRun();
        }
    }

    // 壁走りを始める処理
    private void StartWallRun()
    {
        rb.useGravity = false;  // 重力をオフ
        pm.wallrunning = true;  // ステータスを壁走りにする
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // 移動

        // カメラの角度を左右壁に応じて傾ける
    }

    // 壁走りを止める処理
    private void StopWallRun()
    {
        rb.useGravity = true;   // 重力をオン
        pm.wallrunning = false; // ステータスを壁走りから別のステータスにする

        // 傾けたカメラを元に戻す
    }

    // 壁走り処理
    private void WallRunningMovement()
    {   
        Vector3 wallNormal = wallRight ? RightWallhit.normal : LeftWallhit.normal;  // 左右壁のどっちと接したか

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);              // 壁の並行をとる

        // 後ろ向きに移動しようとしたら壁走りできないようにする
        if((PlayerObj.forward - wallForward).magnitude > (PlayerObj.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        rb.AddForce(wallForward * WallrunForce, ForceMode.Force);   // プレイヤーを壁と並行に移動させる
    }
}
