using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject stackUI;
    public Stack<DataItem> items;
    public int currentSlot=0;
    public int slotsCount=0;
    private void Start()
    {
        items = new Stack<DataItem>();
        foreach(Transform slot in stackUI.transform)
        {
            slotsCount++;
            if (slot.childCount > 0)
            {
                items.Push(slot.GetChild(0).GetComponent<DataItem>());
                currentSlot++;
            }
        }
    }
    public void ClearInventory()
    {
        items.Clear();
        currentSlot = 0;
        foreach (Transform slot in stackUI.transform)
        {
            if (slot.childCount > 0)
            {
                Destroy(slot.GetChild(0).gameObject);
            }
        }
    }
}
