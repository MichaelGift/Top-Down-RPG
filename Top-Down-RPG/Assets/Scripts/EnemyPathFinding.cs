using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Knockback knockback;
    
    private Vector2 movementDir;
    private Rigidbody2D rb;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (knockback.IsGettingKnockedBack) return;
        rb.MovePosition(rb.position + movementDir * (moveSpeed * Time.fixedDeltaTime));
    }
    
    
    public void MoveTo(Vector2 targetPosition)
    {
        movementDir = targetPosition;
    }
}
