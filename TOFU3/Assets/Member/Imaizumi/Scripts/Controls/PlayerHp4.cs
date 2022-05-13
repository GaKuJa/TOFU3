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
        // 最大HPを設定
        MaxHp = 100;
        // 現在値を最大に
        CurrentHp = MaxHp;

        // 残機数を設定
        MaxPlayerRm = 5;
        // 現在値を最大に
        PlayerRm = MaxPlayerRm;

        Debt4 = 0;
    }



    // ダメージ
    public void Damage()
    {

        // CurrentHp -= ;

        // 体力が0になったら残機を1減らす
        if (CurrentHp <= 0)
        {
            --PlayerRm;
        }
        // 残機が0になったら
        if (PlayerRm <= 0)
        {
            Debt4 = 1;
        }
    }
}
