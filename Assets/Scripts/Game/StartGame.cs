using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //starts the game on button click 
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }

   
}
