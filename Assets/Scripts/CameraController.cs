using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Transform player;
    private Vector3 velocity = Vector3.zero;
    private float t = 0;
    private float mainLvlSize=10;
    private float entryLvlSize=7;
    private void Update(){
        transform.position = Vector3.SmoothDamp(
            transform.position, 
                new Vector3(player.position.x,
                player.position.y, transform.position.z),
            ref velocity, speed);

         t += Time.deltaTime;

         if(player.position.y> -6.91){
             Camera.main.orthographicSize = Mathf.SmoothStep(entryLvlSize,mainLvlSize, t/10000);
         }
         else{
             Camera.main.orthographicSize = Mathf.SmoothStep(mainLvlSize,entryLvlSize, t/10000);
         }
    }
    public void moveToRoom(Transform _newRoom){
       float currentPosY= _newRoom.position.y;

    }
}
