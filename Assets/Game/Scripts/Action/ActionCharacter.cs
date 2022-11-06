using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCharacter : ControllableCharacter
{
    public bool canMove;
    public float        moveSpeed, jumpForce;

    private Rigidbody   rigidBody;
    private Vector2     moveInput;

    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rigidBody.velocity = new Vector3(moveInput.x * moveSpeed, rigidBody.velocity.y, moveInput.y * moveSpeed);
    }
}
