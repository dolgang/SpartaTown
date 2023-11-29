using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    private string animationsState = "AnimationState";

    enum States
    {
        Idle = 0,
        Move = 1
    }

    private TopDownCharacterController _controller;
    private Animator _animator;


    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += RunAniSet;
    }

    private void RunAniSet(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            _animator.SetInteger(animationsState, (int)States.Move);
        }
        else
        {
            _animator.SetInteger(animationsState, (int)States.Idle);
        }
    }
}
