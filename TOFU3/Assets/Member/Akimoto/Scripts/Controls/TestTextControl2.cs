using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextControl2 : MonoBehaviour
{
    [SerializeField]
    private Text maxBulletText, nowBulletText;
    [SerializeField]
    private SHOYUGUNScript2 shoyugunScript2 = null;


    void Update()
    {
        ChangeBulletText();
    }

    private void ChangeBulletText()
    {
        maxBulletText.text = shoyugunScript2.magazinNum.ToString();
        nowBulletText.text = shoyugunScript2.bulletNum.ToString();
    }
}
