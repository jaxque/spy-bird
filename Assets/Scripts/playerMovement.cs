using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public bool Hover = false; 
    
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioClip Objectcollide;

    //public bool hover = false;

    Vector3 velocity;
    bool isGrounded;

    public float wingFlaps = 6;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Spacebar to jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        // Ctrl to fly
        if (Input.GetButtonDown("fly") && wingFlaps > 0)
        {
            Hover = !Hover;
            wingFlaps--;
        }

        if (Hover == false)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit");
            AudioSource.PlayClipAtPoint(Objectcollide, transform.position);
        }
    }
}
