using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource clickAudio;
    //starts the game on button click 
    public void PlayGame()
    {
        clickAudio.Play();
        SceneManager.LoadScene(1);
    }
    public void QuitGame() 
    {
        clickAudio.Play();
        Application.Quit();
    }

   
}
