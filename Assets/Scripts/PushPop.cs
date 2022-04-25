using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPop : MonoBehaviour
{
    Inventory playerInventory; //player inventory
    public GameObject workingStack; //stack currnetly working with
    Inventory stackInventory; // workingStack's inventory
    public AudioSource push,pop;
    void Start()
    {
        playerInventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && workingStack != null)
        {
            AddItem();
        }
        else if (Input.GetKeyDown(KeyCode.E) && workingStack != null)
        {
            RemoveItem();
        }
    }
    void AddItem()
    {
        if (playerInventory.isFull[0])
        {
            for (int i = 0; i < stackInventory.items.Count; i++)
            {
                if (!stackInventory.isFull[i])
                {
                    push.Play();
                    stackInventory.attatchedInventory.transform.GetChild(i).gameObject.SetActive(true);
                    stackInventory.attatchedInventory.transform.GetChild(i).gameObject.GetComponent<Item>().sprite = playerInventory.attatchedInventory.transform.GetChild(0).gameObject.GetComponent<Item>().sprite;
                    stackInventory.attatchedInventory.transform.GetChild(i).gameObject.GetComponent<Item>().ID = playerInventory.attatchedInventory.transform.GetChild(0).gameObject.GetComponent<Item>().ID;
                    stackInventory.attatchedInventory.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = playerInventory.attatchedInventory.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
                    stackInventory.isFull[i] = true;
                    playerInventory.isFull[0] = false;
                    playerInventory.attatchedInventory.transform.GetChild(0).gameObject.SetActive(false);
                    break;

                }
            }
        }
    }
    void RemoveItem()
    {
        if (!playerInventory.isFull[0])
        {
            for (int i = stackInventory.items.Count - 1; i >= 0; i--)
            {
                if (stackInventory.isFull[i])
                {
                    pop.Play();
                    stackInventory.attatchedInventory.transform.GetChild(i).gameObject.SetActive(false);
                    stackInventory.isFull[i] = false;
                    playerInventory.attatchedInventory.transform.GetChild(0).gameObject.SetActive(true);
                    playerInventory.attatchedInventory.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = stackInventory.attatchedInventory.transform.GetChild(i).gameObject.GetComponent<Image>().sprite;
                    playerInventory.attatchedInventory.transform.GetChild(0).gameObject.GetComponent<Item>().sprite = stackInventory.attatchedInventory.transform.GetChild(i).gameObject.GetComponent<Item>().sprite;
                    playerInventory.attatchedInventory.transform.GetChild(0).gameObject.GetComponent<Item>().ID = stackInventory.attatchedInventory.transform.GetChild(i).gameObject.GetComponent<Item>().ID;
                    playerInventory.isFull[0] = true;
                    playerInventory.items[0] = stackInventory.items[i];
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stack"))
        {
            workingStack = collision.gameObject;
            stackInventory = workingStack.GetComponent<Inventory>();
            workingStack.GetComponent<Inventory>().attatchedInventory.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stack"))
        {
            workingStack.GetComponent<Inventory>().attatchedInventory.SetActive(false);
            gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            workingStack = null;
            stackInventory = null;
        }
    }
}
