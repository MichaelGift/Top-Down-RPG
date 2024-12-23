using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private Transform weaponCollider;


    private PlayerControls controls;
    private Animator animator;

    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;
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
        weaponCollider.gameObject.SetActive(true);
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.SetParent(this.transform.parent);
    }

    public void OnAttackAnimationComplete()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public void FlipSlashUpAnimationEvent(){
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (playerController.FacingLeft) slashAnim.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void FlipSlashDownAnimationEvent(){
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerController.FacingLeft) slashAnim.GetComponent<SpriteRenderer>().flipX = true;
    }


    private void FollowMouseWithSword()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldToScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(worldToScreenPoint.y, worldToScreenPoint.x) * Mathf.Rad2Deg;


        if (mousePosition.x < worldToScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
