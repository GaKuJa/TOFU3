using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [SerializeField]
    private Text fadeTimeText = null;
    public void FadeTimeToString(int IntFadeTime)
    {
        fadeTimeText.text = IntFadeTime.ToString();
    }
    public void FadeTimeTextOut()
    {
        fadeTimeText.gameObject.SetActive(false);
    }
}
