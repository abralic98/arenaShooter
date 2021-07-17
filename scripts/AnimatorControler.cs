using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Running()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }
    void Strafing()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isStrafingLeft", true);
        }
        if (!Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isStrafingLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isStrafingLeft", false);
            animator.SetBool("isStrafingRight", true);
        }
        if (!Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isStrafingRight", false);
        }
    }
    void Walking()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isWalkingBackward", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackward", true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalkingBackward", false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetBool("isWalking"));
        if (animator.GetBool("isWalking") == true || animator.GetBool("isWalkingBackward")==true || animator.GetBool("isStrafingLeft") == true || animator.GetBool("isStrafingRight") == true)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        if (animator.GetBool("isWalking") == false)
        {
            audioSource.Stop();
        }
        Walking();
        Strafing();
        Running();
    }
}
