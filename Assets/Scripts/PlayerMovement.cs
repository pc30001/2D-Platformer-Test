using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate()
    {
        anim.SetFloat("XInput", moveDirection.x);
        anim.SetFloat("YInput", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude); 
    }
}
