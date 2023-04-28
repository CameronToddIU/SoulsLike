using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow1 : MonoBehaviour
{
    public AudioSource EnemyMusic;

    public Rigidbody2D enemyRB;
    public Transform attackPointEnemy;
    public BoxCollider2D bc;
    public PlayerMovement playerMovement;
    public Enemy enemyScript;
    public Animator animator;
    public SpriteRenderer sprite;

    public Transform enemySword;

    public float speed;
    public Transform target;
    public float minimumDistance;
    public float attackRangeEnemy = 0.5f;
    public int enemyChaseRange = 30;
    public bool enemyActive = false;


    private bool attacking = false;
    private bool shouldMove = false;

    private float timeTracker = 1.4f;
    private float timeTracker2 = 1f;
    private float timeTracker3 = 1.4f;
    private float timeTrackerHitting = 0f;
    private bool PlayerGotHit = false;

    private void Update()
    {
        if(enemyScript.die != true)
        {
            if(attacking != true)
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Chase", true);
                
                  //  Debug.Log("Distance from target: "+ Vector2.Distance(transform.position, target.position));
               	if (Vector2.Distance(transform.position, target.position) > minimumDistance && Vector2.Distance(transform.position, target.position) < enemyChaseRange && enemyActive == true)
                {
                    /*//activates battle music
                    AmbianceManager.SwapTrack(EnemyMusic, true);*/

                    //makes the enemy sword face player
                    Vector3 dir = (target.position - transform.position).normalized;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    enemySword.eulerAngles = new Vector3(0,0,angle);
                    MirrorTest(angle);
                    //makes enemy sword face player


                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    
                } else
                {
                    animator.SetBool("Chase", false);
                    attacking = true;
                    animator.SetBool("Attack", true);
                    timeTracker2 = 2f;
                }

            }else
            {
                animator.SetBool("Attack", true);
                PlayerGotHit = false;
                Damage();
                PlayerGotHit = false;
                animator.SetBool("Chase", false);

                timeTracker2 -= Time.deltaTime;
                if(shouldMove == true)
                {
                    animator.SetBool("Attack", false);
                    animator.SetBool("Chase", true);
                    
                    Debug.Log(timeTracker2);
                    Vector3 dir = (target.position - transform.position).normalized;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    enemySword.eulerAngles = new Vector3(0,0,angle);
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    shouldMove = false;
                    MirrorTest(angle);
                }

            }
        } else {
            attacking = false;
        }
    }

    public void MirrorTest(float swordAngle)
    {
        if(swordAngle > 90 || swordAngle < -90)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }


    public void Active() 
    {
        enemyActive = true;    
    }

    void Damage()
    {
            attacking = true;
            timeTracker -= Time.deltaTime;
            timeTracker3 -= Time.deltaTime;
            timeTrackerHitting -= Time.deltaTime;
            if(timeTracker <= .35f)
            {
                if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
                {
                    if(PlayerGotHit != true && timeTrackerHitting < 0)
                    {
                        Debug.Log("Hitting Player");
                        playerMovement.LossHealth();
                        PlayerGotHit = true;
                        timeTrackerHitting = .5f;
                    }

                }
                if(timeTracker3 < 0)
                {
                    Debug.Log("See");
                    attacking = false;
                    timeTracker = 1.45f;
                    timeTracker3 = 1.45f;
                    shouldMove = true;
                }
            }
        
    }

}
