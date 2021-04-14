using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIDe : MonoBehaviour
{
    public AudioClip FolderCollect;
    public Text GotFolder;
    private float timeAppear = 3f;
    private float timeDisappear;

    private void Start()
    {
        GotFolder.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(FolderCollect, transform.position);
        }
        // Enable text
        GotFolder.enabled = true;
        timeDisappear = Time.time + timeAppear;
    }

    private void Update()
    {
        if (GotFolder.enabled && (Time.time >= timeDisappear))
        {
            GotFolder.enabled = false;
        }
    }
}
