using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class BaseGunStatus : MonoBehaviour
{
    
    // 銃のダメージ数
    [SerializeField]
    protected int bulletDamage = 0;
    // 弾の速度
    [SerializeField]
    protected float bulletShotSpeed = 0;
    // 連射速度
    [SerializeField]
    protected float shootIntervalTime = 0;
    // 銃ごとのレティクルのサイズ
    [SerializeField]
    protected int reticleSize = 0;
    // 最大弾薬数
    [SerializeField]
    protected int magazinNum = 0;
    // 1マガジンに入っている弾薬数
    [SerializeField]
    protected int bulletNum = 0;
}
