using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class camera : MonoBehaviour
{

    float speed = 50;
    float angle = 0;
    int incremement = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += incremement;

        if (angle == 500 || angle == 0)
        {
            incremement = incremement * -1;

        }

        if (incremement == 1)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            //transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            //transform.Rotate(Vector3.down * speed * Time.deltaTime);
        }

    }


   
}
