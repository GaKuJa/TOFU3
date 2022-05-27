using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyerRemaining : MonoBehaviour
{
    [SerializeField]
    private Text CountRemaining;
    [SerializeField]
    private int Remaining; // �c�@
    [SerializeField]
    private float HP = 100; // HP
    private float TimeLeft = 0.1f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 5; i > 0; --i) // �c�@��0����Ȃ�
        {
            if (Input.GetMouseButton(0) && Remaining > 0) // �c�@���c���Ă����獶�N���b�N��HP���炷
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0.0)
                {
                    TimeLeft = 0.1f; // ���X��HP���炷
                    HP--;
                    if (HP <= 0)
                    {
                        Remaining--;
                        CountRemaining.text = Remaining.ToString("�~" + Remaining) ;
                        HP = 100;
                    }
                }

            }
        }
    }
}
