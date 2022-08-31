using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("TitleScene");
    }
}
