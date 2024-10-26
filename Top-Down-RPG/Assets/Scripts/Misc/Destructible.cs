using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destructionVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DamageSource>())
        {
            Instantiate(destructionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
