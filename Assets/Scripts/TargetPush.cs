using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPush : MonoBehaviour
{
    [SerializeField] private string[] objectives;
    private int objectiveIndex = 0;
    private Inventory playerInventory;
    private bool inRange = false;
    [SerializeField] public AudioSource sucessPush, wrongPush;
    [SerializeField] private Transform objetivesUI;
    private void Start()
    {
        playerInventory = GetComponent<Inventory>();
    }
    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            PushToTarget();
        }
    }
    private void PushToTarget()
    {
        if (playerInventory.items.Peek().itemName == objectives[objectiveIndex])
        {
            Destroy(playerInventory.stackUI.transform.GetChild(playerInventory.items.Count - 1).gameObject);
            sucessPush.Play();
            objetivesUI.GetChild(objectiveIndex).Find("CheckMark").gameObject.SetActive(true);
            objectiveIndex++;
            playerInventory.items.Pop();
        }
        else
        {
            // if the player pushed wrong target
            wrongPush.Play();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetStack"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetStack"))
        {
            inRange = false;
        }
    }
}
