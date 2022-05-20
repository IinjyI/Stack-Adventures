using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menus : MonoBehaviour
{
    public AudioMixer audioMixer;
    private GameObject pauseMenu;
    private GameObject darken;
    private GameObject optionsMenu;
    private bool isPaused = false;
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        darken = GameObject.FindGameObjectWithTag("Darken");
        optionsMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            darken.SetActive(false);
            optionsMenu.SetActive(false);
        }
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
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
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
