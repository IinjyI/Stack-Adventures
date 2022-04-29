using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float bugSpeed;
    private Vector3 bugVelocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(player.position.x, player.position.y, transform.position.z),
             ref bugVelocity,
             bugSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Door")
        {
            gameObject.SetActive(false);
        }
    }
}
