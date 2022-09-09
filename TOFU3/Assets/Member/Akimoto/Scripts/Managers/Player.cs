using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Player : MonoBehaviour
{
    public enum PlayerStatus
    {
        Alive,
        Dead,
    }
    [SerializeField]
    protected int moveSpeed = 0;
    // プレイヤーの番号
    [SerializeField]
    public int playerNum = 0;
    // リスポーン座標
    [SerializeField]
    private GameObject respawnPoint;
    [SerializeField]
    public PlayerStatus playerStatus;
    // PlaeyrHp
    [SerializeField]
    private ReactiveProperty<int> hp = new ReactiveProperty<int>(100);
    // Plaeyrの残機
    public int remainingLives { get; set; } = 3;
    private void Update()
    {
        hp.Where(_ => hp.Value <= 0).Subscribe(_ => playerStatus = PlayerStatus.Dead);
        hp.Where(_ => hp.Value >= 100).Subscribe(_ => playerStatus = PlayerStatus.Alive);
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
            BattleSceneManager.Instance.SetPlayerNum(playerNum);
    }
    public void PlayerIsDead()
    {
        hp.Value = 0;
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
    public int GetPlayerNum()
    {
        return playerNum;
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
