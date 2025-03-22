using UnityEngine;

public class wizard : MonoBehaviour
{
   
    public GameObject Quiz1; // Assign the Quiz1 panel in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("player"))
        {
            Quiz1.SetActive(true); // Unhide the Quiz1 panel
        }
    }
}
