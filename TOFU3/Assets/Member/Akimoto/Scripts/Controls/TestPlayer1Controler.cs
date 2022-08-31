using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer1Controler : MonoBehaviour
{

    private float MoveSpeed;                // プレイヤーのステータスに応じて変わる速度
    private float AdaptSpeed;               // ステータスの速度
    private float lastAdaptSpeed;           // ステータスの終速度
    private float startYScale;              // Objの初期高さ
    private string GroundTag = "Ground";    // tag - Ground
    private Rigidbody rb;                   // 物理
    private Vector3 moveDirection;          // 方向

    [Header("Movement")]
    [SerializeField] private float walkSpeed;           // 歩く速度
    [SerializeField] private float sprintSpeed;         // 走る速度
    [SerializeField] private float slideSpeed;          // スライディング速度
    [SerializeField] private float wallrunSpeed;        // 壁走り速度
    [SerializeField] private float Drag;                // 摩擦
    [SerializeField] private float crouchSpeed;         // しゃがみ時の速度
    [SerializeField] private float crouchYScale;        // しゃがみのObjを変える
    [SerializeField] private float jumpForce;           // ジャンプ力
    [SerializeField] private Transform PlayerObj;       // Playerのオブジェクト取得
    //  macなのでしゃがみとスライディングキーはインスペクター上で変更しています。

    [System.NonSerialized] public float x;              // 左右入力 : 変数名が雑なので変更したほうがよければ変えます。
    [System.NonSerialized] public float z;              // 上下入力 : 左右同様
    [System.NonSerialized] public int JumpCount = 0;    // ダブルジャンプのカウント

    [Header("Status")]
    public MovementState state;                             // ステータス
    [System.NonSerialized] public bool sliding;             // - スライディング
    [System.NonSerialized] public bool crouching;           // - しゃがみ
    [System.NonSerialized] public bool wallrunning;         // - 壁走り
    [System.NonSerialized] public bool air;                 // - ジャンプ / 空中
    [System.NonSerialized] public bool isGround = false;    // 接地判定
    
    public enum MovementState
    {
        walking,
        sprinting,
        wallrunning,
        crouching,
        sliding,
        air
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;               // 回転し続けないようにする
        startYScale = transform.localScale.y;   // 高さ取得

        isGround = false;   // 条件を満たしているか確認するために接地していない判定にする
    }
    
    void Update()
    {
        MoveInput();
        StateHandler();

        // 接地していたら摩擦を加える
        if(isGround)
            rb.drag = Drag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    // 基本操作の入力
    private void MoveInput()
    {
        x = Input.GetAxis("Horizontal1");
        z = Input.GetAxis("Vertical1");

        if(Input.GetKeyDown("joystick 1 button 0") && state != MovementState.wallrunning)
            Jump(); 

        if (Input.GetKeyDown("joystick 1 button 1") && isGround)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5.0f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp("joystick 1 button 1"))
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    }

    // 移動処理 - ステータスによって速度変更
    private void Movement()
    {
        moveDirection = -PlayerObj.forward * z + PlayerObj.right * x;
        rb.AddForce(moveDirection.normalized * MoveSpeed, ForceMode.Force);

        if(isGround)
            rb.AddForce(moveDirection.normalized * MoveSpeed * 10.0f, ForceMode.Force);
    }

    // ステータス
    private void StateHandler()
    {
        // 壁走り
        if (wallrunning && state != MovementState.air)
        {
            state = MovementState.wallrunning;
            AdaptSpeed = wallrunSpeed;
        }

        // スライディング
        else if (sliding && isGround)
        {
            state = MovementState.sliding;
            if (rb.velocity.y < 0.1f)
                AdaptSpeed = slideSpeed;
            else
                AdaptSpeed = sprintSpeed;
        }

        // しゃがみ
        else if(Input.GetKey("joystick 1 button 1"))
        {
            state = MovementState.crouching;
            AdaptSpeed = crouchSpeed;
        }

        // 走り
        else if(isGround && Input.GetKey("joystick 1 button 8"))
        {
            state = MovementState.sprinting;
            AdaptSpeed = sprintSpeed;
        }

        // 歩き
        else if (isGround && state != MovementState.sliding)
        {
            state = MovementState.walking;
            AdaptSpeed = walkSpeed;
        }

        // ジャンプ - 空中
        else if (state != MovementState.wallrunning)
            state = MovementState.air;

        // 速度差を滑らかにする
        if(Mathf.Abs(AdaptSpeed - lastAdaptSpeed) > 4.0f && MoveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
            MoveSpeed = AdaptSpeed;

        lastAdaptSpeed = AdaptSpeed;
    }

    // 減速処理
    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        float time = 0;
        float difference = Mathf.Abs(AdaptSpeed - MoveSpeed);
        float startValue = MoveSpeed;

        while (time < difference)
        {
            MoveSpeed = Mathf.Lerp(startValue, AdaptSpeed, time / difference);
            time += Time.deltaTime * 1.0f;

            yield return null;
        }

        MoveSpeed = AdaptSpeed;
    }

    // 加速制限処理
    private void SpeedControl()
    {   
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    // ジャンプ
    private void Jump()
    {
        if (JumpCount <= 1)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(moveDirection.normalized * MoveSpeed + Vector3.up * jumpForce, ForceMode.Impulse);
            JumpCount ++;
        }
    }

    // 接地した
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == GroundTag)
			JumpCount = 0;
            isGround = true;
	}

    // 接地やめた
    private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == GroundTag)
            isGround = false;
	}
}