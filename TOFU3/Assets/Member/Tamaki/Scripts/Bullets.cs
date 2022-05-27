using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{
    public Text CountText;  // 残弾数用
    public Text CountText1; // マガジン用
    [SerializeField]
    private int Count = 30;
    private float Timeleft = 0.1f;
    [SerializeField]
    private int Magazine = 180;

    void Update()
    {
        for (int i = 180; i > 0; i -= 30) 
        {
            //ボタンを押した時の処理
            if (Input.GetMouseButton(1) && Count > 0)
            {
                Timeleft -= Time.deltaTime;
                if (Timeleft <= 0.0)
                {
                    Timeleft = 0.3f;
                    Count--;
                    CountText.text = Count.ToString();
                    if (Count <= 0 && Magazine > 0)
                    {
                        Magazine -= 30;
                        CountText1.text = Magazine.ToString();
                        Count = 30;
                    }
                }
            }

        }

    }
}