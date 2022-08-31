using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextControl1 : MonoBehaviour
{
    [SerializeField]
    private Text maxBulletText, nowBulletText;
    [SerializeField]
    private SHOYUGUNScript1 shoyugunScript1 = null;


    void Update()
    {
        ChangeBulletText();
    }

    private void ChangeBulletText()
    {
        maxBulletText.text = shoyugunScript1.magazinNum.ToString();
        nowBulletText.text = shoyugunScript1.bulletNum.ToString();
    }
}
