using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private float currentPosY;
    private Vector3 velocity = Vector3.zero;
    
    private void Update(){
        transform.position = Vector3.SmoothDamp(transform.position, 
        new Vector3(transform.position.x,
            currentPosY, transform.position.z),
         ref velocity, speed);

         transform.position= new Vector3(player.position.x,player.position.y, transform.position.z);
         
    }
    public void moveToRoom(Transform _newRoom){
        currentPosY= _newRoom.position.y;

    }
}
