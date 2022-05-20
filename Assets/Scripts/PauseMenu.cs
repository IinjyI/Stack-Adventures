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
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        darken = GameObject.FindGameObjectWithTag("Darken");
        optionsMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
        pauseMenu.SetActive(false);
        darken.SetActive(false);
        optionsMenu.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            darken.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            darken.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
