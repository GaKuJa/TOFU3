using UnityEngine;
using UnityEngine.UI;

public class PlayerRemainingUI : MonoBehaviour
{
    // �v���C���[�̃X�e�[�^�X�X�N���v�g
    [SerializeField]
    private Player playerStatus = null;
    // �v���C���[�̎c�@�\��UI
    [SerializeField]
    private Text remainingText = null;
    private void Update()
    {
        RemainingDisplay();
    }

    private void RemainingDisplay()
    {
        // �c�@�� 0 �ȏ�Ȃ�
        if (playerStatus.remainingLives >= 0)
            // �\��
            remainingText.text = playerStatus.remainingLives.ToString("�~" + playerStatus.remainingLives);
    }
}
