using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindFolderTimer : MonoBehaviour
{
    public Text FindFolder;
    public Text GotFolder;
    private float timeAppear = 3f;
    private float timeDisappear;

    private void Start()
    {
        // Enable FindFolder text
        FindFolder.enabled = true;
        timeDisappear = Time.time + timeAppear;

        // Disable GotFolder text
        GotFolder.enabled = false;
    }

    private void Update()
    {
        if (FindFolder.enabled && (Time.time >= timeDisappear))
        {
            FindFolder.enabled = false;
        }
    }
}
