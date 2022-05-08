using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

 public void startDialogue(Dialogue dialogue){
     nameText.text = dialogue.name;
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
    dialogueText.text= sentence;
 }

 public void endDialogue(){
     Debug.Log("dialogue ended");
 }
}
