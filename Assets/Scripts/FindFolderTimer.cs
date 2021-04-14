using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindFolderTimer : MonoBehaviour
{
    public Text FindFolder;
    private float timeAppear = 3f;
    private float timeDisappear;

    private void Start()
    {
        // Enable text
        FindFolder.enabled = true;
        timeDisappear = Time.time + timeAppear;
    }

    private void Update()
    {
        if (FindFolder.enabled && (Time.time >= timeDisappear))
        {
            FindFolder.enabled = false;
        }
    }
}
