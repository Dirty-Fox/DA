using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class RB_move_test : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;
    private Animator animator;

    //---------------Gravity-------------
    public float gravity = -9.81f;
    [SerializeField] public float jumpHeight = 3f;

    private bool isGrounded;
    //--------------------------------------

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        //--------------------------------------------------------------------------------------------------------------
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        Vector3 move = transform.right * moveDirection.x + transform.forward * moveDirection.z;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);

        if (moveDirection.magnitude > 0)
        {
            var rotation = Quaternion.LookRotation(-moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //-----------------------------------------------------
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravity), ForceMode.Impulse);
        }
        //-----------------------------------------------------
    }
}

