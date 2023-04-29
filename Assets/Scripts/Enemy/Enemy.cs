using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;
    public Animator animatorAttack;
    public GameEnding gameEnding;

    public int maxHealth = 100;
    public bool die = false;
    int currentHealth;

    void Start() 
        {
            currentHealth = maxHealth;
        }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        die = true;
        animatorAttack.SetTrigger("AttackDead");
        animator.SetBool("Dead", true);
        Debug.Log("Enemy Died");
        if (this.CompareTag("Boss Enemy"))
        {
            gameEnding.BossDied();
        }
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
