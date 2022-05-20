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
            Pause();
            pauseMenu.SetActive(true);
            darken.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
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
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
