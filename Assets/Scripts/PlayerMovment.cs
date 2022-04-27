using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection, lastMoveDirection;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Getting Movements Input for every frame
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Capturing last movments direction to set idle state
        if (moveDirection.magnitude != 0)
            lastMoveDirection = moveDirection;

        Animate();
    }
    private void FixedUpdate()
    {
        // Updating Postion
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void Animate()
    {
        // Getting Animation's values
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetFloat("Magnitude", moveDirection.magnitude);
        anim.SetFloat("LastMoveHorizontal", lastMoveDirection.x);
        anim.SetFloat("LastMoveVertical", lastMoveDirection.y);
    }
}
