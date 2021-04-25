using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void OpenDoor()
    {
        animator.SetBool("IsOpen", true);
    }

    internal void CloseDoor()
    {
        animator.SetBool("IsOpen", false);
    }
}
