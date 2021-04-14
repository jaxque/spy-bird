using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    public bool hasPackage = false;
    public GameObject folder;
    public Text GotFolder;
    private float timeAppear = 3f;
    private float timeDisappear;

    private void OnTriggerEnter(Collider collider)
    {
        // Item collected
        if (collider.gameObject.tag == "Key")
        {
            hasPackage = true;
        }

        // Successfully returns to starting point with key item
        if (collider.gameObject.tag == "Finish" && hasPackage)
        {
            SceneManager.LoadScene("WinScene");
        }

        // Lose item when caught by guard
        if (collider.gameObject.tag == "Guard")
        {
            hasPackage = false;
            GotFolder.enabled = false;

            if (hasPackage == false)
            {
                folder.SetActive(true);
            }
        }
    }

}
