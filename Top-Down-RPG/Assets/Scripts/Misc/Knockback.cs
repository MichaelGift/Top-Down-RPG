using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool IsGettingKnockedBack { get; private set; }
    [SerializeField] private float recoveryTime = 0.1f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Applies a knockback force to the object in the direction opposite to the given transform.
    /// </summary>
    /// <param name="knockbackDirection">The transform indicating the direction from which the knockback originates.</param>
    /// <param name="force">The magnitude of the knockback force to be applied.</param>
    public void GetKnockedBack(Transform knockbackDirection, float force)
    {
        IsGettingKnockedBack = true;
        Vector2 difference = (transform.position - knockbackDirection.position).normalized * force * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(RecoverFromKnockback());
    }

    private IEnumerator RecoverFromKnockback()
    {
        yield return new WaitForSeconds(recoveryTime);
        rb.velocity = Vector2.zero;
        IsGettingKnockedBack = false;
    }
}
