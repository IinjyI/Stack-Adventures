using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menus : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void NewGame(){
        PlayerPrefs.DeleteAll();
        moveToLvl(1, "Tutorial");
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
}
    public void moveToLvl(int lvl, string sceneName){
       PlayerPrefs.SetInt("levelAt", lvl );
       SceneManager.LoadScene(sceneName);
}
}
