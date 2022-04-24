using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("RunningDown", Input.GetAxisRaw("Vertical") == -1);
        anim.SetBool("RunningUp", Input.GetAxisRaw("Vertical") == 1);
        anim.SetBool("RunningRight", Input.GetAxisRaw("Horizontal") == 1);
        anim.SetBool("RunningLeft", Input.GetAxisRaw("Horizontal") == -1);
    }
}
