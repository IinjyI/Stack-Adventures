using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToScene : MonoBehaviour
{
    // Start is called before the first frame update
public void moveToMain(){
    SceneManager.LoadScene("Main Menu");
}
public void moveNext(){
    PlayerPrefs.SetInt("levelAt", 3 );
    SceneManager.LoadScene("Level 2");
}
}
