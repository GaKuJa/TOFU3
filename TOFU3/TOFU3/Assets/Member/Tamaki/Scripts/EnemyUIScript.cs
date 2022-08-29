using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIScript : MonoBehaviour
{
    [SerializeField]
    private Text enemyPlayerText;
    private string enemyPlayerName;
    [SerializeField]
    private PlayerStata playerStatas;

    private void Start()
    {
        enemyPlayerName = playerStatas.GetPlayerName();
    }

    private void Update()
    {
        enemyPlayerText.text = enemyPlayerName;
    }

    
}
