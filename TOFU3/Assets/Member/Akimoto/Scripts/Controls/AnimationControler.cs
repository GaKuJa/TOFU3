using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    [SerializeField]
    private Animator animator = null;

    public void WalkAnimation(bool animationFlag)
    {
        animator.SetBool("Walk", animationFlag);
    }

    public void DathAnimation(bool animationFlag)
    {
        animator.SetBool("Dash", animationFlag);
    }

    public void JumpAnimation(bool animationFlag)
    {
        animator.SetBool("Jump", animationFlag);
    }

    public void LeftWallRunAnimation(bool animationFlag)
    {
        animator.SetBool("Dash", animationFlag);
    }

    public void RightWallRunAnimation(bool animationFlag)
    {
        animator.SetBool("Dash", animationFlag);
    }

    public void CrounchAnimation(bool animationFlag)
    {
        animator.SetBool("Dash", animationFlag);
    }

    public void CrounchingWalkAnimation(bool animationFlag)
    {
        animator.SetBool("Dash", animationFlag);
    }

    public void SlidingAnimation(bool animationFlag)
    {
        animator.SetBool("Dash", animationFlag);
    }
}
