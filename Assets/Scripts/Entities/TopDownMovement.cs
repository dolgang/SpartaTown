using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    public float movementSpeed = 5.0f;

    private Vector2 _movementDirectrion = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirectrion);
    }

    private void Move(Vector2 direction)
    {
        _movementDirectrion = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * movementSpeed;

        _rigidbody.velocity = direction;
    }
}
