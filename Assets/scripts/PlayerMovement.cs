using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public CharacterController controller;
    
    
    public float speed = 10f;
    public float gravity = -9.80f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    

    bool isGrounded;

    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey("c"))
        {
            controller.height = 1.8f;
        } else
        {
            controller.height = 2.8f;
        }

        
        if(Input.GetKey("left shift"))
        {
            speed = 14f;
        } else
         if(Input.GetKey("caps lock"))
        {
            speed = 4f;
        }else
        {
            speed = 10f;
        }
   

    }
}
