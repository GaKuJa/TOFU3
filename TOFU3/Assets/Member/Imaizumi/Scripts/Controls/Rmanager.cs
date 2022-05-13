using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rmanager : MonoBehaviour
{

    public int NPlayer;
    int MaxNPlayer;

    int PlayerD;
    int PlayerD2;
    int PlayerD3;
    int PlayerD4;

    public PlayerHp playerhp;
    public PlayerHp2 playerhp2;
    public PlayerHp3 playerhp3;
    public PlayerHp4 playerhp4;

    // Start is called before the first frame update
    void Start()
    {
        //最大人数を設定
        MaxNPlayer = 4;
        // 現在値を最大に
        NPlayer = MaxNPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMG();
    }

    // 残機が無くなったら数を減らす
    void PlayerMG()
    {
        PlayerD = playerhp.Debt;
        PlayerD2 = playerhp2.Debt2;
        PlayerD3 = playerhp3.Debt3;
        PlayerD4 = playerhp4.Debt4;

        if (PlayerD == 1)
        {
            --NPlayer;
            PlayerD = 2;
        }
        if (PlayerD2 == 1)
        {
            --NPlayer;
            PlayerD2 = 2;
        }
        if (PlayerD3 == 1)
        {
            --NPlayer;
            PlayerD3 = 2;
        }
        if (PlayerD4 == 1)
        {
            --NPlayer;
            PlayerD4 = 2;
        }

        
    }

    // スコア
    void Score()
    {
        if (NPlayer <= 1)
        {
            if ()
            {

            }
        }
    }


}
