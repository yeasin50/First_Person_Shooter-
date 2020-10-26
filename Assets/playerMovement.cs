using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller ;
    public float speed = 14f;
    
    public float  gravity= -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    
    public LayerMask  groundMask;

    Vector3 velocity ;
    bool isGounded;

   

    // Update is called once per frame
    void Update()
    {
        isGounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGounded && velocity.y <0){
            velocity.y = -2f;
        }

        float x =  Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward*z ;
        controller.Move(move * speed *Time.deltaTime);
        
        if(Input.GetButtonDown("Jump") && isGounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity );
        }

        velocity.y += gravity * Time.deltaTime;
        //for physics y = .5*gt^2
        controller.Move(velocity * Time.deltaTime);
    }
}
