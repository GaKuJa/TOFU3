using UnityEngine;
using UnityEngine.UI;

public class PlayerRemainingUI : MonoBehaviour
{
    // プレイヤーのステータススクリプト
    [SerializeField]
    private Player playerStatus = null;
    // プレイヤーの残機表示UI
    [SerializeField]
    private Text remainingText = null;
    private void Update()
    {
        RemainingDisplay();
    }

    private void RemainingDisplay()
    {
        // 残機が 0 以上なら
        if (playerStatus.remainingLives >= 0)
            // 表示
            remainingText.text = playerStatus.remainingLives.ToString("×" + playerStatus.remainingLives);
    }
}
