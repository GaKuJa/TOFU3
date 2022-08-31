using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{
    // ��ʑS�̂̃t�F�[�h�C���[�W
    [SerializeField]
    private Image screenFadeImage = null;
    private float fadeImageAlpha = 0.0f;
    private bool fadeFlag = true;
    private void Start()
    {
        fadeImageAlpha = screenFadeImage.color.a;
    }
    public void GameStartFadeIn(System.Action SceneModeIsGameStart,float fadeInTime)
    {
        if (fadeFlag)
        {
            // �t�F�[�h�A�E�g�J�n
            fadeImageAlpha -= Time.deltaTime / fadeInTime;
            screenFadeImage.color = new Color(0.0f, 0.0f, 0.0f, fadeImageAlpha);
        }
        if (screenFadeImage.color.a <= 0.0f)
            fadeFlag = false;
        if (!fadeFlag && SceneModeIsGameStart != null)
            SceneModeIsGameStart();
    }
}
