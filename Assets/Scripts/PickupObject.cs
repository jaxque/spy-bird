using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupObject : MonoBehaviour
{
    public bool hasPackage = false;
       
    private void OnTriggerEnter(Collider collider)
    {
        // Item collected
        if (collider.gameObject.tag == "Key")
        {
            hasPackage = true;
            
        }

        // Successfully returns to starting point with key item
        if ( collider.gameObject.tag == "Finish" && hasPackage)
        {
            SceneManager.LoadScene("WinScene");
        }

        if (collider.gameObject.tag == "Office Worker")
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    
}
