using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private TrailRenderer dashTrail;

    private PlayerControls playerControls;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    public bool FacingLeft { get { return isFacingLeft; } private set { isFacingLeft = value; } }

    private bool isFacingLeft = false;
    private bool isDashing = false;

    protected override void Awake()
    {
        base.Awake();
        
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
    }

    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            moveSpeed *= dashSpeed;
            dashTrail.emitting = true;
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        yield return new WaitForSeconds(dashDuration);
        moveSpeed /= dashSpeed;
        dashTrail.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        UpdatePlayerDirection();
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movementInput = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movementInput.x);
        myAnimator.SetFloat("moveY", movementInput.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movementInput * (moveSpeed * Time.fixedDeltaTime));
    }

    private void UpdatePlayerDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerPositionOnScreen = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePosition.x < playerPositionOnScreen.x)
        {
            mySpriteRenderer.flipX = true;
            FacingLeft = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
            FacingLeft = false;
        }
    }
}
