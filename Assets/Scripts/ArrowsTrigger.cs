using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsTrigger : MonoBehaviour
{
    [SerializeField] Inventory intialStack, helperStack;
    [SerializeField] GameObject[] hintArrows;
    public bool isFinshed=false;
    private void Update()
    {
        if (!isFinshed)
        {
            if (intialStack.items.Count == 2)
            {
                hintArrows[2].SetActive(true);
                hintArrows[3].SetActive(false);
            }
            else if (intialStack.items.Count == 1)
            {
                if (helperStack.items.Count == 0)
                {
                    hintArrows[3].SetActive(true);
                    hintArrows[2].SetActive(false);
                }
                else if (helperStack.items.Count == 1)
                {
                    hintArrows[2].SetActive(true);
                    hintArrows[3].SetActive(false);
                }
            }
            else if (intialStack.items.Count == 0)
            {
                if (helperStack.items.Count == 1)
                {
                    hintArrows[3].SetActive(true);
                    hintArrows[2].SetActive(false);
                }
                else
                {
                    hintArrows[3].SetActive(false);
                }
            }
        }
    }
}
