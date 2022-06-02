using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [SerializeField]
    private Text maxBulletText , nowBulletText;

    void Update()
    {
        ChangeBulletText();
    }

    private void ChangeBulletText()
    {
        maxBulletText.text = SHOYUGUNScript.Instance.GetMaxMagazinNum().ToString();
        nowBulletText.text = SHOYUGUNScript.Instance.GetMaxBulletNum().ToString();
    }
}
