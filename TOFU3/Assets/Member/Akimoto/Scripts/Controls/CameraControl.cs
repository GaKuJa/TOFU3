using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float fadeOutTime = 0;

    private float fadeColorAlpha = 0;

    [SerializeField]
    private Image fadeImage = null;
    
    private void Start()
    {
        fadeColorAlpha = fadeImage.color.a;
    }
    public void CameraFadeOut()
    {
        if (fadeColorAlpha != 1.0f)
        {
            // フェードアウト開始
            fadeColorAlpha  += Time.deltaTime / fadeOutTime;
            fadeImage.color =  new Color(0.0f, 0.0f, 0.0f, fadeColorAlpha);
        }
    }
}
