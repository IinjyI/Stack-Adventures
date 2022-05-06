using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject stackUI;
    public Stack<Item> items;
    private void Start()
    {
        items = new Stack<Item>();
        foreach(Transform item in stackUI.transform)
        {
            items.Push(item.GetComponent<Item>());
        }
    }
}
