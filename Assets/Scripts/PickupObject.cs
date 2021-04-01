using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Item obtained.");
            Destroy(gameObject);
        }

        if ( collider.gameObject.tag == "Finish")
        {
            print("WINNER WINNER CHICKEN DINNER!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    
}
