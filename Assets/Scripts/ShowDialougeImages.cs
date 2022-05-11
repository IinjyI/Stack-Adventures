using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialougeImages : MonoBehaviour
{
    private int counter = 0;
    [SerializeField] GameObject dialougeImage1, dialougeImage2;
    public void DisplayDialogueImages()
    {
        counter++;
        if (counter == 1 || counter == 2)
        {
            dialougeImage1.SetActive(true);
            dialougeImage2.SetActive(true);
        }
        else
        {
            dialougeImage1.SetActive(false);
            dialougeImage2.SetActive(false);
        }
    }
}
