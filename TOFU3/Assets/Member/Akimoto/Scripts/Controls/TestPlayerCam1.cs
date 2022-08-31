using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerCam1 : MonoBehaviour
{
    private float xRotation;    // x‰ñ“]
    private float yRotation;    // y‰ñ“]
    private float fieldOfView;  // FOV

    [SerializeField] private float sensX;   // xŠ´“x
    [SerializeField] private float sensY;   // yŠ´“x
    [SerializeField] private Transform PlayerObj;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("R_Stick_H1") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("R_Stick_V1") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // ADS
        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.fieldOfView = 45.0f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Camera.main.fieldOfView = 60.0f;
        }
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        PlayerObj.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
