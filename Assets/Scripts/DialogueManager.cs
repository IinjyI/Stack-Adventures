using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

 public void startDialogue(Dialogue dialogue){
     Debug.Log("starting dialog"+ dialogue.name);
 }
}
