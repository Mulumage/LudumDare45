using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDigInBehaviour : StateMachineBehaviour
{
    public float Speed = 100;

    private Rigidbody2D _rb;
    private Vector2 _direction;

    private float _time;

    private static readonly int DigOut = Animator.StringToHash("DigOut");


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _direction.x = Random.Range(-10, 10);
        _direction.y = Random.Range(-10, 10);
        _time = Random.Range(2f, 6f);
        _rb.velocity = _direction.normalized * Speed * Time.deltaTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.velocity = _rb.velocity.normalized * Speed * Time.deltaTime;
        
        _time -= Time.deltaTime;

        if (_time > 0)
            return;

        
        animator.SetTrigger(DigOut);
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.velocity = Vector2.zero;
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