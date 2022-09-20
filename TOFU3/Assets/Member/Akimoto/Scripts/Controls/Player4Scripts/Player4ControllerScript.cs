using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4ControllerScript : MonoBehaviour
{
    private float MoveSpeed;                // �v���C���[�̃X�e�[�^�X�ɉ����ĕς�鑬�x
    private float AdaptSpeed;               // �X�e�[�^�X�̑��x
    private float lastAdaptSpeed;           // �X�e�[�^�X�̏I���x
    private float startYScale;              // Obj�̏�������
    private string GroundTag = "Ground";    // tag - Ground
    private Rigidbody rb;                   // ����
    private Vector3 moveDirection;          // ����

    [Header("Movement")]
    [SerializeField] private float walkSpeed;           // �������x
    [SerializeField] private float sprintSpeed;         // ���鑬�x
    [SerializeField] private float slideSpeed;          // �X���C�f�B���O���x
    [SerializeField] private float wallrunSpeed;        // �Ǒ��葬�x
    [SerializeField] private float Drag;                // ���C
    [SerializeField] private float crouchSpeed;         // ���Ⴊ�ݎ��̑��x
    [SerializeField] private float crouchYScale;        // ���Ⴊ�݂�Obj��ς���
    [SerializeField] private float jumpForce;           // �W�����v��
    [SerializeField] private Transform PlayerObj;       // Player�̃I�u�W�F�N�g�擾
    //  mac�Ȃ̂ł��Ⴊ�݂ƃX���C�f�B���O�L�[�̓C���X�y�N�^�[��ŕύX���Ă��܂��B

    [System.NonSerialized] public float x;              // ���E���� : �ϐ������G�Ȃ̂ŕύX�����ق����悯��Ες��܂��B
    [System.NonSerialized] public float z;              // �㉺���� : ���E���l
    [System.NonSerialized] public int JumpCount = 0;    // �_�u���W�����v�̃J�E���g

    [Header("Status")]
    public MovementState state;                             // �X�e�[�^�X
    [System.NonSerialized] public bool sliding;             // - �X���C�f�B���O
    [System.NonSerialized] public bool crouching;           // - ���Ⴊ��
    [System.NonSerialized] public bool wallrunning;         // - �Ǒ���
    [System.NonSerialized] public bool air;                 // - �W�����v / ��
    [System.NonSerialized] public bool isGround = false;    // �ڒn����

    [SerializeField]
    private PlayerAnimationControl playerAnimationControl = null;


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
        rb.freezeRotation = true;               // ��]�������Ȃ��悤�ɂ���
        startYScale = transform.localScale.y;   // �����擾

        isGround = false;   // �����𖞂����Ă��邩�m�F���邽�߂ɐڒn���Ă��Ȃ�����ɂ���
    }

    void Update()
    {
        MoveInput();
        StateHandler();

        // �ڒn���Ă����疀�C��������
        if (isGround)
            rb.drag = Drag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    // ��{����̓���
    private void MoveInput()
    {
        x = Input.GetAxis("Horizontal4");
        z = Input.GetAxis("Vertical4");

        if (x == 0.0f && z == 0.0f)
        {
            playerAnimationControl.WalkAnimationStop();
        }
        else
        {
            playerAnimationControl.WalkAnimationStart();
        }

        if (Input.GetKeyDown("joystick 4 button 0") && state != MovementState.wallrunning)
            Jump();

        if (Input.GetKeyDown("joystick 4 button 1") && isGround)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5.0f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp("joystick 4 button 1"))
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    }

    // �ړ����� - �X�e�[�^�X�ɂ���đ��x�ύX
    private void Movement()
    {
        moveDirection = -PlayerObj.forward * z + PlayerObj.right * x;
        rb.AddForce(moveDirection.normalized * MoveSpeed, ForceMode.Force);

        if (isGround)
            rb.AddForce(moveDirection.normalized * MoveSpeed * 10.0f, ForceMode.Force);
    }

    // �X�e�[�^�X
    private void StateHandler()
    {
        // �Ǒ���
        if (wallrunning && state != MovementState.air)
        {
            state = MovementState.wallrunning;
            AdaptSpeed = wallrunSpeed;
        }

        // �X���C�f�B���O
        else if (sliding && isGround)
        {
            state = MovementState.sliding;
            if (rb.velocity.y < 0.1f)
                AdaptSpeed = slideSpeed;
            else
                AdaptSpeed = sprintSpeed;
        }

        // ���Ⴊ��
        else if (Input.GetKey("joystick 4 button 1"))
        {
            state = MovementState.crouching;
            AdaptSpeed = crouchSpeed;
        }

        // ����
        else if (isGround && Input.GetKey("joystick 4 button 8"))
        {
            state = MovementState.sprinting;
            AdaptSpeed = sprintSpeed;
        }

        // ����
        else if (isGround && state != MovementState.sliding)
        {
            state = MovementState.walking;
            AdaptSpeed = walkSpeed;
        }

        // �W�����v - ��
        else if (state != MovementState.wallrunning)
            state = MovementState.air;

        // ���x�������炩�ɂ���
        if (Mathf.Abs(AdaptSpeed - lastAdaptSpeed) > 4.0f && MoveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
            MoveSpeed = AdaptSpeed;

        lastAdaptSpeed = AdaptSpeed;
    }

    // ��������
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

    // ������������
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    // �W�����v
    private void Jump()
    {
        if (JumpCount <= 1)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(moveDirection.normalized * MoveSpeed + Vector3.up * jumpForce, ForceMode.Impulse);
            JumpCount++;
        }
    }

    // �ڒn����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GroundTag)
            JumpCount = 0;
        isGround = true;
    }

    // �ڒn��߂�
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == GroundTag)
            isGround = false;
    }
}
