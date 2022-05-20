using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private GameObject[] levelObjectives;
    [SerializeField] private Transform objectivesUI;
    [SerializeField] private AudioSource sucessPush, wrongPush;
    private int currentObjectiveIndx=0;
    private bool inRange;
    GameObject winMenu, darken;
    private void Awake()
    {
        AddUIObjectives();
        darken = GameObject.FindGameObjectWithTag("Darken");
        winMenu = GameObject.FindGameObjectWithTag("WinMenu");
    }
    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            PushTargetItem();
        }
    }
    private void PushTargetItem()
    {
        if (playerInventory.items.Count > 0)
        {
            var item = playerInventory.stackUI.transform.GetChild(playerInventory.currentSlot - 1).transform.GetChild(0);
            var currentObjective = levelObjectives[currentObjectiveIndx].GetComponent<DataItem>();
            if (item.GetComponent<DataItem>().item.itemColor == currentObjective.item.itemColor)
            {
                // Success Target Push
                currentObjectiveIndx++;
                Destroy(item.gameObject);
                playerInventory.currentSlot--;
                playerInventory.items.Pop();
                objectivesUI.GetChild(currentObjectiveIndx-1).GetComponentInChildren<Toggle>().isOn = true;
                sucessPush.Play();
                if (LevelWin())
                {
                    // Player finshed the level
                    darken.GetComponent<Image>().enabled = true;
                    winMenu.GetComponent<Canvas>().enabled = true;
                    int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    Time.timeScale = 0;
                }
            }
            else
            {
                // Wrong Target Push
                wrongPush.Play();
            }
        }
    }
    private void AddUIObjectives()
    {
        for(int i=0;i<levelObjectives.Length;i++)
        {
            Instantiate(levelObjectives[i], objectivesUI.GetChild(i));
            //Debug.Log(objectivesUI.GetChild(i).name);
        }
    }
    private bool LevelWin()
    {
        return currentObjectiveIndx == levelObjectives.Length;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            collision.transform.Find("UICanvasPush").GetComponent<Canvas>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            collision.transform.Find("UICanvasPush").GetComponent<Canvas>().enabled = false;
        }
    }
}
