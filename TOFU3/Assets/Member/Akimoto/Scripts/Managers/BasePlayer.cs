using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Unity.VisualScripting;

[System.Serializable]
public class BasePlayer : MonoBehaviour
{
    public enum PlayerStatus
    {
        Alive,
        Dead,
    }
    [SerializeField]
    protected int moveSpeed = 0;
    [SerializeField]
    public int playerNum = 0;
    [SerializeField]
    private GameObject respawnPoint;
    [SerializeField]
    public  PlayerStatus playerStatus  = PlayerStatus.Alive;
    [SerializeField]
    private ReactiveProperty<int> hp = new ReactiveProperty<int>(100);
    public int remainingLives = 3;

    private void Update()
    {
        hp.Where(_ => hp.Value <= 0).Subscribe(_ => playerStatus = PlayerStatus.Dead);
        hp.Where(_ => hp.Value >= 100).Subscribe(_ => playerStatus = PlayerStatus.Alive);
    }
    
    public void PlayerReSpawn(System.Action ActionFadeIn)
    {
        this.transform.position = respawnPoint.transform.position;
        if (transform.position == respawnPoint.transform.position && ActionFadeIn != null)
            ActionFadeIn();
    }

    public void PlayerReset()
    {
        hp.Value = 100;
        remainingLives--;
    }

    public int GetHp()
    {
        return hp.Value;
    }

    public void SetHp(int totalHp)
    {
        hp.Value = totalHp;
    }
}
