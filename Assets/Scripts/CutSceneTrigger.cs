using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        StartCoroutine(Waiter());
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
