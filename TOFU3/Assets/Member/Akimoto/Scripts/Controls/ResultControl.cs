using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("joystick 1 button 0") || Input.GetKey("joystick 2 button 0"))
            SceneManager.LoadScene("TitleScene");
    }
}
