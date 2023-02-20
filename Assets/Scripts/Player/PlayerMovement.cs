using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    private enum State {
        Normal,
        Rolling,
    }

    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector3 rollDir;
    private float rollSpeed;
    private bool rollTrue = false;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    private State state;

    private void Awake() {
        state = State.Normal;

    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case State.Normal:
        

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        moveDir = new Vector3(movement.x, movement.y).normalized;

        //checks if movement is not equal to 0 (so if you are moving, the lastMoveDir is set to moveDir)
        if (movement.x != 0 || movement.y != 0) {
            lastMoveDir = moveDir;
        }

        //Gets the space button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //makes the roll direction equal to your last moving direction
            rollDir = lastMoveDir;
            //changes how fast rolling is
            rollSpeed = 40f;

            state = State.Rolling;
            
        }
            break;
        case State.Rolling:
            float rollSpeedDropMultiplier = 5f;
            rollTrue = true;
            //plays rolling animation when rolling
            animator.SetBool("Rolling", rollTrue);
            rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

            float rollSpeedMinimum = 15f;
            if(rollSpeed < rollSpeedMinimum){
                state = State.Normal;
                rollTrue = false;
                //plays rolling animation when rolling
                animator.SetBool("Rolling", rollTrue);
            }
            break;
        }
        
    }

    //movement
    void FixedUpdate()
    {
        switch (state) {
            case State.Normal:
                //Normal WASD movement
                // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                rb.velocity = moveDir * moveSpeed;

        
        break;
        //rolling movement.
    case State.Rolling:
        rb.velocity = rollDir * rollSpeed;
        break;
        }
    }
}