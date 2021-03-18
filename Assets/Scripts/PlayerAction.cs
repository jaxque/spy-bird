using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //access player controller component 
    //WASD or arrow keys, shift to increase speed, space bar to jump/fly
    private CharacterController playerController;

    //Set these values in Payer Action (Script) 
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    //mouse speed
    //float horizontalSpeed = 2.0f;
    //float verticalSpeed = 2.0f;

    //for movement and jump
    private Vector3 movementDirection;
    private Vector3 velocity;

    //Key to find
    GameObject keyObject;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();

        //get access to key object, set GameKey as Tag on key object 
        keyObject = GameObject.FindGameObjectWithTag("GameKey");
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDirection = new Vector3(x, 0, z);
        movementDirection = transform.TransformDirection(movementDirection);

        if (movementDirection != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))  //run if Left Shift key presssed
            {
                //run
                movementDirection = movementDirection * runSpeed;
            }
            else
            {
                //walk
                movementDirection = movementDirection * walkSpeed;
            }
        }
        /* if (Input.GetKey(KeyCode.Space))
        {
            //jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        } */

        //player move - WASD
        playerController.Move(movementDirection * Time.deltaTime);

        //player jump - SPACE bar
        //velocity.y += gravity * Time.deltaTime;
        //playerController.Move(velocity * Time.deltaTime);


        //float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        //transform.Rotate(v, h, 0);

        //Player rotate - mouse based rotation
        float mouseX = Input.GetAxis("Mouse X") * 250 * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GameKey")
        {
            Destroy(keyObject);
            Debug.Log("KEY FOUND!!!");
        }
    }
}
