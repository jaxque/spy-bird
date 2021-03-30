using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void DoInteraction()
    {
        // Picked up key (object disappears)
        gameObject.SetActive(false);
    }

}
