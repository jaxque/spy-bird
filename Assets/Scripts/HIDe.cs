using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIDe : MonoBehaviour
{
    public AudioClip FolderCollect;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(FolderCollect, transform.position);
        }
    }
}
