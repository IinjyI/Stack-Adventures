using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintActivation : MonoBehaviour
{
    [SerializeField] GameObject hintObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TutorialManager.instance.gameHints.transform.Find(hintObject.name).gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TutorialManager.instance.gameHints.transform.Find(hintObject.name).gameObject.SetActive(false);
    }
}
