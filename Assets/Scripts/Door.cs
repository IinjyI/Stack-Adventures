using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

   [SerializeField] private CameraController camera;
    public float mainLvlSize=10;
    public float entryLvlSize=7;
    private Vector3 bugVelocity= Vector3.zero;  
    
    private void OnTriggerEnter2D(Collider2D collision){
       if (collision.tag == "Player")
       {
    //        if (collision.transform.position.y>transform.position.y)
    //        {
    //             camera.moveToEntryLvl();
    //            camera.zoom(entryLvlSize,mainLvlSize);

    //        }
    //        else if(collision.transform.position.y<transform.position.y)
    //        {camera.moveToMainLvl();
              
    //            camera.zoom(mainLvlSize,entryLvlSize);

    //        }
       }
       
     }
   }

