using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    
    private Vector2 movementDir;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDir * (moveSpeed * Time.fixedDeltaTime));
    }
    
    
    public void MoveTo(Vector2 targetPosition)
    {
        movementDir = targetPosition;
    }
}
