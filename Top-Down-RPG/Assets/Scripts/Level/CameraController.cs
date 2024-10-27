using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera virtualCamera;

    public void TrackPlayer(){
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        virtualCamera.Follow = PlayerController.Instance.transform;
    }

}
