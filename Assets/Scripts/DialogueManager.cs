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
     sentences.Clear();
     foreach (string sentence in dialogue.sentences)
     {
         sentences.Enqueue(sentence);
     }
     displayNextSentence();
 }

 public void displayNextSentence(){
     if (sentences.Count == 0)
     {
         endDialogue();
         return;
     }
    string sentence = sentences.Dequeue();
    Debug.Log(sentence);
 }

 public void endDialogue(){
     Debug.Log("dialogue ended");
 }
}
