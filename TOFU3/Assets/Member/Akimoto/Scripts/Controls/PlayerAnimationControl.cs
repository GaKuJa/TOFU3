using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    [SerializeField]
    private Animator tofuAnimator = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            WalkAnimationStart();
        if (Input.GetKeyUp(KeyCode.Space))
            WalkAnimationStop();
    }

    public void WalkAnimationStart()
    {
        tofuAnimator.SetBool("Walk", true);
    }

    public void WalkAnimationStop()
    {
        tofuAnimator.SetBool("Walk", false);
    }
}
