using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpen = false;
    void Update()
    {
        if (isOpen)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        isOpen = false;
    }
}

