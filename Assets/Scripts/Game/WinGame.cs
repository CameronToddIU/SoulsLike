using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameEnding gameEnding;
    public GameObject player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            gameEnding.PlayerEnteredEnd();
        }
    }
}
