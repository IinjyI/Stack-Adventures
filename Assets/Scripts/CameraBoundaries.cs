using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
   public Transform player;
   public Vector2 minPosition;
   public Vector2 maxPosition;
   public float smooth;
void Start(){


}
 
void Update(){
 
if(transform.position != player.position){
    Vector3 targetPosition=new Vector3(player.position.x, player.position.y, transform.position.z);
    targetPosition.x= Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
    targetPosition.y= Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
    transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);

}
 
}
}