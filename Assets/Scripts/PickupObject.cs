using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupObject : MonoBehaviour
{
    public bool hasPackage = false;
    //public AudioClip FolderCollect;
   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            print("Item obtained");

            hasPackage = true;

            //AudioSource.PlayClipAtPoint(FolderCollect, transform.position);
            
        }

        if ( collider.gameObject.tag == "Finish" && hasPackage)
        {
            print("WINNER WINNER CHICKEN DINNER!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    
}
