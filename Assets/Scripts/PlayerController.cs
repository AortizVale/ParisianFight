using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction movement;

    public float speed = 5f;
    public float JumpForce = 2.5f;
    private Rigidbody2D body;

    [SerializeField]
    public Camera playerCamera;

    //Dash variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;


    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Gameplay");
        body = this.GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        int playerID = GetComponent<PlayerInput>().playerIndex + 1;
        player.FindAction("Soft Punch").started += DoSoftPunch;
        player.FindAction("Strong Punch").started += DoStrongPunch;
        player.FindAction("Soft Kick").started += DoSoftKick;
        player.FindAction("Strong Kick").started += DoStrongKick;
        player.FindAction("Left Dash").started += DoLeftDash;
        player.FindAction("Right Dash").started += DoRightDash;
        player.FindAction("Grab").started += DoGrab;
        player.FindAction("Super Move").started += DoSuperMove;
        player.FindAction("Pause").started += DoPause;

        movement = player.FindAction("Movement");
        player.Enable();
    }

    private void DoPause(InputAction.CallbackContext context)
    {
        printAttack("Pause");
    }

    private void DoGrab(InputAction.CallbackContext context)
    {
        printAttack("Grab");
    }

    private void DoRightDash(InputAction.CallbackContext context)
    {
        printAttack("Right Dash");
        StartCoroutine(Dash(true));
    }

    private void DoLeftDash(InputAction.CallbackContext context)
    {
        printAttack("Left Dash");
        StartCoroutine(Dash(false));
    }

    private void DoStrongKick(InputAction.CallbackContext context)
    {
        printAttack("Strong kick");
        GetComponent<PlayerAnimationControl>().DoStrongKick();
    }

    private void DoSoftKick(InputAction.CallbackContext context)
    {
        printAttack("Soft kick");
    }

    private void DoStrongPunch(InputAction.CallbackContext context)
    {
        printAttack("Strong punch");
    }

    private void DoSuperMove(InputAction.CallbackContext context)
    {
        printAttack("Super move");
    }

    private void DoSoftPunch(InputAction.CallbackContext context)
    {
        printAttack("Soft punch");
        GetComponent<PlayerAnimationControl>().DoSoftPunch();
    }

    private void printAttack(String attackName)
    {
        int playerID = GetComponent<PlayerInput>().playerIndex;
        Debug.Log("Player " + (playerID + 1) + " did " +attackName+"!!!!!");
    }

    public void OnDisable()
    {
        player.FindAction("Soft Punch").started -= DoSoftPunch;
        player.FindAction("Strong Punch").started -= DoStrongPunch;
        player.FindAction("Soft Kick").started -= DoSoftKick;
        player.FindAction("Strong Kick").started -= DoStrongKick;
        player.FindAction("Left Dash").started -= DoLeftDash;
        player.FindAction("Right Dash").started -= DoRightDash;
        player.FindAction("Grab").started -= DoGrab;
        player.FindAction("Super Move").started -= DoSuperMove;
        player.FindAction("Pause").started -= DoPause;
        player.Disable();
    }

    private void Update()
    {
        if (isDashing) 
        { 
            return;
        }

        float horizontalInput = movement.ReadValue<Vector2>().x; //Acceder de manera constante al eje horizontal de entrada
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);//Agregamos velocidad en el eje horizontal para mover el personaje
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private IEnumerator Dash(bool isRight)
    {
  
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        
        if (isRight)
        {
            body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        else
        {
            body.velocity = new Vector2(transform.localScale.x * (-1) * dashingPower, 0f);
        }
        GetComponent<PlayerAnimationControl>().DoDash(isRight);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = false;

    }
private Vector2 GetCameraRight(Camera playerCamera)
    {
        Vector2 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}
