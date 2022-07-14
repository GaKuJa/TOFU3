using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float fadeOutTime = 0;
    [SerializeField]
    private Image fadeImage = null;
    
    private float fadeColorAlpha = 0;
    [SerializeField]
    private bool  fadeFlag       = false;

    public Action ActionFadeIn = null;
    
    private void Start()
    {
        fadeColorAlpha = fadeImage.color.a;
        ActionFadeIn   = CameraFadeIn;
    }

    public void CameraFadeOut(System.Action<System.Action> playerReS,System.Action playerReset)
    {

        if (fadeImage.color.a <= 0.0f && !fadeFlag)
        {
            fadeFlag = true;
            fadeColorAlpha = 0;
        }
        if (fadeFlag)
        {
            // フェードアウト開始
            fadeColorAlpha  += Time.deltaTime / fadeOutTime;
            Debug.Log("A: " + fadeColorAlpha);
            fadeImage.color =  new Color(0.0f, 0.0f, 0.0f, fadeColorAlpha);
            Debug.Log(fadeImage.color);
        }
        if (fadeImage.color.a >= 1.0f && playerReS != null)
            playerReS(playerReset);
    }

    public void CameraFadeIn()
    {
        if (fadeImage.color.a >= 1.0f && fadeFlag)
            fadeFlag = false;
        if (!fadeFlag)
        {
            // フェードアウト開始
            fadeColorAlpha  -= Time.deltaTime / fadeOutTime;
            fadeImage.color =  new Color(0.0f, 0.0f, 0.0f, fadeColorAlpha);
        }
    }
}
