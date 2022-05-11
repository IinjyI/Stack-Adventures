using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialObjectives;
    public GameObject hintArrows;
    public GameObject gameHints;
    public int objectiveIndx;
    public static TutorialManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        for(int i=0;i<tutorialObjectives.transform.childCount;i++)
        {
            if(i== objectiveIndx)
            {
                tutorialObjectives.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                tutorialObjectives.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
