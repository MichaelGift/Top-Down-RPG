using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!ps.IsAlive()) Destroy(gameObject);
    }
}
