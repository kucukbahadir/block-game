using UnityEngine;

public class wizard : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("collide");
        }
    }
}
