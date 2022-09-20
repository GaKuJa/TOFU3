using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    private Text shotingBullet, timeText, remamingText, hpText, playerCountText = null;

    public void ShotBulletDisplay(int bulletNum)
    {
        shotingBullet.text = bulletNum.ToString();
    }

    public void TimeDisplay(float time)
    {
        timeText.text = time.ToString();
    }

    public void RemamingDisplay(int remaming)
    {
        remamingText.text = remaming.ToString();
    }

    public void HPDisplay(int hp)
    {
        hpText.text = hp.ToString();
    }

    public void PlayerCountDisplay(int playerCount)
    {
        playerCountText.text = playerCount.ToString();
    }

}
