using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menus : MonoBehaviour
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
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
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
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
