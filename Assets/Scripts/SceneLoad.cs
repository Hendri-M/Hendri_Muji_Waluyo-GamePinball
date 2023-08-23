using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
     public void LoadGame()
    {
          SceneManager.LoadScene("Games");
     }
     public void LoadMenu()
    {
          SceneManager.LoadScene("Main Menu");
     }
     public void LoadCredits()
    {
          SceneManager.LoadScene("Credits");
     }
}
