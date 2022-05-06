using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] popUps;
    private int popUpIndx;
    void Update()
    {
        foreach (GameObject currentPopUp in popUps)
        {
            currentPopUp.SetActive(true);
        }
    }
}
