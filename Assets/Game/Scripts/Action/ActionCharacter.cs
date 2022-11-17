using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCharacter : ControllableCharacter
{
    public bool                 canMove;
    public float                moveSpeed, jumpForce;
    public bool                 isGrounded;

    public CharacterController  characterController;
    public Animator             animator;
    private Vector2             moveInput;

    public float                force = 5f;
    public float                ySpeed;
    private float               defaultStepOffset;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
        defaultStepOffset = characterController.stepOffset;
    }

    public void Move()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = defaultStepOffset;
            ySpeed = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpForce;
            }
        }
        else characterController.stepOffset = 0f;

        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        // Animation
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y));
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }
        //transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime);
        //transform.Translate(new Vector3(moveInput.x, rigidBody.velocity.y, moveInput.y) * moveSpeed * Time.deltaTime);
    }
}
