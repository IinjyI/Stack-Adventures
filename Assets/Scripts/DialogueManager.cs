using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

 public void startDialogue(Dialogue dialogue){
     nameText.text = dialogue.name;
     animator.SetBool("IsOpen", true);
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
     animator.SetBool("IsOpen", false);
 }
}
