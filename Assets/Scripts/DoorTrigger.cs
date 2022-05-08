using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorSetActive door;
    [SerializeField] Inventory targetStackInventory;
    public TriggerId triggerId;
    public enum TriggerId
    {
        firstDoor,
        secondDoor,
        thirdDoor,
        fourthDoor
    }
    private void Update()
    {
        if (triggerId == TriggerId.secondDoor)
        {
            if (targetStackInventory.items.Count == 0)
            {
                door.OpenDoor();
            }
        }
        else if (triggerId == TriggerId.thirdDoor)
        {
            if (targetStackInventory.items.Count == 1)
            {
                door.OpenDoor();
            }
        }
        else if (triggerId == TriggerId.fourthDoor)
        {
            if (targetStackInventory.items.Count == 1)
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
    }
}
