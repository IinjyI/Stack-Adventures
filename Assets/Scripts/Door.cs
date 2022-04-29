using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

   [SerializeField] private CameraController camera;

    private Vector3 bugVelocity= Vector3.zero;  
    
    private void OnTriggerEnter2D(Collider2D collision){
       if (collision.tag == "Player")
       {
          
       }
       
     }
   }

