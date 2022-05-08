using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;
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
    StopAllCoroutines();
    StartCoroutine(typeSentence(sentence));
 }
 IEnumerator typeSentence (string sentence){
     dialogueText.text="";
     foreach (char letter in sentence.ToCharArray()){
         dialogueText.text+=letter;
         yield return null;
     }
 }

 public void endDialogue(){
     animator.SetBool("IsOpen", false);
 }
}