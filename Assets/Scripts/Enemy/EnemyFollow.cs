using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public Rigidbody2D enemyRB;
    public Transform attackPointEnemy;
    public BoxCollider2D bc;
    public PlayerMovement playerMovement;
    public Enemy enemyScript;

    public Transform enemySword;


    public float speed;
    public Transform target;
    public float minimumDistance;
    public float attackRangeEnemy = 0.5f;

    private bool attacking = false;

    private float timeTracker = 2f;



    private void Update()
    {
        if(enemyScript.die != true)
        {
            if(attacking != true)
            {
                if (Vector2.Distance(transform.position, target.position) > minimumDistance)
                {
                    //makes the enemy sword face player
                    Vector3 dir = (target.position - transform.position).normalized;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    enemySword.eulerAngles = new Vector3(0,0,angle);
                    //makes enemy sword face player


                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    
                } else
                {
                    attacking = true;
                }

            }else
            {
                Damage();
                // timeTracker -= Time.deltaTime;
                // if(timeTracker < 0)
                // {
                //     if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
                //     {
                //         Debug.Log("Hitting Player");
                //     }
                //     attacking = false;
                //     timeTracker = 2f;
                // }

            }
        }
    }




    void Damage()
    {
            attacking = true;
            timeTracker -= Time.deltaTime;
            if(timeTracker < 0)
            {
                if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
                {
                    Debug.Log("Hitting Player");
                    playerMovement.LossHealth();
                }
                attacking = false;
                timeTracker = 2f;
            }
    }

    //shows the attack sphere for player in unity
    void OnDrawGizmosSelected() 
    {
        if(attackPointEnemy == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointEnemy.position, attackRangeEnemy);
    }
}
