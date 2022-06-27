using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private float xRotation;    // x回転
    private float yRotation;    // y回転
    private float fieldOfView;  // FOV

    [SerializeField] private float sensX;   // x感度
    [SerializeField] private float sensY;   // y感度
    
    public Rigidbody rb;    // 物理
    Transform FPSCamera;    // カメラ取得
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // カーソル固定
        Cursor.visible = false;                     // カーソルを非表示

        // カメラは未完成
        FPSCamera = Camera.main.transform;
        xRotation = FPSCamera.localEulerAngles.x;
    }

    // addforce -> transform
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        if(Input.GetKeyDown("x"))
        {
            Camera.main.fieldOfView = 45.0f;
        }
        if(Input.GetKeyUp("x"))
        {
            Camera.main.fieldOfView = 60.0f;
        }

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        rb.MoveRotation(Quaternion.Euler(0.0f, rb.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f, 0.0f));
        xRotation = Mathf.Clamp(xRotation - mouseY * Time.deltaTime * 100.0f, -90, 60);
        FPSCamera.localEulerAngles = new Vector3(xRotation, 0, 0);
    }
}
