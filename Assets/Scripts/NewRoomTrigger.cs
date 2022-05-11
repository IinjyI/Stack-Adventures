using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoomTrigger : MonoBehaviour
{
    private bool isTrigger = false;
    [SerializeField] DoorSetActive previousDoor;
    [SerializeField] Inventory playerInventory;
    public RoomId roomId;
    public enum RoomId
    {
        firstRoom,
        secondRoom,
        ThirdRoom,
        FourthRoom,
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Invoked on entering new room
        if (!isTrigger)
        {
            previousDoor.CloseDoor();
            GetComponent<DialogueTrigger>().TriggerDialogue();
            TutorialManager.instance.objectiveIndx++;
            if (roomId == RoomId.firstRoom)
            {

            }
            else if (roomId == RoomId.secondRoom)
            {
                playerInventory.stackUI.gameObject.SetActive(true);
                TutorialManager.instance.hintArrows.transform.Find("arrow 01").gameObject.SetActive(true);
            }
            else if (roomId == RoomId.ThirdRoom)
            {
                TutorialManager.instance.hintArrows.transform.Find("arrow 02").gameObject.SetActive(true);

            }
            else if (roomId == RoomId.FourthRoom)
            {
                TutorialManager.instance.hintArrows.transform.Find("arrow 03").gameObject.SetActive(true);
                TutorialManager.instance.hintArrows.transform.Find("arrow 04").gameObject.SetActive(true);
                playerInventory.ClearInventory();
            }
            isTrigger = true;
        }
    }
}
