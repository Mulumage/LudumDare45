using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDigOutBehaviour : StateMachineBehaviour
{
    private Vector2 _direction;

    private float _time;
    private static readonly int Shoot = Animator.StringToHash("Shoot");


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _time = Random.Range(1f, 4f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _time -= Time.fixedDeltaTime;
        
        if (_time < 0)
            animator.SetTrigger(Shoot);
    }
}
