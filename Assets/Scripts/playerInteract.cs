using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentObject = null;

    // Detects object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log(other.name);
            currentObject = other.gameObject;
        }
    }

    // Leaves object
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            if (other.gameObject == currentObject)
            {
                currentObject = null;
            }
        }
    }

  

    private void Update()
    {
        if (Input.GetButtonDown("Pick up") && currentObject)
        {
            // Does something
            currentObject.SendMessage("DoInteraction");
        }
    }
}
