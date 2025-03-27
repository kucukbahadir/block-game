using UnityEngine;

public class portal2 : MonoBehaviour
{
    public GameObject portalthing;
    public GameObject portalthing2;
    public GameObject player;

    private bool isTeleporting = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player" and if teleporting is not already in progress
        if (collision.gameObject.CompareTag("player") && !isTeleporting)
        {
            isTeleporting = true;
            player.transform.position = portalthing.transform.position;

            // Find the other portal script and disable its teleporting temporarily
            portal otherPortal = portalthing.GetComponent<portal>();
            if (otherPortal != null)
            {
                otherPortal.SetTeleporting(true);
            }
        }
    }

    public void SetTeleporting(bool state)
    {
        isTeleporting = state;
    }
}