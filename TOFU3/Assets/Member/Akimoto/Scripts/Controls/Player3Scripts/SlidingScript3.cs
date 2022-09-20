using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingScript3 : MonoBehaviour
{
    private float startYScale;  // �����̍���
    private float slideTimer;   // �X���C�f�B���O����
    private Rigidbody rb;       // ����
    private Player3ControllerScript pm; // MovementManager���擾(����PlayerMovve�������̂ŕϐ���pm)

    [Header("Slideing")]
    [SerializeField] private float maxSlideTime;                // �X���C�f�B���O�Œ�����
    [SerializeField] private float slideForce;                  // �X���C�f�B���O�̉����o����
    [SerializeField] private float slideYScale;                 // �X���C�f�B���O����Obj����
    [SerializeField] private Transform playerObj;               // Obj�擾

    [Header("Keybinding")]
    [SerializeField] KeyCode slideKey = KeyCode.LeftControl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<Player3ControllerScript>();   // MovementManager���擾

        startYScale = playerObj.localScale.y;   // Obj�̏����������擾
    }

    void Update()
    {
        //  �L�[���͂���
        if (Input.GetKeyDown(slideKey) && (pm.x != 0 || pm.z != 0) && pm.isGround)
            StartSlide();

        // �L�[���͂�߂�
        if (Input.GetKeyUp(slideKey) && pm.sliding && pm.isGround)
            StopSlide();
    }

    private void FixedUpdate()
    {
        // �X�e�[�^�X�ƈ�v������X���C�f�B���O����
        if (pm.sliding)
            SlidingMovement();
    }

    // �X���C�f�B���O���n�߂鏈��
    private void StartSlide()
    {
        pm.sliding = true;  // �X�e�[�^�X���X���C�f�B���O�ɂ���

        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);    // �������X���C�f�B���O�ɕς���
        rb.AddForce(Vector3.down * 5.0f, ForceMode.Impulse);                                                // �X���C�f�B���O : �����o��

        slideTimer = maxSlideTime;  // �Œ����Ԃ܂ŃX���C�f�B���O
    }

    // �X���C�f�B���O���~�߂鏈��
    private void StopSlide()
    {
        pm.sliding = false;

        playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z);    // �����̍����ɖ߂�
    }

    // �X���C�f�B���O����
    private void SlidingMovement()
    {
        Vector3 inputDirection = playerObj.forward; // Obj�̑O����

        // �X���C�f�B���O����
        if (rb.velocity.y > -0.1f)
        {
            rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Impulse);

            slideTimer -= Time.deltaTime;
        }

        // ���Ԃ�������~�߂�
        if (slideTimer <= 0)
            StopSlide();
    }
}
