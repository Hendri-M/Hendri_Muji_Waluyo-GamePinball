using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
     // enum untuk mengatur state
     private enum SwitchState
     {
        off,
        on,
        blink
     }
     public Collider bola;

     // Variabel untuk material
     public Material offMaterial;
     public Material onMaterial;

     // State untuk switch menyala atau mati
     private SwitchState state;

     // Komponen renderer pada objek yang akan diubah
     public new Renderer renderer;

     public ScoreManager scoreManager;
     public AudioManager audioManager;
     public VFXManager vfxManager;


     void Start()
     {
          renderer = GetComponent<Renderer>();
          lampuSwitch(false);

          renderer.material = offMaterial;

          StartCoroutine(BlinkTimeStart(5));
     }

     private void lampuSwitch(bool active)
     {
          if(active == true)
          {
               state = SwitchState.on;
               renderer.material = onMaterial;

               // Menghentikan blink
               StopAllCoroutines();
          }
          else 
          {
               state = SwitchState.off;
               renderer.material = offMaterial;
               StartCoroutine(BlinkTimeStart(5));
          }
     }
     private void OnTriggerEnter(Collider collider)
     {
        if(collider == bola)
        {
               Toggle();
        }
     }

     private void Toggle()
     {
        if (state == SwitchState.on)
        {
               lampuSwitch(false);
               audioManager.PlaySFXSwitchOff(GetComponent<Collider>().transform.position);
          }
        else 
        {
               lampuSwitch(true);
               audioManager.PlaySFXSwitchOn(GetComponent<Collider>().transform.position);
               vfxManager.PlayVFXSwitch(GetComponent<Collider>().transform.position);
          }
          scoreManager.AddScore(10);
     }

     private IEnumerator Blink(int times)
     {
          state = SwitchState.blink;

          for (int i = 0; i < times; i++)
          {
               renderer.material = onMaterial;
               yield return new WaitForSeconds(0.5f);
               renderer.material = offMaterial;
               yield return new WaitForSeconds(0.5f);
          }
          state = SwitchState.off;
          StartCoroutine(BlinkTimeStart(5));
     }

     private IEnumerator BlinkTimeStart(float time)
     {
          yield return new WaitForSeconds(time);
          StartCoroutine(Blink(2));
     }
}
