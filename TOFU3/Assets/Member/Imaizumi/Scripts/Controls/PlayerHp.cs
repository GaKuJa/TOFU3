using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int CurrentHp;
     int MaxHp;

    public int PlayerRm;
    int MaxPlayerRm;

    public int Debt;

    // Start is called before the first frame update
    void Start()
    {
        // �ő�HP��ݒ�
        MaxHp = 100;
        // ���ݒl���ő��
        CurrentHp = MaxHp;

        // �c�@����ݒ�
        MaxPlayerRm = 5;
        // ���ݒl���ő��
        PlayerRm = MaxPlayerRm;

        Debt = 0;

    }

    // �_���[�W
    public void Damage()
    {

        // CurrentHp -= ;

        // �̗͂�0�ɂȂ�����c�@��1���炷
        if (CurrentHp <= 0)
        {
            --PlayerRm;
        }
        // �c�@���O�ɂȂ�����
        if (PlayerRm <= 0)
        {
            Debt = 1;
        }
    }
}
