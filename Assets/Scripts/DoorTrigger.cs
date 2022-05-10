using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorSetActive door;
    [SerializeField] Inventory targetStackInventory;
    bool isTriggerd;
    public DoorId doorId;
    public enum DoorId
    {
        firstDoor,
        secondDoor,
        thirdDoor,
        fourthDoor
    }
    private void Update()
    {
        if (doorId == DoorId.secondDoor)
        {
            if (targetStackInventory.currentSlot == 0 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.popUpIndx++;
                isTriggerd = true;
            }
        }
        else if (doorId == DoorId.thirdDoor)
        {
            if (targetStackInventory.currentSlot == 1 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.popUpIndx++;
                isTriggerd = true;
            }
        }
        else if (doorId == DoorId.fourthDoor)
        {
            if (targetStackInventory.currentSlot == 2 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.popUpIndx++;
                isTriggerd = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorId == DoorId.firstDoor && !isTriggerd)
        {
            door.OpenDoor();
            //TutorialManager.instance.popUpIndx++;
            isTriggerd = true;
        }
    }
}
