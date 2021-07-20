using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    Animator animator;
    AudioSource audioSourceWalk;
    [SerializeField] AudioSource audioSourceRun;
    void Start()
    {
        audioSourceWalk = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Running()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", false);
            if (audioSourceRun.isPlaying != true)
            {
                audioSourceRun.Play();
            }
            
            animator.SetBool("isRunning", true);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            audioSourceRun.Stop();
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
            animator.SetBool("isWalkingGlobal", true);
            animator.SetBool("isWalkingBackward", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackward", true);
            animator.SetBool("isWalkingGlobal", true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingGlobal", false);

        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalkingBackward", false);
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {//sredi ovo ne radi kako triba

        if (animator.GetBool("isWalkingGlobal") == true)
        {
            if (!audioSourceWalk.isPlaying)
            {
                audioSourceWalk.Play();
            }

        }
        if(animator.GetBool("isWalkingGlobal") == false)
        {
            audioSourceWalk.Stop();
        }

       

        Walking();
        Strafing();
        Running();
    }
}
