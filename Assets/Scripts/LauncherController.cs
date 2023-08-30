using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
     public Collider bola;
     public KeyCode input;
     public float maxTimeHold;
     public float maxForce;
     public Color colorPressed;
     public Color colorRelease;
     private new Renderer renderer;
     private bool isHold;
     // Start is called before the first frame update
     void Start()
    {
          isHold = false;
          renderer = GetComponent<Renderer>();
          renderer.material.color = colorRelease;
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
               ReadInput(bola);
          }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
               StartCoroutine(StartHold(collider));
          }
    }

    private IEnumerator StartHold(Collider collider)
    {
          isHold = true;
          float force = 0.0f;
          float timeHold = 0.0f;

          while(Input.GetKey(input))
        {
               force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

               yield return new WaitForEndOfFrame();
               timeHold += Time.deltaTime;
               renderer.material.color = colorPressed;
          }
          collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
          isHold = false;
          renderer.material.color = colorRelease;
     }
}
