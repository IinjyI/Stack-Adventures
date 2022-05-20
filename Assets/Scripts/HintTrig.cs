using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrig : MonoBehaviour
{
    private bool isTriggred;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggred)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            isTriggred = true;
        }
    }
}
