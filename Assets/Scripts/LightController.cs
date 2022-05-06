using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;
    [SerializeField] private GameObject roomLight;
    public int doorIndx = 0;
    private Door currentDoor;

    void Update()
    {
        if (doors[doorIndx].GetComponent<Door>().isPassed)
        {
            currentDoor = doors[doorIndx].GetComponent<Door>();
            currentDoor.isPassed = false;
            doorIndx++;
        }
        if (currentDoor != null)
        {
            roomLight.transform.position = Vector3.Lerp(roomLight.transform.position, currentDoor.roomPosition, Time.deltaTime * 8);
            roomLight.transform.localScale = Vector3.Lerp(roomLight.transform.localScale, currentDoor.roomScaling, Time.deltaTime * 8);
        }
    }
}
