using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menus : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenu;
    public GameObject darken;
    public GameObject optionsMenu;
    private bool isPaused = false;
    void Start()
    {
        //pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        //darken = GameObject.FindWithTag("Darken");
        darken.SetActive(false);
        //optionsMenu = GameObject.FindWithTag("OptionsMenu");
        optionsMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
            pauseMenu.SetActive(true);
            darken.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            darken.SetActive(false);
            Resume();
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Resume();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void MoveToMain()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
