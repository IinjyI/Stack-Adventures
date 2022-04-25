using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    
    private void Update(){
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),
         ref velocity, speed);
         
    }
    public void moveToRoom(Transform _newRoom){
        currentPosX= _newRoom.position.x;

    }
}
