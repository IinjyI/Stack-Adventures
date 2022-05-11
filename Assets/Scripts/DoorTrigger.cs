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
            if (targetStackInventory.currentSlot == 4 && !isTriggerd)
            {
                door.OpenDoor();
                GetComponent<DialogueTrigger>().TriggerDialogue();
                TutorialManager.instance.objectiveIndx++;
                TutorialManager.instance.hintArrows.transform.Find("arrow 01").gameObject.SetActive(false);
                isTriggerd = true;
            }
        }
        else if (doorId == DoorId.thirdDoor)
        {
            if (targetStackInventory.currentSlot == 5 && !isTriggerd)
            {
                door.OpenDoor();
                GetComponent<DialogueTrigger>().TriggerDialogue();
                TutorialManager.instance.objectiveIndx++;
                TutorialManager.instance.hintArrows.transform.Find("arrow 02").gameObject.SetActive(false);
                isTriggerd = true;
            }
        }
        else if (doorId == DoorId.fourthDoor)
        {
            if (targetStackInventory.currentSlot == 2 && !isTriggerd)
            {
                door.OpenDoor();
                TutorialManager.instance.objectiveIndx++;
                GetComponent<DialogueTrigger>().TriggerDialogue();
                TutorialManager.instance.GetComponent<ArrowsTrigger>().isFinshed = true;
                TutorialManager.instance.hintArrows.transform.Find("arrow 05").gameObject.SetActive(true);
                isTriggerd = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorId == DoorId.firstDoor && !isTriggerd)
        {
            door.OpenDoor();
            TutorialManager.instance.gameHints.transform.Find("Moving").gameObject.SetActive(false);
            isTriggerd = true;
        }
    }
}
