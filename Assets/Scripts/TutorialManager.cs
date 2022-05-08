using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPopUps;
    public int popUpIndx;
    private void Update()
    {
        for(int i=0;i<tutorialPopUps.Length;i++)
        {
            if(i==popUpIndx)
            {
                tutorialPopUps[i].SetActive(true);
            }
            else
            {
                tutorialPopUps[i].SetActive(false);
            }
        }
    }
}
