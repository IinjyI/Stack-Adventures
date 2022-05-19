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
}
