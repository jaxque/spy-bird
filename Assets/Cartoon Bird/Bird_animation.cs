using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_animation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        if (Input.GetButton("LeftControl"))
        {
            anim.SetBool("fly", true);
            anim.Play("skeletal.3|hover_skeletal.3");
        }
        else if (Input.GetButtonDown("LeftControl"))
        {
            anim.SetBool("fly", false);
            anim.enabled = false;
        }
    }
}
