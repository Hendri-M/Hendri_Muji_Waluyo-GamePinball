using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BumperController : MonoBehaviour
{
     public Collider bola;
     public float multiplier;
     public Color color;
     public AudioManager audioManager;

     private new Renderer renderer;
     private Animator animator;

     public ScoreManager scoreManager;
     public VFXManager VFXManager;

     void Start()
    {
          renderer = GetComponent<Renderer>();
          animator = GetComponent<Animator>();
          renderer.material.color = color;

          Debug.Log(color);
     }
     private void OnCollisionEnter(Collision collision)
     {
        if(collision.collider == bola)
        {
               Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
               bolaRig.velocity *= multiplier;

               animator.SetTrigger("Trigger");

               audioManager.PlaySFXBumper(collision.transform.position);
               VFXManager.PlayVFXBumper(collision.transform.position);
               scoreManager.AddScore(5);

          }
     }
}
