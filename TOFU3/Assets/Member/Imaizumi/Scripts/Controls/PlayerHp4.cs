using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp4 : MonoBehaviour
{
    public int CurrentHp;
    int MaxHp;

    public int PlayerRm;
    int MaxPlayerRm;

    public int Debt4;

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

        Debt4 = 0;
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
        // �c�@��0�ɂȂ�����
        if (PlayerRm <= 0)
        {
            Debt4 = 1;
        }
    }
}
