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

    [SerializeField] WallRun wallrun;
    [SerializeField] private Transform PlayerObj;
    [SerializeField] private Transform CamHolder;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // ADS
        if(Input.GetMouseButtonDown(0))
        {
            Camera.main.fieldOfView = 45.0f;
        }
        if(Input.GetMouseButtonUp(0))
        {
            Camera.main.fieldOfView = 60.0f;
        }

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        CamHolder.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallrun.tilt);
        PlayerObj.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
