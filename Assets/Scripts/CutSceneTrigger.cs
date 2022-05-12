using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector cutScene;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cutScene.Play();
        mainCamera.GetComponent<CameraController>().enabled = false;
        player.GetComponent<PlayerMovment>().enabled = false;
        OnLevelCompleted();
        StartCoroutine(Waiter());
    }
    public void OnLevelCompleted()
{
    // Retrieve name of current scene / level
    string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    PlayerPrefs.SetInt( sceneName, 1 ) ; // Indicates the level is completed
}
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
