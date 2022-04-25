using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movment;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Getting Movments Input
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        movment = movment.normalized;
    }
    private void FixedUpdate()
    {
        // Updating Postion
        rb.velocity = new Vector2(movment.x * moveSpeed, movment.y * moveSpeed);
    }
}
