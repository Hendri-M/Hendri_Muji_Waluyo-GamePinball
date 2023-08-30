using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringRamo : MonoBehaviour
{
     public Collider bola;
     public ScoreManager scoreManager;

     private void OnTriggerEnter(Collider collider)
     {
          if (collider == bola)
          {
            scoreManager.AddScore(20);
          }
     }
}
