using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
     public AudioSource audioSource;
     public GameObject sfxAudioBumper;
     public GameObject sfxAudioSwitchOn;
     public GameObject sfxAudioSwitchOff;
     // Start is called before the first frame update
     void Start()
    {
          // Jalankan BGM pada saat play game
          PlayBGM();
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM()
    {
          audioSource.Play();
     }
    public void PlaySFXBumper(Vector3 spawnPosition)
    {
          GameObject.Instantiate(sfxAudioBumper, spawnPosition, Quaternion.identity);
     }
    public void PlaySFXSwitchOn(Vector3 spawnPosition)
    {
          GameObject.Instantiate(sfxAudioSwitchOn, spawnPosition, Quaternion.identity);
     }
    public void PlaySFXSwitchOff(Vector3 spawnPosition)
    {
          GameObject.Instantiate(sfxAudioSwitchOff, spawnPosition, Quaternion.identity);
     }
}
