using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    //public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    bool isActive;

    void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if(isActive&&(Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return)))
        {
            GameObject.FindGameObjectWithTag("ContinueButton").GetComponent<Button>().onClick.Invoke();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //nameText.text = dialogue.name;
        isActive = true;
        animator.SetBool("IsOpen", true);
        Time.timeScale = 0;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            isActive = false;
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Time.timeScale = 1;
    }
}
