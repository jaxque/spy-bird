using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public void DoInteraction()
    {
        // Picked up key (object disappears)
        gameObject.SetActive(false);
    }

}
