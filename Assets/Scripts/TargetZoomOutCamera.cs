using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoomOutCamera : MonoBehaviour
{
     public Collider bola;
     public CameraController cameraController;

     private void OnTriggerEnter(Collider collider)
     {
        if (collider == bola)
        {
               cameraController.BackToDefault();
          }
     }
}
