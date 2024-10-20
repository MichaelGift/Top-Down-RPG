using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls controls;
    private Animator animator;

    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private void Awake()
    {
        controls = new PlayerControls();
        animator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        FollowMouseWithSword();
    }

    private void Start()
    {
        controls.Combat.Attack.performed += _ => Attack();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void FollowMouseWithSword()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldToScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(worldToScreenPoint.y, worldToScreenPoint.x) * Mathf.Rad2Deg;


        if (mousePosition.x < worldToScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
}
