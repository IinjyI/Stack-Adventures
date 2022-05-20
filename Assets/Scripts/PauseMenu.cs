using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject darken;
    private GameObject optionsMenu;
    void Start()
    {
     public AudioMixer audioMixer;
    private Canvas pauseMenu;
    private Canvas optionsMenu;
    private Image darken;
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>();
        optionsMenu = GameObject.FindGameObjectWithTag("OptionsMenu").GetComponent<Canvas>();
        darken = GameObject.FindGameObjectWithTag("Darken").GetComponent<Image>();
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
        darken.enabled = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.enabled && !optionsMenu.enabled)
        {
            Pause();
            pauseMenu.enabled = true;
            darken.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.enabled && optionsMenu.enabled)
        {
            pauseMenu.enabled = true;
            optionsMenu.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.enabled)
        {
            optionsMenu.enabled = false;
            pauseMenu.enabled = false;
            darken.enabled = false;
            Resume();
        }
    }
}
}