using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorSetActive door;
    public TriggerId triggerId;
    bool inRange = false;
    public enum TriggerId
    {
        firstDoor,
        secondDoor,
        thirdDoor,
        fourthDoor
    }
    private void Update()
    {
        if (inRange)
        {
            if (triggerId == TriggerId.secondDoor && Input.GetKeyDown(KeyCode.Q))
            { 
                door.OpenDoor();
            }
            else if (triggerId == TriggerId.thirdDoor && Input.GetKeyDown(KeyCode.E))
            {
                door.OpenDoor();
            } 

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerId == TriggerId.firstDoor)
        {
            door.OpenDoor();
        }
        else if (triggerId == TriggerId.secondDoor || triggerId == TriggerId.thirdDoor)
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerId == TriggerId.secondDoor || triggerId == TriggerId.thirdDoor)
        {
            inRange = false;
        }
    }
}
