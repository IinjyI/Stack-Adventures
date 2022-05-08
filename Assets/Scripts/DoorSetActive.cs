using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour
{
    private PlatformEffector2D oneWayCollider;
    private Animator anim;
    private void Awake()
    {
        oneWayCollider = GetComponent<PlatformEffector2D>();
        anim = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        oneWayCollider.enabled = true;
        anim.SetBool("IsOpen", true);
    }
    public void CloseDoor()
    {
        oneWayCollider.enabled = false;
        anim.SetBool("IsOpen", false);
    }
}
