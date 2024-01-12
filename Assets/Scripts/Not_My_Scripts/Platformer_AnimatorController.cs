using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer_Animator : MonoBehaviour
{
    public bool IsAttacking { get; private set; }

    Animator anim;
    SpriteRenderer sprite;

    enum State
    {
        Idle,
        Jumping,
        Walking,
        Attacking
    }

    private State state = State.Idle;


    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        //start off facing to the right.
        anim.SetBool("IsWalking", false);
        anim.SetInteger("WalkDir", 1);
        sprite.flipX = true;
    }

    private void Update()
    {
        if (state == State.Idle)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                state = State.Walking;
            } else if (Input.GetAxis("Vertical") > 0)
            {
                state = State.Jumping;
            }

            anim.SetBool("IsWalking", false);
        }

        if (state == State.Walking)
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                state = State.Idle;
            } else if (Input.GetAxis("Vertical") > 0)
            {
                state = State.Jumping;
            } else if (Input.GetMouseButton(0))
            {
                state = State.Attacking;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            
            anim.SetBool("IsWalking", true);
        }

        if (state == State.Jumping)
        {
            
        }

        if (state == State.Attacking)
        {
            
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("IsWalking", true);

            if (Input.GetAxis("Horizontal") > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Attack");
            anim.SetBool("IsWalking", false);
        }

        IsAttacking = anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
    }
}
