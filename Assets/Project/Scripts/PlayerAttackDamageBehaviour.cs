﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamageBehaviour : StateMachineBehaviour
{
    [Range(0.0f, 1.0f)]
    public float movementSpeedPercentDuringAttack;
    public bool isDashEnabled;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ComboManager.instance.setCanDamageEnemy(true);

        ComboManager.instance.setActiveAttack(true);

        ComboManager.instance.setMovementSpeedPercentDuringAttack(movementSpeedPercentDuringAttack);
        ComboManager.instance.setIfDodgeIsEnabled(isDashEnabled);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ComboManager.instance.setCanDamageEnemy(false);
        ComboManager.instance.setMovementSpeedPercentDuringAttack(1.0f);
        ComboManager.instance.setIfDodgeIsEnabled(true);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
