using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public bool isGrounded;
    bool forward;

    private void Start()
    {
       
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime; 
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Debug.Log(forward);
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            forward = true; // bool za potvrdu kretnje
        }
        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            forward = false;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 20f;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                speed = 12f; // da ne moze sprintat u stranu
            }
        }
        if (!Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 12f;
        }

        if (!isGrounded)
        {
             x = 0f; // da zamrzne ustranu dok leti
            if (forward) // da ne mogu ic nazad dok letim naprid
            {
                z = 1 * speed * Time.deltaTime;
            }
            if (!forward)
            {
                z = -1 * speed * Time.deltaTime;
            }
        }
        Vector3 move = transform.right * x + transform.forward * z; // kretnja u odnosu na rotaciju modela
        //Vector3 move = new Vector3(x, 0f, z); kretnja u odnosu na svijet
        
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // fiyika formula za skok 
        }
        controller.Move(move);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
