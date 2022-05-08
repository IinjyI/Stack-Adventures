using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorSetActive door;
    [SerializeField] Inventory targetStackInventory;
    bool isTriggerd;
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
            if (targetStackInventory.items.Count == 0 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.popUpIndx++;
                isTriggerd = true;
            }
        }
        else if (triggerId == TriggerId.thirdDoor)
        {
            if (targetStackInventory.items.Count == 1 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.popUpIndx++;
                isTriggerd = true;
            }
        }
        else if (triggerId == TriggerId.fourthDoor)
        {
            if (targetStackInventory.items.Count == 1 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.popUpIndx++;
                isTriggerd = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerId == TriggerId.firstDoor && !isTriggerd)
        {
            door.OpenDoor();
            TutorialManager.instance.popUpIndx++;
            isTriggerd = true;
        }
    }
}
