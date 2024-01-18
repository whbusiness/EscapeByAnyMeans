using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Move : MonoBehaviour
{
    NewControls controls;
    private Vector3 move, movementDirection, look;
    private bool StopMovement;
    public CharacterController controller;
    public float speed;
    public Animator _anims;
    public Transform center;
    public float distance, radius, rotSpeed;
    public Transform cmCam;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NoiseDetector"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(center.position + center.forward * distance, radius);
            foreach (Collider go in hitColliders)
            {
                if (go.CompareTag("Enemy"))
                {
                    if (Gamepad.current.rightTrigger.isPressed)
                    {
                        Destroy(go.gameObject);
                    }
                    print("HIT");
                }
            }
        }
    }
    private void Awake()
    {
        controls = new NewControls();
        controls.Newactionmap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Move.canceled += ctx => move = Vector2.zero;
        controls.Newactionmap.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Look.canceled += ctx => look = Vector2.zero;
        // controls.Newactionmap.SlowWalk.performed += ctx => isSlowWalking = true;
        // controls.Newactionmap.SlowWalk.canceled += ctx => isSlowWalking = false;
    }
    private void OnEnable()
    {
        controls.Newactionmap.Enable();
    }
    private void OnDisable()
    {
        controls.Newactionmap.Disable();
    }
    private void FixedUpdate()
    {
            CalculateMovement();
    }
    private void Update()
    {
        /*Debug.DrawRay(center.position + new Vector3(-1, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position + new Vector3(1, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position + new Vector3(0.5f, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position + new Vector3(-0.5f, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position, center.forward * distance, Color.green);*/
        //Check for player inputs, Applied movement is in fixedupdate
        movementDirection = new(move.x, 0, move.y);
        // print(look.x);
        movementDirection.Normalize();
        var direction = move.x * transform.right + move.y * transform.forward;
        controller.Move(direction.normalized * speed * Time.deltaTime);
        Animations();
        Rotations();

    }
    private void Rotations()
    {
        if (look.x != 0)
        {
            //transform.localRotation = Quaternion.Euler(lookDirection);
            // float angleA = Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg;
            // _rb.MoveRotation(_rb.rotation * Quaternion.AngleAxis(angleA, transform.forward));
            //transform.rotation = Quaternion.Euler(0f, angleA, 0f);
            //_rb.MoveRotation(_rb.rotation * Quaternion.Euler(lookDirection * rotSpeed));
            float LookingX = look.x * Time.deltaTime * rotSpeed;
            //transform.Rotate(Vector3.up, LookingX);
            //cmCam.localRotation *= Quaternion.Euler(0f, LookingX, 0f);
            var rotateValue = new Vector3(0f, -LookingX, 0f);
            cmCam.eulerAngles -= rotateValue;
        }
        var CharacterRotation = cmCam.rotation;
        CharacterRotation.x = 0;
        CharacterRotation.z = 0;
        transform.rotation = CharacterRotation;
    }

    private void Animations()
    {
        if (move.x == 0 && move.y == 0)
        {
            _anims.SetFloat("Movement", 0); //Idle Animation
        }
        if (move.x != 0 || move.y != 0)
        {
            _anims.SetFloat("Movement", 0.5f); //Sprint Animation
        }
        if (Gamepad.current.rightTrigger.wasPressedThisFrame)//Play attack anim on f key press
        {
            _anims.SetTrigger("Attack");
        }
        if (_anims.GetCurrentAnimatorStateInfo(0).IsName("RightHand@Attack01")) //Checks if Attack animation is running
        {
            StopMovement = true;
        }
        else
        {
            StopMovement = false;
        }
    }

    private void CalculateMovement()
    {
        /* print(move.x);
         if(move.x == 1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection + transform.right;
         }
         else if(move.x == -1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection - transform.right;
         }
         if(move.y == 1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection + transform.forward;
         }
         else if(move.y == -1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection - transform.forward;
         }
         if (move == Vector3.zero)
         {
             _rb.velocity = Vector3.zero;
             //movementDirection = Vector3.zero;
             //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), RotTime);
         }
         if(movementDirection != Vector3.zero && look == Vector3.zero)
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), RotTime);
         }
         if(look != Vector3.zero)
         {
             transform.Rotate(0, look.x * rotSpeed, 0);
         }
         _rb.velocity = speed * Time.fixedDeltaTime * movementDirection + transform.forward;*/
        /* if (k.EnableThrowingKnifeMode)
         {
             transform.Rotate(transform.up * look.x * rotSpeed);
             Vector3 ForwardMovement = transform.forward;
             Vector3 RightMovement = transform.right;
             ForwardMovement.y = 0;
             RightMovement.y = 0;
             Vector3 ForwardMovementY = move.y * ForwardMovement;
             Vector3 ForwardMovementX = move.x * RightMovement;
             Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
             _rb.velocity = speed * Time.fixedDeltaTime * MovementBasedOnCamera.normalized;
             if (MovementBasedOnCamera == Vector3.zero)
             {
                 return;
             }
         }
         else
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), RotTime);
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection;
         }*/
        //_rb.MoveRotation(look.x * rotSpeed * transform.up);
        //transform.Rotate(look.x * rotSpeed * transform.up);

    }
   
}
