using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
     public Collider bola;
     public GameObject panel;

     private void OnTriggerEnter(Collider collider)
     {
        if (collider == bola)
        {
               Debug.Log("GAME OVER, PANEL MUNCUL!!!!");
               panel.SetActive(true);
          }
     }
     // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
