using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    [SerializeField] private int activeLevelIndex;

    private void Start()
    {

        if (activeLevelIndex == SceneManager.GetActiveScene().buildIndex){
            PlayerController.Instance.transform.position = transform.position;
            CameraController.Instance.TrackPlayer();
        }
        
    }
}
