using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMultiDisplay : MonoBehaviour
{
    private void Start()
    {
        int maxDisplayCount = GameManager.Instance.GetMatchingNum();
        for(int i = 0; i < maxDisplayCount && i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
