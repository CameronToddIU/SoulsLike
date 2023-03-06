using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Animator animator;
    public Animator animator2;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public int meter = 0;
    public bool meterReady = false;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && meterReady) {
            //press Left Ctrl to heal
            Debug.Log("Meter Used");
            playerHealth.Heal();
            meter = 0;
            meterReady = false;
        }

        //checks if you can attack yet
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                
                // makes the attack time lower so you can attack again after enough time passes
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //play attack animation
        animator2.SetTrigger("Attack");

        //Detect if enemy is in range to be hit
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damge Enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            meter = meter + 1;
            if (meter >= 3)
            {
                Debug.Log(meter);
                meterReady = true;
                //playerHealth.Heal();
                //meter = 0;
            }
        }
        
    }
    
    public int getMeter()
    {
        return meter;
    }

    //shows the attack sphere for player in unity
    void OnDrawGizmosSelected() 
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
