using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Animator animator;
    // public Animator animatorAttack;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    public int attackDamage = 1;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {

        //checks if you can attack yet
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))//testing purpose, delete and replace with enemy ai later
            {
                Attack();

                // makes the attack time lower so you can attack again after enough time passes
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {


        //Detect if player is in range to be hit
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //Damage Player
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Attack Player");
            player.GetComponent<PlayerHealth>().Damaged(attackDamage);
        }


    }

    //shows the attack sphere for enemy in unity
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
