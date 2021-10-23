using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkspeed;
    [SerializeField] private float runspeed;
    [SerializeField] private float movespeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool isgrounded;
    [SerializeField] private float groundcheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    //[SerializeField] private float turnsmoothtime = 0.1f;
    //private float turnsmoothvelocity;

    //variable
    private Vector3 moveforward;
    private Vector3 velocity;

    private CharacterController controller;
    


    //calling functions in the begining of the game
    private void Start()
    {
       

        controller = GetComponent<CharacterController>();
        
    }

    //calling functions in every frame of the game
    private void Update()
    {
        

        Move();
    }




    //player's all movements
    private void Move()
    {
        isgrounded = Physics.CheckSphere(transform.position, groundcheckDistance, groundMask);

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float movez = Input.GetAxisRaw("Vertical");
        // float movex = Input.GetAxisRaw("Horizontal");
        moveforward = new Vector3(0, 0, movez).normalized;

        //move player to player's direction not to world direction
        moveforward = transform.TransformDirection(moveforward);


        if (moveforward != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
           
        }

        else if (moveforward != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
            
        }

        else if (moveforward == Vector3.zero)
        {
            Idle();
           
        }


        if (isgrounded)
        {


            //calling jump function when pressed space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

        }







        //rotate player to the input direction
        /*float targetangle = Mathf.Atan2(moveforward.x, moveforward.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turnsmoothtime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);*/

        controller.Move(moveforward * movespeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //walk function 
    private void Walk()
    {
        movespeed = walkspeed;
    }

    //run function
    private void Run()
    {
        movespeed = runspeed;
    }

    //idle function
    private void Idle()
    {
        movespeed = 0;
    }

    //jump function
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        


    }

  

}
