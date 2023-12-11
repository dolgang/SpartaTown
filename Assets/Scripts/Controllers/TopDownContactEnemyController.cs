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

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

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
}
