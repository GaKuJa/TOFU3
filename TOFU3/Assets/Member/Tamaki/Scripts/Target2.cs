using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Target2 : MonoBehaviour
{
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
            if (Input.GetKey(KeyCode.Alpha3) && Remaining > 0) // �c�@���c���Ă����獶�N���b�N��HP���炷
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0.0)
                {
                    TimeLeft = 0.1f; // ���X��HP���炷
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
