using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public  Action ActionPlayerMove;
    private int    playerHP = 10;
    private int    GunATK = 1;
    private void Start()
    {
        ActionPlayerMove = PlayerMove;
    }
    // 移動関数
    private void PlayerMove()
    {

    }
    
    // 秋元
    private void SubPlayerHP()
    {
        playerHP -= GunATK;//2年生
    }
    
    // 弾の生成
    // 精度計算
    // 弾の押し出す関数
    private void AddForceBUllet()
    {
        
    }
}
