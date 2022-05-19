using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDialougeTrigger : MonoBehaviour
{
    private void Start()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
