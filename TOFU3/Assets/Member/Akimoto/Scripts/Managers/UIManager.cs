using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Player> playerList = new List<Player>();
    [SerializeField]
    private List<Text> textList = new List<Text>();
    
    // Update is called once per frame
    void Update()
    {
        textList[0].text = playerList[0].GetHp().ToString();
        textList[1].text = playerList[1].GetHp().ToString();
    }
}
