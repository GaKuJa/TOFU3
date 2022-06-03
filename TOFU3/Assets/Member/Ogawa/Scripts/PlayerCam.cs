using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    float xRotation;
    float yRotation;
    public Rigidbody rb;
    Transform transformCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transformCamera = Camera.main.transform;
        //カメラのX回転角を取得
        xRotation = transformCamera.localEulerAngles.x;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        rb.MoveRotation(Quaternion.Euler(0.0f, rb.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f, 0.0f));
        xRotation = Mathf.Clamp(xRotation - mouseY * Time.deltaTime * 100.0f, -90, 60);
        transformCamera.localEulerAngles = new Vector3(xRotation, 0, 0);
    }
}
