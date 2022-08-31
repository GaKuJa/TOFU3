using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [SerializeField]
    private Text fadeTimeText, GameTimeMinutesText, GameTimeSecondsText = null;
    [SerializeField]
    private Text[] playerStockText,playerHpText = new Text[2];
    public void FadeTimeToString(int IntFadeTime)
    {
        fadeTimeText.text = IntFadeTime.ToString();
    }
    public void GameTimerDisplay(int Minutes,int Seconds)
    {
        GameTimeMinutesText.text = Minutes.ToString();
        GameTimeSecondsText.text = Seconds.ToString();
    }
    public void PlayerStockDisplay(int play1Stock,int play2Stock)
    {
        playerStockText[0].text = play1Stock.ToString();
        playerStockText[1].text = play2Stock.ToString();
    }
    public void FadeTimeTextOut()
    {
        fadeTimeText.gameObject.SetActive(false);
    }
    public void HpDisPlay(int play1Hp, int play2Hp)
    {
        playerHpText[0].text = play1Hp.ToString();
        playerHpText[1].text = play2Hp.ToString();
    }
}
