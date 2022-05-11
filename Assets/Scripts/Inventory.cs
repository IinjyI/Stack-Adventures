using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject stackUI;
    public Stack<Item> items;
    public int currentSlot=0;
    private void Start()
    {
        items = new Stack<Item>();
        foreach(Transform slot in stackUI.transform)
        {
            if (slot.childCount > 0)
            {
                items.Push(slot.GetChild(0).GetComponent<Item>());
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
