using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons; 
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt",1);
        for(int i = 0; i< lvlButtons.Length; i++){
            lvlButtons[i].onClick.AddListener(()=>moveToLvl(i));
            if(i+1 > levelAt){
                lvlButtons[i].interactable=false;
            }
        }
    }

    public void moveToLvl(int lvl){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+lvl+1);
}
}
