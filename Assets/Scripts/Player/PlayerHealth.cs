using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public GameEnding gameEnding;
    public PlayerAttack playerAttack;


    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int meter;
    public int numOfMeters;
    public Image[] meters;
    public Sprite fullMeterLeft;
    public Sprite fullMeterCenter;
    public Sprite fullMeterRight;
    public Sprite emptyMeterLeft;
    public Sprite emptyMeterCenter;
    public Sprite emptyMeterRight;

    public AudioSource healAudio;


    // Start is called before the first frame update
    void Start()
    {
        health = numOfHearts;
        meter = 0;
    }

    public void Damaged(int damageTaken) 
    {
        Debug.Log("Player Damaged");
        health -= damageTaken;
        if (health <= 0) 
        {
            Die();
        }
    
    }

    public void Die() 
    {
        Debug.Log("Player Died");
        gameEnding.PlayerDied();
        
    }
    public void Heal() 
    {
        Debug.Log("Player Healed!");
        health = numOfHearts;
        healAudio.Play();
    }
    // Update is called once per frame
    void Update()
    {
        meter = playerAttack.getMeter();
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        if (meter > numOfMeters) 
        {
            meter = numOfMeters;
        }

        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else 
            {
                hearts[i].enabled = false;
            }
        }

        for (int i = 0; i < meters.Length; i++)
        {
            if (i < meter)
            {
                if (i == 0)
                {
                    meters[i].sprite = fullMeterLeft;
                }
                else if (i == meters.Length - 1)
                {
                    meters[i].sprite = fullMeterRight;
                }
                else
                {
                    meters[i].sprite = fullMeterCenter;
                }
            }
            else
            {
                if (i == 0)
                {
                    meters[i].sprite = emptyMeterLeft;
                }
                else if (i == meters.Length - 1)
                {
                    meters[i].sprite = emptyMeterRight;  
                }
                else 
                {      
                    meters[i].sprite = emptyMeterCenter;
                }
            }
            if (i < numOfMeters)
            {
                meters[i].enabled = true;
            }
            else
            {
                meters[i].enabled = false;
            }
        }
    }
}
