using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationControl : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private float walkSpeed = 0f;

    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityX = rb.velocity.x;
        float velocityY = rb.velocity.y;

        if (velocityX < walkSpeed && GetComponent<Transform>().rotation.y==0|| velocityX > walkSpeed && GetComponent<Transform>().rotation.y != 0)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Backwards", true);
        }
        else if (velocityX > walkSpeed && GetComponent<Transform>().rotation.y == 0 || velocityX < walkSpeed && GetComponent<Transform>().rotation.y != 0)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Backwards", false);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Soft Punch"))
        {
            animator.SetBool("SoftPunch", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Strong Kick"))
        {
            animator.SetBool("StrongKick", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Front Dash"))
        {
            animator.SetBool("FrontDash", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Back Dash"))
        {
            animator.SetBool("BackDash", false);
        }
    }

    public void DoSoftPunch()
    {
        animator.SetBool("SoftPunch", true);
    }
    public void DoStrongKick()
    {
        animator.SetBool("StrongKick", true);
    }

    public void DoDash(bool isRight)
    {
        float velocityX = rb.velocity.x;
        float velocityY = rb.velocity.y;

        if (velocityX < walkSpeed && GetComponent<Transform>().rotation.y == 0 || velocityX > walkSpeed && GetComponent<Transform>().rotation.y != 0)
        {
            animator.SetBool("BackDash", true);
        }
        else if (velocityX > walkSpeed && GetComponent<Transform>().rotation.y == 0 || velocityX < walkSpeed && GetComponent<Transform>().rotation.y != 0)
        {
            animator.SetBool("FrontDash", true);
        }
    }
}
