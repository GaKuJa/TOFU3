using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Target2 : MonoBehaviour
{
    [SerializeField]
    private int Remaining; // 残機
    [SerializeField]
    private float HP = 100; // HP
    private float TimeLeft = 0.1f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 5; i > 0; --i) // 残機が0より上なら
        {
            if (Input.GetKey(KeyCode.Alpha3) && Remaining > 0) // 残機が残っていたら左クリックでHP減らす
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0.0)
                {
                    TimeLeft = 0.1f; // 徐々にHP減らす
                    HP--;
                    if (HP <= 0)
                    {
                        Remaining--;
                        HP = 100;
                    }
                }

            }
        }
    }
}
