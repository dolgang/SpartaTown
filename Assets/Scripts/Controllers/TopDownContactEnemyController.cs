using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRanget;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private HealthSystem healthSystem;
    private HealthSystem _collidingTargetHealthSystem;
    private TopDownMovement _collidingMovement;

    protected override void Start()
    {
        base.Start();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        followRanget = 100f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_isCollidingWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 directrion = Vector2.zero;
        if(DistanceToTarget() < followRanget)
        {
            directrion = DirectionToTarget();
        }

        CallMoveEvent(directrion);
        Rotate(directrion);
    }

    private void Rotate(Vector2 directrion)
    {
        float rotZ = Mathf.Atan2(directrion.y, directrion.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject;

        if (!receiver.CompareTag(targetTag))
        {
            return;
        }

        _collidingTargetHealthSystem = receiver.GetComponent<HealthSystem>();
        if(_collidingTargetHealthSystem != null)
        {
            _isCollidingWithTarget = true;
        }

        _collidingMovement = receiver.GetComponent<TopDownMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
        {
            return;
        }
        _isCollidingWithTarget = false;
    }

    private void ApplyHealthChange()
    {
        AttackSO attackSO = Stats.CurrentStats.attackSO;
        bool hasBeenChanged = _collidingTargetHealthSystem.ChangeHealth(-attackSO.power);
        if(attackSO.isOnKnockback && _collidingMovement != null)
        {
            _collidingMovement.ApplyKnockback(transform, attackSO.knockbackPower, attackSO.knockbackTime);
        }
    }
}
