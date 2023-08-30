using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
     public GameObject vfxSource1;
     public GameObject vfxSource2;

     public void PlayVFXBumper(Vector3 spawnPosition)
     {
          GameObject.Instantiate(vfxSource1, spawnPosition, Quaternion.identity);
     }
     public void PlayVFXSwitch(Vector3 spawnPosition)
     {
          GameObject.Instantiate(vfxSource2, spawnPosition, Quaternion.identity);
     }
}
