using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] private Transform prevRoom;
   [SerializeField] private Transform nextRoom;
   [SerializeField] private CameraController camera;

   private void OnTriggerEnter2D(Collider2D collision){
       if (collision.tag == "Player")
       {
           if (collision.transform.position.y>transform.position.y)
           {
               camera.moveToRoom(nextRoom);
           }
           else
           {
               camera.moveToRoom(prevRoom);
           }
       }
   }
}
