using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{
    /*
     privateとpubuliceの使い分け
     田中くんの変数の紐付け
     関数わけ
     キャメルケースに直す
     */
    [SerializeField]
    private Text CountText;  // �c�e���p
    [SerializeField]
    private Text CountText1; // �}�K�W���p
    [SerializeField]
    private int Count = 30;
    private float TimeLeft = 0.1f;
    [SerializeField]
    private int Magazine = 180;


    void Update()
    {

        for (int i = 180; i > 0; i -= 30)
        {
            //�{�^�������������̏���
            if (Input.GetMouseButton(1) && Count > 0)
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0.0)
                {
                    TimeLeft = 0.3f;
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