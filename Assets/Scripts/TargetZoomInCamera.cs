using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoomInCamera : MonoBehaviour
{
     public Collider bola;
     public CameraController cameraController;
     public float length;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == bola)
        {
               cameraController.FollowTarget(bola.transform, length);
          }
    }
}
