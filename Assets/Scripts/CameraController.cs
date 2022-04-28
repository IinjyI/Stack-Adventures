using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Transform player;
    private Vector3 velocity = Vector3.zero;
    private float mainLvlSize=10;
    private float entryLvlSize=7;
    
    private void Update(){
        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
                new Vector3(player.position.x,
                player.position.y, transform.position.z),
            ref velocity, speed);

         if(player.position.y> -6.91){
            cameraZoom(mainLvlSize,entryLvlSize);
         }
         else{
            cameraZoom(entryLvlSize,mainLvlSize);
         }
         
    }

    public void moveToRoom(Transform _newRoom){
       float currentPosY= _newRoom.position.y;
    }

    public void cameraZoom(float startSize, float targetSize){
         for(float t = 0f; t < 100; t += Time.deltaTime) {
        float blend = t/100;
        Camera.main.orthographicSize = Mathf.SmoothStep(startSize, targetSize, blend); 
         }
    }
    
}
