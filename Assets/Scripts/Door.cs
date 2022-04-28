using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] private Transform entryLevel;
   [SerializeField] private Transform mainLevel;
   [SerializeField] private CameraController camera;
   [SerializeField] private Transform Bug;
    private float mainLvlSize=10;
    private float entryLvlSize=7;
    private Vector3 bugVelocity= Vector3.zero;  
   private void OnTriggerEnter2D(Collider2D collision){
       if (collision.tag == "Player")
       {
           if (collision.transform.position.y>transform.position.y)
           {
               camera.moveToRoom(entryLevel);
               camera.zoom(entryLvlSize,mainLvlSize);

           }
           else if(collision.transform.position.y<transform.position.y)
           {
               camera.moveToRoom(mainLevel);
               camera.zoom(mainLvlSize,entryLvlSize);

           }
       }
       
     }
   }

