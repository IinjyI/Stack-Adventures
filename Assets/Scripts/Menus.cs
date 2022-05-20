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
    void Start(){
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        darken = GameObject.FindWithTag("Darken");
        darken.SetActive(false);
        optionsMenu= GameObject.FindWithTag("OptionsMenu");
        optionsMenu.SetActive(false);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf){
            pauseMenu.SetActive(true);
            darken.SetActive(true);
            pause();
        }
         if(Input.GetKeyDown(KeyCode.Escape) &&( pauseMenu.activeSelf || optionsMenu.activeSelf)){
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            darken.SetActive(false);
            resume();
        }
    }

    public void NewGame(){
       PlayerPrefs.DeleteAll();
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
       resume();
       
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void setVolume(float volume){
       audioMixer.SetFloat("volume", volume);
   }

    public void setFullScreen(bool isFullScreen){
       Screen.fullScreen=isFullScreen;
   }

    public void moveToMain(){
       SceneManager.LoadScene("Main Menu");
       Time.timeScale=1f;

}
    public void pause(){
        Time.timeScale=0f;
}
    public void resume(){
        Time.timeScale=1f;
}
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
}
}
