using UnityEngine;

public class playerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit");
        }
    }
}
