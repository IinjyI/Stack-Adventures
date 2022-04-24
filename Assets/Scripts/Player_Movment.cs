using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movment;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Getting Movments Input
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        // Updating Postion
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movment.normalized);
    }
}
