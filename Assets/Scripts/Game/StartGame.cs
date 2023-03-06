using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //starts the game on button click 
    void PlayGame()
    {
        Debug.Log("Play Clicked");
        SceneManager.LoadScene(1);
    }

   
}
