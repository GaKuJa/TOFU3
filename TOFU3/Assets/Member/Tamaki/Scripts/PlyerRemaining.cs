using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyerRemaining : MonoBehaviour
{
    [SerializeField]
    private Text CountRemaining;
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
            if (Input.GetMouseButton(0) && Remaining > 0) // 残機が残っていたら左クリックでHP減らす
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0.0)
                {
                    TimeLeft = 0.1f; // 徐々にHP減らす
                    HP--;
                    if (HP <= 0)
                    {
                        Remaining--;
                        CountRemaining.text = Remaining.ToString("×" + Remaining) ;
                        HP = 100;
                    }
                }

            }
        }
    }
}
