using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     // Waktu untuk kembali ke poisi awal
     public float returnTime;
     // Kecepatan kamera dalam mengikuti target
     public float followSpeed;
     // Jarak kamera dengan target
     public float length;
     public Transform target;
     private Vector3 defaultPost;

     // State hasTarget yang diambil dari nilai target != null
     public bool hasTarget{get { return target != null; } }

     // Start is called before the first frame update
     void Start()
    {
          defaultPost = transform.position;
          target = null;
     }

    // Update is called once per frame
    void Update()
    {
        // fungsi update kita ubah total menjadi fungsi untuk kamera mengikuti object
		// secara terus menerus sampai target kamera dikosongkam kembali
        if(hasTarget)
        {
            Vector3 targetCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetCameraDirection * length);

               // disini kamera dipindahkan menggunakan lerp biasa yang terjadi tiap update
               // Lerp yang dijalankan disini secara otomatis menjadi smoothing karena menggunakan
               // transform.position secara langsung
               transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
          }
    }

    public void FollowTarget (Transform targetTransform, float targetLength)
    {
          StopAllCoroutines();
          
          target = targetTransform;
          length = targetLength;

     }

     public void BackToDefault()
     {
          StopAllCoroutines();
          target = null;

          StartCoroutine(MovePosition(defaultPost,returnTime));

     }

     private IEnumerator MovePosition(Vector3 target, float time)
     {
          float timer = 0;
          Vector3 start = transform.position;
          while (timer < time)
          {
                // pindahkan posisi camera secara bertahap menggunakan Lerp
			    // Lerp ini kita tambahkan smoothing menggunakan SmoothStep
               transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time));
               
               // di lakukan berulang2 tiap frame selama parameter time
               timer += Time.deltaTime;
               yield return new WaitForEndOfFrame();
          }

          // kalau proses pergerakan sudah selesai, kamera langsung dipaksa pindah
          // ke posisi target tepatnya agar tidak bermasalah nantinya
          transform.position = target;

     }
}
