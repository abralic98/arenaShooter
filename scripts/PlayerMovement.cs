using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 6f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 1f;
    public bool isGrounded;
    float x;
    float z;

    private void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)//ako sam na podu rade komande
        {
            x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 12f;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                speed = 6f; // da ne moze sprintat u stranu
            }
        }
        if (!Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 6f;
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
