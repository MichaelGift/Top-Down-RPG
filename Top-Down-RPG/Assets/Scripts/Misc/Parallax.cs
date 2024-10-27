using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxOffset = -.15f;

    private Camera mainCamera;
    private Vector2 lastCameraPosition;
    private Vector2 travelDistance => (Vector2)mainCamera.transform.position - lastCameraPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        lastCameraPosition = mainCamera.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position  = lastCameraPosition + travelDistance * parallaxOffset;
    }
}
