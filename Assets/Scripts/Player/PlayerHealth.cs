using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public GameEnding gameEnding;

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        health = numOfHearts;
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
        animator.SetBool("Dead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameEnding.PlayerDied();
        
    }
    public void Heal() 
    {
        Debug.Log("Player Healed!");
        health = numOfHearts;
    }
    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
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
    }
}
