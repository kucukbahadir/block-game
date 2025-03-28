using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour
{
    public GameObject portalthing;
    public GameObject portalthing2;
    public GameObject player;

    private bool isTeleporting = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTeleporting)
        {
            Debug.Log($"{gameObject.name}: Collision detected with {collision.gameObject.name}");
            isTeleporting = true;

            CharacterController characterController = player.GetComponent<CharacterController>();
            if (characterController != null)
            {
                Debug.Log($"Player position before teleport: {player.transform.position}");
                Vector3 teleportPosition = portalthing2.transform.position; // Directly set to portal position
                characterController.enabled = false; // Disable CharacterController temporarily
                player.transform.position = teleportPosition;
                characterController.enabled = true; // Re-enable CharacterController
                Debug.Log($"Player position after teleport: {player.transform.position}");
            }
            else
            {
                Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    Debug.Log($"Player position before teleport: {playerRigidbody.position}");
                    playerRigidbody.position = portalthing2.transform.position; // Directly set to portal position
                    Debug.Log($"Player position after teleport: {playerRigidbody.position}");
                }
                else
                {
                    Debug.Log($"Player position before teleport: {player.transform.position}");
                    player.transform.position = portalthing2.transform.position; // Directly set to portal position
                    Debug.Log($"Player position after teleport: {player.transform.position}");
                }
            }

            Debug.Log("teleporting");

            portal2 otherPortal = portalthing2.GetComponent<portal2>();
            if (otherPortal != null)
            {
                otherPortal.SetTeleporting(true); // Notify the other portal
            }

            StartCoroutine(TeleportCooldown());
        }
    }

    public void SetTeleporting(bool state)
    {
        isTeleporting = state;
        Debug.Log($"{gameObject.name} isTeleporting set to {state}");
    }

    private IEnumerator TeleportCooldown()
    {
        Debug.Log($"{gameObject.name}: Starting teleport cooldown...");
        yield return new WaitForSeconds(0.5f); // Cooldown duration
        isTeleporting = false;
        portal2 otherPortal = portalthing2.GetComponent<portal2>();
            
                otherPortal.SetTeleporting(false); // Notify the other portal
            
        Debug.Log($"{gameObject.name}: Teleport cooldown ended. isTeleporting = {isTeleporting}");
    }
}