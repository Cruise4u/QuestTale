using System;
using UnityEngine;

public class UnitAnimations : MonoBehaviour
{
    public Animator animator;
    AnimatorStateInfo animatorStateInfo;


    public void SwitchToAnimationState(string state)
    {
        switch (state)
        {
            case "Idle":


                break;
            case "Walking":

                animator.SetBool("isMoving", true);
                break;
            case "Attack":


                break;
        }
    }
}
