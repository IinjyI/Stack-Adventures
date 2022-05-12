using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private ItemScriptableObject[] levelObjectives;
    private int currentObjectiveIndx=0;
    private bool inRange;
    
    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            PushTargetItem();
        }
    }
    private void PushTargetItem()
    {
        if (playerInventory.items.Count > 0)
        {
            var item = playerInventory.stackUI.transform.GetChild(playerInventory.currentSlot - 1).transform.GetChild(0);
            if (item.GetComponent<DataItem>().item.itemColor == levelObjectives[currentObjectiveIndx].itemColor)
            {
                // Success Target Push
                currentObjectiveIndx++;
                Destroy(item.gameObject);
                playerInventory.currentSlot--;
                playerInventory.items.Pop();
                if (isWin())
                {

                }
            }
            else
            {
                // Wrong Target Push

            }
        }
    }
    private bool isWin()
    {
        return currentObjectiveIndx == levelObjectives.Length;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
