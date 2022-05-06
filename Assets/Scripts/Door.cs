using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false, isPassed = false;
    public Vector3 roomPosition;
    public Vector3 roomScaling;
    void Update()
    {
        if (isOpen)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D collison)
    {
        isOpen = false;
        GetComponent<Collider2D>().isTrigger = false;
        isPassed = true;
    }
}

