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
    // �v���C���[�̔ԍ�
    [SerializeField]
    public int playerNum = 0;
    // ���X�|�[�����W
    [SerializeField]
    private GameObject respawnPoint;
    [SerializeField]
    public PlayerStatus playerStatus;
    // PlaeyrHp
    [SerializeField]
    private ReactiveProperty<int> hp = new ReactiveProperty<int>(100);

    public bool matchingFlag { get; private set; } = false;

    // Plaeyr�̎c�@
    public int remainingLives { get; set; } = 3;

    private void Update()
    {
        hp.Where(_ => hp.Value <= 0).Subscribe(_ => playerStatus = PlayerStatus.Dead);
        hp.Where(_ => hp.Value >= 100).Subscribe(_ => playerStatus = PlayerStatus.Alive);

        if (GameManager.Instance.sceneList == GameManager.SceneList.MatchingScene)
        {
            if (Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("joystick 2 button 2")
                || Input.GetKeyDown("joystick 3 button 2") || Input.GetKeyDown("joystick 4 button 2"))
            {
                MatchingSceneManager.Instance.SetMatchingFlag(playerNum, true);
            }
        }
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
